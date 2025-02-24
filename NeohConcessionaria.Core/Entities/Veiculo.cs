using NeohConcessionaria.Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeohConcessionaria.Core.Entities
{
    public class Veiculo:BaseEntity
    {
        public int VeiculoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Length(3, 100, ErrorMessage = "Numero de caracteres inválido: minimo 3, maximo 100")]
        public string Modelo { get; set;}

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1800, 3000, ErrorMessage = "Ano de fabricação Inválido")]
        public int AnoFabricacao { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(0,99999999999999, ErrorMessage = "Ano de fabricação Inválido")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        public EnumTipoVeiculo TipoVeiculo { get; set; }

        public string? Descricao { get; set; }

    }
}
