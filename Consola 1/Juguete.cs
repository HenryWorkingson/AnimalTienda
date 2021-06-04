using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    public class Juguete
    {
        protected DatabaseContext _context;
        public Juguete(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateJuguete(DtoJuguete J)
        {
            global::Animal.Juguete miJuguete = new global::Animal.Juguete()
            {
                Nombre_Juguete = J.Nombre_Juguete,
                Descripcion_Juguete = J.Descripcion_Juguete,
                precio= J.precio
            };
            //Añade al contexto
            _context.Juguete.Add(miJuguete);
            _context.SaveChanges();
            
            global::Animal.Clase_Producto miProducto = new global::Animal.Clase_Producto()
            {
                Tipo_Producto = "Juguete",
                Id_Asignado = miJuguete.id_Juguete,
                Descripcion_Producto = J.Descripcion_Juguete,
                Precio_Producto = J.precio,
            };
            _context.Clase_Productos.Add(miProducto);
            _context.SaveChanges();
            return true;
        }
        public void listarJugueteConsola()
        {
            var list = _context.Juguete;
            foreach (var ani in list)
            {
                Console.Write(ani.id_Juguete + " ");
                Console.Write(ani.Nombre_Juguete + " ");
                Console.Write(ani.precio + " ");
                Console.WriteLine(ani.Descripcion_Juguete);
            }
        }
        public void listarIdJuguete(int id)
        {
            var q = _context.Juguete.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.id_Juguete + " ");
                Console.Write(q.Nombre_Juguete + " ");
                Console.Write(q.precio + " ");
                Console.WriteLine(q.Descripcion_Juguete);
            }
        }
        public void upDateJuguete(int id, DtoJuguete j)
        {
            var q = _context.Juguete.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Nombre_Juguete = j.Nombre_Juguete;
                q.Descripcion_Juguete = j.Descripcion_Juguete;
                q.precio = j.precio;
            }
            _context.SaveChanges();
        }
        public bool EliminarJuguete(int id)
        {
            var q = _context.Juguete.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Juguete.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
