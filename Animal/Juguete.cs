using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Juguete")]
    public class Juguete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Juguete { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre_Juguete { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Descripcion_Juguete { get; set; }
    }
}
