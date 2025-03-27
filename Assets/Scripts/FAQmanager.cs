using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class FAQManager : MonoBehaviour
{
    public List<TextMeshProUGUI> allFAQTexts;  
    private TextMeshProUGUI currentlyOpenText = null;

    public void ToggleText(TextMeshProUGUI textToToggle)
    {
        if (currentlyOpenText == textToToggle)
        {
            textToToggle.gameObject.SetActive(false);
            currentlyOpenText = null;
            return;
        }

        if (currentlyOpenText != null)
        {
            currentlyOpenText.gameObject.SetActive(false);
        }

        textToToggle.gameObject.SetActive(true);
        currentlyOpenText = textToToggle;
    }
}