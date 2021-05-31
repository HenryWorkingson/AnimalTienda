using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    class Producto
    {
        protected DatabaseContext _context;
        public Producto(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateProducto(DtoProducto p)
        {
            Animal.Producto miProducto = new Animal.Producto()
            {
                Tipo_Producto = p.Tipo_Producto,
                Id_Asignado = p.Id_Asignado,
                Descripcion_Producto = p.Descripcion_Producto,
            };
            //Añade al contexto
            _context.Productos.Add(miProducto);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarProductoConsola()
        {
            var list = _context.Productos;
            foreach (var ani in list)
            {
                Console.Write(ani.id_Producto + " ");
                Console.Write(ani.Tipo_Producto + " ");
                Console.Write(ani.Id_Asignado + " ");
                Console.WriteLine(ani.Descripcion_Producto);
            }
        }
        public void upDateProducto(int id, DtoProducto p)
        {
            var q = _context.Productos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Tipo_Producto = p.Tipo_Producto;
                q.Id_Asignado = p.Id_Asignado;
                q.Descripcion_Producto = p.Descripcion_Producto;
            }
        }
        public bool EliminarProducto(int id)
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
    }
}
