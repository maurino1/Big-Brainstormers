using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class NotesApiClient : MonoBehaviour
{
    public WebClient webClient;

    public async Awaitable<IWebRequestReponse> ReadNotes()
    {
        string route = "/notes";

        IWebRequestReponse webRequestResponse = await webClient.SendGetRequest(route);
        return ParseNotesResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> CreateNotes(Notes notes)
    {
        string route = "/notes";
        string data = JsonUtility.ToJson(notes);

        IWebRequestReponse webRequestResponse = await webClient.SendPostRequest(route, data);
        return ParseNotesResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> UpdateNotes(Notes notes)
    {
        string route = "/notes";
        string data = JsonUtility.ToJson(notes);

        return await webClient.SendPutRequest(route, data);
    }

    public async Awaitable<IWebRequestReponse> DeleteNotes(string notesId)
    {
        string route = "/notes/" + notesId;
        return await webClient.SendDeleteRequest(route);
    }

    private IWebRequestReponse ParseNotesResponse(IWebRequestReponse webRequestResponse)
    {
        switch (webRequestResponse)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                Notes notes = JsonUtility.FromJson<Notes>(data.Data);
                return new WebRequestData<Notes>(notes);

            default:
                return webRequestResponse;
        }
    }
}
