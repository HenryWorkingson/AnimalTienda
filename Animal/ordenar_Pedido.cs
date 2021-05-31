using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Ordenar_Pedido")]
    public class ordenar_Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Ordernar { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int id_Producto { get; set; }

        // precio, importe total, cantidad y etc...
    }
}
