using UnityEngine;
using UnityEngine.UI;

public class Buttonappear : MonoBehaviour
{
    public Button triggerButton; // Assign the first button in the Inspector
    public Button hiddenButton;  // Assign the second button in the Inspector

    void Start()
    {
        hiddenButton.gameObject.SetActive(false); // Initially hide the second button
        triggerButton.onClick.AddListener(ShowHiddenButton);
    }

   public void ShowHiddenButton()
    {
        hiddenButton.gameObject.SetActive(true);
    }
}
