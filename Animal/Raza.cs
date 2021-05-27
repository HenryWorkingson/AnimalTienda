using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Raza")]
    public class Raza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Raza { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre_Raza { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public String Descripcion_Raza { get; set; }
    }
}
