using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5;

    private Vector2 moveInput;
    private Vector2 lookInput;

    public int playerNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);
        //transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * speed * Time.deltaTime);
    }

    public void OnPlayerJoined()
    {
        // Assign player number
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 1)
        {
            playerNumber = 1;
        }
        else
        {
            playerNumber = 2;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) => moveInput = ctx.ReadValue<Vector2>();

    public void OnLook(InputAction.CallbackContext ctx) => lookInput = ctx.ReadValue<Vector2>();


}
