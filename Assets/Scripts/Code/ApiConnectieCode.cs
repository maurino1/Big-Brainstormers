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
    public NotesApiClient notesApiClient;
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
    public async Task<bool> Register(User user)
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Register(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Register succes!");
                // TODO: Handle succes scenario;
                feedbackTextRegister.text = "Registratie succesvol!";
                feedbackTextRegister.color = Color.green;
                return true;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Register error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                return false;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    public async Task<bool> SendUserData(UserData userData)
    {
        IWebRequestReponse webRequestResponse = await userApiClient.SendUserData(userData);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("✅ UserData succesvol opgeslagen!");
                return true;
            case WebRequestError errorResponse:
                Debug.LogError("❌ Fout bij opslaan van UserData: " + errorResponse.ErrorMessage);
                return false;
            default:
                throw new NotImplementedException("Onverwachte response: " + webRequestResponse.GetType());
        }
    }


    [ContextMenu("User/Login")]
    public async Task<bool> Login(User user)
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Login(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("✅ Login succesvol!");
                feedbackTextLogin.text = "Login succesvol!";
                feedbackTextLogin.color = Color.green;
                SceneManager.LoadScene("RoadmapScene"); // ✅ Ga naar de home screen na inloggen
                return true;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.LogError("❌ Login fout: " + errorMessage);
                feedbackTextLogin.text = "Login mislukt: " + errorMessage;
                feedbackTextLogin.color = Color.red;
                return false;
            default:
                throw new NotImplementedException("Onverwachte response: " + webRequestResponse.GetType());
        }
    }
    #endregion

    #region NotesAndData

    public async Task<Notes> ReadNotes()
    {
        IWebRequestReponse response = await notesApiClient.ReadNotes();

        switch (response)
        {
            case WebRequestData<Notes> data:
                Debug.Log("✅ Notes geladen!");
                return data.Data;

            case WebRequestError error:
                Debug.LogError("❌ Fout bij ophalen van Notes: " + error.ErrorMessage);
                return null;

            default:
                throw new NotImplementedException("Onverwachte response: " + response.GetType());
        }
    }

    public async Task<bool> CreateNotes(string noteContent)
    {
        Notes notes = new Notes
        {
            content = noteContent
        };

        IWebRequestReponse response = await notesApiClient.CreateNotes(notes);

        switch (response)
        {
            case WebRequestData<Notes> data:
                Debug.Log("✅ Note aangemaakt!");
                return true;

            case WebRequestError error:
                Debug.LogWarning("⚠️ Note bestaat al of aanmaak mislukt: " + error.ErrorMessage);
                return false;

            default:
                throw new NotImplementedException("Onverwachte response: " + response.GetType());
        }
    }

    public async Task<bool> UpdateNotes(string noteContent)
    {
        Notes notes = new Notes
        {
            content = noteContent
        };

        IWebRequestReponse response = await notesApiClient.UpdateNotes(notes);

        switch (response)
        {
            case WebRequestData<string> _:
                Debug.Log("✅ Note bijgewerkt!");
                return true;

            case WebRequestError error:
                Debug.LogError("❌ Fout bij bijwerken van Notes: " + error.ErrorMessage);
                return false;

            default:
                throw new NotImplementedException("Onverwachte response: " + response.GetType());
        }
    }

    #endregion

}
