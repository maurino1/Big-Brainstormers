using UnityEngine;

public class ButtonHandlerPanel : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;

    public void PanelSwapper()
    {
        if (currentPanel != null)
            currentPanel.SetActive(false);

        if (nextPanel != null)
            nextPanel.SetActive(true);
    }
}
