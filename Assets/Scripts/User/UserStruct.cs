using System;
using UnityEngine;

namespace Assets.Scripts.User
{
    [Serializable]
    public struct UserStruct
    {
        public string Name;
        public string AvatarURL;
        public Sprite Avatar;
        public string Level;
        public string FoodData;
        public string FoodQuantity;
        public string FoodPriceForOneItem;
    }
}
