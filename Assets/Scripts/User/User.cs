using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class User : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    public string Name { get => nameText.text; set => nameText.text = value; }

    [SerializeField] private Image avatar;
    public Sprite Avatar { get => avatar.sprite; set => avatar.sprite = value; }

    [SerializeField] private TMP_Text levelText;
    public int Level { get => int.Parse(levelText.text); set => levelText.text = value.ToString(); }

    [SerializeField] private Food food;
    public Food Food { get => food; set => food = value; }
    public int FoodQuantity { get => food.Quantity; set => food.Quantity = value; }
    public int FoodPriceForOneItem { get; set; }


}
