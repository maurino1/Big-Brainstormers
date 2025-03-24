using System.Collections;
using UnityEngine;
using TMPro;

public class ContinueScene : MonoBehaviour
{
    public TextMeshProUGUI welcomeText;
    public TextMeshProUGUI appNameText;
    public TextMeshProUGUI descriptionText;
    public float fadeDuration = 0.5f; 
    public float delayBetweenTexts = 0.5f; 

    private void Start()
    {
        SetAlpha(welcomeText, 0f);
        SetAlpha(appNameText, 0f);
        SetAlpha(descriptionText, 0f);

        StartCoroutine(ShowTextSequence());
    }

    private IEnumerator ShowTextSequence()
    {
        // Fade in "Welcome bij"
        yield return StartCoroutine(FadeText(welcomeText, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(delayBetweenTexts); // Wait before next text

        // Fade in "TODO: NAAM APP"
        yield return StartCoroutine(FadeText(appNameText, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(delayBetweenTexts); // Wait before next text

        // Fade in description text
        yield return StartCoroutine(FadeText(descriptionText, 0f, 1f, fadeDuration));
    }

    private IEnumerator FadeText(TextMeshProUGUI text, float startAlpha, float endAlpha, float duration)
    {
        float time = 0f;
        Color color = text.color;

        while (time < duration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, time / duration);
            text.color = color;
            yield return null;
        }

        color.a = endAlpha;
        text.color = color;
    }

    private void SetAlpha(TextMeshProUGUI text, float alpha)
    {
        Color color = text.color;
        color.a = alpha;
        text.color = color;
    }
}