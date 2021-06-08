using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1.DTOS
{
    public class DtoPedido
    {
        public string Descripcion_Pedido { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Tarjeta { get; set; }
        public int Id_Direccion { get; set; }
        public double Precio_Total { get; set; }
    }
}
