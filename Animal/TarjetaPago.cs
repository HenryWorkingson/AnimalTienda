using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("TarjetaPago")]
    public class TarjetaPago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_TarjetaPago { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Numero_Tarjeta { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public string FechaCadu_Tarjeta { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Nom_Propietario { get; set; }
    }
}
