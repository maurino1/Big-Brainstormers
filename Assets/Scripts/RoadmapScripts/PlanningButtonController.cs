using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class PlanningButtonController : MonoBehaviour
{
    public GameObject Panel;

    [Header("Text Elements")]
    public TMP_Text dokterNaamText;
    public TMP_Text datumAfspraakText;
    public TMP_Text routeText;


    private void Start()
    {
        dokterNaamText.text = "";
        datumAfspraakText.text = "";
        routeText.text = "";
    }
    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
            _ = LoadUserData();
        }
    }

    private async Task LoadUserData()
    {
        var response = await ApiConnectieCode.instance.userApiClient.ReadUserData();

        switch (response)
        {
            case WebRequestData<UserData> data:
                Debug.Log("✅ Gebruikersdata geladen");

                UserData userData = data.Data;

                Debug.Log($"DokterNaam: {userData.dokterNaam}");
                Debug.Log($"EersteAfspraak: {userData.eersteAfspraak}");
                Debug.Log($"Route: {userData.route}");

                if (dokterNaamText != null)
                    dokterNaamText.text = $"Naam Dokter: {userData.dokterNaam}";

                if (datumAfspraakText != null)
                    datumAfspraakText.text = $"Datum afspraak: {userData.eersteAfspraak ?? "Onbekend"}";

                if (routeText != null)
                    routeText.text = $"Route: {userData.route}";
                break;

            case WebRequestError error:
                Debug.LogError("❌ Fout bij laden van gebruikersdata: " + error.ErrorMessage);
                break;
        }
    }
}
