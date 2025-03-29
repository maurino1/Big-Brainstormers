using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset;

    void OnMouseDown()
    {
        // Calculate offset between mouse and object position
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        // Move object with mouse, maintaining offset
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        newPos.z = 0; // Lock to 2D plane
        transform.position = newPos;
    }
}