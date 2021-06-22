using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Consola_1
{
    public class Pedido
    {
        List<global::Animal.Linea_Pedido> carro;
        protected DatabaseContext _context;

        public Pedido(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreatePedido(DtoPedido p)
        {
            carro = new List<global::Animal.Linea_Pedido>();
            global::Animal.Pedido miPedido = new global::Animal.Pedido()
            {
                Descripcion_Pedido = p.Descripcion_Pedido,
                Id_Tarjeta= p.Id_Tarjeta,
                Precio_Total= p.Precio_Total,
                Id_Direccion = p.Id_Direccion,
                Id_Cliente = p.Id_Cliente,
            };
            //loadCarro(miPedido.id_Pedido);
           
            _context.Pedidos.Add(miPedido);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarPedidoConsola()
        {
            var list = _context.Pedidos;
            foreach (var ani in list)
            {
                Console.Write(ani.id_Pedido + " ");
                Console.Write(ani.Descripcion_Pedido + " ");
                Console.Write(ani.Id_Cliente + " ");
                Console.Write(ani.Id_Direccion + " ");
                Console.Write(ani.Id_Tarjeta + " ");
                Console.WriteLine(ani.Precio_Total);
            }
        }
        public void listarLineasProducto()
        {
            foreach (var proc in carro)
            {
                Console.Write(proc.id_LineaPedido + " ");
                Console.Write(proc.Cantidad + " ");
                Console.Write(proc.id_Pedido + " ");
                Console.Write(proc.PrecioProductoUnitario + " ");
                Console.Write(proc.PrecioTotal + " ");
                Console.WriteLine(proc.id_Producto);
            }
        }
        public void listarIdPedido(int id)
        {
            var q = _context.Pedidos.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.id_Pedido + " ");
                Console.Write(q.Descripcion_Pedido + " ");
                Console.Write(q.Id_Cliente + " ");
                Console.Write(q.Id_Direccion + " ");
                Console.Write(q.Id_Tarjeta + " ");
                Console.WriteLine(q.Precio_Total);
            }
        }
        public void upDatePedido(int id, DtoPedido p)
        {
            var q = _context.Pedidos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Descripcion_Pedido = p.Descripcion_Pedido;
                q.Id_Cliente = p.Id_Cliente;
                q.Id_Direccion = p.Id_Direccion;
                q.Id_Tarjeta = p.Id_Tarjeta;
                q.Precio_Total = p.Precio_Total;
            }
            _context.SaveChanges();
        }
        public bool EliminarPedido(int id)
        {
            var q = _context.Pedidos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Pedidos.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
        public void addLineaProducto(global::Animal.Linea_Pedido p)
        {
            _context.Linea_Pedidos.Add(p);
            carro.Add(p);
        }
        public void eliminarLineaProducto(global::Animal.Linea_Pedido p)
        {
            foreach(var q in carro)
            {
                if (q.Equals(p))    
                    carro.Remove(p);
                _context.Linea_Pedidos.Remove(p);
            }
        }
        //public void loadCarro(int id)
        //{
        //    ////var q = _context.Linea_Pedidos;
        //    ////var z =_context.Linea_Pedidos.Include(p => p.Lista_Pedidos).Where(p => p.id_Pedido == id).ToList();
        //    ////var z =  _context.Pedidos.Include(p => p.lineas).Where(p=>p.id_Pedido ==id);
        //    //var z = _context.Pedidos.Include(p => p.lineas.Where(lineas => lineas.id_Pedido.Equals(id))).ToList();
        //    //if (z != null)
        //    //{
        //    //    //var z = _context.Pedidos.Include(p => p.lineas).Where(p=> p.lineas.Select(list=> list.id_Pedido).Equals(id)).ToList();
        //    //    //var z=_context.Linea_Pedidos.Include(p => p.id_Pedido).Where(p=>p.id_Pedido == id).ToList();
        //    //    // z.FirstOrDefault().lineas.Count();
        //    //    //var z = _context.Pedidos.Include(p => p.lineas).FirstOrDefault(p => p.id_Pedido == id);  
        //    //    var x = z.FirstOrDefault().lineas;
        //    //    foreach (var p in x)
        //    //    {
        //    //        carro.Add(p);
        //    //    }
        //    //}
        //    var q = _context.Linea_Pedidos;
        //    foreach (var z in q ) {
        //        if (z.id_Pedido == id)
        //        {
        //            carro.Add(z);
        //            Console.WriteLine(z.id_LineaPedido);
        //        }
        //    }
        //    mostrarCarro(id);
        //}
        public List<global::Animal.Linea_Pedido> getCarro()
        {
            return carro;
        }
        public void mostrarCarro(int idPedido)
        {
            var p= _context.Pedidos.Find(idPedido);
            if (p == null || p.lineas == null)
                if(p == null)
                    Console.WriteLine("perdido1");
                else
                    Console.WriteLine("perdido2");
            else
            {
                foreach (var q in p.lineas)
                {
                    Console.Write(q.id_LineaPedido + " ");
                    Console.Write(q.Cantidad + " ");
                    Console.Write(q.id_Pedido + " ");
                    Console.Write(q.PrecioProductoUnitario + " ");
                    Console.Write(q.PrecioTotal + " ");
                    Console.WriteLine(q.id_Producto);
                }
            }
        }
        public global::Animal.Pedido ultimoPedido()
        {
            var list = _context.Pedidos;
            global::Animal.Pedido q=null;
            foreach (var ani in list)
            {
                if (ani != null)
                {
                    Console.Write(ani.id_Pedido + " ");
                    Console.Write(ani.Descripcion_Pedido + " ");
                    Console.Write(ani.Id_Cliente + " ");
                    Console.Write(ani.Id_Direccion + " ");
                    Console.Write(ani.Id_Tarjeta + " ");
                    Console.WriteLine(ani.Precio_Total);
                    q = ani;
                }
            }
            return q;
        }

    }
}
