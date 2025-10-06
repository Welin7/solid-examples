namespace SolidExamples.Correcoes
{
    public interface IImpressora
    {
        void Imprimir();
    }
    public interface IScanner
    {
        void Escanear();
    }

    public class ImpressoraPadrao : IImpressora
    {
        public void Imprimir() => Console.WriteLine("Imprimindo...");
    }

    public class ImpressoraMultifuncional : IImpressora, IScanner
    {
        public void Imprimir() => Console.WriteLine("Imprimindo...");
        public void Escanear() => Console.WriteLine("Escaneando...");
    }

    public static class ISP_Correcao
    {
        public static void Executar()
        {
            Console.WriteLine("\n[ISP - Correção - Segregação de Interface]");
            IImpressora impressoraPadrao = new ImpressoraPadrao();
            impressoraPadrao.Imprimir();

            IImpressora impressoraMultinfuncional = new ImpressoraMultifuncional();
            IScanner scanner = new ImpressoraMultifuncional();
            impressoraMultinfuncional.Imprimir();
            scanner.Escanear();

            Console.WriteLine("Agora cada classe só implementa o que faz sentido.");
            Console.WriteLine("Problema resolvido: A ImpressoraPadrao não é forçada a implementar o método Escanear.");
            Console.WriteLine("");
        }
    }
}
