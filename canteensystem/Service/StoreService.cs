using canteensystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canteensystem.Service
{
    public class StoreService
    {
        public CanteenContext context;

        public StoreService(CanteenContext context)
        {
            this.context = context;
        }

        public List<Store> GetStores()
        {
            var query = context.Stores;
            return query.ToList();
        }

        public void AddStore(Store store)
        {
            context.Stores.Add(store);
            context.SaveChanges();
        }

        public void DeleteStore(string storename)
        {
            var store = context.Stores.FirstOrDefault(p => p.storeName == storename);
            if (store == null) return;
            context.Stores.Remove(store);
            context.SaveChanges();
        }

        public List<Store> FindStoreByStoreName(string storename)
        {
            var query = context.Stores.Where(p => p.storeName.Contains(storename));
            List<Store> list = query.ToList();
            return list;
        }

        public bool modifyMenu(Food food, List<Food> menu) 
        {
            var substitute = from f in menu where (f.foodName == food.foodName) select f;
            if (substitute == null)
            {
                return false;
            }
            foreach (Food f in substitute)
            {
                menu.Remove(f);
            }
            menu.Add(food);
            return true;
        }
    }
}
