using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCubosExamenEnriqueGPB.Models
{
    [Table("COMPRACUBOS")]
    public class CompraCubo
    {
        [Key]
        [Column("id_pedido")]
        public int IdPedido { get; set; } 
        [Column("id_cubo")]
        public int IdCubo { get; set; }
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("nombre")]
        public string Nonbre { get; set; }
        [Column("marca")]
        public string Marca { get; set; }
        [Column("imagen")]
        public string Imagen { get; set; }
        [Column("precio")]
        public int Precio { get; set; }
    }
}
