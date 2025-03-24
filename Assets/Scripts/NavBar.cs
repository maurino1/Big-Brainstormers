using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class NavBar : MonoBehaviour
{
    public Button profileButton;
    public Button FAQButton;
    public Button avatarButton;

    private void Start()
    {
        profileButton.onClick.AddListener(() => SceneManager.LoadScene("Login"));
        FAQButton.onClick.AddListener(() => SceneManager.LoadScene("FAQ"));
        avatarButton.onClick.AddListener(() => SceneManager.LoadScene("CharacterSelectScene"));
    }
}
