using System;
using System.Security.Cryptography.X509Certificates;

public abstract class Funcionario
{
	//Propriedades
		public int Id { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public decimal SalarioBase { get; set; }

	   //Construtor
	   protected Funcionario(string nome, string cpf, decimal salarioBase) 
	   {
			Nome = nome;
			CPF = cpf;
			SalarioBase = salarioBase;
	   }

		// Método abstrato - cada filho vai implementar de um jeito
		public abstract decimal CalcularSalario();

		public virtual void ExibirDados()
		{
			Console.WriteLine($"ID: {Id} | Nome: {Nome} | CPF: {CPF} | Salário: {CalcularSalario():C}");
		}
	
}
