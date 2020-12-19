using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(GetUserDataCoroutine(url, onError, onSuccess));
    }

    private IEnumerator GetUserDataCoroutine(string url, Action<string> onError, Action<UserStruct[]> onSuccess)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
                onError(request.error);
            else
                onSuccess(JsonHelper.GetArray<UserStruct>(request.downloadHandler.text));
        }
    }
}
