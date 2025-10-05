namespace SolidExamples.Violacoes
{
    public interface ICalculadora
    {
        decimal Calcular(decimal a, decimal b, string tipoOperacao);
    }

    // Violação: precisa alterar código para cada nova tipo de operação
    public class Calculadora : ICalculadora
    {
        public decimal Calcular(decimal a, decimal b, string tipoOperacao)
        {
            if (tipoOperacao == "soma") return a + b;
            if (tipoOperacao == "subtrair") return a - b;
            
            return 0;
        }
    }

    public static class OCP_Violacao
    {
        public static void Executar()
        {
            Console.WriteLine("\n[OCP - Violação - Aberto/Fechado]");
            var calculadora = new Calculadora();
            Console.WriteLine($"Soma: {calculadora.Calcular(100, 100, "soma")}");
            Console.WriteLine($"Subtração: {calculadora.Calcular(150, 100, "subtrair")}");
            Console.WriteLine("Para incluir novos tipos de operações, precisaremos alterar a classe Calculadora.");
            Console.WriteLine("Problema: não conseguimos multiplicar ou dividir sem mudar a classe Calculadora.");
        }
    }
}
