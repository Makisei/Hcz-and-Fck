using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canteensystem.Models
{
    public class Store
    {
        public string storeId;
        public string storeName;
        public int waitingQueue;
        public List<Food> menu;

        public Store(string name)
        {
            this.storeId = Guid.NewGuid().ToString();
            this.storeName = name;
            this.menu = new List<Food>();
        }
        public Store()
        {

        }
    }
}
