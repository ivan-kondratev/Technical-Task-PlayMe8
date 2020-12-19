using UnityEngine;
using Assets.Scripts.User;

public class ItemSpawner : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] private GameObject itemTemplate;

    [Header("Food Data")]
    [SerializeField] private FoodSO butter;
    [SerializeField] private FoodSO corn;
    [SerializeField] private FoodSO mushrooms;
    [SerializeField] private FoodSO wheat;

    [Header("JSON URL")]
    [SerializeField] private string JSONURL;

    private DataDownloader dataDownloader;

    private void Start()
    {
        dataDownloader = gameObject.GetComponent<DataDownloader>();
        dataDownloader.GetUsersData(JSONURL, (string error) => Debug.Log("Error: " + error),
            (UserStruct[] users) => SpawnItems(itemTemplate, users));
    }

    private void SpawnItems(GameObject itemTemplate, UserStruct[] users)
    {
        for (int i = 0; i < users.Length; i++)
        {
            GameObject tempGameObject = Instantiate(itemTemplate, transform);
            tempGameObject.name += " " + i;
            InitializeUser(tempGameObject.GetComponent<User>(), users[i]);
        }
    }

    private void InitializeUser(User user, UserStruct userStruct)
    {
        user.Name = userStruct.Name;
        dataDownloader.GetAvatar(userStruct.AvatarURL,
            (string error) => Debug.Log(error),
            (Texture2D texture) =>
            user.Avatar = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f)));
        user.Level = int.Parse(userStruct.Level);

        user.FoodQuantity = int.Parse(userStruct.FoodQuantity);
        user.FoodPriceForOneItem = int.Parse(userStruct.FoodPriceForOneItem);

        InitializeFood(user, userStruct.FoodData);
    }

    private void InitializeFood(User user, string foodData)
    {
        Food food = user.Food;
        switch (foodData)
        {
            case "butter":
                food.Name = butter.Name;
                food.Image = butter.Image;
                break;
            case "corn":
                food.Name = corn.Name;
                food.Image = corn.Image;
                break;
            case "mushrooms":
                food.Name = mushrooms.Name;
                food.Image = mushrooms.Image;
                break;
            case "wheat":
                food.Name = wheat.Name;
                food.Image = wheat.Image;
                break;
            default:
                break;
        }
        food.Quantity = user.FoodQuantity;
        food.Price = user.FoodPriceForOneItem * food.Quantity;
    }
}
