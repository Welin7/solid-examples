namespace SolidExamples.Violacoes;

public class Conta
{
    public decimal Saldo { get; protected set; }

    public virtual void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor deve ser positivo.");

        if (valor > Saldo)
            throw new InvalidOperationException("Saldo insuficiente.");

        Saldo -= valor; // Invariância: Saldo nunca pode ser negativo
    }

    public void Depositar(decimal valor)
    {
        Saldo += valor;
    }
}

public class ContaEspecial : Conta
{
    public override void Sacar(decimal valor)
    {
        // Viola a invariância: agora o saldo pode ficar negativo
        Saldo -= valor;
    }
}

public static class LSP_Violacao
{
    public static void Executar()
    {
        Console.WriteLine("\n[LSP - Violação - Substituição de Liskov]");

        Conta conta = new Conta();
        conta.Depositar(1000);
        conta.Sacar(500);
        Console.WriteLine($"Saldo Conta Comum: {conta.Saldo}");
        Console.WriteLine("");

        Conta contaEspecial = new ContaEspecial();
        contaEspecial.Depositar(-200);
        contaEspecial.Sacar(500); // Aqui o saldo fica negativo, violando a expectativa
        Console.WriteLine($"Saldo Conta Especial: {contaEspecial.Saldo}");
        Console.WriteLine("");

        Console.WriteLine("Nota: Conta Especial altera o comportamento esperado do método Sacar, violando o LSP.");
        Console.WriteLine("Problema: O método Sacar da Conta Especial restringe o comportamento da classe base Conta.");
        Console.WriteLine("Um código que espera trabalhar com Conta vai falhar quando receber uma Conta Especial.");
        Console.WriteLine("Conta Especial permite saldo negativo e permite sacar um valor maior que o saldo.");
        Console.WriteLine("");
    }
}
