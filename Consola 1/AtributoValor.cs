using Animal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    class AtributoValor
    {
        protected DatabaseContext _context;
        public AtributoValor (DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateAtributoValor(DtoAtributo_Valor AValor)
        {
            global::Animal.Atributo_Valor miAValor = new global::Animal.Atributo_Valor()
            {
                Descripcion=AValor.Descripcion,
                IdAtributo=AValor.IdAtributo,
            };
            //Añade al contexto
            _context.Atributo_Valors.Add(miAValor);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarAtributoValorConsola()
        {
            var list = _context.Atributo_Valors;
            foreach (var ani in list)
            {
                Console.Write(ani.IdAtributo + " ");
                Console.Write(ani.IdAtributoValor + " ");
                Console.WriteLine(ani.Descripcion);
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdAtributoValor(int id)
        {
            var q = _context.Atributo_Valors.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.IdAtributo + " ");
                Console.Write(q.IdAtributoValor + " ");
                Console.WriteLine(q.Descripcion);
            }
        }
        public void upDateAtributoValor(int id, DtoAtributo_Valor AValor)
        {
            var q = _context.Atributo_Valors.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.IdAtributo = AValor.IdAtributo;
                q.Descripcion = AValor.Descripcion;
                listarIdAtributoValor(id);
            }
            _context.SaveChanges();
        }
        public bool EliminarAtributoValor(int id)
        {
            var q = _context.Atributo_Valors.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Atributo_Valors.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
