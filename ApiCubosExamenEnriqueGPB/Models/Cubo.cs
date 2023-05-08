using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCubosExamenEnriqueGPB.Models
{
    [Table("CUBOS")]
    public class Cubo
    {
        [Key]
        [Column("id_cubo")]
        public int IdCubo { get; set; }
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
