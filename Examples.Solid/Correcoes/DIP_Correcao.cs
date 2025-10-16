// Interface
public interface INotificacao
{
    void Enviar(string msg);
}

// Implementações
public class EmailService : INotificacao
{
    public void Enviar(string msg) => Console.WriteLine($"Email enviado: {msg}");
}

public class SmsService : INotificacao
{
    public void Enviar(string msg) => Console.WriteLine($"SMS enviado: {msg}");
}

// Classe de alto nível (depende da abstração)
public class Notificador
{
    private readonly INotificacao _notificacao;

    public Notificador(INotificacao notificacao)
    {
        _notificacao = notificacao;
    }

    public void Notificar(string msg)
    {
        _notificacao.Enviar(msg);
    }
}

// Camada de composição (fora da lógica de negócio). 
// Em um sistema real, isso seria substituído por um container de injeção de dependência (como o IServiceProvider).
public static class DIP_Correcao
{
    public static void Executar()
    {
        Console.WriteLine("\n[DIP - Correção - Inversão de Dependência]");
        // Aqui é o Composition Root
        INotificacao servicoEmail = new EmailService();
        var notificador = new Notificador(servicoEmail);
        notificador.Notificar("Mensagem via Email");

        // Trocar implementação sem mexer na classe Notificador
        INotificacao servicoSms = new SmsService();
        notificador = new Notificador(servicoSms);
        notificador.Notificar("Mensagem via SMS");

        Console.WriteLine("");
        Console.WriteLine("A classe Notificador não depende mais de implementações concretas e sim da abstração.");
        Console.WriteLine("Agora é fácil trocar o serviço de notificação sem alterar a classe Notificador.");
        Console.WriteLine("Isso melhora a flexibilidade e a extensibilidade do código.");
        Console.WriteLine("");
    }
}
