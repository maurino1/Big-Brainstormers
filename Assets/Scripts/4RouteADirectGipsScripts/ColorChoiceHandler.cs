using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorChoiceSystem : MonoBehaviour
{
    [Header("Drag & Drop Setup")]
    public Button[] colorButtons;  
    public TMP_Text colorDisplayText;
    public TMP_Text continueText;

    private Color[] colors = {
        Color.red,                   
        new Color(1f, 0.5f, 0f),      
        Color.yellow,                 
        Color.green,               
        Color.blue,                     
        new Color(1f, 0.75f, 0.79f),    
        new Color(0.5f, 0f, 0.5f)      
    };

    private string[] colorNames = {
        "rood", "oranje", "geel", "groen", "blauw", "roze", "paars"
    };

    void Start()
    {
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i;
            colorButtons[i].onClick.AddListener(() => OnColorClicked(index));
        }
    }

    private void OnColorClicked(int buttonIndex)
    {
        if (buttonIndex < colors.Length)
        {
            colorDisplayText.text = $"Je hebt voor {colorNames[buttonIndex]} gekozen. " +
                $"Dat is een erg mooie gipskleur!";
            continueText.text = $"Klik nu op verder gaan!";
        }
    }
}