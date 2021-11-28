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
    public class StoresController : ControllerBase
    {
        StoreService storeService;

        public StoresController(CanteenContext context)
        {
            storeService = new StoreService(context);
        }

        // GET: api/Stores
        [HttpGet]
        public ActionResult<List<Store>> GetStores()
        {
            var query = storeService.GetStores();
            return query.ToList();
        }

        // GET: api/Stores/name/{name}
        [HttpGet("name/{name}")]
        public ActionResult<List<Store>> DetailsByStoreName(string name)
        {
            var store = storeService.FindStoreByStoreName(name);
            if (store == null)
            {
                return NotFound();
            }
            return store;
        }

        // POST: api/Stores
        [HttpPost]
        public ActionResult<Store> Create(Store store)
        {
            try
            {
                storeService.AddStore(store);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return store;
        }

        // DELETE: api/Stores/storeName={storename}
        [HttpDelete("storeName={storename}")]
        public ActionResult Delete(string storename)
        {
            try
            {
                storeService.DeleteStore(storename);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

        // POST: api/Stores/Menu
        // [HttpPost]
        // public ActionResult ModifyMenu(Food food, List<Food> menu)
        // {
        //     try
        //     {
        //         storeService.modifyMenu(food, menu);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.InnerException.Message);
        //     }
        //     return NoContent();
        // }
    }
}
