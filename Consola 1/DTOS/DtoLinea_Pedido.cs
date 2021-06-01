using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1.DTOS
{
    public class DtoLinea_Pedido
    {
        public int id_Producto { get; set; }
        public int id_Pedido { get; set; }
        public int Cantidad { get; set; }
        public float PrecioProductoUnitario { get; set; }
        public float PrecioTotal { get; set; }
    }
}
