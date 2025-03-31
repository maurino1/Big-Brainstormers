using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    // Reference to the panel that should be activated (the inside of the hospital)
    public GameObject insidePanel;
    // Reference to the panel to hide (the outside)
    public GameObject outsidePanel;

    public void OnDrop(PointerEventData eventData)
    {
        // Check if the dropped object is your draggable character
        DraggableCharacter draggable = eventData.pointerDrag.GetComponent<DraggableCharacter>();
        if (draggable != null)
        {
            Debug.Log("Character successfully dropped in the target area!");
            // Hide the outside panel
            if (outsidePanel != null)
            {
                outsidePanel.SetActive(false);
            }
            // Show the inside panel
            if (insidePanel != null)
            {
                insidePanel.SetActive(true);
            }
        }
    }
}
