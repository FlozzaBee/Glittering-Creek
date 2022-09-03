using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    //Internal Variables
    //Input system 
    private PlayerInput playerInput;
        //Inputs
    private InputAction movement;
    private InputAction interact;
    private InputAction numKeys;
    private InputAction scrollUp, scrollDown;

    //Input 
    private bool isMove = false;
    [HideInInspector]
    public bool moveEnabled = true;
    //Interaction 
    private bool isInIteraction = false;
    private GameObject interactiveObject;
    //Animation
    private Animator animator;

    //Editor Variables
    [Header("Input Variables")]
    [Tooltip("How many units the player moves in 1 second")]
    public float playerSpeed = 1;

    [Header("Interactions")]
    [Tooltip("The bubble that appears when youre in range of an interaction")]
    public GameObject interactIcon;
    public GameObject pickUpIcon;
    public DialogueManager inkTest;
    public InvManager invManager;

    public SceneChange sceneChange;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        movement = playerInput.actions["Movement"];
        interact = playerInput.actions["Interact"];
        numKeys = playerInput.actions["NumberKeys"];
        scrollUp = playerInput.actions["ScrollUp"];
        scrollDown = playerInput.actions["ScrollDown"];
    }

    private void OnEnable()
    {
        movement.started += StartMovement;
        movement.canceled += EndMovement;

        interact.performed += Interact;

        numKeys.performed += NumKey;
        scrollUp.performed += ScrollUp;
        scrollDown.performed += ScrollDown;
    }

    private void OnDisable()
    {
        movement.started -= StartMovement;
        movement.canceled -= EndMovement;

        interact.performed -= Interact;

        numKeys.performed -= NumKey;
        scrollUp.performed -= ScrollUp;
        scrollDown.performed -= ScrollDown;
    }

    private void StartMovement(InputAction.CallbackContext context)
    {
        if (moveEnabled)
        {
            Debug.Log("movement started");
            isMove = true;
            animator.SetBool("isWalking", true);
            StartCoroutine(Movement());
        }
    }
    IEnumerator Movement()
    {
        while (isMove && moveEnabled) //while a move input is present and movement is enabled (i.e. not in a dialogue)
        {
            Vector2 inputVector = movement.ReadValue<Vector2>();
            Vector3 inputVector3 = inputVector;
            GetComponent<Rigidbody2D>().MovePosition(transform.position + (inputVector3 * Time.deltaTime * playerSpeed));
            animator.SetFloat("xInput", inputVector.x);
            animator.SetFloat("yInput", inputVector.y);
            yield return new WaitForFixedUpdate();
        }
    }

    private void EndMovement(InputAction.CallbackContext context)
    {
        Debug.Log("movement ended");
        isMove = false;
        animator.SetBool("isWalking", false);
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (isInIteraction)
        {
            if (interactiveObject.tag == "Interaction")
            {
                inkTest.PlayDialogue(interactiveObject);
                //InteractionData interactionData = interactiveObject.GetComponent<InteractionData>();
                //if (interactionData != null)
                //{
                //    //sends data from interacted object to the dialogue script
                //    inkTest.PlayDialogue(interactionData.inkJSON, interactionData.sprite);
                //}
                //else
                //{
                //    Debug.Log("No InteractionData on interacted object");
                //} // this will save me a lot of headaches later i promise
            }
            if (interactiveObject != null) //null check useful as the play dialogue method sometimes disables the dialogue after playing.
            {
                if (interactiveObject.tag == "InventoryInteraction")
                {
                    invManager.InventoryInteract(interactiveObject);
                }
            }
        }
        else { Debug.Log("Interaction collider not found"); }
    }

    //Hotbar selection
    private void NumKey(InputAction.CallbackContext context)
    {
        //Debug.Log("Numkey " + context.ReadValue<float>());
        invManager.SetHotbarSelector(Mathf.RoundToInt(context.ReadValue<float>()));
    }
    private void ScrollUp(InputAction.CallbackContext context)
    {
        //Debug.Log("Scrolled up");
        invManager.MoveHotbarSelector(-1);
    }
    private void ScrollDown(InputAction.CallbackContext context)
    {
        //Debug.Log("Scrolled down");
        invManager.MoveHotbarSelector(1);
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interaction")
        {
            interactIcon.SetActive(true);
            isInIteraction = true;
            interactiveObject = collision.gameObject;
        } 
        if (collision.tag == "InventoryInteraction")
        {
            InvInteractData data = collision.GetComponent<InvInteractData>();
            if (data.label != null)
            {
                data.ShowLabel(true);
                
            }
            pickUpIcon.SetActive(true);
            isInIteraction = true;
            interactiveObject = collision.gameObject;

        }
        if (collision.tag == "SceneChangeTrigger")
        {
            sceneChange.ChangeScene(collision.GetComponent<SceneTriggerData>().sceneName);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interaction")
        {
            interactIcon.SetActive(false);
            isInIteraction = false;
            interactiveObject = null;
        }
        if (collision.tag == "InventoryInteraction")
        {
            InvInteractData data = collision.GetComponent<InvInteractData>();
            if (data.label != null)
            {
                data.ShowLabel(false);
                
            }
            pickUpIcon.SetActive(false);
            isInIteraction = false;
            interactiveObject = null;
        }
        
    }

    //sets all interaction data, as if player had entered interaction trigger
    //does not enable labels however
    public void ForceStartInteraction(GameObject interactObj)
    {
        isInIteraction = true;
        interactiveObject = interactObj; //note, forced interactions must still have a gameobject tagged with Interaction to reference.

    }
    //removes all interaction data and disables label, as if player had left interaction trigger
    public void ForceEndInteraction()
    {
        interactIcon.SetActive(false);
        pickUpIcon.SetActive(false);
        isInIteraction = false;
        interactiveObject = null;
    }

}
