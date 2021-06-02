using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    class Cliente
    {
        protected DatabaseContext _context;
        public Cliente(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateCliente(DtoCliente cliente)
        {
            global::Animal.Cliente miCliente = new global::Animal.Cliente()
            {
                Nombre_Cliente = cliente.Nombre_Cliente,
                Apellido_Cliente= cliente.Apellido_Cliente,
                cuenta_Cliente = cliente.cuenta_Cliente,
                password_Cliente = cliente.password_Cliente,
                correo_Cliente = cliente.correo_Cliente,           
            };
            //Añade al contexto
            _context.Clientes.Add(miCliente);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarClienteConsola()
        {
            var list = _context.Clientes;
            foreach (var ani in list)
            {
                Console.Write(ani.id_Cliente + " ");
                Console.Write(ani.Nombre_Cliente + " ");
                Console.Write(ani.Apellido_Cliente + " ");
                Console.Write(ani.cuenta_Cliente + " ");
                Console.Write(ani.password_Cliente + " ");
                Console.Write(ani.correo_Cliente + " ");
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdCliente(int id)
        {
            var q = _context.Clientes.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.id_Cliente + " ");
                Console.Write(q.Nombre_Cliente + " ");
                Console.Write(q.Apellido_Cliente + " ");
                Console.Write(q.cuenta_Cliente + " ");
                Console.Write(q.password_Cliente + " ");
                Console.Write(q.correo_Cliente + " ");
            }
        }
        public void upDateCliente(int id, DtoCliente cliente)
        {
            var q = _context.Clientes.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Nombre_Cliente = cliente.Nombre_Cliente;
                q.Apellido_Cliente = cliente.Apellido_Cliente;
                q.cuenta_Cliente = cliente.cuenta_Cliente;
                q.password_Cliente = cliente.password_Cliente;
                q.correo_Cliente = cliente.correo_Cliente;
            }
        }
        public bool EliminarCliente(int id)
        {
            var q = _context.Clientes.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Clientes.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
