using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class VideoButtonHandler : MonoBehaviour
{
    [Header("Panel References")]
    public GameObject currentPanel; // The panel to close (drag in Inspector)
    public GameObject nextPanel;    // The panel to open (drag in Inspector)

    [Header("YouTube Link")]
    public string youtubeURL = "https://www.youtube.com/watch?v=fKDIc1sFNU8";

    // Called when the button is clicked
    public void OnButtonClick()
    {
        // 1. Open the YouTube link in a browser (optional)
        Application.OpenURL(youtubeURL);

        // 2. Close the current panel and open the next one
        if (currentPanel != null)
            currentPanel.SetActive(false);

        if (nextPanel != null)
            nextPanel.SetActive(true);
    }
}