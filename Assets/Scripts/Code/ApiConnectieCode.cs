using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class ApiConnectieCode : MonoBehaviour
{
    [Header("Test data")]
    //public User user;
    //public Environment2D environment2D;
    //public Object2D object2D;

    [Header("Dependencies")]
    public UserApiClient userApiClient;
    public Environment2DApiClient enviroment2DApiClient;
    public Object2DApiClient object2DApiClient;
    public TMP_Text feedbackTextLogin;
    public TMP_Text feedbackTextRegister;

    public static ApiConnectieCode instance { get; private set; }

    void Awake()
    {
        // hier controleren we of er al een instantie is van deze singleton
        // als dit zo is dan hoeven we geen nieuwe aan te maken en verwijderen we deze
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    #region Login

    [ContextMenu("User/Register")]
    public async void Register(User user)
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Register(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Register succes!");
                // TODO: Handle succes scenario;
                feedbackTextRegister.text = "Registratie succesvol!";
                feedbackTextRegister.color = Color.green;
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Register error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("User/Login")]
    public async void Login(User user)
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Login(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("✅ Login succesvol!");
                feedbackTextLogin.text = "Login succesvol!";
                feedbackTextLogin.color = Color.green;
                //SceneManager.LoadScene("HomeScreen"); // ✅ Ga naar de home screen na inloggen
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.LogError("❌ Login fout: " + errorMessage);
                feedbackTextLogin.text = "Login mislukt: " + errorMessage;
                feedbackTextLogin.color = Color.red;
                break;
            default:
                throw new NotImplementedException("Onverwachte response: " + webRequestResponse.GetType());
        }
    }
    #endregion
}
