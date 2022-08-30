using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvInteractData : MonoBehaviour
{
    [Header("Object Data")]
    [Tooltip("The icon that the object will show in the hotbar")]
    public Sprite objectIcon;
    [Tooltip("The text name of the object, must be kept consistent")]
    public string objectName;
    [Tooltip("text component that appears above objects to label them")]
    public TextMeshProUGUI label;

    [Header("Object Settings")]
    [Tooltip("If enabled, the object will be disabled after interaction")]
    public bool isSingleUse = true;

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }

    public void ShowLabel(bool show)
    {
        label.enabled = show;
    }
}
