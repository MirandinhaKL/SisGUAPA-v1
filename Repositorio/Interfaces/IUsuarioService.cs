using Repositorio.Entidades;
using System.Collections.Generic;

namespace Repositorio.Interfaces
{
    public interface IUsuarioService
    {
        int SalvarUsuario(Usuario usuario);

        IEnumerable<Usuario> GetUsuariosAtivos(int idEntidade);

        Dictionary<string, string> GetMensagemDadosInvalidos();

        Usuario GetUsuario(string email, string senha);

        string UsuarioEhValido(int identificador);

        (bool senhaOk, string senha) GetSenha(string email);

        (string destinatario, string titulo, string mensagem) GetDadosEmailRecuperacaoSenha(string email, string senha);

        string GetMensagemEnvioSenha();
    }
}