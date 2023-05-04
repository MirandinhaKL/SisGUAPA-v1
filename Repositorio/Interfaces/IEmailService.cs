using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IEmailService
    {
        Task<string> EnviarEmailAsync(string destinatario, string titulo, string conteudo);

        bool EmailEhValido(string emailaddress);
    }
}