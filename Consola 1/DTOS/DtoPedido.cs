using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1.DTOS
{
    public class DtoPedido
    {
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int Id_Producto { get; set; }
    }
}
