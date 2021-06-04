using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Atributo")]
    public class Atributo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAtributo { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Atributo_Valor> lineas { get; set; }
    }
}
