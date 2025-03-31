using UnityEngine;

public class MoveCarOnClick : MonoBehaviour
{
    public Transform target; // The object to move towards (assign in Inspector)
    public float moveSpeed = 2f; // Movement speed per click
    private int clickCount = 0;

    private void OnMouseDown()
    {
        clickCount++; // Increment click count
        Debug.Log("Click Count: " + clickCount);

        if (target != null)
        {
            // Move the car towards the target position
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                moveSpeed
            );
        }
    }
}
