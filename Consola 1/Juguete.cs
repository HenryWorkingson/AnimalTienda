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
            Animal.Juguete miJuguete = new Animal.Juguete()
            {
                Nombre_Juguete = J.Nombre_Juguete,
                Descripcion_Juguete = J.Descripcion_Juguete,
            };
            //Añade al contexto
            _context.Juguete.Add(miJuguete);
            //Guarda en BBDD
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
           
                Console.WriteLine(ani.Descripcion_Juguete);
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
            }
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
