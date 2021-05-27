using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Comida")]
    public class Comida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Comida { get; set; }
        [Column(TypeName = "varchar(50)")]
        
        public string Nombre_Comida { get; set; }
        [Column(TypeName = "varchar(200)")]
        
        public string Descripcion_Comida { get; set; }
        
    }
}
