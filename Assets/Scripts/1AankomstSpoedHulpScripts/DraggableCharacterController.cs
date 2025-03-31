using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableCharacter : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas parentCanvas;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        // Get the parent canvas (make sure your character is under a Canvas)
        parentCanvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Make the character semi-transparent while dragging
        canvasGroup.alpha = 0.6f;
        // Allow events to pass through so drop targets can detect the drag
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the character based on the pointer's delta
        rectTransform.anchoredPosition += eventData.delta / parentCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Reset transparency and raycast blocking when done dragging
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
