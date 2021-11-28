using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using canteensystem.Models;
using canteensystem.Service;

namespace canteensystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagersController : ControllerBase
    {
        ManagerService managerService;

        public ManagersController(CanteenContext context)
        {
            managerService = new ManagerService(context);
        }

        // GET: api/Managers
        [HttpGet]
        public ActionResult<List<Manager>> GetManagers()
        {
            var query = managerService.GetManagers();
            return query.ToList();
        }

        // GET: api/Managers/{id}
        [HttpGet("{id}")]
        public ActionResult<Manager> DetailsByManagerId(string id)
        {
            var manager = managerService.FindManagerById(id);
            if (manager == null)
            {
                return NotFound();
            }
            return manager;
        }

        // GET: api/Managers/name/{name}
        [HttpGet("name/{name}")]
        public ActionResult<Manager> DetailsByManagerName(string name)
        {
            var manager = managerService.FindManagerByName(name);
            if (manager == null)
            {
                return NotFound();
            }
            return manager;
        }

        // POST: api/Managers
        [HttpPost]
        public ActionResult<Manager> Create(Manager manager)
        {
            try
            {
                managerService.AddManager(manager);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return manager;
        }


        // DELETE: api/Managers/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                managerService.DeleteManager(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
    }
}
