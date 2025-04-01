using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReturnToRoadmapDrop : MonoBehaviour, IDropHandler
{
    // Name of the roadmap scene to load
    public string roadmapSceneName = "RoadmapScene";

    public void OnDrop(PointerEventData eventData)
    {
        // Check if the dropped object is your draggable character
        DraggableCharacter draggable = eventData.pointerDrag.GetComponent<DraggableCharacter>();
        if (draggable != null)
        {
            Debug.Log("Dropped on exit zone — loading Roadmap scene.");
            SceneManager.LoadScene(roadmapSceneName);
        }
    }
}
