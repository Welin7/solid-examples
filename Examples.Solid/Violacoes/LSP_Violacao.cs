namespace SolidExamples.Violacoes;

public class CalculadoraPadrao
{
    public virtual int Somar(int a, int b)
    {
        int resultado = a + b;

        // Pós-condição: resultado deve ser a + b
        return resultado;
    }
}

public class CalculadoraLimitada : CalculadoraPadrao
{
    public override int Somar(int a, int b)
    {
        int resultado = a + b;

        // Pós-condição enfraquecida: se o resultado > 120, retorna 120
        if (resultado > 120)
            resultado = 120;

        return resultado;
    }
}


public static class LSP_Violacao
{
    public static void Executar()
    {
        Console.WriteLine("\n[LSP - Violação - Substituição de Liskov]");

        CalculadoraPadrao calculadoraPadrao = new CalculadoraPadrao();
        calculadoraPadrao.Somar(70, 60); // 130
        Console.WriteLine($"Calculadora Padrão: = {calculadoraPadrao.Somar(70, 60)}");
        Console.WriteLine("");

        CalculadoraPadrao calculadoraLimitada = new CalculadoraLimitada();
        calculadoraLimitada.Somar(70, 60); // 130
        Console.WriteLine($"Calculadora Limitada: = {calculadoraLimitada.Somar(70, 60)}");
        Console.WriteLine("");
        
        Console.WriteLine("Problema: a CalculadoraLimitada não respeita o contrato da CalculadoraPadrao.");
        Console.WriteLine("A subclasse enfraquece o contrato, ela retorna outro valor (limitado a 120).");
        Console.WriteLine("Isso viola o LSP e também o OCP (Principio Aberto/Fechado),"); 
        Console.WriteLine("pois altera comportamento em vez de estender de forma segura.");
        Console.WriteLine("");
    }
}
