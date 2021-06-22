using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    class LineaDireccionCliente
    {
        protected DatabaseContext _context;
        public LineaDireccionCliente (DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateLineaDireccionCliente (DtoLineaDireccionCliente animal)
        {
            global::Animal.LineaDireccionCliente miLDC = new global::Animal.LineaDireccionCliente()
            {
                Id_Cliente= animal.Id_Cliente,
                Id_Direccion = animal.Id_Direccion,
                Ultima_Dir_Env = animal.Ultima_Dir_Env,
            };
            _context.LineasDireccionClientes.Add(miLDC);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarLineaDireccionClienteConsola()
        {
            var list = _context.LineasDireccionClientes;
            foreach (var ani in list)
            {
                Console.Write(ani.id_DireccionCliente + " ");
                Console.Write(ani.Id_Cliente + " ");
                Console.Write(ani.Id_Direccion + " ");
                Console.WriteLine(ani.Ultima_Dir_Env + " ");
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdLineaDireccionCliente(int id)
        {
            var ani = _context.LineasDireccionClientes.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (ani == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(ani.id_DireccionCliente + " ");
                Console.Write(ani.Id_Cliente + " ");
                Console.Write(ani.Id_Direccion + " ");
                Console.WriteLine(ani.Ultima_Dir_Env + " ");
            }
        }
        public void upDateLineaDireccionCliente(int id, DtoLineaDireccionCliente animal)
        {
            var q = _context.LineasDireccionClientes.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Id_Cliente= animal.Id_Cliente;
                q.id_DireccionCliente = animal.Id_Direccion;
                q.Ultima_Dir_Env = animal.Ultima_Dir_Env;
            }
            _context.SaveChanges();
        }
        public bool EliminarLineaDireccionCliente(int id)
        {
            var q = _context.LineasDireccionClientes.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.LineasDireccionClientes.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
