using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;
/*
 * Criado em: 13/09/20
 */
namespace Repositorio.DAO
{
    public class EnderecoRecolhimentoDAO : RepositorioCrudDao<EnderecoRecolhimento>
    {
        public static int Salvar(EnderecoRecolhimento endereco)
        {
            return (int)new EnderecoRecolhimentoDAO().Inserir(endereco);
        }

        public static bool Atualizar(EnderecoRecolhimento endereco)
        {
            return new EnderecoRecolhimentoDAO().Alterar(endereco);
        }

        public static string Apagar(EnderecoRecolhimento endereco)
            => new EnderecoRecolhimentoDAO().Excluir(endereco);

        public static List<EnderecoRecolhimento> GetTodosRegistros(int entidadeId)
        {
            return new EnderecoRecolhimentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
        }

        public static EnderecoRecolhimento GetById(int enderecoId)
        {
            EnderecoRecolhimentoDAO enderecoDAO = new EnderecoRecolhimentoDAO();
            var resultado = enderecoDAO.GetPorId(enderecoId);
            return resultado;
            //return new EnderecoRecolhimentoDAO().GetPorId(enderecoId);
        }
    }
}
