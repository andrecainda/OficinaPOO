using OficinaPOO;
using System;

public class FuncionarioMensalista : Funcionario, IAutenticavel
{

	public bool TemBeneficios {  get; set; }
	private const decimal TAXA_BENEFICIO = 1.1m; // 10% a mais se tiver benefícios
    public string Login { get; set; }
    private string Senha { get; set; }

    public FuncionarioMensalista(
		string nome,
		string cpf,
		decimal salarioBase,
		bool temBeneficios,
        string login,
        string senha)
        : base(nome, cpf, salarioBase)
		
		{
			TemBeneficios = temBeneficios;
            Login = login;
            Senha = senha;
    }

    public bool Autenticar(string senha)
    {
        return Senha == senha; // Simplificado - NÃO faça isso em produção!
    }


    public override decimal CalcularSalario()
    {
       // Mensalista ganha salário base, com acréscimo se tiver benefícios
        return TemBeneficios ? SalarioBase * TAXA_BENEFICIO : SalarioBase;
    }

    public override void ExibirDados()
    {
        base.ExibirDados();
        Console.WriteLine($"Tipo: Mensalista | Benefícios: {(TemBeneficios ? "Sim" : "Não")}");
    }
}