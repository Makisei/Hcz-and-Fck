using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canteensystem.Models
{
    public class Factory
    {
        public Factory() { }
        public Object getCustomers(string categories, string name, string password, int storeid)
        {
            switch (categories)
            {
                case "User":
                    return new Users(name, password);
                    break;

                case "Manager":
                    return new Manager(name, password, storeid);
                    break;

                default:
                    return null;
            }
        }

        public Object getStore(string categories, string name)
        {
            switch (categories)
            {
                case "Store":
                    return new Store(name);
                    break;

                default:
                    return null;
            }
        }
        public Object getFood(string categories, string name, int price, string describe)
        {
            switch (categories)
            {
                case "Food":
                    return new Food(name, price, describe);
                    break;

                default:
                    return null;
            }
        }
    }
}
