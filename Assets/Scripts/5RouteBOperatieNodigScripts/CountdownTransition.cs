using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CountdownTransition : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Button startButton;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject currentPanel;
    [SerializeField] private GameObject nextPanel;
    [SerializeField] private Image darkenerPanel;
    [SerializeField] private Image darkenerPanel2;

    [Header("Settings")]
    [SerializeField] private float countdownDuration = 10f;

    private Color originalDarkenerColor;
    private Coroutine countdownCoroutine;

    private void Awake()
    {
        // Store original darkener color (should be transparent or semi-transparent)
        originalDarkenerColor = darkenerPanel.color;

        // Hide countdown text initially
        countdownText.gameObject.SetActive(false);

        // Hide next panel and darkener initially
        nextPanel.SetActive(false);
        darkenerPanel.gameObject.SetActive(false);

        // Add button listener
        startButton.onClick.AddListener(StartCountdown);
    }

    private void StartCountdown()
    {
        // Disable button during countdown
        startButton.interactable = false;

        // Show countdown text and darkener panel
        countdownText.gameObject.SetActive(true);
        darkenerPanel.gameObject.SetActive(true);

        // Reset darkener to initial state
        darkenerPanel.color = originalDarkenerColor;

        // Start countdown coroutine
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
        countdownCoroutine = StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        float timeLeft = countdownDuration;
        float timeLeft2 = 3f;

        while (timeLeft > 0)
        {
            // Update countdown text
            countdownText.text = Mathf.CeilToInt(timeLeft).ToString();

            // Calculate darkening progress (0 to 1)
            float darkenProgress = 1 - (timeLeft / countdownDuration);

            // Make darkener panel more opaque over time
            Color newColor = darkenerPanel.color;
            newColor.a = Mathf.Lerp(originalDarkenerColor.a, 1f, darkenProgress);
            darkenerPanel.color = newColor;

            // Wait for next frame
            yield return null;

            // Decrease time
            timeLeft -= Time.deltaTime;
        }

        // Ensure final values
        countdownText.text = "0";
        darkenerPanel.color = new Color(originalDarkenerColor.r,
                                      originalDarkenerColor.g,
                                      originalDarkenerColor.b,
                                      1f); // Fully opaque

        // Switch panels
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);

        // show darkener panel
        while (timeLeft2 > 0) {
            Color newColor2 = darkenerPanel2.color;
            newColor2.a = Mathf.Lerp(1f, 0f, (3f - timeLeft2) / 3f);
            darkenerPanel2.color = newColor2;
            yield return null;
            timeLeft2 -= Time.deltaTime;
        }

        // Reset for next use
        darkenerPanel.gameObject.SetActive(false);
        startButton.interactable = true;
        countdownText.gameObject.SetActive(false);
        darkenerPanel.color = originalDarkenerColor;
    }
}