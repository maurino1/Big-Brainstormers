using UnityEngine;

public class CollectibleHover : MonoBehaviour
{
    [Header("Hover Instellingen")]
    public float hoverHeight = 0.5f;  // Hoe hoog het zweeft
    public float hoverSpeed = 2f;     // Hoe snel het zweeft
    public float rotateSpeed = 50f;   // Hoe snel het roteert

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Onthoud de startpositie
    }

    public void Update()
    {
        // Hover effect met een sinusgolf
        float newY = startPos.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // Voortdurend roteren
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
