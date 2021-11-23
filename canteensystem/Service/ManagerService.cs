using canteensystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canteensystem.Service
{
    public class ManagerService
    {
        public CanteenContext context;

        public ManagerService(CanteenContext context)
        {
            this.context = context;
        }

        public List<Manager> GetManagers()
        {
            var query = context.Managers;
            return query.ToList();
        }

        public void AddManager(Manager manager)
        {
            context.Managers.Add(manager);
            context.SaveChanges();
        }

        public void DeleteManager(string managerid)
        {
            var manager = context.Managers.FirstOrDefault(p => p.ID == managerid);
            if (manager == null) return;
            context.Managers.Remove(manager);
            context.SaveChanges();
        }

        public Manager FindManagerById(string managerid)
        {
            var manager = context.Managers.FirstOrDefault(p => p.ID == managerid);
            return manager;
        }

        public Manager FindManagerByName(string name)
        {
            var manager = context.Managers.FirstOrDefault(p => p.userName == name);
            return manager;
        }
    }
}
