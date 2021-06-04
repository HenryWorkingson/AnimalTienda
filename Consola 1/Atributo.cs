using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    public class Atributo
    {
        protected DatabaseContext _context;
        public Atributo(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateAtributo(DtoAtributo atri)
        {
            global::Animal.Atributo miAtributo = new global::Animal.Atributo()
            {
                Descripcion=atri.Descripcion,
            };
            //Añade al contexto
            _context.Atributos.Add(miAtributo);
            //Guarda en BBDD
            _context.SaveChanges();
           
            return true;
        }
        public void listarAtributoConsola()
        {
            var list = _context.Atributos;
            foreach (var ani in list)
            {
                Console.Write(ani.IdAtributo + " ");
                Console.WriteLine(ani.Descripcion + " ");
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdAtributo(int id)
        {
            var q = _context.Atributos.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.IdAtributo + " ");
                Console.WriteLine(q.Descripcion + " ");
            }
        }
        public void upDateAtributo(int id, DtoAtributo atri)
        {
            var q = _context.Atributos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Descripcion= atri.Descripcion;
                listarIdAtributo(id);
            }
            _context.SaveChanges();
        }
        public bool EliminarAtributo(int id)
        {
            var q = _context.Atributos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Atributos.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
