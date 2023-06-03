using Dominio.Enums;
using Repositorio.Classes;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        public Dictionary<string, string> GetMensagemDadosInvalidos()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("EMAIL", "Por favor, informe o e-mail utilizado no cadastro do sistema.");
            map.Add("SENHA", "Por favor, informe a senha utilizada no cadastro.");
            return map;
        }

        public int SalvarUsuario(Usuario usuario)
        {
            return (int)new UsuarioDAO().Inserir(usuario);
        }

        public Usuario GetUsuario(string email, string senha)
        {
            return new UsuarioDAO().ValidarLogin(email, senha);
        }

        public IEnumerable<Usuario> GetUsuariosAtivos(int idEntidade)
        {
            var usuarioDAO = new UsuarioDAO();
            var usuarios = UsuarioDAO.GetTodosRegistros(idEntidade).ToList().Where(k => k.Status != (int)EnumPessoa.EnumStatusUsuario.Inativo);
            return usuarios;
        }

        public string UsuarioEhValido(int identificador)
        {
            if (identificador == 0)
                return "O e-mail informado não está cadastrado no sistema.";
            if (identificador == -1)
                return "A senha informada é inválida.";
            return string.Empty;
        }

        public (bool senhaOk, string senha) GetSenha(string email)
        {
            if (string.IsNullOrEmpty(email))
                return (false, "É necessário informar o e-mail cadastrado para o envio da senha.");

            var senha = ObterSenha(email);
            if (string.IsNullOrEmpty(senha))
                return (false, "O e-mail informado não está cadastrado neste sistema.");
            
            return (true, senha);
        }

        private string ObterSenha(string email)
        {
            Usuario usuario = UsuarioDAO.GetPorEmail(email);
            return usuario?.Senha;
        }

        public (string destinatario, string titulo, string mensagem) GetDadosEmailRecuperacaoSenha(string email, string senha)
        {
            string destinaratio_ = email;
            string titulo_ = "SisGUAPA - Recuperação da senha";
            string mensagem_ = "Olá, este é um e-mail automático enviado pelo SisGUAPA (Sistema de Gestão"
                + "Unificado para Associações de Proteção Animal).\r\n" +
                $"Conforme a sua solicitação a senha de acesso do sistema é: {senha}" +
                "\r\n Obrigada pelo seu contato!";

            return (destinatario: destinaratio_, titulo: titulo_, mensagem: mensagem_);
        }

        public string GetMensagemEnvioSenha()
            => "E-mail enviado com sucesso. Verifique a sua conta de e-mail para obter a sua senha.";


    }
}