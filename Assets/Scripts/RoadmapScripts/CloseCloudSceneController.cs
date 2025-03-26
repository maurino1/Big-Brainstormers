using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ClosePanelButton : MonoBehaviour
{
    // Reference to the panel (CloudScenePanel) that should be hidden.
    public GameObject panelToClose;
    
    // Name of your main scene (the one that should remain loaded, e.g., "Roadmap")
    public string mainSceneName;

    // This method is called when the X button is clicked.
    public void ClosePanel()
    {
        // Hide the panel.
        if (panelToClose != null)
        {
            panelToClose.SetActive(false);
        }
        
        // Create a list to store the names of all additively loaded scenes.
        List<string> scenesToUnload = new List<string>();
        
        // Loop through all loaded scenes.
        int totalScenes = SceneManager.sceneCount;
        for (int i = 0; i < totalScenes; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            // If the scene is loaded and its name is not the main scene, mark it for unloading.
            if (scene.isLoaded && scene.name != mainSceneName)
            {
                scenesToUnload.Add(scene.name);
            }
        }
        
        // Unload all marked scenes.
        foreach (string sceneName in scenesToUnload)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}