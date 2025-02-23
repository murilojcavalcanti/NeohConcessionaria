using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Core.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Length(0, 100, ErrorMessage = "Numero de caracteres inválido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Length(0, 11, ErrorMessage = "Numero de caracteres inválido")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Length(0, 15, ErrorMessage = "Numero de caracteres inválido")]
        public string Telefone { get; set; }
    }
}
