using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoClosePanel : MonoBehaviour
{
    public float sluitTijd = 5f; // Aantal seconden voordat het paneel sluit
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup-component ontbreekt! Voeg een CanvasGroup toe aan het paneel.");
            return;
        }
        StartCoroutine(SluitPaneelNaTijd());
    }

    IEnumerator SluitPaneelNaTijd()
    {
        yield return new WaitForSeconds(sluitTijd);
        canvasGroup.alpha = 0; // Maak het paneel onzichtbaar
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
