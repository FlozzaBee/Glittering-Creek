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
    public bool useFullbodyPortraitPrefab = false;
    [Header("Can you interact with this object multiple times?")]
    public bool isSingleUse;

    [Header("Actions")]
    public bool hasAction;
    public UnityEvent postDialogueEvent;

    [Header("Potion delivery")]
    public bool isDelivery = false;
    public string requiredItem;

}
