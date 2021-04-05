using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmirProject.Models;
using AmirProject.Data;


namespace AmirProject.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {

        }
        public DbSet<Animals> Animals { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animals>().HasData(
                new { AnimalId = 1, Name = "Cat", Age = 12, PictureName = "/Photos/cat.jpg", Desctiption = "", CategoryId = 1, },
                new { AnimalId = 2, Name = "Pycnonotus", Age = 1, PictureName = "/Photos/Pycnonotus.jpg", Desctiption = "The White-spectacled Bulbul also known as the Yellow-vented Bulbul, Pycnonotus xanthopygos, is a small bird, a bit bigger than a sparrow. A stable bird that lives in fruit plantations, gardens, cities etc.", CategoryId = 2, },
                new { AnimalId = 3, Name = "Golden Retriever", Age = 2, PictureName = "/Photos/golden.jpg", Desctiption = "The Golden Retriever is a medium-large gun dog that was bred to retrieve shot waterfowl, such as ducks and upland game birds, during hunting and shooting parties. The name 'retriever' refers to the breed's ability to retrieve shot game undamaged due to their soft mouth.", CategoryId = 3, }
                ) ;
            modelBuilder.Entity<Categories>().HasData(
                new { CategoryId = 1, Name = "Cat"},
                new { CategoryId = 2, Name = "Birds"},
                new { CategoryId = 3, Name = "Dog"}
                );
            modelBuilder.Entity<Comments>().HasData(
                new { CommentsId = 1, AnimalId = 1, Comment = "a"},
                new { CommentsId = 2, AnimalId = 1, Comment = "b" },
                new { CommentsId = 3, AnimalId = 1, Comment = "c" },
                new { CommentsId = 4, AnimalId = 1, Comment = "d" },
                new { CommentsId = 5, AnimalId = 2, Comment = "e" },
                new { CommentsId = 6, AnimalId = 3, Comment = "f" },
                new { CommentsId = 7, AnimalId = 3, Comment = "g" },
                new { CommentsId = 8, AnimalId = 2, Comment = "h" },
                new { CommentsId = 9, AnimalId = 1, Comment = "i" },
                new { CommentsId = 10, AnimalId = 3, Comment = "j" },
                new { CommentsId = 11, AnimalId = 3, Comment = "k" },
                new { CommentsId = 12, AnimalId = 3, Comment = "m" },
                new { CommentsId = 13, AnimalId = 3, Comment = "l" },
                new { CommentsId = 14, AnimalId = 3, Comment = "n" },
                new { CommentsId = 15, AnimalId = 3, Comment = "o" }
                );
        }
    }
}
