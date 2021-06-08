using System;
using System.Collections.Generic;
using System.Text;
using Animal;
using System.Linq;
namespace Consola_1
{
    public class carrito
    {

        private List<global::Animal.Producto> _articulos;

        public List<global::Animal.Producto> Articulos { get => _articulos; set => _articulos = value; }

        public carrito()
        {

            Articulos = new List<global::Animal.Producto>();

        }


        public bool AddItem(global::Animal.Producto articulo)
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

        public bool RemoveItem(global::Animal.Producto articulo)
        {
            try
            {
                Articulos.Remove(articulo);
                //Articulos.RemoveAll(_ => _.id_Producto == articulo.id_Producto);
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

        public List<global::Animal.Producto> getAllItems()
        {
            foreach (var q in _articulos)
            {
                Console.Write(q.IdProducto + " ");
                Console.Write(q.NombreProducto + " ");
                Console.Write(q.DescripcionProducto + " ");
                Console.WriteLine(q.PrecioBase);
            }
            return _articulos;
        }
        public double PrecioTotal()
        {
            double result = 0;
            foreach(var q in _articulos)
            {
                result= result + q.PrecioBase;
            }
            return result;
        }

    }
}
