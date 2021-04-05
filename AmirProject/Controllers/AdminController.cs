using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AmirProject.Models;
using AmirProject.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AmirProject.Controllers
{
    public class AdminController : Controller
    {
        readonly IPetRepository _IPetRepository;
        readonly IHostingEnvironment _hostingEnvironment;
        public AdminController(IPetRepository IPetRepository, IHostingEnvironment hostingEnvironment)
        {
            _IPetRepository = IPetRepository;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(int categoryId)
        {
            ViewBag.category = categoryId;
            List<Animals> animalsList;
            ViewBag.CategoryName = _IPetRepository.GetAllCategoryName();
            if (categoryId == 0)
            {
                animalsList = _IPetRepository.GetAllAnimals();
            }
            else
            {
                animalsList = _IPetRepository.GetSSpecificAnimalByCategoryId(categoryId);
            }
            return View(animalsList);
        }
        public IActionResult DeletePet(int petId)
        {
            _IPetRepository.DeletePet(petId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddPet()
        {
            ViewBag.category = _IPetRepository.GetAllCategoryName();
            return View();
        }
        [HttpPost]
        public IActionResult AddPet(Upload model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.PictureName != null)
                {
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PictureName.FileName;
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Photos");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.PictureName.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Animals newAnimal = new Animals
                {
                    Name = model.Name,
                    Age = model.Age,
                    Desctiption = model.Desctiption,
                    PictureName = "/Photos/" + uniqueFileName,
                    CategoryId = model.CategoryId
                };

                _IPetRepository.AddAnimal(newAnimal);
                return RedirectToAction("Index", new { id = newAnimal.AnimalId });
            }
            return View();
        }
        public IActionResult EditPet(int animalid)
        {
            ViewBag.category = _IPetRepository.GetAllCategoryName();
            List<Animals> allanimal = _IPetRepository.GetAllAnimals();
            Animals animal = allanimal.FirstOrDefault(a => a.AnimalId == animalid);
            return View(animal);
        }
        [HttpPost]
        public IActionResult EditPet(Upload animal,int animalid)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (animal.PictureName != null)
                {
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + animal.PictureName.FileName;
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Photos");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    animal.PictureName.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                List<Animals> allanimal = _IPetRepository.GetAllAnimals();
                Animals animals = allanimal.FirstOrDefault(a => a.AnimalId == animalid);
                animals = new Animals
                {
                    AnimalId = animalid,
                    Name = animal.Name,
                    Age = animal.Age,
                    Desctiption = animal.Desctiption,
                    PictureName = "/Photos/" + uniqueFileName,
                    CategoryId = animal.CategoryId
                };

                _IPetRepository.EditAnimal(animals);
                return RedirectToAction("Index", new { id = animals.AnimalId });
            }
            return View();
        }
    }
}
