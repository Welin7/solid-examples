namespace SolidExamples.Violacoes
{
    public interface IEmailService
    {
        void EnviarEmail(string msg);
    }

    public class EmailService : IEmailService
    {
        public void EnviarEmail(string msg) 
            => Console.WriteLine($"[EmailService] Enviando email: {msg}");
    }

    // Violação: depende de implementação concreta e não de abstração
    public class Notificador
    {
        private readonly EmailService _emailService; 

        public Notificador()
        {
            _emailService = new EmailService();
        }
        public void Notificar(string msg) => _emailService.EnviarEmail(msg);
    }

    public static class DIP_Violacao
    {
        public static void Executar()
        {
            Console.WriteLine("\n[DIP - Violação - Inversão de Dependência]");
            var notificador = new Notificador();
            notificador.Notificar("Mensagem via Email");

            Console.WriteLine("Importante, O ponto é que a violação não quebra o programa imediatamente, ele roda normalmente.");
            Console.WriteLine("No entanto, quebra a flexibilidade ou extensibilidade.");
            Console.WriteLine("");
            Console.WriteLine("Tentando mudar para SMS...");
            Console.WriteLine("Se você quiser usar SmsService, precisa alterar o código da classe Notificador.");
            Console.WriteLine("Problema: Notificador só funciona com Email, sem chance de mudar para Sms sem editar o código.");
        }
    }
}
