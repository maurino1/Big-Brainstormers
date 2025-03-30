using UnityEngine;
using UnityEngine.UI;

public class VideoButtonHandler2 : MonoBehaviour
{
    [Header("Panel References")]
    public GameObject currentPanel;
    public GameObject nextPanel;

    [Header("YouTube Link")]
    public string youtubeURL = "https://youtu.be/MlzDB4y3gD4?si=1o4mTihSsup5r9Ly";

    public void OnButtonClick()
    {
        Application.OpenURL(youtubeURL);

        if (currentPanel != null)
            currentPanel.SetActive(false);

        if (nextPanel != null)
            nextPanel.SetActive(true);
    }
}