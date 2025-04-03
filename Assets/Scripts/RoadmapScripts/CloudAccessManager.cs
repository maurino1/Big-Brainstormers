using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class CloudAccessManager : MonoBehaviour
{
    [Header("Clouds for Everyone")]
    public GameObject[] sharedClouds;

    [Header("Route A Only")]
    public GameObject[] routeAClouds;

    [Header("Route B Only")]
    public GameObject[] routeBClouds;

    async void Start()
    {
        // Make sure route is loaded before applying visibility
        await EnsureRouteIsLoaded();
        UpdateCloudVisibility();
    }

    async Task EnsureRouteIsLoaded()
    {
        if (SessionManager.IsLoggedIn && string.IsNullOrEmpty(SessionManager.Route))
        {
            var response = await ApiConnectieCode.instance.userApiClient.ReadUserData();
            if (response is WebRequestData<UserData> data)
            {
                SessionManager.Route = data.Data.route;
                Debug.Log($"✅ Route loaded in CloudAccessManager: {SessionManager.Route}");
            }
        }
    }

    void UpdateCloudVisibility()
    {
        // Always keep clouds visible
        SetInteractableAll(sharedClouds, true); // always interactable

        if (!SessionManager.IsLoggedIn || string.IsNullOrEmpty(SessionManager.Route))
        {
            SetInteractableAll(routeAClouds, true);
            SetInteractableAll(routeBClouds, true);
            return;
        }

        string route = SessionManager.Route;

        if (route == "A: Geen operatie")
        {
            SetInteractableAll(routeAClouds, true);
            SetInteractableAll(routeBClouds, false);
        }
        else if (route == "B: Operatie")
        {
            SetInteractableAll(routeAClouds, false);
            SetInteractableAll(routeBClouds, true);
        }
        else
        {
            SetInteractableAll(routeAClouds, true);
            SetInteractableAll(routeBClouds, true);
        }
    }


    void SetInteractableAll(GameObject[] targets, bool state)
    {
        foreach (var obj in targets)
        {
            if (obj != null)
            {
                // Keep it visible, but disable interaction
                var button = obj.GetComponent<Button>();
                if (button != null)
                {
                    button.interactable = state;
                }
            }
        }
    }
}
