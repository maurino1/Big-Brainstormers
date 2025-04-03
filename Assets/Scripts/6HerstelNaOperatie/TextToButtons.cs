using System.Collections;
using UnityEngine;
using TMPro;

public class TextToButtons : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    void Start()
    {
        // Ensure panel1 is visible and panel2 is hidden at the start
        panel1.SetActive(true);
        panel2.SetActive(false);

        // Start the coroutine only after panel1 is active
        if (panel1.activeSelf)
        {
            StartCoroutine(SwitchPanelsAfterDelay(7f)); // Wait 7 seconds before switching
        }
    }

    IEnumerator SwitchPanelsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
}
