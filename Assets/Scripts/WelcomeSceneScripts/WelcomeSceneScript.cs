using UnityEngine;
using TMPro;
using System.Collections;

public class WelcomeSceneScript : MonoBehaviour
{
    public Color Color1; 
    public Color Color2;        
    public TextMeshProUGUI myText;
    public float fadeDuration = 1.0f; 
    public float delayBeforeFade = 2.0f; 
    private bool isTextActive = false;

    private void Start()
    {
        myText.color = new Color(Color1.r, Color1.g, Color1.b, 0f);

        StartCoroutine(FadeInText());
    }

    private IEnumerator FadeInText()
    {
        // Wait for initial delay
        yield return new WaitForSeconds(delayBeforeFade);

      
        float elapsed = 0f;
        Color startColor = new Color(Color1.r, Color1.g, Color1.b, 0f);
        Color targetColor = new Color(Color1.r, Color1.g, Color1.b, 1f);

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            myText.color = Color.Lerp(startColor, targetColor, elapsed / fadeDuration);
            yield return null;
        }


        isTextActive = true;
    }

    private void Update()
    {
        if (isTextActive)
        {
            float t = Mathf.PingPong(Time.time, 1f);
            myText.color = Color.Lerp(Color1, Color2, t);
        }
    }
}