using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        playerController.ForceStartInteraction(startDialogueData); //force starts the dialogue despite having no dialogue collider etc. Yeah i know this is a bit of a hack...  
        dialogueManager.PlayDialogue(startDialogueData);
        
    }

}
