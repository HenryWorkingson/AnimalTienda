using Animal;
using Consola_1.DTOS;
using System;

namespace Consola_1
{
    public class Animal
    {
        protected DatabaseContext _context;
        public Animal(DatabaseContext context)
        {
            _context = context;
        }
        public bool  CreateAnimal(DtoAnimal animal)
        {
            global::Animal.Animal miAnimal = new global::Animal.Animal()
            {
                Nombre = animal.Nombre,
                peso = animal.Peso,
                color = animal.Color,
                edad = animal.Edad,
                tipo_Raza = animal.TipoRaza,
                descripcion = animal.descripcion,
                precio= animal.precio
            };
            _context.Animals.Add(miAnimal);
            //Guarda en BBDD
            _context.SaveChanges();
            global::Animal.Clase_Producto miProducto = new global::Animal.Clase_Producto()
            {
                Tipo_Producto = "Animal",
                Id_Asignado = miAnimal.id_Animal,
                Descripcion_Producto = animal.descripcion,
                Precio_Producto = animal.precio,
            };
            _context.Clase_Productos.Add(miProducto);
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
                Console.Write(ani.precio + " ");
                Console.Write(ani.descripcion + " ");
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
                Console.Write(q.precio + " ");
                Console.Write(q.descripcion + " ");
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
                q.descripcion = animal.descripcion;
                q.precio = animal.precio;
                listarIdAnimal(id);
            }
            _context.SaveChanges();
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
