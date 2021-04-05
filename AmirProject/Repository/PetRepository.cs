using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmirProject.Models;
using AmirProject.Data;
using Microsoft.EntityFrameworkCore;

namespace AmirProject.Repository
{
    public class PetRepository : IPetRepository
    {
        readonly PetContext _petContext;

        public PetRepository(PetContext petContext)
        {
            _petContext = petContext;
        }
        public void DeletePet(int id)
        {
            var pet = _petContext.Animals.SingleOrDefault(m => m.AnimalId == id);
            _petContext.Remove(pet);
            _petContext.SaveChanges();
        }
        public List<Animals> GetTheMostAnimalWithComments()
        {
            return _petContext.Animals.OrderByDescending(c => c.Comments.Count()).Take(2).ToList();
        }
        #region First Catalog lod
        public List<Animals> GetAllAnimals()
        {
            return _petContext.Animals.ToList();
        }
        public List<Categories> GetAllCategoryName()
        {
            return _petContext.Categories.ToList();
        }
        #endregion
        public List<Animals> GetSSpecificAnimalByCategoryId(int categoryId)
        {
            return _petContext.Animals.Where(c => c.CategoryId == categoryId).ToList();
        }
        public Animals GetSpecificAnimal(int animalId)
        {
            List<Animals> animal = _petContext.Animals.ToList();
            return animal.First(c => c.AnimalId == animalId);
        }
        public void AddAnimal(Animals animal)
        {
            _petContext.Add(animal);
            _petContext.SaveChanges();
        }
        public void EditAnimal(Animals animal)
        {
            List<Animals> animalAll = _petContext.Animals.ToList();
            Animals anim = animalAll.FirstOrDefault(a => a.AnimalId == animal.AnimalId);
            anim.Name = animal.Name;
            anim.Age = animal.Age;
            anim.Desctiption = animal.Desctiption;
            anim.PictureName = animal.PictureName;
            anim.CategoryId = animal.CategoryId;
            _petContext.SaveChanges();
        }
        public void Add_Comment(int animalID, string comment)
        {
            _petContext.Comments.Add(new Comments { AnimalId = animalID, Comment = comment });
            _petContext.SaveChanges();
        }
        public async void Save_Changes_Async()
        {
            await _petContext.SaveChangesAsync();
        }
        public void Save_Changes()
        {
            _petContext.SaveChanges();
        }
    }
}
