namespace SolidExamples.Correcoes;

public class Conta
{
    public decimal Saldo { get; protected set; }

    public virtual void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor deve ser positivo.");

        if (valor > Saldo)
            throw new InvalidOperationException("Saldo insuficiente.");

        Saldo -= valor;
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Depósito deve ser positivo.");

        Saldo += valor;
    }
}

public class ContaEspecial : Conta
{
    public decimal LimiteCredito { get; }

    public ContaEspecial(decimal limiteCredito)
    {
        LimiteCredito = limiteCredito;
    }

    public override void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor deve ser positivo.");

        // Mantém o contrato base: não permite ultrapassar saldo + limite
        if (valor > Saldo + LimiteCredito)
            throw new InvalidOperationException("Saldo insuficiente, mesmo com limite.");

        Saldo -= valor; // pode ficar negativo, mas dentro do limite definido
    }
}

public static class LSP_Correcao
{
    public static void Executar()
    {
        Console.WriteLine("\n[LSP - Correção - Substituição de Liskov]");

        Conta conta = new Conta();
        conta.Depositar(200);
        conta.Sacar(120);
        Console.WriteLine($"Saldo Conta Comum: {conta.Saldo}");
        Console.WriteLine("");

        ContaEspecial contaEspecial = new ContaEspecial(300);
        contaEspecial.Depositar(200);
        contaEspecial.Sacar(120); // Sacando mais que o saldo, mas dentro do limite
        Console.WriteLine($"Saldo Conta Especial após saque: {contaEspecial.Saldo}");
        Console.WriteLine("");

        try
        {
            contaEspecial.Sacar(500); // Tentando sacar além do limite (saldo + limite)
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao sacar da Conta Especial: {ex.Message}");
            Console.WriteLine("");
        }

        Console.WriteLine("Nota: Conta Especial mantém o contrato do método Sacar, respeitando as regras da classe base.");
        Console.WriteLine("Problema resolvido: O sistema entende que Saldo pode ficar negativo, mas apenas até o limite de crédito.");
        Console.WriteLine("Conta Especial exige que o valor a sacar seja positivo, assim com na classe base.");
        Console.WriteLine("Assim, qualquer código que funcione com Conta também funcionará com Conta Especial.");        
        Console.WriteLine("");
    }
}

