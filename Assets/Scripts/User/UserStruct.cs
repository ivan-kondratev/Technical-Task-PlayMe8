using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.User
{
    [Serializable]
    public struct UserStruct
    {
        public string Name;
        public string AvatarURL;
        public string Level;
        public string FoodData;
        public string FoodQuantity;
        public string FoodPriceForOneItem;
    }
}
