using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class MouseHover : MonoBehaviour
{

    //Editor variables
    public TextMeshProUGUI labelText;
    [Tooltip("How far above the mouse to place the label")]
    public float yOffset = 10;

    //Input
    private PlayerInput playerInput;
    private InputAction mousePosition;
    
    private bool isHover = false;
    private RectTransform rectTransform;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        mousePosition = playerInput.actions["MousePosition"];
        rectTransform = labelText.gameObject.GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        
    }

    public void HoverStart(string ingredientDisplayName)
    {
        isHover = true;
        labelText.text = ingredientDisplayName;
        StartCoroutine(IngredientLabel());
        Debug.Log("Started hover over " + ingredientDisplayName);
    }
    public void HoverEnd()
    {
        isHover = false;
        labelText.text = null;
        Debug.Log("ended hover");
    }

    IEnumerator IngredientLabel()
    {
        while (isHover)
        {
            Vector2 mousePoint = Camera.main.ScreenToViewportPoint(mousePosition.ReadValue<Vector2>());
            //Calculate canvas position from viewport point, 640 * 360 is canvas reference size
            Vector2 canvasPoint = new Vector2(mousePoint.x * 640, (mousePoint.y * 360) + yOffset);
            rectTransform.anchoredPosition = canvasPoint;
            yield return new WaitForFixedUpdate();
        }
    }
}
