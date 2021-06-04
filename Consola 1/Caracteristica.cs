using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    class Caracteristica
    {
        protected DatabaseContext _context;
        public Caracteristica(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateCaracteristica(DtoCaracteristica carac)
        {
            global::Animal.Caracteristica miCarac = new global::Animal.Caracteristica()
            {
                Descripcion = carac.Descripcion
            };
            //Añade al contexto
            _context.Caracteristicas.Add(miCarac);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarCaractConsola()
        {
            var list = _context.Caracteristicas;
            foreach (var ani in list)
            {
                Console.Write(ani.Id + " ");
                Console.WriteLine(ani.Descripcion);
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdCaract(int id)
        {
            var q = _context.Caracteristicas.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.Id + " ");
                Console.WriteLine(q.Descripcion);
            }
        }
        public void upDateCaract(int id, DtoCaracteristica caract)
        {
            var q = _context.Caracteristicas.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Descripcion = caract.Descripcion;
                listarIdCaract(id);
            }
            _context.SaveChanges();
        }
        public bool EliminarCaract(int id)
        {
            var q = _context.Caracteristicas.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Caracteristicas.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
