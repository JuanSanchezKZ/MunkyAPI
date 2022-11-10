using AxelWebApi.Data;
using AxelWebApi.Helpers;
using AxelWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AxelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public RestaurantController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]    
        public async Task<IActionResult> Post([FromForm] Restaurant restaurant)
        {
            var imageUrl = await FileHelper.UploadImage(restaurant.Image);
            restaurant.ImageUrl = imageUrl;
            await _dbContext.Restaurants.AddAsync(restaurant);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }

        [HttpGet]

        public async Task<IActionResult> GetRestaurants()
        {

           var restaurants = await (from restaurant in _dbContext.Restaurants
                select new
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    ImageUrl = restaurant.ImageUrl,
                    Rating = restaurant.Rating
                }).ToListAsync();

            
            return Ok(restaurants);
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> RestaurantsDetails(int restaurantId)
        {
            var restaurantsDetails = await _dbContext.Restaurants.Where(a => a.Id == restaurantId).Include(a => a.Menus).ToListAsync();

                return Ok(restaurantsDetails);
        }
    }
}
