using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    public class Pedido
    {
        protected DatabaseContext _context;
        public Pedido(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreatePedido(DtoPedido p)
        {
            Animal.Pedido miPedido = new Animal.Pedido()
            {
                Descripcion_Pedido = p.Descripcion_Pedido,
                Id_Tarjeta=p.Id_Tarjeta,
                Precio_Total=p.Precio_Total,
                Id_Direccion = p.Id_Direccion,
                Id_Cliente = p.Id_Cliente,
            };
            //Añade al contexto
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
    }
}
