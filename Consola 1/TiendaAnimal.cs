using Animal;
using Consola_1.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    public class TiendaAnimal
    {
        protected DatabaseContext _context;
        public TiendaAnimal(DatabaseContext context)
        {
            _context = context;
        }
        public bool  CreateAnimal(DtoAnimal animal)
        {
            Animal.Animal miAnimal = new Animal.Animal()
            {
                Nombre = animal.Nombre,
                peso = animal.Peso,
                color = animal.Color,
                edad = animal.Edad,
                tipo_Raza = animal.TipoRaza
            };

            //Añade al contexto
            _context.Animals.Add(miAnimal);

            //Guarda en BBDD
            _context.SaveChanges();

            return true;

        }
        public void listarAnimalConsola()
        {
            var list = _context.Animals;
            foreach (var ani in list)
            {
                Console.Write(ani.id_Animal + " ");
                Console.Write(ani.Nombre + " ");
                Console.Write(ani.edad + " ");
                Console.Write(ani.color + " ");
                Console.Write(ani.tipo_Raza + " ");
                Console.WriteLine(ani.peso);
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdAnimal(int id)
        {
            var q=_context.Animals.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.id_Animal + " ");
                Console.Write(q.Nombre + " ");
                Console.Write(q.edad + " ");
                Console.Write(q.color + " ");
                Console.Write(q.tipo_Raza + " ");
                Console.WriteLine(q.peso);
            }
        }
        public void upDateAnimal(int id, DtoAnimal animal)
        {
            var q = _context.Animals.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Nombre = animal.Nombre;
                q.peso = animal.Peso;
                q.color = animal.Color;
                q.edad = animal.Edad;
                q.tipo_Raza = animal.TipoRaza;
                listarIdAnimal(id);
            }
        }
        public bool EliminarAnimal(int id)
        {
            var q = _context.Animals.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado");return false; }
            else
            {
                _context.Animals.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
