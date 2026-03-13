namespace OficinaPOO;
using System;

public class FuncionarioHorista : Funcionario, IAutenticavel
{
    public int HorasTrabalhadas { get; set; }
    public decimal ValorPorHora { get; set; }
    public string Login { get; set; }
    private string Senha { get; set; }

    public FuncionarioHorista(
        string nome,
        string cpf,
        decimal salarioBase,
        int horasTrabalhadas,
        decimal valorPorHora,
        string login,
        string senha
        )
        : base(nome, cpf, salarioBase) // Chama o construtor da classe pai
    {
        HorasTrabalhadas = horasTrabalhadas;
        ValorPorHora = valorPorHora;
        Login = login;
        Senha = senha;
    }

    public bool Autenticar(string senha)
    { 
        return Senha == senha;
    }

    // Implementação específica do cálculo para horista
    public override decimal CalcularSalario()
    {
        // Horista ganha por hora trabalhada
        return HorasTrabalhadas * ValorPorHora;
    }

    // Sobrescrita (override) do método para incluir informação extra
    public override void ExibirDados()
    {
        base.ExibirDados(); // Chama o método da classe pai
        Console.WriteLine($"Tipo: Horista | Horas: {HorasTrabalhadas} | Valor/hora: {ValorPorHora:C}");
    }
}