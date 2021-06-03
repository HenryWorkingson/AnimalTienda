using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    class LineaTarjetaCliente
    {
        protected DatabaseContext _context;
        public LineaTarjetaCliente(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateLineaTarjetaCliente(DtoLineaTarjetaCliente animal)
        {
            global::Animal.LineaTarjetaCliente miTarCl = new global::Animal.LineaTarjetaCliente()
            {
                Id_Cliente = animal.Id_Cliente,
                Id_Tarjeta = animal.Id_Tarjeta,
                Ultima_Tarjeta = animal.Ultima_Tarjeta,
            };
            //Añade al contexto
            _context.LineaTarjetaClientes.Add(miTarCl);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarLineaTarjetaClienteConsola()
        {
            var list = _context.LineaTarjetaClientes;
            foreach (var ani in list)
            {
                Console.Write(ani.id_TarjetaCliente + " ");
                Console.Write(ani.Id_Cliente + " ");
                Console.Write(ani.id_TarjetaCliente + " ");
                Console.WriteLine(ani.Ultima_Tarjeta + " ");
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdLineaTarjetaCliente(int id)
        {
            var ani = _context.LineaTarjetaClientes.Find(id);
            if (ani == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(ani.id_TarjetaCliente + " ");
                Console.Write(ani.Id_Cliente + " ");
                Console.Write(ani.id_TarjetaCliente + " ");
                Console.WriteLine(ani.Ultima_Tarjeta + " ");
            }
        }
        public void upDateLineaTarjetaCliente(int id, DtoLineaTarjetaCliente animal)
        {
            var q = _context.LineaTarjetaClientes.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Id_Cliente = animal.Id_Cliente;
                q.Id_Tarjeta = animal.Id_Tarjeta;
                q.Ultima_Tarjeta = animal.Ultima_Tarjeta;
            }
            _context.SaveChanges();
        }
        public bool EliminarLineaTarjetaCliente(int id)
        {
            var q = _context.LineaTarjetaClientes.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.LineaTarjetaClientes.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
