using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canteensystem.Models
{
    public class Food
    {
        public string foodId;
        public string foodName;
        public int foodPrice;
        public string describe;

        public Food(string name, int price, string describe)
        {
            this.foodId = Guid.NewGuid().ToString();
            this.foodName = name;
            this.foodPrice = price;
            this.describe = describe;
        }

        public Food()
        {

        }
    }
}
