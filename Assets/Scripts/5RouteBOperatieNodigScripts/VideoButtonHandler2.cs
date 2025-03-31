using UnityEngine;
using UnityEngine.UI;

public class VideoButtonHandler2 : MonoBehaviour
{
    [Header("Panel References")]
    public GameObject currentPanel;
    public GameObject nextPanel;

    [Header("YouTube Link")]
    public string youtubeURL = "https://www.youtube.com/watch?v=MlzDB4y3gD4";

    public void OnButtonClick()
    {
        Application.OpenURL(youtubeURL);

        if (currentPanel != null)
            currentPanel.SetActive(false);

        if (nextPanel != null)
            nextPanel.SetActive(true);
    }
}