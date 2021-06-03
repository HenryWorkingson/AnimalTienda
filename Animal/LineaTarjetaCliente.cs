using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("LineaTarjetaCliente")]
    public class LineaTarjetaCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_TarjetaCliente { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Tarjeta{ get; set; }
        public bool Ultima_Tarjeta { get; set; }
    }
}
