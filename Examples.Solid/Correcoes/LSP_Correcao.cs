namespace SolidExamples.Correcoes;

public interface ICalculadoraPadrao
{
    int Somar(int a, int b);
}


public class CalculadoraPadrao : ICalculadoraPadrao
{
    public int Somar(int a, int b)
    {
        return a + b;
    }
}

public class CalculadoraLimitada : ICalculadoraPadrao
{
    private readonly ICalculadoraPadrao _calculadoraPadrao;
    private readonly int _limite;

    public CalculadoraLimitada(ICalculadoraPadrao calculadoraPadrao, int limite)
    {
        _calculadoraPadrao = calculadoraPadrao;
        _limite = limite;
    }

    public int Somar(int a, int b)
    {
        int resultado = _calculadoraPadrao.Somar(a, b);

        // Extensão do comportamento — sem quebrar contrato
        return resultado > _limite ? _limite : resultado;
    }
}


public static class LSP_Correcao
{
    public static void Executar()
    {
        Console.WriteLine("\n[LSP - Correção - Substituição de Liskov]");

        ICalculadoraPadrao calculadoraPadrao = new CalculadoraPadrao();
        Console.WriteLine($"Calculadora Padrão: = {calculadoraPadrao.Somar(70, 60)}");
        Console.WriteLine("");

        ICalculadoraPadrao calculadoraLimitada = new CalculadoraLimitada(calculadoraPadrao, 100);
        Console.WriteLine($"Calculadora Limitada: = {calculadoraLimitada.Somar(70, 60)}");
        Console.WriteLine("");
        Console.WriteLine("O contrato da CalculadoraPadrao permanece inalterado, somar sempre retorna a + b");
        Console.WriteLine("CalculadoraLimitada adiciona comportamento extra sem quebrar o que já existe");
        Console.WriteLine("Isso respeita o LSP (substituição segura), OCP (aberta à extensão, fechada à modificação)");
        Console.WriteLine("e também o SRP (cada classe com sua responsabilidade clara)");
        Console.WriteLine("");
    }
}

