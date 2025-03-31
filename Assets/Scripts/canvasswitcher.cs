using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas startingCanvas; // De canvas die als eerste zichtbaar moet zijn
    public Canvas canvasToShow; // De canvas die je wilt laten zien
    public Canvas canvasToHide; // De canvas die je wilt verbergen
    public Button switchButton; // De knop die de canvas wisselt

    void Start()
    {
        if (startingCanvas != null)
        {
            startingCanvas.gameObject.SetActive(true);
        }
        if (canvasToShow != null)
        {
            canvasToShow.gameObject.SetActive(false);
        }
        if (canvasToHide != null)
        {
            canvasToHide.gameObject.SetActive(true);
        }
        if (switchButton != null)
        {
            switchButton.onClick.AddListener(SwitchCanvas);
        }
    }

    public void SwitchCanvas()
    {
        if (canvasToShow != null && canvasToHide != null)
        {
            canvasToShow.gameObject.SetActive(true);
            canvasToHide.gameObject.SetActive(false);
        }
    }
}