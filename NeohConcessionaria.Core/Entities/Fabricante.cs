using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Core.Entities
{
    public class Fabricante
    {
        public int FabricanteId { get; set; }
        [Required(ErrorMessage ="Campo Obrigatório")]
        [Length(4,100, ErrorMessage = "Numero de caracteres inválido: minimo 4, maximo 100")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage ="Campo Obrigatório")]
        [Length(3,50, ErrorMessage = "Numero de caracteres inválido: minimo 3, maximo 50")]
        public string PaisOrigem { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        [Range(1800,3000,ErrorMessage ="Ano de fundação Inválido")]
        public int AnoFundacao { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        [Range(10,255, ErrorMessage = "Numero de caracteres inválido: minimo 10, maximo 255")]
        [Url(ErrorMessage ="Insira uma url valida")]
        public string Website { get; set; }
    }
}
