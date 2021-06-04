using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("AtributoProducto")]
    public class AtributoProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdAtributo { get; set; }
        public int IdAtributoValor { get; set; }

    }
}
