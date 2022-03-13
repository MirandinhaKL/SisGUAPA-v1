using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
 * Criado em: 24/0/121
 */
namespace Repositorio.DAO
{
    public class EnderecoUsuarioDAO : RepositorioCrudDao<EnderecoUsuario>
    {
        public static int Salvar(EnderecoUsuario endereco)
        {
            return (int) new EnderecoUsuarioDAO().Inserir(endereco);
        }

        public static bool Atualizar(EnderecoUsuario endereco)
        {
            return new EnderecoUsuarioDAO().Alterar(endereco);
        }

        public static string Apagar(EnderecoUsuario endereco)
            => new EnderecoUsuarioDAO().Excluir(endereco);

        public static List<EnderecoUsuario> GetTodosRegistros(int entidadeId)
        {
            return new EnderecoUsuarioDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
        }

        public static EnderecoUsuario GetById(int enderecoId)
        {
            return new EnderecoUsuarioDAO().GetPorId(enderecoId);
        }
    }
}
