using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animal
{
    [Table("Animal")]
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Animal { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int edad { get; set; }
        [Column(TypeName = "float")]
        [Required]
        public float peso { get; set; }
        [Column(TypeName ="int")]
        [Required]
        public int tipo_Raza { get; set; }
        public string color { get; set; }
        public string descripcion { get; set; }
        public float precio { get; set; }
    }
}
