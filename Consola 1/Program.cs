using Animal;
using Consola_1.DTO;
using System;

namespace Consola_1
{
    class Program
    {
        public static DtoAnimal CrearDtoAnimal(String nombre, string color, int peso, int edad, int tipoRaza)
        {
            DtoAnimal miAnimal = new DtoAnimal()
            {
                Nombre = nombre,
                Color = color,
                Peso = peso,
                Edad = edad,
                TipoRaza = tipoRaza

            };
            return miAnimal;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a la tienda Animal");
            DatabaseContext _context = new DatabaseContext();
            TiendaAnimal miTienda = new TiendaAnimal(_context);

            DtoAnimal miAnimal=CrearDtoAnimal("Perro", "Azul", 100, 20, 1);
            DtoAnimal miAnimal2 = CrearDtoAnimal("Gato", "negro", 10, 4, 2);
            DtoAnimal miAnimal3 = CrearDtoAnimal("Perro", "Marron", 10, 5, 1);

            if (miTienda.CreateAnimal(miAnimal) && miTienda.CreateAnimal(miAnimal2) && miTienda.CreateAnimal(miAnimal3)) {
                Console.WriteLine("Animal Creado");
            };
            //Listar-Todo Animal
            miTienda.listarAnimalConsola();
            //Listar-espefico Animal
            miTienda.listarIdAnimal(1);
            



        }
    }
}
