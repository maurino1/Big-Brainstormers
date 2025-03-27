using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System;

public class LoginScene : MonoBehaviour
{
    public TMP_InputField usernameInputLogin;
    public TMP_InputField passwordInputLogin;
    public TMP_InputField usernameInputRegister;
    public TMP_InputField passwordInputRegister;
    public TMP_InputField naam;
    public TMP_InputField leeftijd;
    public TMP_InputField dokter;
    public TMP_InputField eersteAfspraak;
    public TMP_Dropdown route;
    public Button registerButton;
    public Button loginButton;
    public TMP_Text errorMessageRegister;
    public TMP_Text errorMessageLogin;
    private ApiConnectieCode apiConnectieCode;

    private void Start()
    {
        apiConnectieCode = GameObject.FindGameObjectWithTag("WebApi").GetComponent<ApiConnectieCode>();

        registerButton.onClick.AddListener(async () => await Register());
        loginButton.onClick.AddListener(async () => await Login());

        errorMessageLogin.text = "";
        errorMessageRegister.text = "";
    }

    async Task Register()
    {
        string email = usernameInputRegister.text.Trim();
        string password = passwordInputRegister.text.Trim();
        string naamText = naam.text.Trim();
        string leeftijdText = leeftijd.text.Trim();
        string dokterNaam = dokter.text.Trim();
        string eersteAfspraakText = eersteAfspraak.text.Trim();
        string gekozenRoute = route.options[route.value].text;

        // Check if any field is empty
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(naamText) || string.IsNullOrEmpty(leeftijdText) ||
            string.IsNullOrEmpty(dokterNaam))
        {
            errorMessageRegister.text = "Alle velden moeten ingevuld zijn!";
            errorMessageRegister.color = Color.red;
            return;
        }

        // Validate password strength
        if (!IsValidPassword(password))
        {
            errorMessageRegister.text = "Wachtwoord moet minstens 10 karakters, 1 hoofdletter, 1 kleine letter, 1 cijfer en 1 speciaal teken bevatten.";
            errorMessageRegister.color = Color.red;
            return;
        }

        // Validate leeftijd
        if (!DateTime.TryParseExact(leeftijdText, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime geboortedatum))
        {
            errorMessageRegister.text = "Geboortedatum moet in het formaat dd-mm-jjjj zijn!";
            errorMessageRegister.color = Color.red;
            return;
        }

        // Validate eerste afspraak datum
        DateTime? afspraakDate = null;
        if (!string.IsNullOrWhiteSpace(eersteAfspraak.text))
        {
            if (DateTime.TryParseExact(eersteAfspraak.text.Trim(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                afspraakDate = parsedDate;
            }
            else
            {
                errorMessageRegister.text = "Eerste afspraak moet in het formaat dd-mm-jjjj zijn!";
                errorMessageRegister.color = Color.red;
                return;
            }
        }

        // Create User and UserData objects
        User newUser = new User { email = email, Password = password };
        UserData userData = new UserData
        {
            Naam = naamText,
            GeboorteDatum = geboortedatum,
            Route = gekozenRoute,
            DokterNaam = dokterNaam,
            EersteAfspraak = afspraakDate ?? default,
            UserId = null
        };

        // Call API for registration (adjust method signature if needed)
        await apiConnectieCode.Register(newUser);
        await apiConnectieCode.SendUserData(userData);
    }


    public void ClearRegisterFields()
    {
        usernameInputRegister.text = "";
        passwordInputRegister.text = "";
        naam.text = "";
        leeftijd.text = "";
        errorMessageRegister.text = ""; // Clear any error messages
    }


    async Task Login()
    {
        string email = usernameInputLogin.text.Trim();
        string password = passwordInputLogin.text.Trim();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            errorMessageLogin.text = "Gebruikersnaam of wachtwoord mag niet leeg zijn!";
            errorMessageLogin.color = Color.red;
            return;
        }
            User user = new User {email = email, Password = password};
        apiConnectieCode.Login(user);
    }

    bool IsValidPassword(string password)
    {
        return password.Length >= 10 &&
               Regex.IsMatch(password, @"[a-z]") &&   // Minstens 1 kleine letter
               Regex.IsMatch(password, @"[A-Z]") &&   // Minstens 1 hoofdletter
               Regex.IsMatch(password, @"\d") &&      // Minstens 1 cijfer
               Regex.IsMatch(password, @"[\W_]");     // Minstens 1 speciaal teken
    }
}
