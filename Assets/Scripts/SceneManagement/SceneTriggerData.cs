using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTriggerData : MonoBehaviour
{
    public string sceneName;

    public void setDoor(string targetSceneName)
    {
        sceneName = targetSceneName;
    }
}
