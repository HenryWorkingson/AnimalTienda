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
                Cantidad = p.Cantidad,
                Descripcion_Pedido = p.Descripcion,
                Id_Producto = p.Id_Producto,
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
                Console.Write(ani.Id_Producto + " ");
                Console.Write(ani.Descripcion_Pedido + " ");
                Console.WriteLine(ani.Cantidad);
            }
        }
        public void upDatePedido(int id, DtoPedido p)
        {
            var q = _context.Pedidos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Cantidad = p.Cantidad;
                q.Descripcion_Pedido = p.Descripcion;
                q.Id_Producto = p.Id_Producto;
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
