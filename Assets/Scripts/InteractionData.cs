using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.Events;

public class InteractionData : MonoBehaviour
{
    [Header("Inky story JSON")]
    public TextAsset inkJSON;
    [Header("Icon/portrait")]
    public Sprite sprite;

    public bool hasAction;
    
    public UnityEvent postDialogueEvent;


}
