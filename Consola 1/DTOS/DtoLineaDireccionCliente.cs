using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1.DTOS
{
    class DtoLineaDireccionCliente
    {
        public int Id_Cliente { get; set; }
        public int Id_Direccion { get; set; }
        public bool Ultima_Dir_Env { get; set; }
    }
}
