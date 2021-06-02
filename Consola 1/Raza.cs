using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    public class Raza
    {
        protected DatabaseContext _context;
        public Raza(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateRaza(DtoRaza raza)
        {
            global::Animal.Raza miRaza = new global::Animal.Raza()
            {
                Nombre_Raza = raza.Nombre_Raza,
                Descripcion_Raza = raza.Descripcion_Raza,
            };
            //Añade al contexto
            _context.Razas.Add(miRaza);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarRazaConsola()
        {
            var list = _context.Razas;
            foreach (var ani in list)
            {
                Console.Write(ani.id_Raza + " ");
                Console.Write(ani.Nombre_Raza + " ");
                Console.WriteLine(ani.Descripcion_Raza);
            }
        }
        public void listarIdRaza(int id)
        {
            var q = _context.Razas.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.id_Raza + " ");
                Console.Write(q.Nombre_Raza + " ");
                Console.WriteLine(q.Descripcion_Raza);
            }
        }
        public void upDateRazas(int id, DtoRaza raza)
        {
            var q = _context.Razas.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Nombre_Raza = raza.Nombre_Raza;
                q.Descripcion_Raza = raza.Descripcion_Raza;
            }
        }
        public bool EliminarAnimal(int id)
        {
            var q = _context.Razas.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Razas.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
