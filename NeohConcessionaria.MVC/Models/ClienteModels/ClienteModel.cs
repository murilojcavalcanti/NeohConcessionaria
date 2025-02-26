using NeohConcessionaria.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace NeohConcessionaria.MVC.Models.ClienteModels
{
    public class ClienteModel
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }
        public static ClienteModel FromEntity(Cliente cliente)
           => new ClienteModel{
           Nome=cliente.Nome,
           CPF=cliente.CPF,
           Telefone = cliente.Telefone
           };
    }
}
