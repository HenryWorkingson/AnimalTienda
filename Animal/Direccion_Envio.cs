using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Direccion_Envio")]
    public class Direccion_Envio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_DireccionEnvio { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Nombre_Direccion { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Provincia { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Municipal { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string DNI_Cliente_Rceiv { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre_Cliente_Rec { get; set; }
        
        
    }
}
