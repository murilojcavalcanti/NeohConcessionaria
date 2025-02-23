using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Core.Entities
{
    public class Concessionaria
    {
        public int ConcessionariaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Length(3, 100, ErrorMessage = "Numero de caracteres inválido: minimo 3, maximo 100")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Length(5, 255, ErrorMessage = "Numero de caracteres inválido: minimo 5, maximo 255")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Length(3, 50, ErrorMessage = "Numero de caracteres inválido: minimo 3, maximo 50")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Length(3, 50, ErrorMessage = "Numero de caracteres inválido: minimo 3, maximo 50")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Length(0,10, ErrorMessage = "Numero de caracteres inválido: CEP tem 10")]
        public string CEP { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Length(0, 15, ErrorMessage = "Numero de caracteres inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Length(0, 100, ErrorMessage = "Numero de caracteres inválido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(0,int.MaxValue, ErrorMessage = "Capacidade Invalida")]
        public int CapacidadeMaximaVeiculos { get; set; }

    }
}
