using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Carro")]
    public class Carro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idLProducto { get; set; }
        public int idProducto { get; set; }
        public int idCliente { get; set; }
        public string nombreProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioProductoUnitario { get; set; }
        public double PrecioTotal { get; set; }
    }
}
