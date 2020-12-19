using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Food : MonoBehaviour
{
    [SerializeField] private TMP_Text foodNameText;
    public string Name { get => foodNameText.text; set => foodNameText.text = value; }

    [SerializeField] private TMP_Text foodPriceText;
    public int Price { get => int.Parse(foodPriceText.text); set => foodPriceText.text = value.ToString(); }

    [SerializeField] private TMP_Text foodQuantityText;
    public int Quantity
    {
        get
        {
            if (foodQuantityText.text[0] == 'x')
                return int.Parse(foodQuantityText.text.Remove(0, 1));
            else
                return int.Parse(foodQuantityText.text);
        }
        set => foodQuantityText.text = "x" + value.ToString();
    }

    [SerializeField] private Image foodImage;
    public Sprite Image { set => foodImage.sprite = value; }
}
