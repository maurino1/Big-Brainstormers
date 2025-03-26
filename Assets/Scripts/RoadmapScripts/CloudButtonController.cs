using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloudLoader : MonoBehaviour
{
    // Naam van de additieve scene voor deze wolk (bijv. "CloudScene1").
    public string sceneName;

    // Referentie naar het UI-panel dat als venster fungeert (met bijvoorbeeld een RawImage).
    public GameObject windowPanel;

    // Houdt bij of de scene al geladen is.
    private bool sceneLoaded = false;

    // Button-component op dit GameObject.
    private Button button;

    void Awake()
    {
        // Probeer de Button-component te pakken.
        button = GetComponent<Button>();
        if (button != null)
        {
            // Voeg de OnClick listener toe via code.
            button.onClick.AddListener(OnCloudButtonClick);
        }
        else
        {
            Debug.LogWarning("Geen Button component gevonden op " + gameObject.name);
        }
    }

    // Methode die wordt aangeroepen wanneer de wolk-button wordt ingedrukt.
    public void OnCloudButtonClick()
    {
        Debug.Log("Cloud button clicked!");
        if (windowPanel != null)
        {
            windowPanel.SetActive(true);
        }

        // Laad de scene additief als deze nog niet geladen is.
        if (!sceneLoaded && !string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            sceneLoaded = true;
        }
    }

    // Optionele methode voor het sluiten van het venster en ontladen van de scene.
    // Deze methode kun je via een sluitknop in het venster aanroepen.
    public void CloseWindow()
    {
        if (windowPanel != null)
        {
            windowPanel.SetActive(false);
        }

        if (sceneLoaded && !string.IsNullOrEmpty(sceneName))
        {
            SceneManager.UnloadSceneAsync(sceneName);
            sceneLoaded = false;
        }
    }
}
