using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas canvasToShow; // De canvas die je wilt laten zien
    public Button switchButton; // De knop die de canvas wisselt

    void Start()
    {
        if (canvasToShow != null)
        {
            canvasToShow.gameObject.SetActive(false); // Zorgt ervoor dat het canvas verborgen start
        }
        if (switchButton != null)
        {
            switchButton.onClick.AddListener(SwitchCanvas);
        }
    }

    public void SwitchCanvas()
    {
        if (canvasToShow != null)
        {
            canvasToShow.gameObject.SetActive(true); // Laat alleen deze canvas zien
        }
    }
}
