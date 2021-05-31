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
        public bool CreateOrdenar_Pedido(DtoOrdenar_Pedido c)
        {
            Animal.ordenar_Pedido miOrden = new Animal.ordenar_Pedido()
            {
                id_Producto = c.id_Producto,
            };
            //Añade al contexto
            _context.Ordenar_Pedidos.Add(miOrden);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarOrdenarPedidoConsola()
        {
            var list = _context.Ordenar_Pedidos;
            foreach (var ani in list)
            {
                Console.Write(ani.id_Ordernar + " ");
                Console.WriteLine(ani.id_Producto);
            }
        }
        public void upDateOrdenarPedido(int id, DtoOrdenar_Pedido Op)
        {
            var q = _context.Ordenar_Pedidos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.id_Producto = Op.id_Producto;
            }
        }
        public bool EliminarOrdenarPedido(int id)
        {
            var q = _context.Ordenar_Pedidos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Ordenar_Pedidos.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
