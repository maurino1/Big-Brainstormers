﻿using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class UserApiClient : MonoBehaviour
{
    public WebClient webClient;

    public async Awaitable<IWebRequestReponse> Register(User user)
    {
        string route = "/account/register";
        string data = JsonUtility.ToJson(user);

        return await webClient.SendPostRequest(route, data);
    }

    public async Awaitable<IWebRequestReponse> SendUserData(UserData userData)
    {
        string route = "/userdata";
        string data = JsonUtility.ToJson(userData);

        return await webClient.SendPostRequest(route, data);
    }

    public async Awaitable<IWebRequestReponse> Login(User user)
    {
        string route = "/account/login";
        string data = JsonUtility.ToJson(user);

        IWebRequestReponse response = await webClient.SendPostRequest(route, data);
        return ProcessLoginResponse(response);
    }

    private IWebRequestReponse ProcessLoginResponse(IWebRequestReponse webRequestResponse)
    {
        switch (webRequestResponse)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                string token = JsonHelper.ExtractToken(data.Data);
                webClient.SetToken(token);
                return new WebRequestData<string>("Succes");
            default:
                return webRequestResponse;
        }
    }

    public async Awaitable<IWebRequestReponse> ReadUserData()
    {
        string route = "/userdata";

        IWebRequestReponse response = await webClient.SendGetRequest(route);
        return ParseUserDataListResponse(response);
    }

    private IWebRequestReponse ParseUserDataListResponse(IWebRequestReponse response)
    {
        switch (response)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                UserData userData = JsonUtility.FromJson<UserData>(data.Data); // ✅ parse single object
                return new WebRequestData<UserData>(userData);
            default:
                return response;
        }
    }
}

