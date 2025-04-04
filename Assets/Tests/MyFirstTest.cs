using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropAreaTests
{
    private GameObject dropZoneObject;
    private DropArea dropArea;

    private GameObject insidePanel;
    private GameObject outsidePanel;

    private GameObject draggableObject;

    [SetUp]
    public void SetUp()
    {
        // Create drop zone and component
        dropZoneObject = new GameObject("DropZone", typeof(DropArea));
        dropArea = dropZoneObject.GetComponent<DropArea>();

        // Create and assign inside/outside panels
        insidePanel = new GameObject("InsidePanel");
        outsidePanel = new GameObject("OutsidePanel");

        insidePanel.SetActive(false);
        outsidePanel.SetActive(true);

        dropArea.insidePanel = insidePanel;
        dropArea.outsidePanel = outsidePanel;

        // Create draggable character object
        draggableObject = new GameObject("Draggable", typeof(DraggableCharacter));
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(dropZoneObject);
        Object.DestroyImmediate(insidePanel);
        Object.DestroyImmediate(outsidePanel);
        Object.DestroyImmediate(draggableObject);
    }

    [Test]
    public void OnDrop_TogglesPanelStates()
    {
        // Simulate drop
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            pointerDrag = draggableObject
        };

        dropArea.OnDrop(eventData);

        Assert.IsTrue(insidePanel.activeSelf, "Inside panel should be activated.");
        Assert.IsFalse(outsidePanel.activeSelf, "Outside panel should be deactivated.");
    }
}
