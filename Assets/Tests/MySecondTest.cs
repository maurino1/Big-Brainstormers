using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ReturnToRoadmapDropTests
{
    private GameObject dropZoneObject;
    private ReturnToRoadmapDrop returnToRoadmapDrop;
    private GameObject draggableObject;

    [SetUp]
    public void SetUp()
    {
        // Create drop zone and component
        dropZoneObject = new GameObject("DropZone", typeof(ReturnToRoadmapDrop));
        returnToRoadmapDrop = dropZoneObject.GetComponent<ReturnToRoadmapDrop>();

        // Create draggable object (with DraggableCharacter)
        draggableObject = new GameObject("Draggable", typeof(DraggableCharacter));
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(dropZoneObject);
        Object.DestroyImmediate(draggableObject);
    }

    [Test]
    public void OnDrop_LoadsRoadmapScene_WhenDraggableCharacterIsDropped()
    {
        // Set up the expected scene name
        returnToRoadmapDrop.roadmapSceneName = "RoadmapScene";

        // Use a mock or fake method to check if LoadScene was called
        bool sceneLoaded = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "RoadmapScene")
            {
                sceneLoaded = true;
            }
        };

        // Simulate drop of a draggable character
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            pointerDrag = draggableObject
        };

        returnToRoadmapDrop.OnDrop(eventData);

        // Assert that the correct scene was loaded
        Assert.IsTrue(sceneLoaded, "Roadmap scene should be loaded when a DraggableCharacter is dropped.");
    }

    [Test]
    public void OnDrop_DoesNotLoadScene_WhenNoDraggableCharacterIsDropped()
    {
        // Set up the expected scene name
        returnToRoadmapDrop.roadmapSceneName = "RoadmapScene";

        // Use a mock or fake method to check if LoadScene was called
        bool sceneLoaded = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "RoadmapScene")
            {
                sceneLoaded = true;
            }
        };

        // Create an object without DraggableCharacter
        var nonDraggableObject = new GameObject("NonDraggable");

        // Simulate drop of a non-draggable object
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            pointerDrag = nonDraggableObject
        };

        returnToRoadmapDrop.OnDrop(eventData);

        // Assert that the scene was not loaded
        Assert.IsFalse(sceneLoaded, "Scene should not be loaded when a non-draggable object is dropped.");

        Object.DestroyImmediate(nonDraggableObject);
    }

    // Optionally, you could add additional tests for edge cases or other scenarios.
}
