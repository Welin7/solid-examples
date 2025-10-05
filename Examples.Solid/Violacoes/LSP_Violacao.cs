namespace SolidExamples.Violacoes
{
    // Classe base
    public class Conta
    {
        protected decimal Saldo { get; set; }

        public virtual void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor deve ser positivo.");

            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente.");

            Saldo -= valor;
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor deve ser positivo.");

            Saldo += valor;
        }

        public decimal ObterSaldo() => Saldo;
    }

    // Subclasse que viola o LSP
    // Ela muda o comportamento esperado do método Sacar
    public class ContaPoupanca : Conta
    {
        public override void Sacar(decimal valor)
        {
            // Violação do LSP:
            // Agora o método lança exceção diferente e tem lógica inesperada
            // Quem usa Conta espera que Sacar retire o valor, mas aqui não funciona igual
            if (valor > 1000)
                throw new InvalidOperationException("Não é permitido sacar mais de 1000 de uma vez.");

            base.Sacar(valor);
        }
    }

    public static class LSP_Violacao
    {
        public static void Executar()
        {
            Console.WriteLine("\n[LSP - Violação - Substituição de Liskov]");

            Conta conta = new Conta();
            conta.Depositar(2000);
            conta.Sacar(1500);
            Console.WriteLine($"Saldo Conta Comum: {conta.ObterSaldo()}");

            Conta contaPoupanca = new ContaPoupanca();
            contaPoupanca.Depositar(2000);

            // Mesmo tipo base, mas comportamento diferente — viola LSP
            try
            {
                // Mesmo tipo base, mas comportamento diferente — viola LSP
                contaPoupanca.Sacar(1500);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao sacar na poupança: {ex.Message}");
            }

            Console.WriteLine($"Saldo Conta Poupança: {contaPoupanca.ObterSaldo():C}");
        }
    }
}
