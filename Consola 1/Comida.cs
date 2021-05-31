using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    public class Comida
    {
        protected DatabaseContext _context;
        public Comida(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateComida(DtoComida c)
        {
            Animal.Comida miComida = new Animal.Comida()
            {
                Nombre_Comida = c.Nombre_Comida,
                Descripcion_Comida = c.Descripcion_Comida,
                precio=c.precio
            };
            //Añade al contexto
            _context.Comidas.Add(miComida);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarComidaConsola()
        {
            var list = _context.Comidas;
            foreach (var ani in list)
            {
                Console.Write(ani.id_Comida + " ");
                Console.Write(ani.Nombre_Comida + " ");
                Console.Write(ani.precio + " ");
                Console.WriteLine(ani.Descripcion_Comida);
            }
        }
        public void upDateComida(int id, DtoComida p)
        {
            var q = _context.Comidas.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Nombre_Comida = p.Nombre_Comida;
                q.Descripcion_Comida = p.Descripcion_Comida;
                q.precio = p.precio;
            }
        }
        public bool EliminarComida(int id)
        {
            var q = _context.Comidas.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Comidas.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
