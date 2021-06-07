using System;
using System.Collections.Generic;
using System.Text;
using Animal;
using System.Linq;
namespace Consola_1
{
    public class carrito
    {

        private List<global::Animal.Linea_Pedido> _articulos;

        public List<global::Animal.Linea_Pedido> Articulos { get => _articulos; set => _articulos = value; }

        public carrito()
        {

            Articulos = new List<global::Animal.Linea_Pedido>();

        }


        public bool AddItem(global::Animal.Linea_Pedido articulo)
        {
            try
            {
                Articulos.Add(articulo);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool RemoveItem(global::Animal.Linea_Pedido articulo)
        {
            try
            {
                Articulos.RemoveAll(_ => _.id_Producto == articulo.id_Producto);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public bool RemoveAllItems()
        {

            try
            {
                Articulos.Clear();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<global::Animal.Linea_Pedido> getAllItems()
        {
            return _articulos;
        }


    }
}
