using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AmirProject.Data;
using AmirProject.Models;
using AmirProject.Repository;

namespace AmirProject.Controllers
{
    public class HomeController : Controller
    {
        readonly IPetRepository _IPetRepository;
        public HomeController(IPetRepository iPetRepository)
        {
            _IPetRepository = iPetRepository;
        }
        public IActionResult Index()
        {
            List<Animals> animals = _IPetRepository.GetTheMostAnimalWithComments();
            return View(animals);
        }
        public IActionResult Catalog()
        {
            List<Animals> animals = _IPetRepository.GetAllAnimals();
            return View(animals);
        }
        public IActionResult CatalogCategory()
        {
            List<Animals> animals = _IPetRepository.GetAllAnimals();
            return View(animals);
        }
    }
}
