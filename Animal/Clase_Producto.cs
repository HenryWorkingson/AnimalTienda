using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Clase_Producto")]
    public class Clase_Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Producto { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Tipo_Producto { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Descripcion_Producto { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int Id_Asignado { get; set; }
        public float Precio_Producto { get; set; }
    }
}
