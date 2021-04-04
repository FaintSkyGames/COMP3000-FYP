using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerControls : MonoBehaviour
{
    public CharacterController controller;

    public float movementSpeed = 5;
    public float rotationSpeed = 20;
    public bool sprinting = false;

    private Vector3 velocity = Vector3.zero;
    public bool playerGrounded = true;
    public float jumpHeight = 1f;
    private float gravityValue = -9.81f;

    private Vector2 moveInput;
    private Vector2 lookInput;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        //OnPlayerJoined();
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = controller.isGrounded;
        Move();
        Look();
        ReduceVelocity();
    }

    private void Move()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        if (sprinting)
        {
            controller.Move(move * movementSpeed * 2 * Time.deltaTime);
        }
        else
        {
            controller.Move(move * movementSpeed * Time.deltaTime);
        }
       
    }

    private void Look()
    {
        // Look up & down
        Vector3 lookX = new Vector3(-lookInput.y * rotationSpeed * Time.deltaTime, 0, 0);
        float newRotation = lookX.x + GetComponentInChildren<Camera>().transform.localEulerAngles.x;

        if (newRotation <= 30f && newRotation >= -40)
        {
            //Debug.Log("In! no1 " + newRotation);
            GetComponentInChildren<Camera>().transform.Rotate(lookX);
        }
        else if (newRotation <= 390 && newRotation >= 320)
        {
            //Debug.Log("In! no2 " + newRotation);
            GetComponentInChildren<Camera>().transform.Rotate(lookX);
        }

        // Look left & right
        Vector3 lookY = new Vector3(0, lookInput.x * rotationSpeed * Time.deltaTime, 0);
        this.transform.Rotate(lookY);
    }

    private void ReduceVelocity()
    {
            velocity.y += gravityValue * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
    }

    /// <summary>
    /// 
    /// Callback Context
    /// 
    /// </summary>

    public void OnMove(CallbackContext ctx)
    {
        Vector2 v2 = ctx.ReadValue<Vector2>();
        moveInput = v2;
    }

    public void OnLook(Vector2 ctx)
    {
        lookInput = ctx;
    }

    //public void OnMove(InputAction.CallbackContext ctx) => moveInput = ctx.ReadValue<Vector2>();

    //public void OnLook(InputAction.CallbackContext ctx) => lookInput = ctx.ReadValue<Vector2>();

    public void OnJump()
    {
        if (playerGrounded)
        {
            velocity = new Vector3(0, Mathf.Sqrt(jumpHeight * -2f * gravityValue), 0);
        }
    }

}
