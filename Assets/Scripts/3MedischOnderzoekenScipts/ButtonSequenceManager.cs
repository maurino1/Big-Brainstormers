using UnityEngine;
using UnityEngine.UI;

public class ButtonSequenceManager : MonoBehaviour
{
    [Header("UI References")]
    public Button firstButton;    // Eerste knop (startknop)
    public Button secondButton;   // Tweede knop
    public RawImage displayImage; // RawImage dat verschijnt
    public Button thirdButton;    // Derde knop (verschijnt later)

    void Start()
    {
        // Zet alles uit behalve de eerste knop
        secondButton.gameObject.SetActive(false);
        displayImage.gameObject.SetActive(false);
        thirdButton.gameObject.SetActive(false);

        // Koppel klik-events
        firstButton.onClick.AddListener(OnFirstButtonClick);
        secondButton.onClick.AddListener(OnSecondButtonClick);
    }

    void OnFirstButtonClick()
    {
        // Stap 1: Verberg eerste knop, toon tweede
        firstButton.gameObject.SetActive(false);
        secondButton.gameObject.SetActive(true);
    }

    void OnSecondButtonClick()
    {
        // Stap 2: Verberg tweede knop, toon image en derde knop
        secondButton.gameObject.SetActive(false);
        displayImage.gameObject.SetActive(true);
        thirdButton.gameObject.SetActive(true);

        // Optioneel: Voeg hier eventueel extra logica toe
        // zoals het laden van een texture voor de RawImage
    }

    // Vergeet niet om listeners te verwijderen bij OnDestroy
    void OnDestroy()
    {
        firstButton.onClick.RemoveAllListeners();
        secondButton.onClick.RemoveAllListeners();
    }
}