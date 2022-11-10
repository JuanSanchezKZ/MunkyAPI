using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace AxelWebApi.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }


        public string ImageUrl { get; set; }
        public int RestaurantId  { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
