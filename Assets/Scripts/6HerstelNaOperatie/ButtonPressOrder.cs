using UnityEngine;
using TMPro;

public class ButtonPressOrder : MonoBehaviour
{
    public TextMeshProUGUI text;    // Verbind TextMeshPro tekst
    public string correctMessage = "Je hebt de volgorde goed!";
    private int buttonPressCount = 0; // Aantal keren dat knoppen in de juiste volgorde zijn ingedrukt

    // Functie die wordt aangeroepen wanneer de eerste knop wordt ingedrukt
    public void OnButton1Pressed()
    {
        // Als de eerste knop wordt ingedrukt in de juiste volgorde
        if (buttonPressCount == 0)
        {
            buttonPressCount = 1; // Eerste knop is goed ingedrukt
        }
        else
        {
            ResetPressOrder();  // Reset als de volgorde niet klopt
        }
    }

    // Functie die wordt aangeroepen wanneer de tweede knop wordt ingedrukt
    public void OnButton2Pressed()
    {
        // Als de tweede knop wordt ingedrukt in de juiste volgorde
        if (buttonPressCount == 1)
        {
            text.text = correctMessage;  // Pas de tekst aan
            buttonPressCount = 0;  // Reset de volgorde na een correcte volgorde
        }
        else
        {
            ResetPressOrder();  // Reset als de volgorde niet klopt
        }
    }

    // Functie om de volgorde van knoppen te resetten
    private void ResetPressOrder()
    {
        buttonPressCount = 0;
        text.text = "Verkeerde volgorde, probeer opnieuw!";
    }
}


