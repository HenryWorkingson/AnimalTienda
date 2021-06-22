using Animal;
using Consola_1.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consola_1
{
    class Cliente
    {
        private List<global::Animal.TarjetaPago> misTars;
        private List<global::Animal.Direccion_Envio> misDirs;
        private List<global::Animal.Pedido> misPedidos;

        protected DatabaseContext _context;
        public Cliente(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateCliente(DtoCliente cliente)
        {

            misDirs = new List<global::Animal.Direccion_Envio>();
            misTars = new List<global::Animal.TarjetaPago>();
            misPedidos = new List<global::Animal.Pedido>();

            global::Animal.Cliente miCliente = new global::Animal.Cliente()
            {
                Nombre_Cliente = cliente.Nombre_Cliente,
                Apellido_Cliente= cliente.Apellido_Cliente,
                cuenta_Cliente = cliente.cuenta_Cliente,
                password_Cliente = cliente.password_Cliente,
                correo_Cliente = cliente.correo_Cliente,           
            };
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
                Console.WriteLine(ani.correo_Cliente + " ");
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
            _context.SaveChanges();
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
        public List<global::Animal.TarjetaPago> addTarjetaPago(global::Animal.TarjetaPago tar, int idCliente)
        {
            global::Animal.LineaTarjetaCliente miT = new global::Animal.LineaTarjetaCliente()
            {
                Id_Cliente = idCliente,
                Id_Tarjeta = tar.id_TarjetaPago,
                Ultima_Tarjeta = false
            };
            _context.LineaTarjetaClientes.Add(miT);
            _context.SaveChanges();

            misTars.Add(tar);
            return misTars;
        }
        public List<global::Animal.TarjetaPago> eliminarTarjetaPago(global::Animal.TarjetaPago tar)
        {
            var q=_context.LineaTarjetaClientes.Find(tar.id_TarjetaPago);
            _context.LineaTarjetaClientes.Remove(q);
            _context.SaveChanges();

            misTars.Remove(tar);
            return misTars;
        }
        public List<global::Animal.TarjetaPago> MisTarjetaPago()
        {
            return misTars;
        }
        public List<global::Animal.Direccion_Envio> addDirEnvio(global::Animal.Direccion_Envio dir , int idCliente)
        {
            global::Animal.LineaDireccionCliente miDir = new global::Animal.LineaDireccionCliente()
            {
                Id_Cliente = idCliente,
                Ultima_Dir_Env= false,
                Id_Direccion=dir.id_DireccionEnvio
                
            };
            _context.LineasDireccionClientes.Add(miDir);
            _context.SaveChanges();
            misDirs.Add(dir);
            return misDirs;
        }
        public List<global::Animal.Direccion_Envio> eliminarDirEnvio(global::Animal.Direccion_Envio dir)
        {
            var q = _context.LineasDireccionClientes.Find(dir.id_DireccionEnvio);
            _context.LineasDireccionClientes.Remove(q);
            _context.SaveChanges();

            misDirs.Remove(dir);
            return misDirs;
        }
        public List<global::Animal.Direccion_Envio> MisDirEnvio()
        {
            return misDirs;
        }
        public bool logIn( int idCliente, string password)
        {
            misDirs = new List<global::Animal.Direccion_Envio>();
            misTars = new List<global::Animal.TarjetaPago>();
            misPedidos = new List<global::Animal.Pedido>();

            bool result = true;
            var q = _context.Clientes.Find(idCliente);
            if (!q.password_Cliente.Equals(password)) { return false; }
            var dirs = _context.LineasDireccionClientes;
            var tars = _context.LineaTarjetaClientes;
            var peds = _context.Pedidos;

            foreach (var dir in dirs)
            {
                if (dir.Id_Cliente == idCliente)
                {
                    var d = _context.Direccion_Envios.Find(dir.Id_Direccion);
                    misDirs.Add(d);
                }
            }
            foreach(var tar in tars)
            {            
                if (tar.Id_Cliente == idCliente)
                {
                    var d = _context.TarjetaPagos.Find(tar.Id_Tarjeta);
                    misTars.Add(d);
                }
            }
            foreach(var ped in peds)
            {
                if(ped.Id_Cliente == idCliente)
                {
                    var d = _context.Pedidos.Find(ped.id_Pedido);
                    misPedidos.Add(d);
                }
            }
            return result;
        }
        public bool logOut()
        {
            misDirs = new List<global::Animal.Direccion_Envio>();
            misTars = new List<global::Animal.TarjetaPago>();
            misPedidos = new List<global::Animal.Pedido>();
            return true;
        }
        public List<global::Animal.Pedido> MisPedido()
        {
            return misPedidos;
        }
        public List<global::Animal.Pedido> CrearPedido (global::Animal.Pedido p)
        {
            misPedidos.Add(p);
            return misPedidos;
        }
        public void loadLista(int idCliente)
        {
            var z = _context.Clientes.Include(p => p.lineasDir).Include(p => p.lineasPedido).Include(p => p.lineasTar).FirstOrDefault(p => p.id_Cliente == idCliente);
            var x = z.lineasDir.ToList();
            foreach (var p in x)
            {              
                misDirs.Add(p);
            }
            var k = z.lineasTar.ToList();
            foreach (var p in k)
            {
                misTars.Add(p);
            }
            var f = z.lineasPedido.ToList();
            foreach (var p in f)
            {
                misPedidos.Add(p);
            }
        }
        public global::Animal.Cliente ultimoCliente()
        {
            var list = _context.Clientes;
            global::Animal.Cliente q = null;
            foreach (var ani in list)
            {
                if (ani != null)
                {
                    q = ani;
                }
            }
            return q;
        }
        public bool paga(global::Animal.TarjetaPago t)
        {
            return true;
        }
    }
}
