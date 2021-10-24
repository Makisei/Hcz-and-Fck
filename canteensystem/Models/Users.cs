using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canteensystem.Models
{
    public class Users
    {
        public string userName;
        protected string password;
        public string ID;
        public List<Food> shoppingCar;

        public Users(string name, string password)
        {
            this.userName = name;
            this.password = password;
            this.ID = Guid.NewGuid().ToString();
            this.shoppingCar = new List<Food>();
        }

        public Users()
        {

        }
    }
}
