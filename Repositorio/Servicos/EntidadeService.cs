using Repositorio.Classes;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System.Collections.Generic;

namespace Repositorio.Servicos
{
    public class EntidadeService : IEntidadeService
    {
        public Dictionary<string, string> GetMensagemDadosInvalidos()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("NOME", "Informe o nome da Entidade a qual este sistema irá gernciar os dados.");
            map.Add("EMAIL", "Informe o e-mail da entidade que será utilizado para efetuar login neste sistema.");
            map.Add("SENHA", "Informe a senha para utilização deste sistema.");
            map.Add("SENHA_REP", "Repita a senha informada no campo 'Senha'.");
            map.Add("SENHA_REP_DIFERENTE", "A repetição da senha não confere.");
            return map;
        }

        public int SalvarEntidade(Entidade entidade)
        {
            var entidadeDAO = new EntidadeDAO();
            return (int)entidadeDAO.Inserir(entidade);
        }

        public string EntidadeJaSalva(string email)
        {
            bool resultado = new EntidadeDAO().EntidadeExiste(email);
            if (resultado)
                return "O e-mail informado já está sendo utilizado.";
            else
                return string.Empty;
        }

        public Dictionary<string, string> GetMensagemDeErro()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("SALVAR", "Falha ao cadastrar uma nova entidade no sistema.");
            return map;
        }
    }
}
