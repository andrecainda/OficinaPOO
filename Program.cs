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


Console.WriteLine("\n=== PRATICANDO LINQ ===\n");

// 1. Filtrar (WHERE) - Funcionários com salário > 3000
var salarioAlto = funcionarios.Where(f => f.CalcularSalario() > 3000);
Console.WriteLine("Funcionários com salário > 3000:");
foreach (var f in salarioAlto)
{
    Console.WriteLine($"  - {f.Nome}: {f.CalcularSalario():C}");
}

// 2. Ordenar (ORDER BY) - Por nome
Console.WriteLine("\nFuncionários em ordem alfabética:");
var ordenados = funcionarios.OrderBy(f => f.Nome);
foreach (var f in ordenados)
{
    Console.WriteLine($"  - {f.Nome}");
}

// 3. Projetar (SELECT) - Criar objetos anônimos
Console.WriteLine("\nApenas nomes e CPFs:");
var dadosBasicos = funcionarios.Select(f => new { f.Nome, f.CPF });
foreach (var item in dadosBasicos)
{
    Console.WriteLine($"  - {item.Nome} ({item.CPF})");
}

// 4. Agregação - Total da folha de pagamento
var totalFolha = funcionarios.Sum(f => f.CalcularSalario());
Console.WriteLine($"\nTotal da folha de pagamento: {totalFolha:C}");

// 5. Verificar se algum atende condição (ANY)
var alguemGanhaMuito = funcionarios.Any(f => f.CalcularSalario() > 5000);
Console.WriteLine($"Alguém ganha mais de 5000? {(alguemGanhaMuito ? "SIM" : "NÃO")}");

// 6. Primeiro que atende condição (FIRSTOrDefault)
var primeiroHorista = funcionarios.OfType<FuncionarioHorista>().FirstOrDefault();
if (primeiroHorista != null)
    Console.WriteLine($"Primeiro horista: {primeiroHorista.Nome}");