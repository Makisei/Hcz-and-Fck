using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canteensystem.Models
{
    public class Manager:Users
    {
        private int storeID;

        public Manager(string name, string password, int storeid):base(name, password)
        {
            this.storeID = storeid;
        }
        public Manager():base()
        {

        }
    }
}
