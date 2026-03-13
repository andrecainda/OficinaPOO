using OficinaPOO;

// Criando funcionários incluindo o novo Comissionado
var funcionarios = new List<Funcionario>
{
    new FuncionarioHorista("João Silva", "123.456.789-00", 0, 160, 25.50m, "joao", "123"),
    new FuncionarioMensalista("Maria Santos", "987.654.321-00", 3000, true, "maria", "456"),
    new FuncionarioComissionado("Carlos Lima", "111.222.333-44", 2000, 0.10m, 5000m)
};

Console.WriteLine("=== FOLHA DE PAGAMENTO ===\n");
foreach (var func in funcionarios)
{
    func.ExibirDados();
    Console.WriteLine(new string('-', 50));
}

// Testando autenticação (uso de Interface)
Console.WriteLine("\n=== TESTE DE AUTENTICAÇÃO ===\n");
foreach (var func in funcionarios)
{
    // Verifica se o funcionário é autenticável
    if (func is IAutenticavel autenticavel)
    {
        Console.WriteLine($"Testando login: {autenticavel.Login}");
        bool autenticou = autenticavel.Autenticar("123456"); // Testando com a senha "123456"
        Console.WriteLine($"Autenticou? {(autenticou ? "SIM" : "NÃO")}");
    }
    else
    {
        Console.WriteLine($"Funcionário {func.Nome} não pode acessar o sistema.");
    }
}