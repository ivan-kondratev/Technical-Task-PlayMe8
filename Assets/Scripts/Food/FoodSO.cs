using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New FoodData", menuName = "Food Data", order = 51)]
public class FoodSO : ScriptableObject
{
    public Sprite foodImage;
    public string foodName;

    [Header("Food Price Range")]
    public int foodPriceFrom;
    public int foodPriceTo;
}
