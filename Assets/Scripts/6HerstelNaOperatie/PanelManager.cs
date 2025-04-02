using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject panel; // Assign your UI panel in Inspector

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Ensure the panel starts off
        }
    }

    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true); // Show the panel
        }
    }

    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Hide the panel
        }
    }
}
