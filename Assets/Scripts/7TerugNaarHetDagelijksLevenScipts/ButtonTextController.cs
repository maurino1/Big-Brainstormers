using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonTextController : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public TMP_Text displayText;

    [TextArea]
    public string textForButton1 = "Button 1 was clicked!";
    [TextArea]
    public string textForButton2 = "Button 2 was clicked!";

    void Start()
    {
        displayText.gameObject.SetActive(false);

        button1.onClick.AddListener(() => UpdateText(textForButton1));
        button2.onClick.AddListener(() => UpdateText(textForButton2));
    }

    void UpdateText(string newText)
    {
        displayText.text = newText;
        displayText.gameObject.SetActive(true);
    }
}