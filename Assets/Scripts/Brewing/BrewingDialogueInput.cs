using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BrewingDialogueInput : MonoBehaviour
{
    //Internal Variables
    //Input system 
    private PlayerInput playerInput;
    //Inputs
    private InputAction interact;

    //External Objects
    public BrewingDialogueManager brewingDialogueManager;
    public GameObject dialogueData;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        interact = playerInput.actions["Interact"];
    }

    private void OnEnable()
    {
        interact.performed += Interact;
    }

    private void OnDisable()
    {
        interact.performed -= Interact;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        brewingDialogueManager.PlayDialogue(dialogueData);
    }
}
