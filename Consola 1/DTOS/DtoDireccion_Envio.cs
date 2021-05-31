using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1.DTOS
{
    public class DtoDireccion_Envio
    {
        public string Nombre_Direccion { get; set; }
        public string Provincia { get; set; }
        public string Municipal { get; set; }
        public string DNI_Cliente_Rceiv { get; set; }
        public string Nombre_Cliente_Rec { get; set; }
    }
}
