using Repositorio.Entidades;
using System.Collections.Generic;

namespace Repositorio.Interfaces
{
    public interface IEntidadeService
    {
        Dictionary<string, string> GetMensagemDadosInvalidos();

        int SalvarEntidade(Entidade entidade);

        string EntidadeJaSalva(string email);

        Dictionary<string, string> GetMensagemDeErro();
    }
}