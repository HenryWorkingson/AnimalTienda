using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Cliente { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre_Cliente { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Apellido_Cliente { get; set; }
        public string cuenta_Cliente { get; set; }
        public string password_Cliente { get; set; }
        public string correo_Cliente { get; set; }
        public ICollection<TarjetaPago> lineasTar { get; set; }
        public ICollection<Direccion_Envio> lineasDir { get; set; }
        public ICollection<Pedido> lineasPedido { get; set; }
    }
}
