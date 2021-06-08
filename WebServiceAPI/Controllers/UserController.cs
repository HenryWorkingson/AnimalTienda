
using Animal;
using Consola_1.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceAPI.Controllers
{
    public class UserController : Controller
    {
        protected DatabaseContext db;
        public UserController(DatabaseContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            //var q = (from u in db.Users select u).ToList();
            var q = db.Productos.Select(u => u).ToList();
            return View(q);
        }
        public IActionResult TarjetaPago()
        {
            var q = db.TarjetaPagos.Select(u => u).ToList();
            return View(q);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DtoProducto product)
        {
            if (ModelState.IsValid)
            {
                //TO DO
                Producto miProducto = new Producto()
                {
                    DescripcionProducto = product.DescripcionProducto,
                    NombreProducto=product.NombreProducto,
                    PrecioBase=product.PrecioBase
                };
                
                db.Productos.Add(miProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult DeleteProducto(int id)
        {
            Producto p=db.Productos.Find(id);
            if(p != null)
            {
                db.Productos.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

    }
}
