using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;


public class ButtonHandler2 : MonoBehaviour
{
    public Button IntroductionButton;
    void Start()
    {
        IntroductionButton.onClick.AddListener(() => SceneManager.LoadScene("CharacterSelectScene"));
    }


}
