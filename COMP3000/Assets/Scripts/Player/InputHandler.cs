using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private PlayerControls playerControls;

    private Controls controls;

    private void Awake()
    {
        playerControls = GetComponent<PlayerControls>();
        controls = new Controls();
    }

    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        this.name = "Player " + pc.PlayerIndex;
        pc.Input.onActionTriggered += Input_onActionTriggered;

        if (playerConfig.PlayerIndex == 0)
        {
            // camera setup
            // Vertical Rect(0.0f, 0.0f, 1.0f, 0.5f) bottom
                                                                 // x, y, w, h
            this.GetComponentInChildren<Camera>().rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
        }
        else if (playerConfig.PlayerIndex == 1)
        {
            // Vertical Rect(0.0f, 0.5f, 1.0f, 1.0f) top
            this.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
        }

    }

    private void Input_onActionTriggered(CallbackContext ctx)
    {
        if (ctx.action.name == controls.GamePlay.Move.name)
        {
            playerControls.OnMove(ctx.ReadValue<Vector2>());
        }
        else if (ctx.action.name == controls.GamePlay.Look.name)
        {
            playerControls.OnLook(ctx.ReadValue<Vector2>());
        }
        else if (ctx.action.name == controls.GamePlay.Jump.name)
        {
            if (ctx.performed)
            {
                playerControls.OnJump();
            }
        }
        else if (ctx.action.name == controls.GamePlay.Sprint.name)
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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
