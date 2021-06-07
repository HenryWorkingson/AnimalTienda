using Animal;
using Consola_1.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consola_1
{
    class Producto
    {
        private List<global::Animal.AtributoProducto> AtriProduct;
        private List<global::Animal.CaracteristicaProducto> CaracProduct;

        protected DatabaseContext _context;
        public Producto(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateProducto(DtoProducto produc)
        {
            global::Animal.Producto miProduc = new global::Animal.Producto()
            {
                DescripcionProducto=produc.DescripcionProducto,
                NombreProducto=produc.NombreProducto,
                PrecioBase=produc.PrecioBase
            };
            //Añade al contexto
            _context.Productos.Add(miProduc);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarProductoConsola()
        {
            var list = _context.Productos;
            foreach (var ani in list)
            {
                Console.Write(ani.IdProducto + " ");
                Console.Write(ani.NombreProducto + " ");
                Console.Write(ani.DescripcionProducto + " ");
                Console.WriteLine(ani.PrecioBase);
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdProducto(int id)
        {
            var q = _context.Productos.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.IdProducto + " ");
                Console.Write(q.NombreProducto + " ");
                Console.Write(q.DescripcionProducto + " ");
                Console.WriteLine(q.PrecioBase);
            }
        }
        public void upDateProducto(int id, DtoProducto proct)
        {
            var q = _context.Productos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.NombreProducto = proct.NombreProducto;
                q.DescripcionProducto = proct.DescripcionProducto;
                q.PrecioBase = proct.PrecioBase;
                listarIdProducto(id);
            }
            _context.SaveChanges();
        }
        public bool EliminarAnimal(int id)
        {
            var q = _context.Productos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Productos.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
        public void loadLista(int idProducto)
        {
            var z = _context.Productos.Include(p => p.lineasAtri).Include(p => p.lineasCarac).FirstOrDefault(p => p.IdProducto == idProducto);
            //z.FirstOrDefault().lineasAtri.Count();
            var x = z.lineasAtri.ToList();
            foreach (var p in x)
            {
                AtriProduct.Add(p);
            }
            var k = z.lineasCarac.ToList();
            foreach (var p in k)
            {
                CaracProduct.Add(p);
            }
        }
    }
}
