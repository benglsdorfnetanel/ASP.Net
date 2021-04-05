using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace AmirProject.Models
{
    public class Upload
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Desctiption { get; set; }
        [Required]
        public IFormFile PictureName { get; set; }
        [Required]
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
    }
}
