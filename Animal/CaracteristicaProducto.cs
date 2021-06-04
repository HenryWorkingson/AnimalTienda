using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("CaracteristicaProducto")]
    public class CaracteristicaProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdCaracteristica { get; set; }
        public int Valor { get; set; }
    }
}
