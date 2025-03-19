using UnityEngine;
using TMPro;

public class FAQManager : MonoBehaviour
{
    public TextMeshProUGUI textToToggle;

    public void ToggleText()
    {
        textToToggle.gameObject.SetActive(!textToToggle.gameObject.activeSelf);
    }
}