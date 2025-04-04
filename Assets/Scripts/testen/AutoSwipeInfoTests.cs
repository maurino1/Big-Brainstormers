using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[TestFixture]
public class AutoSwipeInfoTests
{
    private GameObject scrollRectObject;
    private GameObject contentObject;
    private ScrollRect scrollRect;
    private AutoSwipeInfo autoSwipeInfo;

    [SetUp]
    public void Setup()
    {
        // Create GameObject for ScrollRect
        scrollRectObject = new GameObject("ScrollRectObject");
        scrollRect = scrollRectObject.AddComponent<ScrollRect>();

        // Create content GameObject for ScrollRect
        contentObject = new GameObject("Content");
        scrollRect.content = contentObject.AddComponent<RectTransform>();

        // Add AutoSwipeInfo component to ScrollRect object
        autoSwipeInfo = scrollRectObject.AddComponent<AutoSwipeInfo>();

        // Create buttons for testing
        autoSwipeInfo.nextButton = new GameObject("NextButton").AddComponent<Button>();
        autoSwipeInfo.prevButton = new GameObject("PrevButton").AddComponent<Button>();

        // Initialize variables
        autoSwipeInfo.swipeInterval = 0.1f;  // Fast interval for testing
        autoSwipeInfo.swipeSpeed = 0.5f;
        autoSwipeInfo.Start(); // Start the script functionality
    }

    [Test]
    public void TestNextPageMovesCorrectly()
    {
        // Before clicking, the scroll position should be at the first page (0)
        float initialPosition = scrollRect.horizontalNormalizedPosition;

        // Click on the Next button
        autoSwipeInfo.NextPage();

        // The target position for the next page should be updated, so the position should change
        Assert.AreNotEqual(initialPosition, scrollRect.horizontalNormalizedPosition, "Scroll position should change after NextPage is called.");
    }

    [Test]
    public void TestPreviousPageMovesCorrectly()
    {
        // Before clicking, the scroll position should be at the first page (0)
        float initialPosition = scrollRect.horizontalNormalizedPosition;

        // First, click Next to go to the next page (page 1)
        autoSwipeInfo.NextPage();

        // Now, the position should be different from the initial position
        Assert.AreNotEqual(initialPosition, scrollRect.horizontalNormalizedPosition, "Scroll position should change after NextPage is called.");

        // Click on the Previous button to go back to the first page
        autoSwipeInfo.PreviousPage();

        // The scroll position should now be back to the initial position
        Assert.AreEqual(initialPosition, scrollRect.horizontalNormalizedPosition, "Scroll position should return to the initial position after PreviousPage is called.");
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy GameObjects after tests
        Object.Destroy(scrollRectObject);
        Object.Destroy(contentObject);
    }
}
