using AxelWebApi.Data;
using AxelWebApi.Helpers;
using AxelWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace AxelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public MenuController (ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Post([FromForm] Menu menu)
        {
            var imageUrl = await FileHelper.UploadImage(menu.Image);
            menu.ImageUrl = imageUrl;
            await _dbContext.Menus.AddAsync(menu);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }

        [HttpGet]

        public async Task<IActionResult> GetAllSong()
        {
            var menus = await _dbContext.Menus.ToListAsync();
            return Ok(menus);
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> SearchMenus(string query)
        {
            var menus = await (from menu in _dbContext.Menus
                               where menu.Name.StartsWith(query)
                               select new
                               {
                                   Id = menu.Id,
                                   Name = menu.Name,
                                   Description = menu.Description,
                                   ImageUrl = menu.ImageUrl,



                               }).Take(15).ToListAsync();

            return Ok(menus);
        }
    }
}
