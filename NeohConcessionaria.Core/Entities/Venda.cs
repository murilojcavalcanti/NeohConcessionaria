using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Core.Entities
{
    public class Venda:BaseEntity
    {
        public  int VendaId { get; set; }
        
        public  int VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        
        public  int ConcessionariaId { get; set; }
        public virtual Concessionaria Concessionaria { get; set; }
        
        public  int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
       

        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataVenda { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(0, 99999999999999, ErrorMessage = "Ano de fabricação Inválido")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoVenda { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string ProtocoloVenda { get; set; }

    }
}
