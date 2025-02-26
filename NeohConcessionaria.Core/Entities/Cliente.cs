using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Core.Entities
{
    public class Cliente : BaseEntity
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
        [Phone]
        public string Telefone { get; set; }
        public List<Venda> Vendas { get; set; }

       public static bool ValidarCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return false;

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11) return false;

            if (cpf.Distinct().Count() == 1) return false;

            int[] pesos1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesos2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int primeiroDigito = CalcularDigitoVerificador(cpf, pesos1);
            int segundoDigito = CalcularDigitoVerificador(cpf, pesos2);

            return cpf[9] == (char)('0' + primeiroDigito) && cpf[10] == (char)('0' + segundoDigito);
        }

        private static int CalcularDigitoVerificador(string cpf, int[] pesos)
        {
            int soma = 0;
            for (int i = 0; i < pesos.Length; i++)
            {
                soma += (cpf[i] - '0') * pesos[i];
            }

            int resto = soma % 11;
            return (resto < 2) ? 0 : 11 - resto;
        }
    }
}
