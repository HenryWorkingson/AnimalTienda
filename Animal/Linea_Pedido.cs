﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal
{
    [Table("Linea_Pedido")]
    public class Linea_Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_LineaPedido { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int id_Producto { get; set; }

        public int id_Pedido { get; set; }
        public int Cantidad { get; set; }
        public float PrecioProductoUnitario { get; set; }
        public float PrecioTotal { get; set; }
        // precio, importe total, cantidad y etc...
    }
}
