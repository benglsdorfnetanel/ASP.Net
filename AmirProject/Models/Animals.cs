using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace AmirProject.Models
{
    public class Animals
    {
        [Key]
        [Required]
        public int AnimalId { get; set; }
        [Required]
        //[RegularExpression("[A-Za-z]", ErrorMessage = "Plaese enter only words(A-Z)")]
        public string Name { get; set; }
        [Required]
        [Range(1,99)]
        public int Age { get; set; }
        [Required]
        public string PictureName { get; set; }
        [Required]
        [StringLength(300)]
        public string Desctiption { get; set; }
        [Required]
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual IEnumerable<Comments> Comments { get; set; }
    }
}
