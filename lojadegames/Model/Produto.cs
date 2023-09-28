using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lojadegames.Model
{
    public class Produto : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "decimal(5,2)")]
        //[Decimal(5, 2)]

        public decimal Preco { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Foto { get; set; } = string.Empty;

        public virtual Categoria? Categoria { get; set; }
    }
}

