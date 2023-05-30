using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScreen : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private void OnEnable()
    {
        StartCoroutine(FadeLoadingScreen(0.8f));
    }

    IEnumerator FadeLoadingScreen(float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1;
        SceneManager.LoadScene("Level 2");
    }
}
