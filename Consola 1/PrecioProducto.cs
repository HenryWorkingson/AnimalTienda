using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    class PrecioProducto
    {
        protected DatabaseContext _context;
        public PrecioProducto (DatabaseContext context)
        {
            _context = context;
        }
        public bool CreatePrecioProducto (DtoPrecioProducto PPro)
        {
            global::Animal.PrecioProducto miPPro = new global::Animal.PrecioProducto()
            {
                IdProducto=PPro.IdProducto,
                FechaFin=PPro.FechaFin,
                PVP=PPro.PVP,
            };
            _context.PrecioProductos.Add(miPPro);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarPrecioProductoConsola()
        {
            var list = _context.PrecioProductos;
            foreach (var ani in list)
            {
                Console.Write(ani.Id + " ");
                Console.Write(ani.IdProducto + " ");
                Console.Write(ani.PVP + " ");
                Console.WriteLine(ani.FechaFin);
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdPrecioProducto(int id)
        {
            var q = _context.PrecioProductos.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.Id + " ");
                Console.Write(q.IdProducto + " ");
                Console.Write(q.PVP + " ");
                Console.WriteLine(q.FechaFin);
            }
        }
        public void upDatePrecioProducto(int id, DtoPrecioProducto PPro)
        {
            var q = _context.PrecioProductos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.IdProducto = PPro.IdProducto;
                q.PVP = PPro.PVP;
                q.FechaFin = PPro.FechaFin;
                listarIdPrecioProducto(id);
            }
            _context.SaveChanges();
        }
        public bool EliminarPrecioProducto(int id)
        {
            var q = _context.PrecioProductos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.PrecioProductos.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
