namespace SolidExamples.Correcoes
{
    public interface IOperacao
    {
        decimal Calcular(decimal a, decimal b);
    }

    public class Soma : IOperacao
    {
        public decimal Calcular(decimal a, decimal b) => a + b;
    }

    public class Subtracao : IOperacao
    {
        public decimal Calcular(decimal a, decimal b) => a - b;
    }

    public class Multiplicacao : IOperacao
    {
        public decimal Calcular(decimal a, decimal b) => a * b;
    }

    public class Calculadora
    {
        public decimal RealizarCalculo(IOperacao operacao, decimal a, decimal b) 
            => operacao.Calcular(a, b);
    }

    public static class OCP_Correcao
    {
        public static void Executar()
        {
            Console.WriteLine("\n[OCP - Correção - Princípio do Aberto/Fechado]");
            var calculadora = new Calculadora();
            Console.WriteLine($"Soma: {calculadora.RealizarCalculo(new Soma(), 10, 5)}");
            Console.WriteLine($"Subtração: {calculadora.RealizarCalculo(new Subtracao(), 10, 5)}");
            Console.WriteLine($"Multiplicação: {calculadora.RealizarCalculo(new Multiplicacao(), 10, 5)}");
            Console.WriteLine("");            
            Console.WriteLine("Agora conseguimos estender (nova operação) sem mexer na Calculadora.");
            Console.WriteLine("");
        }
    }
}
