using UnityEngine;

public class ObjectPulse : MonoBehaviour
{
    public float scaleSpeed = 2f; // Speed of scaling
    public float minScale = 0.8f; // Minimum size
    public float maxScale = 1.2f; // Maximum size

    private Vector3 initialScale;
    private float timeCounter = 0f;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        timeCounter += Time.deltaTime * scaleSpeed;
        float scaleFactor = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(timeCounter) + 1f) / 2f);
        transform.localScale = initialScale * scaleFactor;
    }
}
