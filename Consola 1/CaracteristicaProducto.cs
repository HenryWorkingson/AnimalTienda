using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    public class CaracteristicaProducto
    {
        protected DatabaseContext _context;
        public CaracteristicaProducto (DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateCaracteristicaProducto(DtoCaracteristicaProducto CPro)
        {
            global::Animal.CaracteristicaProducto miCPro = new global::Animal.CaracteristicaProducto()
            {
                IdCaracteristica = CPro.IdCaracteristica,
                IdProducto=CPro.IdProducto,
                Valor=CPro.Valor
            };
            //Añade al contexto
            _context.CaracteristicaProductos.Add(miCPro);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarCaracteristicaProductoConsola()
        {
            var list = _context.CaracteristicaProductos;
            foreach (var ani in list)
            {
                Console.Write(ani.Id + " ");
                Console.Write(ani.IdCaracteristica + " ");
                Console.Write(ani.IdProducto + " ");
                Console.WriteLine(ani.Valor);
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdCaracteristicaProductoConsolal(int id)
        {
            var q = _context.CaracteristicaProductos.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.Id + " ");
                Console.Write(q.IdCaracteristica + " ");
                Console.Write(q.IdProducto + " ");
                Console.WriteLine(q.Valor);
            }
        }
        public void upDateCaracteristicaProductoConsola(int id, DtoCaracteristicaProducto CPro)
        {
            var q = _context.CaracteristicaProductos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.IdCaracteristica = CPro.IdCaracteristica;
                q.IdProducto = CPro.IdProducto;
                q.Valor = CPro.Valor;
                listarIdCaracteristicaProductoConsolal(id);
            }
            _context.SaveChanges();
        }
        public bool EliminarCaracteristicaProducto(int id)
        {
            var q = _context.CaracteristicaProductos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.CaracteristicaProductos.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
