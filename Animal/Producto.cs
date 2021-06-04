using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public double PrecioBase { get; set; }
    }
}
