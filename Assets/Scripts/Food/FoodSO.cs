using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New FoodData", menuName = "Food Data", order = 51)]
public class FoodSO : ScriptableObject
{
    public Sprite Image;
    public string Name;
}
