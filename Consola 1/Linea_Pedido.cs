using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    class Ordenar_Pedido
    {
        protected DatabaseContext _context;
        public Ordenar_Pedido(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateLinea_Pedido(DtoLinea_Pedido c)
        {
            Animal.Linea_Pedido miLinea = new Animal.Linea_Pedido()
            {
                id_Producto = c.id_Producto,
                id_Pedido=c.id_Pedido,
                Cantidad=c.Cantidad,
                PrecioProductoUnitario=c.PrecioProductoUnitario,
                PrecioTotal =c.PrecioTotal
            };
            //Añade al contexto
            _context.Linea_Pedidos.Add(miLinea);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarLineaPedidoConsola()
        {
            var list = _context.Linea_Pedidos;
            foreach (var ani in list)
            {
                Console.Write(ani.id_LineaPedido + " ");
                Console.Write(ani.Cantidad+ " ");
                Console.Write(ani.id_Pedido + " ");
                Console.Write(ani.PrecioProductoUnitario + " ");
                Console.Write(ani.PrecioTotal + " ");
                Console.WriteLine(ani.id_Producto);
            }
        }
        public void upDateLineaPedido(int id, DtoLinea_Pedido Op)
        {
            var q = _context.Linea_Pedidos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.id_Producto = Op.id_Producto;
                q.id_Pedido = Op.id_Pedido;
                q.Cantidad = Op.Cantidad;
                q.PrecioProductoUnitario = Op.PrecioProductoUnitario;
                q.PrecioTotal = Op.PrecioTotal;
            }
        }
        public bool EliminarLineaPedido(int id)
        {
            var q = _context.Linea_Pedidos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Linea_Pedidos.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
