using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AxelWebApi.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Products { get; set; }
        
        public int Rating { get; set; }

        [NotMapped]

        public IFormFile Image { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Menu> Menus { get; set; }

    }
}
