using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Atributo_Valor")]
    public class Atributo_Valor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAtributoValor { get; set; }
        public int IdAtributo { get; set; }
        public string Descripcion { get; set; }
    }
}
