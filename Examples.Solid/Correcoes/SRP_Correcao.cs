namespace SolidExamples.Correcoes
{
    public interface IRelatorio
    {
        void SalvarRelatorio();
    }

    public interface IEmail
    {
        void EnviarEmail();
    }

    // Correção: Classe Relatorio salva relatório em pdf
    public class RelatorioPDF : IRelatorio
    {
        public void SalvarRelatorio()
        {
            Console.WriteLine("Salvando relatório em PDF...");
        }
    }

    // Correção: Classe Email envia email
    public class Email : IEmail
    {
        public void EnviarEmail()
        {
            Console.WriteLine("Enviando email ao cliente...");
        }
    }

    public static class SRP_Correcao
    {
        public static void Executar()
        {
            Console.WriteLine("\n[SRP - Correção - Responsabilidade Única]");

            IEmail email = new Email();
            email.EnviarEmail();

            IRelatorio relatorio = new RelatorioPDF();
            relatorio.SalvarRelatorio();

            Console.WriteLine("");
            Console.WriteLine("Classe Relatório salva o relatório em pdf e a classe Email envia o email para o cliente.");
            Console.WriteLine("Problema resolvido: Agora cada classe tem sua própria responsabilidade.");
            Console.WriteLine("");
        }
    }
}
