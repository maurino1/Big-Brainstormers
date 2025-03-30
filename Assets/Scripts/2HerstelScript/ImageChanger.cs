using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image targetImage; // Sleep hier je UI Image in Unity
    public Sprite yesSprite;  // Sleep hier de afbeelding voor "Ja"
    public Sprite noSprite;   // Sleep hier de afbeelding voor "Nee"

    // Deze functie wordt aangeroepen als je op de "Ja" knop drukt
    public void ChangeToYes()
    {
        targetImage.sprite = yesSprite;
    }

    // Deze functie wordt aangeroepen als je op de "Nee" knop drukt
    public void ChangeToNo()
    {
        targetImage.sprite = noSprite;
    }
}
