using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Pedido { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Descripcion_Pedido { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int Cantidad { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int Id_Producto { get; set; }
    }
}
