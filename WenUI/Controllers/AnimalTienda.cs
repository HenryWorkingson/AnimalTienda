using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal;
using WenUI.DTO;

namespace WenUI.Controllers
{
    public class AnimalTienda : Controller
    {
        protected DatabaseContext _context;
        public AnimalTienda(DatabaseContext context)
        {
            _context = context;
        }

        //CRUD
        //C -> Create
        //R -> Read
        //RM -> Read Multiple
        //U -> Update
        //D -> Delete

        [HttpPost]
        public IActionResult CreateAnimal(DtoAnimal animal) {
            Animal.Animal miAnimal = new Animal.Animal() { 
                Nombre = animal.Nombre,
                peso = animal.Peso,
                color = animal.Color,
                edad = animal.Edad,
                tipo_Raza = animal.TipoRaza            
            };

            //Añade al contexto
            _context.Animals.Add(miAnimal);

            //Guarda en BBDD
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        public IActionResult Index()
        {
            var q = _context.Animals.Select(u => u).ToList();
            return View(q);
        }

        public IActionResult IndexNombreColor(string nombre, string color)
        {
            //var q = (from u in db.Animals select u).ToList();
            var q = _context.Animals.Where(u => u.Nombre == nombre && u.color == color).ToList();
            return View(q);
        }
        public IActionResult IndexIdAnimal(int idAnimal)
        {
            //var q = (from u in db.Animals select u).ToList();
            var q = _context.Animals.FirstOrDefault(u => u.id_Animal == idAnimal);
            return View(q);
        }
        public IActionResult BorrarAnimal(int idAnimal)
        {
            var q = _context.Animals.FirstOrDefault(u => u.id_Animal == idAnimal);
            _context.Animals.Remove(q);
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ActualizarAnimal(int idAnimal, DtoAnimal animal)
        {
            var q = _context.Animals.FirstOrDefault(u => u.id_Animal == idAnimal);
            q.Nombre = animal.Nombre;
            q.peso = animal.Peso;
            q.color = animal.Color;
            q.edad = animal.Edad;
            q.tipo_Raza = animal.TipoRaza;
            _context.Update(q);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
