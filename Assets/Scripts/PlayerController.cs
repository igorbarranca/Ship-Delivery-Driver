using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInputActions.IShipActions
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 2f;

    private Rigidbody2D playerRb;
    private float movementInput;
    private float rotationInput;

    PlayerInputActions playerInputs;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerInputs = new PlayerInputActions();
        playerInputs.Ship.SetCallbacks(this);
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<float>();
    }
    private void Move()
    {
        Vector2 movementDirection = new Vector2(movementInput * moveSpeed, 0f);
        playerRb.AddRelativeForce(movementDirection, ForceMode2D.Force);
    }

    public void OnRotation(InputAction.CallbackContext context)
    {
        rotationInput = context.ReadValue<float>();

        if(rotationInput != 0)
        {
            AudioPlayer.instance.PlayTurningClip();
        }
    }
    private void Rotate()
    {
        Vector3 rotationDirection = new Vector3(0f, 0f, rotationInput * rotateSpeed * Time.deltaTime);
        transform.Rotate(rotationDirection);
    }



    private void OnEnable()
    {
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }
}
