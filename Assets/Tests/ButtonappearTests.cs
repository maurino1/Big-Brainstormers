using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

[TestFixture]
public class ButtonappearTests
{
    private GameObject gameObject;
    private Buttonappear buttonAppearScript;
    private Button triggerButton;
    private Button hiddenButton;

    [SetUp]
    public void Setup()
    {
        // Maak een nieuw GameObject en voeg de Buttonappear-component toe
        gameObject = new GameObject();
        buttonAppearScript = gameObject.AddComponent<Buttonappear>();

        // Maak en voeg triggerButton en hiddenButton toe aan het GameObject
        triggerButton = new GameObject().AddComponent<Button>();
        hiddenButton = new GameObject().AddComponent<Button>();

        // Koppel de knoppen aan het script
        buttonAppearScript.triggerButton = triggerButton;
        buttonAppearScript.hiddenButton = hiddenButton;

        // Zet het hiddenButton object uit bij het begin
        hiddenButton.gameObject.SetActive(false);

        // Voeg de listener toe
        triggerButton.onClick.AddListener(buttonAppearScript.ShowHiddenButton);
    }

    [Test]
    public void TestHiddenButtonBecomesVisibleAfterTriggerButtonClick()
    {
        // Controleer of de verborgen knop in het begin uitgeschakeld is
        Assert.IsFalse(hiddenButton.gameObject.activeSelf, "Hidden button should be inactive at the start.");

        // Simuleer een klik op de triggerButton
        triggerButton.onClick.Invoke();

        // Controleer of de verborgen knop zichtbaar is na de klik
        Assert.IsTrue(hiddenButton.gameObject.activeSelf, "Hidden button should be active after the trigger button is clicked.");
    }

    [TearDown]
    public void Teardown()
    {
        // Verwijder het GameObject en andere instellingen
        Object.Destroy(gameObject);
        Object.Destroy(triggerButton.gameObject);
        Object.Destroy(hiddenButton.gameObject);
    }
}
