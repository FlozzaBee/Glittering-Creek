using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayEndManager : MonoBehaviour
{
    [Header("fade in parameters")]
    public float fadeTime = 1; //dont be 0 
    public Image fade;
    public float waitTime = 5;
    public string nextScene;


    private void Awake()
    {
        fade.color = new Color(0, 0, 0, 1); //sets fade image to black & 100% opacity
        StartCoroutine(FadeIn()); //starts fade in 
    }

    IEnumerator FadeIn() //Interpolates between 100% opacity and 0% opacity over fadeTime seconds
    {
        float fadeFactor = 0;
        Color fadeColor = fade.color;
        while (fadeFactor < 1) 
        {
            fadeFactor += Time.deltaTime / fadeTime;
            fadeColor.a = Mathf.Lerp(1, 0, fadeFactor);
            fade.color = fadeColor;
            yield return new WaitForFixedUpdate();
        }
        Debug.Log("Finished fade in");
        StartCoroutine(WaitForFadeOut()); 
    }

    IEnumerator WaitForFadeOut() //waits waitTime seconds then starts fade out
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(FadeOut());
        Debug.Log("finished wait for fade out");

    }

    IEnumerator FadeOut() //Interpolates between 0% opacity and 100% opacity over fadeTime seconds, then changes scene to nextScene
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
        SceneManager.LoadScene(nextScene);
    }
}
