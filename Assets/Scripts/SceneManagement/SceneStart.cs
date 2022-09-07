using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneStart : MonoBehaviour
{
    [Header("fade in parameters")]
    public float fadeTime = 1; //dont be 0 
    public Image fade;

    [Header("Start dialogue parameters")]
    [Tooltip("Should the scene start with a dialogue playing?")]
    public bool startWithDialogue = false;
    [Tooltip("What dialogue should play?")]
    public GameObject startDialogueData;
    
    public DialogueManager dialogueManager;

    public bool isBrewingScene;
    public BrewingDialogueManager brewingDialogueManager;
    public PlayerController playerController;
    private void Awake()
    {
        StartCoroutine(fadeIn());
        if (startWithDialogue)
        {
            StartIntroDialogue();
        }
    }

    IEnumerator fadeIn()
    {
        float fadeFactor = 0;
        Color fadeColor = fade.color;
        while(fadeFactor < 1)
        {
            fadeFactor += Time.deltaTime / fadeTime;
            fadeColor.a = Mathf.Lerp(1, 0, fadeFactor);
            fade.color = fadeColor;
            yield return new WaitForFixedUpdate();
        }
        
    }

    private void StartIntroDialogue()
    {
        if (!isBrewingScene)
        {
            playerController.ForceStartInteraction(startDialogueData); //force starts the dialogue despite having no dialogue collider etc. Yeah i know this is a bit of a hack...  
            dialogueManager.PlayDialogue(startDialogueData);
        } // its only getting hackier from here 
        else
        {
            brewingDialogueManager.PlayDialogue(startDialogueData);
        }
        
    }
    public void FadeOutToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeOut(string sceneName) //Interpolates between 0% opacity and 100% opacity over fadeTime seconds, then changes scene to nextScene
    {
        Debug.Log("started fade out");
        float fadeFactor = 0;
        Color fadeColor = fade.color;
        while (fadeFactor < 1)
        {
            fadeFactor += Time.deltaTime / fadeTime;
            fadeColor.a = Mathf.Lerp(0, 1, fadeFactor);
            fade.color = fadeColor;
            yield return new WaitForFixedUpdate();
        }
        SceneManager.LoadScene(sceneName);
    }

}
