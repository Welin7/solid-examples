namespace SolidExamples.Violacoes
{
    public interface IRelatorio
    {
        void SalvarRelatorioEmPdf();
        void EnviarEmail();
    }

    // Violação: mesma classe salva e envia email
    public class Relatorio : IRelatorio
    {
        public void EnviarEmail()
        {
            Console.WriteLine("Enviando email ao cliente...");
        }

        public void SalvarRelatorioEmPdf()
        {
           Console.WriteLine("Salvando relatório em PDF...");
        }
    }

    public static class SRP_Violacao
    {
        public static void Executar()
        {
            Console.WriteLine("\n[SRP - Violação - Responsabilidade Única]");
            IRelatorio relatorio = new Relatorio();
            relatorio.EnviarEmail();
            relatorio.SalvarRelatorioEmPdf();
            Console.WriteLine("A classe Relatorio tem mais de uma responsabilidade, dois motivos para mudar.");
            Console.WriteLine("Problema: se mudar o formato (ex: DOCX), precisaremos alterar a classe Relatorio.");
        }
    }
}
