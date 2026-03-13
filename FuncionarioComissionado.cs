using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaPOO
{
    public class FuncionarioComissionado : Funcionario
    {
        public decimal PercentualComissao { get; set; }
        public decimal VendasRealizadas { get; set; }

        public FuncionarioComissionado(
            string nome,
            string cpf,
            decimal salarioBase,
            decimal percentualComissao,
            decimal vendasRealizadas
            ) : base(nome, cpf, salarioBase)
        {
            PercentualComissao = percentualComissao;
            VendasRealizadas = vendasRealizadas;
        }

        public override decimal CalcularSalario()
        {
            return SalarioBase + (VendasRealizadas * PercentualComissao);
        }

        // Opcional: sobrescrever ExibirDados
        public override void ExibirDados()
        {
            base.ExibirDados();
            Console.WriteLine($"Tipo: Comissionado | Comissão: {PercentualComissao:P} | Vendas: {VendasRealizadas:C}");
        }
    }
}
