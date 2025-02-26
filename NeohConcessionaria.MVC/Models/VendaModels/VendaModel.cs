using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.MVC.Models.ClienteModels;

namespace NeohConcessionaria.MVC.Models
{
    public class VendaModel
    {
        public int VendaId { get; set; }
        public  string VeiculoModelo { get; set; }
        public  string FabricanteNome { get; set; }
        public  int AnoFabricacao { get; set; }
        
        public  string ConcessionariaNome { get; set; }
        
        public  ClienteModel Cliente { get; set; }
        public DateTime DataVenda { get; set; }

        public decimal PrecoVenda { get; set; }
        
        public string ProtocoloVenda { get; set; }

        public static VendaModel FomEntity(Venda v) => new VendaModel
        {
            VendaId = v.VendaId,
            VeiculoModelo = v.Veiculo.Modelo,
            AnoFabricacao = v.Veiculo.AnoFabricacao,
            FabricanteNome = v.Veiculo.Fabricante.Nome,
            Cliente = ClienteModel.FromEntity(v.Cliente),
            ConcessionariaNome = v.Concessionaria.Nome,
            DataVenda = v.DataVenda,
            PrecoVenda = v.PrecoVenda,
            ProtocoloVenda = v.ProtocoloVenda
        };

    }
}
