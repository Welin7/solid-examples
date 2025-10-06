namespace SolidExamples.Violacoes
{
    public interface IImpressora
    {
        void Imprimir();
        void Escanear();
    }

    // Violação: impressora padrão não escaneia, mas é obrigada a implementar o método Escanear
    public class ImpressoraPadrao : IImpressora
    {
        public void Imprimir() => Console.WriteLine("Imprimindo...");
        public void Escanear() => Console.WriteLine("Escanear Forçado: não deveria existir em uma impressora simples.");
    }

    public static class ISP_Violacao
    {
        public static void Executar()
        {
            Console.WriteLine("\n[ISP - Violação - Segregação de Interface]");
            IImpressora impressora = new ImpressoraPadrao();
            impressora.Imprimir();
            impressora.Escanear();
            Console.WriteLine("");
            Console.WriteLine("Impressora padrão não escaneia, mas é obrigada a implementar o método Escanear.");
            Console.WriteLine("Problema: Classe ImpressoraPadrao usa métodos que não fazem sentido.");
            Console.WriteLine("");
        }
    }
}
