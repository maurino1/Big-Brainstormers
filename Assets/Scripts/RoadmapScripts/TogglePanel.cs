using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject panel;

    public void TogglePanelVisibility()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
