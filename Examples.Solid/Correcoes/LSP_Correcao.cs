// Abstração mais adequada
public interface IConta
{
    void Sacar(decimal valor);
    void Depositar(decimal valor);
    decimal ObterSaldo();
}

public class ContaCorrente : IConta
{
    private decimal _saldo;

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor deve ser positivo.");

        if (valor > _saldo)
            throw new InvalidOperationException("Saldo insuficiente.");

        _saldo -= valor;
        Console.WriteLine($"[Conta Corrente] Saque de {valor:C} realizado. Saldo: {_saldo:C}");
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor deve ser positivo.");

        _saldo += valor;
    }

    public decimal ObterSaldo() => _saldo;
}

public class ContaPoupancaCorreta : IConta
{
    private decimal _saldo;
    private const decimal LimiteSaque = 1000m;

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor deve ser positivo.");

        if (valor > _saldo)
            throw new InvalidOperationException("Saldo insuficiente.");

        if (valor > LimiteSaque)
            throw new InvalidOperationException("Limite de saque para conta poupança é de R$ 1000.");

        _saldo -= valor;

        Console.WriteLine($"[Conta Poupança] Saque de {valor:C} realizado. Saldo: {_saldo:C}");
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor deve ser positivo.");

        _saldo += valor;
    }

    public decimal ObterSaldo() => _saldo;
}

public static class LSP_Correcao
{
    public static void Executar()
    {
        Console.WriteLine("\n[LSP - Correção - Substituição de Liskov]");

        IConta contaCorrente = new ContaCorrente();
        contaCorrente.Depositar(2000);
        contaCorrente.Sacar(1500);
        Console.WriteLine($"Saldo Conta Corrente: {contaCorrente.ObterSaldo():C}");

        IConta contaPoupanca = new ContaPoupancaCorreta();
        contaPoupanca.Depositar(2000);
        contaPoupanca.Sacar(900);
        Console.WriteLine($"Saldo Conta Poupança: {contaPoupanca.ObterSaldo():C}");

        Console.WriteLine("");
        Console.WriteLine("Ambas as contas funcionam conforme esperado, respeitando suas regras específicas.");
        Console.WriteLine("Herdar de uma classe base só faz sentido quando a subclasse mantém o mesmo comportamento esperado.");
        Console.WriteLine("Se ela muda as regras, o mais correto é criar uma abstração separada (interface ou classe base diferente).");
        Console.WriteLine("");
    }
}