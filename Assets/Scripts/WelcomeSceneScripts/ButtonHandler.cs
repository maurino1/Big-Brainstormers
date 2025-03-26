using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
    public Button avatarButton;

    private void Start()
    {
        avatarButton.gameObject.SetActive(false);

        StartCoroutine(ShowButtonAfterDelay());

        avatarButton.onClick.AddListener(() => SceneManager.LoadScene("IntroductionAppScene"));
    }

    private IEnumerator ShowButtonAfterDelay()
    {
        yield return new WaitForSeconds(2.75f);

        avatarButton.gameObject.SetActive(true);
    }
}