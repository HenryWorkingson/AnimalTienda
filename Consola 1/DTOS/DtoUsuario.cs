using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1.DTOS
{
    public class DtoUsuario
    {
        public string Nombre { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool privilegio { get; set; }
    }
}
