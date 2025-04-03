using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class LoginScene : MonoBehaviour
{
    [Header("Panels")]
    public GameObject loginPanel;
    public GameObject registerPanel1;
    public GameObject registerPanel2;

    [Header("Login Fields")]
    public TMP_InputField usernameInputLogin;
    public TMP_InputField passwordInputLogin;

    [Header("Register Step 1")]
    public TMP_InputField usernameInputRegister;
    public TMP_InputField passwordInputRegister;

    [Header("Register Step 2")]
    public TMP_InputField naam;
    public TMP_InputField leeftijd;
    public TMP_InputField dokter;
    public TMP_InputField eersteAfspraak;
    public TMP_Dropdown route;

    [Header("Buttons")]
    public Button registerButtonStep1;
    public Button registerButtonStep2;
    public Button loginButton;
    public Button homeButton;

    [Header("Errors")]
    public TMP_Text errorMessageRegister;
    public TMP_Text errorMessageLogin;

    private ApiConnectieCode apiConnectieCode;
    private User registeredUser;

    private void Start()
    {
        apiConnectieCode = GameObject.FindGameObjectWithTag("WebApi").GetComponent<ApiConnectieCode>();

        registerButtonStep1.onClick.AddListener(async () => await RegisterAccount());
        registerButtonStep2.onClick.AddListener(async () => await RegisterUserData());
        loginButton.onClick.AddListener(async () => await Login());
        homeButton.onClick.AddListener(() => SceneManager.LoadScene("RoadmapScene"));

        // Initial panel states
        loginPanel.SetActive(true);
        registerPanel1.SetActive(false);
        registerPanel2.SetActive(false);

        errorMessageLogin.text = "";
        errorMessageRegister.text = "";
    }

    public void GoToRegisterStep1()
    {
        loginPanel.SetActive(false);
        registerPanel1.SetActive(true);
    }

    public void BackToLogin()
    {
        registerPanel1.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void BackToRegisterStep1()
    {
        registerPanel2.SetActive(false);
        registerPanel1.SetActive(true);
    }

    async Task RegisterAccount()
    {
        string email = usernameInputRegister.text.Trim();
        string password = passwordInputRegister.text.Trim();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ShowError(errorMessageRegister, "E-mail en wachtwoord zijn verplicht.");
            return;
        }

        if (!IsValidPassword(password))
        {
            ShowError(errorMessageRegister, "Wachtwoord moet minstens 10 karakters, 1 hoofdletter, 1 kleine letter, 1 cijfer en 1 speciaal teken bevatten.");
            return;
        }

        User user = new User { email = email, Password = password };
        bool success = await apiConnectieCode.Register(user);

        if (!success)
        {
            ShowError(errorMessageRegister, "Registratie mislukt. Probeer opnieuw.");
            return;
        }

        registeredUser = user;
        ClearError(errorMessageRegister);

        // Move to next panel
        registerPanel1.SetActive(false);
        registerPanel2.SetActive(true);
    }

    async Task RegisterUserData()
    {
        string naamText = naam.text.Trim();
        string leeftijdText = leeftijd.text.Trim();
        string dokterNaam = dokter.text.Trim();
        string afspraakText = eersteAfspraak.text.Trim();
        string gekozenRoute = route.options[route.value].text;

        Regex validDateRegex = new Regex(@"^\d{2}-\d{2}-\d{4}$");

        if (string.IsNullOrEmpty(naamText) || string.IsNullOrEmpty(leeftijdText) || string.IsNullOrEmpty(dokterNaam))
        {
            ShowError(errorMessageRegister, "Alle velden moeten ingevuld zijn!");
            return;
        }

        if (!validDateRegex.IsMatch(leeftijdText))
        {
            ShowError(errorMessageRegister, "Geboortedatum moet in het formaat dd-mm-jjjj zijn.");
            return;
        }

        if (!string.IsNullOrEmpty(afspraakText) && !validDateRegex.IsMatch(afspraakText))
        {
            ShowError(errorMessageRegister, "Eerste afspraak moet in het formaat dd-mm-jjjj zijn.");
            return;
        }

        UserData userData = new UserData
        {
            naam = naamText,
            geboorteDatum = leeftijdText,
            route = gekozenRoute,
            dokterNaam = dokterNaam,
            eersteAfspraak = string.IsNullOrWhiteSpace(afspraakText) ? null : afspraakText,
            userId = null
        };

        await apiConnectieCode.Login(registeredUser);
        await apiConnectieCode.SendUserData(userData);

        SessionManager.IsLoggedIn = true;
        SessionManager.Route = userData.route;

        ClearError(errorMessageRegister);
        errorMessageRegister.text = "Registratie succesvol!";
        errorMessageRegister.color = Color.green;
    }

    async Task Login()
    {
        string email = usernameInputLogin.text.Trim();
        string password = passwordInputLogin.text.Trim();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ShowError(errorMessageLogin, "Gebruikersnaam of wachtwoord mag niet leeg zijn!");
            return;
        }

        User user = new User { email = email, Password = password };
        bool success = await apiConnectieCode.Login(user);

        if (success)
        {
            SessionManager.IsLoggedIn = true; // ✅ Mark session as logged in
            SceneManager.LoadScene("RoadMapScene");
        }
        else
        {
            ShowError(errorMessageLogin, "Login mislukt. Controleer je gegevens.");
        }
    }


    bool IsValidPassword(string password)
    {
        return password.Length >= 10 &&
               Regex.IsMatch(password, @"[a-z]") &&
               Regex.IsMatch(password, @"[A-Z]") &&
               Regex.IsMatch(password, @"\d") &&
               Regex.IsMatch(password, @"[\W_]");
    }

    void ShowError(TMP_Text target, string message)
    {
        target.text = message;
        target.color = Color.red;
    }

    void ClearError(TMP_Text target)
    {
        target.text = "";
    }

    public void ClearRegisterFields()
    {
        usernameInputRegister.text = "";
        passwordInputRegister.text = "";
        naam.text = "";
        leeftijd.text = "";
        dokter.text = "";
        eersteAfspraak.text = "";
        ClearError(errorMessageRegister);
    }
}
