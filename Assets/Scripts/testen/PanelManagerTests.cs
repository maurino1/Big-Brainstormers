using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class PanelManagerTests
{
    private GameObject panelObject;
    private PanelManager panelManager;

    [SetUp]
    public void Setup()
    {
        // Maak een nieuw GameObject voor het paneel
        panelObject = new GameObject("Panel");

        // Voeg de PanelManager script toe aan dit GameObject
        panelManager = panelObject.AddComponent<PanelManager>();

        // Maak een ander GameObject voor het UI-paneel dat beheerd wordt door PanelManager
        panelManager.panel = new GameObject("PanelUI");
        panelManager.panel.SetActive(false); // Zorg ervoor dat het paneel verborgen is bij het starten
    }

    [Test]
    public void TestPanelIsInitiallyHidden()
    {
        // Test of het paneel aanvankelijk verborgen is
        Assert.IsFalse(panelManager.panel.activeSelf, "The panel should be initially hidden.");
    }

    [Test]
    public void TestOpenPanel()
    {
        // Roep de OpenPanel methode aan om het paneel zichtbaar te maken
        panelManager.OpenPanel();

        // Test of het paneel zichtbaar is na het aanroepen van OpenPanel
        Assert.IsTrue(panelManager.panel.activeSelf, "The panel should be visible after calling OpenPanel.");
    }

    [Test]
    public void TestClosePanel()
    {
        // Roep eerst de OpenPanel methode aan om het paneel zichtbaar te maken
        panelManager.OpenPanel();

        // Roep daarna de ClosePanel methode aan om het paneel weer te verbergen
        panelManager.ClosePanel();

        // Test of het paneel verborgen is na het aanroepen van ClosePanel
        Assert.IsFalse(panelManager.panel.activeSelf, "The panel should be hidden after calling ClosePanel.");
    }

    [TearDown]
    public void Teardown()
    {
        // Verwijder het GameObject na de test om geheugen vrij te maken
        Object.Destroy(panelObject);
    }
}
