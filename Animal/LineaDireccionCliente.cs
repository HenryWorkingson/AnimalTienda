using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("LineaDireccionCliente")]
    public class LineaDireccionCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_DireccionCliente { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Direccion { get; set; }
        public bool Ultima_Dir_Env { get; set; }
    }
}
