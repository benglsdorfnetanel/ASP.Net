using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmirProject.Models;
using AmirProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AmirProject.Controllers
{
    public class CatalogController : Controller
    {
        readonly IPetRepository _IPetRepository;
        public CatalogController(IPetRepository iPetRepository)
        {
            _IPetRepository = iPetRepository;
        }
        public IActionResult Index(int categoryId)
        {
            List<Animals> animalsList;
            ViewBag.test = categoryId;
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
        public IActionResult Animal(int animalid)
        {
            ViewBag.CategoryName = _IPetRepository.GetAllCategoryName();
            Animals animalsList = _IPetRepository.GetSpecificAnimal(animalid);
            return View(animalsList);
        }
        public IActionResult AnimalCategory(int categoryId)
        {
            ViewBag.CategoryName = _IPetRepository.GetAllCategoryName();
            List<Animals> animalsList = _IPetRepository.GetSSpecificAnimalByCategoryId(categoryId);
            return View(animalsList);
        }
        [HttpPost]
        public void Upload_Comment(int animalID, string comment)
        {
            _IPetRepository.Add_Comment(animalID, comment);
            _IPetRepository.Save_Changes();
            Response.Redirect($"../Catalog/Animal?AnimalId={animalID}");
            //RedirectToAction("Edit_Animal", new { animalId = animalID });
        }

    }
}
