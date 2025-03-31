using UnityEngine;
using UnityEngine.UI;

public class PanelSwapper : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;

    public void OnButtonClick()
    {

        if (currentPanel != null)
            currentPanel.SetActive(false);

        if (nextPanel != null)
            nextPanel.SetActive(true);
    }
}
