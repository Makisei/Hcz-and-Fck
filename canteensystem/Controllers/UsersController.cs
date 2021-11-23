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
    public class UsersController : Controller
    {
        UserService userService;
        StoreService storeService;

        public UsersController(CanteenContext context)
        {
            userService = new UserService(context);
            storeService = new StoreService(context);
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<List<Users>> GetUsers()
        {
            var query = userService.GetUsers();
            return query.ToList();
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public ActionResult<Users> DetailsByUserId(string id)
        {
            var user = userService.FindUserByUserId(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // GET: api/Users/name/{name}
        [HttpGet("name/{name}")]
        public ActionResult<Users> DetailsByUserName(string name)
        {
            var user = userService.FindUserByName(name);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<Users> Create(Users user)
        {
            try
            {
                userService.AddUser(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return user;
        }


        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                userService.DeleteUser(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

        // POST: api/Users/order
        [HttpPost]
        public ActionResult<bool> Order(Food food, string id)
        {
            bool check;
            try
            {
                var user = userService.FindUserByUserId(id);
                if (user == null)
                {
                    return false;
                }
                check = userService.order(food, user.shoppingCar);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return check;
        }

        // GET: api/Users/buy/{id}
        [HttpGet("{id}")]
        public ActionResult<float> Buy(string id)
        {
            float sum;
            var user = userService.FindUserByUserId(id);
            if (user == null)
            {
                return NotFound();
            }
            sum = userService.buy(user.shoppingCar);
            return sum;
        }

        // GET: api/Users/waitingnumbers/{storename}
        [HttpGet("{storename}")]
        public ActionResult<int> Waitingnumbers(string storename)
        {
            int number = 0;
            var store = storeService.FindStoreByStoreName(storename);
            if (store == null)
            {
                return NotFound();
            }
            foreach (Store s in store)
            {
                number = userService.getWaitingNumber(s);
            }
            return number;
        }
    }
}
