using canteensystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canteensystem.Service
{
    public class UserService
    {
        public CanteenContext context;

        public UserService(CanteenContext context)
        {
            this.context = context;
        }

        public List<Users> GetUsers()
        {
            var query = context.Users;
            return query.ToList();
        }

        public void AddUser(Users user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteUser(string userid)
        {
            var user = context.Users.FirstOrDefault(p => p.ID == userid);
            if (user == null) return;
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public Users FindUserByUserId(string userid)
        {
            var user = context.Users.FirstOrDefault(p => p.ID == userid);
            return user;
        }

        public Users FindUserByName(string name)
        {
            var user = context.Users.FirstOrDefault(p => p.userName == name);
            return user;
        }

        public bool order(Food food, List<Food> shoppingCar)
        {
            shoppingCar.Add(food);
            return true;
        }
        public float buy(List<Food> shoppingCar)
        {
            float sum = 0;
            if (shoppingCar == null) return -1;
            foreach(Food f in shoppingCar)
            {
                sum += f.foodPrice;
            }
            return sum;
        }
        public int getWaitingNumber(Store store) 
        {
            store.waitingQueue++;
            return store.waitingQueue; 
        }
    }
}
