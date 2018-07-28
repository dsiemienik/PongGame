using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class Fader : MonoBehaviour {

    public float fadingSpeed;

    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

    }
    public void ShowUI()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutUI(alphaTarget: 1f));
    }
    public void HideUI()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInUI(alphaTarget: 0f));
    }
    IEnumerator FadeInUI(float alphaTarget)
    {
        while(canvasGroup.alpha >= alphaTarget)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, alphaTarget, fadingSpeed);
            yield return null;
        }
    }
    IEnumerator FadeOutUI(float alphaTarget)
    {
        while (canvasGroup.alpha <= alphaTarget)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, alphaTarget, fadingSpeed);
            yield return null;
        }
    }
}
