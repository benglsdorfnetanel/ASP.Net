using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmirProject.Models
{
    public class Comments
    {
        public int CommentsId { get; set; }
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public virtual Animals Animal { get; set; }
        public string Comment { get; set; }
    }
}
