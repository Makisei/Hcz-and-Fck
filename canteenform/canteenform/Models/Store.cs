using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canteensystem.Models
{
    public class Store
    {
        public string storeId { get; set; }
        public string storeName { get; set; }
        public int waitingQueue { get; set; }
        public List<Food> menu { get; set; }

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
