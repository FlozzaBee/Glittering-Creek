using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Manages the recipe and ingredient list viewer 
public class RecipeManager : MonoBehaviour
{
    //Recipe 
    public TextMeshProUGUI recipeText;
    public Button recipeViewButton;
    //Animation
    public Animator recipeAnimator;

    private void Awake()
    {
        //SetRecipeText();
    }
    public void ToggleRecipeView() //Checks what animation is playing/last played (enter or exit) and plays the other one. 
    {
        if (recipeAnimator.GetCurrentAnimatorStateInfo(0).IsName("recipeEnter"))
        {
            recipeAnimator.SetTrigger("RecipeExit");
        }
        else
        {
            recipeAnimator.SetTrigger("RecipeEnter");
        }
    }

    public void SetRecipeText(TextMeshProUGUI recipe)
    {
        InvPersistant.Instance.currentRecipe = recipe.text;
        recipeText.text = InvPersistant.Instance.currentRecipe;
        recipeViewButton.gameObject.SetActive(true);
    }
}
