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
        // Aqui é o Composition Root
        INotificacao servico = new EmailService();
        var notificador = new Notificador(servico);
        notificador.Notificar("Mensagem via Email");

        // Trocar implementação sem mexer na classe Notificador
        servico = new SmsService();
        notificador = new Notificador(servico);
        notificador.Notificar("Mensagem via SMS");
    }
}
