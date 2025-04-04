using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class CollectibleHoverTests
{
    private GameObject collectibleObject;
    private CollectibleHover collectibleHover;
    private Vector3 initialPosition;
    private float initialTime;

    [SetUp]
    public void Setup()
    {
        // Maak een nieuw GameObject aan en voeg de CollectibleHover component toe
        collectibleObject = new GameObject();
        collectibleHover = collectibleObject.AddComponent<CollectibleHover>();

        // Stel de hover instellingen in
        collectibleHover.hoverHeight = 0.5f;
        collectibleHover.hoverSpeed = 2f;
        collectibleHover.rotateSpeed = 50f;

        // Zet de startpositie van het object
        initialPosition = collectibleObject.transform.position;

        // Onthoud de initiële tijd voor het testen van de sinusgolf
        initialTime = Time.time;
    }

    [Test]
    public void TestHoverMovement()
    {
        // Simuleer de update cycle
        float expectedY = initialPosition.y + Mathf.Sin(initialTime * collectibleHover.hoverSpeed) * collectibleHover.hoverHeight;

        // Roep de Update methode aan
        collectibleHover.Update();

        // Controleer of de Y-positie van het object veranderd is volgens de sinusgolf
        Assert.AreEqual(expectedY, collectibleObject.transform.position.y, 0.01f, "The Y position should match the hover effect using a sine wave.");
    }

    [Test]
    public void TestRotation()
    {
        // Bewaar de initiële rotatie
        float initialRotation = collectibleObject.transform.rotation.eulerAngles.y;

        // Roep de Update methode aan om de rotatie bij te werken
        collectibleHover.Update();

        // De rotatie moet met de opgegeven snelheid zijn verhoogd
        float expectedRotation = initialRotation + collectibleHover.rotateSpeed * Time.deltaTime;

        // Controleer of de rotatie is bijgewerkt
        Assert.AreEqual(expectedRotation, collectibleObject.transform.rotation.eulerAngles.y, 0.01f, "The object should rotate by the specified rotation speed.");
    }

    [TearDown]
    public void Teardown()
    {
        // Verwijder het GameObject na de test
        Object.Destroy(collectibleObject);
    }
}
