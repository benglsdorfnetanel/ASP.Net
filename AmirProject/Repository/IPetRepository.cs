using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmirProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AmirProject.Repository
{
    public interface IPetRepository
    {
        void DeletePet(int id);
        List<Animals> GetTheMostAnimalWithComments();
        List<Animals> GetAllAnimals();
        List<Categories> GetAllCategoryName();
        List<Animals> GetSSpecificAnimalByCategoryId(int categoryId);
        Animals GetSpecificAnimal(int animalId);
        void AddAnimal(Animals animal);
        void EditAnimal(Animals animal);
        void Add_Comment(int animalID, string comment);
        void Save_Changes_Async();
        void Save_Changes();
    }
}
