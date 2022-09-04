using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;

//Used to play dialogue during the brewing mini game
//like the main dialogue manager but with all the player controller references stripped out
public class BrewingDialogueManager : MonoBehaviour
{
    [Header("UI component prefabs")]
    public GameObject textPrefab;
    public GameObject portraitPrefab;
    public GameObject fullbodyPrefab;
    public GameObject uiBackground;
    public Button buttonPrefab;

    [Header("External gameobjects")]
    [Tooltip("The canvas to attach UI elements to")]
    public Canvas mainCanvas;
    [Tooltip("The canvas to attach specifically dialogue to")]
    public Canvas dialogueCanvas;


    //Internal Variables
    private GameObject interactionObject;
    private InteractionData interactionData;
    //Dialogue
    private TextAsset inkJSON;
    private Story story;
    //Portrait
    private Sprite sprite;
    private GameObject portrait;
    //Background
    private GameObject uiBackgroundObj;

    //Ink variable check
    private bool isAction = false;

    public void PlayDialogue(GameObject interactedObject)
    {
        Debug.Log("Play dialogue called");
        if (interactionObject != interactedObject)
        {
            interactionObject = interactedObject;
            interactionData = interactedObject.GetComponent<InteractionData>();
            inkJSON = interactionData.inkJSON;
            sprite = interactionData.sprite;
            StartStory();
            Debug.Log("story started");
        }
        //if(inkJSON != interactedInkJSON)
        //{
        //    inkJSON = interactedInkJSON;
        //    sprite = interactedSprite;
        //    StartStory();

        //}
        else
        {
            if (story.currentChoices.Count > 0)
            {
                DestroyChildren();
                for (int i = 0; i < story.currentChoices.Count; i++)
                {
                    Choice choice = story.currentChoices[i];
                    Button button = CreateChoiceView(choice.text.Trim());
                    // Tell the button what to do when we press it
                    button.onClick.AddListener(delegate {
                        OnClickChoiceButton(choice);
                    });
                }
            }
            else
            {
                ContinueStory();
            }
        }

    }

    private void StartStory()
    {
        //Creates UI background image. This goes first so its behind later objects
        uiBackgroundObj = Instantiate(uiBackground);
        uiBackgroundObj.transform.SetParent(mainCanvas.transform, false);

        story = new Story(inkJSON.text); //assign ink JSON file to story variable
        CreateContentView(story.Continue()); //Generates initial line of dialogue

        //Creates portrait, makes it child of main canvas
        if (interactionData.useFullbodyPortraitPrefab)
        {
            portrait = Instantiate(fullbodyPrefab);
        }
        else
        {
            portrait = Instantiate(portraitPrefab);
        }
        portrait.GetComponent<Image>().sprite = sprite;
        portrait.transform.SetParent(mainCanvas.transform, false);

        isAction = false; //resets isAction for multiple actions in a scene
        //Watch for change in "action" variable within Ink. if it changes, update isAction
        if (interactionData.hasAction)
        {
            story.ObserveVariable("action", (string varName, object action) =>
            {
                isAction = (bool)action;
            });
        }

    }

    private void ContinueStory()
    {
        if (isAction)
        {
            interactionData.postDialogueEvent.Invoke();
        }
        if (story.canContinue)
        {
            // Debug.Log(story.Continue());
            DestroyChildren();
            CreateContentView(story.Continue());
            Debug.Log("continued story");
        }
        else //When no more dialogue is available, deletes dialogue UI & returns player control
        {
            DestroyChildren();
            inkJSON = null;
            Destroy(portrait);
            Destroy(uiBackgroundObj);
            if (interactionData.isSingleUse) //If the dialogue is set as single use, disable it after use.
            {
                interactionObject.SetActive(false); //resets interaction data
            }
            interactionObject = null; //resets interaction object so you can interact with teh same object again
        }
    }

    //Draws new dialogue text
    private void CreateContentView(string dialogueText)
    {
        GameObject textObj = Instantiate(textPrefab);
        TextMeshProUGUI text = textObj.GetComponent<TextMeshProUGUI>();
        text.text = dialogueText;
        text.transform.SetParent(dialogueCanvas.transform, false);
        Debug.Log("created content");
    }



    //Destroys previous dialogue text
    private void DestroyChildren()
    {
        int childCount = dialogueCanvas.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            if (dialogueCanvas.transform.GetChild(i).tag == "DialogueText")
            {
                Destroy(dialogueCanvas.transform.GetChild(i).gameObject);
            }
        }
    }

    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(dialogueCanvas.transform, false);

        // Gets the text from the button prefab
        TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
        choiceText.text = text;

        // Make the button expand to fit the text
        //HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        //layoutGroup.childForceExpandHeight = false;

        Canvas.ForceUpdateCanvases(); //this ensures the vertical layout component activates and organizes the choices

        return choice;
    }

    // When we click the choice button, tell the story to choose that choice! 
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        ContinueStory();
    }
}
