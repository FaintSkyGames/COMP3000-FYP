using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem.UI;

public class InputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    // player actions
    [SerializeField]
    private PlayerControls playerControls;
    [SerializeField]
    private ShooterControls shooterControls;
    [SerializeField]
    private PlayerControls puzzleControls;

    // control system
    private Controls controls;

    private PauseControl pauseController;

    [SerializeField]
    private PlayerInput playerInput;

    private void Awake()
    {
        //playerControls = GetComponent<PlayerControls>();
        controls = new Controls();

        pauseController = GameObject.Find("UI").GetComponent<PauseControl>();
        //playerInput = GetComponent<PlayerInput>();
    }

    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        this.name = "Player " + pc.PlayerIndex;
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;


        if (playerConfig.PlayerIndex == 0)
        {
            // camera setup
            // Vertical Rect(0.0f, 0.0f, 1.0f, 0.5f) bottom
                                                                 // x, y, w, h
            //this.GetComponentInChildren<Camera>().rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);

            //For testing only
            this.GetComponentInChildren<Camera>().rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        }
        else if (playerConfig.PlayerIndex == 1)
        {
            // Vertical Rect(0.0f, 0.5f, 1.0f, 1.0f) top
            this.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
        }

    }

    public void Input_onActionTriggered(CallbackContext ctx)
    {
        Debug.Log(ctx);

        // Gameplay controls for both players
        if (!pauseController.GetStatus())
        {
            //ctx.action.name == controls.Shooter.Move.name || ctx.action.name == controls.Puzzle.Move.name
            if (ctx.action.name == controls.Gameplay.Move.name)
            {
                playerControls.OnMove(ctx);
            }
            //ctx.action.name == controls.Shooter.Look.name || ctx.action.name == controls.Puzzle.Look.name
            else if (ctx.action.name == controls.Gameplay.Look.name)
            {
                playerControls.OnLook(ctx.ReadValue<Vector2>());
            }
            //ctx.action.name == controls.Shooter.Jump.name || ctx.action.name == controls.Puzzle.Jump.name
            else if (ctx.action.name == controls.Gameplay.Jump.name)
            {
                if (ctx.performed)
                {
                    playerControls.OnJump();
                }
            }
            //ctx.action.name == controls.Shooter.Sprint.name || ctx.action.name == controls.Puzzle.Sprint.name
            else if (ctx.action.name == controls.Gameplay.Sprint.name) 
            {
                if (ctx.performed)
                {
                    playerControls.sprinting = true;
                }
                else
                {
                    playerControls.sprinting = false;
                }
            }
            //ctx.action.name == controls.Shooter.Pause.name || ctx.action.name == controls.Puzzle.Pause.name
            else if (ctx.action.name == controls.Gameplay.Pause.name)
            {
                if (ctx.performed)
                {
                    pauseController.PauseGame();
                    playerInput.currentActionMap.Disable();
                    playerInput.SwitchCurrentActionMap("UI");

                    playerInput.uiInputModule = pauseController.GetPauseMenu().GetComponent<InputSystemUIInputModule>();
                }
            }

            // Use button
            else if (ctx.action.name == controls.Gameplay.UseTool.name)
            {
                // Shooter fires weapon
                if (playerConfig.PlayerType == "Shooter")
                {
                    shooterControls.OnFire();
                }
                // Puzzle interacts
                else if (true)
                {

                }
            }

        }
        else
        {
            if (ctx.action.name == controls.UI.Pause.name)
            {
                if (ctx.performed)
                {
                    pauseController.PauseGame();
                    playerInput.currentActionMap.Disable();
                    playerInput.SwitchCurrentActionMap("GamePlay");

                    playerInput.uiInputModule = null;
                }
            }
        }
        
    }
}
