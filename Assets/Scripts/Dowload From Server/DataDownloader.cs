﻿using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Networking;
using Assets.Scripts.Dowload_From_Server;
using Assets.Scripts.User;

public class DataDownloader : MonoBehaviour
{
    public void GetAvatar(string url, Action<string> onError, Action<Texture2D> onSuccess)
    {
        StartCoroutine(GetTextureCoroutine(url, onError, onSuccess));
    }

    private IEnumerator GetTextureCoroutine(string url, Action<string> onError, Action<Texture2D> onSuccess)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
                onError(unityWebRequest.error);
            else
            {
                DownloadHandlerTexture downloadHandlerTexture = unityWebRequest.downloadHandler as DownloadHandlerTexture;
                onSuccess(downloadHandlerTexture.texture);
            }

        }

    }

    public void GetUsersData(string url, Action<string> onError, Action<UserStruct[]> onSuccess)
    {
        StartCoroutine(GetUsersDataCoroutine(url, onError, onSuccess));
    }

    private IEnumerator GetUsersDataCoroutine(string url, Action<string> onError, Action<UserStruct[]> onSuccess)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
                onError("Не удалось установить соединение с сервером.");
            else if (request.isHttpError)
                onError("Не удалось получить данные. Возвращайтесь позже.");
            else
                onSuccess(JsonHelper.GetArray<UserStruct>(request.downloadHandler.text));
        }
    }
}
