using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginScene : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField naam;
    public TMP_InputField leeftijd;
    public Button registerButton;
    public Button loginButton;
    private ApiConnectieCode apiConnectieCode;

    private void Start()
    {
        registerButton.onClick.AddListener(Register);
        loginButton.onClick.AddListener(Login);
    }

    private void Register()
    {
        User user = new User
        {
            Username = usernameInput.text,
            Password = passwordInput.text
        };

        UserData userData = new UserData
        {
            Naam = naam.text,
            Leeftijd = int.Parse(leeftijd.text)
        };

        apiConnectieCode.Register(user);
    }

    private void Login()
    {
        User user = new User
        {
            Username = usernameInput.text,
            Password = passwordInput.text
        };
        apiConnectieCode.Login(user);
    }
}
