using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.User;

public class ItemSpawner : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] private GameObject itemTemplate;
    //[SerializeField] private int itemQuantity;

    [Header("Food Data")]
    [SerializeField] private FoodSO butter;
    [SerializeField] private FoodSO corn;
    [SerializeField] private FoodSO mushrooms;
    [SerializeField] private FoodSO wheat;

    [Header("JSON URL")]
    [SerializeField] private string JSONURL;

    private UserStruct[] users;

    private void Start()
    {
        //SpawnItems(itemTemplate, itemQuantity);
        DataDownloader dataDownloader = gameObject.GetComponent<DataDownloader>();
        dataDownloader.GetUsersData(JSONURL, (string error) => Debug.Log("Error: " + error),
            (UserStruct[] users) =>
            {
                for (int i = 0; i < users.Length; i++)
                {
                    Debug.Log(users[i].Name);
                }
            });
    }

    private void SpawnItems(GameObject itemTemplate)
    {
        int itemsQuantity = users.Length;
        for (int i = 0; i < itemsQuantity; i++)
        {
            GameObject tempGameObject = Instantiate(itemTemplate, transform);
            tempGameObject.name += " " + i;
            InitializeUser(tempGameObject.GetComponent<User>());
        }
    }

    private void InitializeUser(User user)
    {
        //AvatarsDownloader avatarsDownloader = gameObject.GetComponent<AvatarsDownloader>();
        //avatarsDownloader.GetAvatar(randomImageURL,
        //    (string error) => Debug.Log("Error: " + error)
        //, (Texture2D texture) => {
        //    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
        //    user.Avatar = sprite;
        //});
    }
}
