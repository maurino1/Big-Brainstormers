using UnityEngine;
using TMPro;
using System.Collections;

public class WachtkamerUI : MonoBehaviour
{
    public TMP_Text welkomText;

    void Start()
    {
        welkomText.text = "Welkom in de wachtkamer";
        StartCoroutine(VeranderNaarVraag());
    }

    IEnumerator VeranderNaarVraag()
    {
        yield return new WaitForSeconds(3f); // Wacht 3 seconden
        welkomText.text = "Doet het veel pijn?";
    }
}
