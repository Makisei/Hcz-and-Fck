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
    public class FoodsController : Controller
    {
        FoodService foodService;
        public FoodsController(CanteenContext context)
        {
            foodService = new FoodService(context);
        }

        // GET: api/Food
        [HttpGet]
        public ActionResult<List<Food>> GetFoods()
        {
            var query = foodService.GetFood();
            return query.ToList();
        }

        // GET: api/Food/name/{name}
        [HttpGet("name/{name}")]
        public ActionResult<List<Food>> DetailsByFoodName(string name)
        {
            var food = foodService.FindFoodByName(name);
            if (food == null)
            {
                return NotFound();
            }
            return food;
        }

        // POST: api/Food
        [HttpPost]
        public ActionResult<Food> Create(Food food)
        {
            try
            {
                foodService.AddFood(food);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return food;
        }

        // DELETE: api/Food/foodName={foodname}
        [HttpDelete("foodName={foodname}")]
        public ActionResult Delete(string foodname)
        {
            try
            {
                foodService.DeleteFood(foodname);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
    }
}
