using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Manages the brewing mini game
//Note, this script must run after InvPersistant
public class BrewingManager : MonoBehaviour
{
    public Image liquid;

    //List of possible potion recipies
    public List<string> potionRecipes;

    public List<string> potions;

    public List<Sprite> potionSprites;

    public string currentPotion;

    [Header("Final Potion")]
    public GameObject finalPotionParent;
    public TextMeshProUGUI finalPotionText;
    public GameObject radialHighlight;
    public Image finalPotionImage;

    [Header("Settings")]
    public bool allowMultipleBrews = false;
    public bool requireSpecificPotion = false;
    public string requiredPotion;

    [Header("Buttons")]
    public Button tryAgain;
    public Button brewAnother;
    public Button finishBrewing;
    public Button wrongPotion;

    [Header("animation")]
    public Animator brewingAnimator;

    [Header("Audio")]
    public AudioSource splash;

    [Header("debugging/fun")]
    public bool unlockAll = false;

    //Internal variables
    private List<string> usedIngredients = new List<string>();

    //Ingredient label on mouse hover
    private bool isHover;


    private void Awake()
    {
        GameObject[] ingredients = GameObject.FindGameObjectsWithTag("Ingredient"); //make an array of all ingredient gameobjects
        
        List<string> ingredientNames = new List<string>(); 
        foreach (GameObject ingredient in ingredients) //for each ingredient in the scene, add its name to the ingredientNames list & disable it
        {
            ingredientNames.Add(ingredient.GetComponent<BrewingIngredient>().ingredientName);
            if (!unlockAll) { ingredient.SetActive(false); }; // disables all ingredients unless unlock all is true
        }
        if (InvPersistant.Instance.invItemNames != null) //Pulls ingredient name list from InvPersistant
        {
            foreach (string name in InvPersistant.Instance.invItemNames) //Enable ingredient if its found in the inventory list
            {
                int ingIndex = ingredientNames.IndexOf(name);
                if (ingIndex > -1)
                {
                    ingredients[ingIndex].SetActive(true);
                }
            }
        }
    }
    public void AddIngredient(BrewingIngredient ingredient)
    {
        
        if (liquid.enabled == false)
        {
            if (ingredient.isLiquid)
            {
                liquid.enabled = true;
                SetPotionProperties(ingredient);
            }
            else
            {
                Debug.Log("you need a base liquid first");
            }
        }
        else
        {
            SetPotionProperties(ingredient);
            splash.Play();
            splash.pitch = 1 + Random.Range(-0.5f, 0.5f);
        }
    }

    private void SetPotionProperties(BrewingIngredient ingredient)
    {
        currentPotion += ingredient.ingredientName.Trim() + " ";   // the trim isnt strictly necessary, but i have a tendancy to hit space after i type a word so its saving me from that screw up
        liquid.color = ingredient.ingredientColor;
        ingredient.gameObject.SetActive(false);
        if (ingredient.tag == "Ingredient")
        {
            usedIngredients.Add(ingredient.ingredientName);
        }
        Debug.Log("Current potion " + currentPotion);
    }

    
    public void FinalizePotion()  // checks if the current potion string is in the list of viable potions, if it is show "you made a (potion name)! screen"
    {
        if (potionRecipes.Contains(currentPotion.Trim()))
        {
            int potionIndex = potionRecipes.IndexOf(currentPotion.Trim());
            finalPotionText.text = potions[potionIndex] + "!";
            if (requireSpecificPotion) // if a specific potion is required
            {
                if (potions[potionIndex] == requiredPotion) //check for the potion
                { //if specific potion is found, enable potion end screen, set sprite, text, etc.
                    if (!unlockAll)
                    {
                        //Debug.Log("You made a " + potions[potionRecipes.IndexOf(currentPotion.Trim())]);
                        InvPersistant.Instance.RemoveItems(usedIngredients);
                    }
                    InvPersistant.Instance.AddItem(potions[potionIndex], potionSprites[potionIndex]);
                    finishBrewing.gameObject.SetActive(true);
                    finalPotionImage.gameObject.SetActive(true);
                    finalPotionImage.sprite = potionSprites[potionIndex];
                    radialHighlight.SetActive(true);
                }
                else //if the made potion is wrong
                {
                    //Show potion end screen with relevent potion
                    finalPotionImage.gameObject.SetActive(true);
                    finalPotionImage.sprite = potionSprites[potionIndex];
                    radialHighlight.SetActive(true);
                    wrongPotion.gameObject.SetActive(true); //enables the "wrong potion, try again" button
                }
            }
            else //if no specific potion is required
            {
                if (!unlockAll)
                {
                    //Debug.Log("You made a " + potions[potionRecipes.IndexOf(currentPotion.Trim())]);
                    InvPersistant.Instance.RemoveItems(usedIngredients);
                }
                InvPersistant.Instance.AddItem(potions[potionIndex], potionSprites[potionIndex]);
                finishBrewing.gameObject.SetActive(true);
                finalPotionImage.gameObject.SetActive(true);
                finalPotionImage.sprite = potionSprites[potionIndex];
                radialHighlight.SetActive(true);
                if (InvPersistant.Instance.invItemNames.Count < 9) //Prevents brewing extra if inv full
                {
                    if (allowMultipleBrews) //If brewing multiple potions per brewing scene is allowed, enable the brew another button.
                    {
                        brewAnother.gameObject.SetActive(true);
                    }
                }
            }
        }
        else
        {
            finalPotionText.text = "Dubious Potion?";
            tryAgain.gameObject.SetActive(true);
        }
        finalPotionParent.SetActive(true);
    }

    public void playAnimation(string animationName)
    {
        brewingAnimator.SetTrigger(animationName);
    }
}
