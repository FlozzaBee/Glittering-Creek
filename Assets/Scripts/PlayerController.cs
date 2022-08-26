using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    //Input System
    private PlayerInput playerInput;
        //Inputs
    private InputAction movement;
    private InputAction interact;


    //Internal Variables
    //Input
    private bool isMove = false;

    //Editor Variables
    [Header("Input Variables")]
    [Tooltip("How many units the player moves in 1 second")]
    public float playerSpeed = 1;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        movement = playerInput.actions["Movement"];
        interact = playerInput.actions["Interact"];
    }

    private void OnEnable()
    {
        movement.started += StartMovement;
        movement.canceled += EndMovement;

        interact.performed += Interact;
    }

    private void OnDisable()
    {
        movement.started -= StartMovement;
        movement.canceled -= EndMovement;

        interact.performed -= Interact;
    }

    private void StartMovement(InputAction.CallbackContext context)
    {
        Debug.Log("movement started");
        isMove = true;
        StartCoroutine(Movement());
    }

    private void EndMovement(InputAction.CallbackContext context)
    {
        Debug.Log("movement ended");
        isMove = false;
    }

    private void Interact(InputAction.CallbackContext context)
    {

    }

    IEnumerator Movement()
    {
        while (isMove)
        {
            Vector2 inputVector = movement.ReadValue<Vector2>();
            Vector3 inputVector3 = inputVector;
            //transform.position += inputVector3 * Time.deltaTime * playerSpeed;
            GetComponent<Rigidbody2D>().MovePosition(transform.position + (inputVector3 * Time.deltaTime * playerSpeed));
            yield return new WaitForFixedUpdate();
        }
    }

}
