using canteensystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace canteensystem.Service
{
    public class FoodService
    {
        public CanteenContext context;

        public FoodService(CanteenContext context)
        {
            this.context = context;
        }

        public List<Food> GetFood()
        {
            var query = context.Food;
            return query.ToList();
        }

        public void AddFood(Food food)
        {
            context.Food.Add(food);
            context.SaveChanges();
        }

        public void DeleteFood(string foodname)
        {
            var food = context.Food.FirstOrDefault(p => p.foodName == foodname);
            if (food == null) return;
            context.Food.Remove(food);
            context.SaveChanges();
        }

        public List<Food> FindFoodByName(string foodname)
        {
            var query = context.Food.Where(p => p.foodName.Contains(foodname));
            List<Food> list = query.ToList();
            return list;
        }
    }
}
