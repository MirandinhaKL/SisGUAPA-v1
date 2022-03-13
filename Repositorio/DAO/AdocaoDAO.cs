using Repositorio.ClassesGerais;
using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;
/*
 * Criado em: 29/09/21
 */
namespace Repositorio.DAO
{
    public class AdocaoDAO : RepositorioCrudDao<Adocao>
    {
        public static int Salvar(Adocao Adocao)
        {
            return (int) new AdocaoDAO().Inserir(Adocao);
        }

        public static string Apagar(Adocao Adocao)
        {
            return new AdocaoDAO().Excluir(Adocao);
        }

        public static bool Adicionar(Adocao Adocao)
        {
            var status = Salvar(Adocao);
            return true;
            //return Adocao.Id != (int)EnumeracoesRep.EnumStatusDaAcao.FALHA;
        }

        public static IEnumerable<Adocao> GetTodosRegistros(int entidadeId)
        {
            var adocoes = new AdocaoDAO().Consultar(entidadeId).ToList();
            var adocoesInstituicao = adocoes?.Where(k => k.Entidade?.Id == entidadeId);

            if (adocoesInstituicao != null && adocoesInstituicao.Any())
            {
                var animais = AnimalDAO.GetTodosRegistros(entidadeId);

                foreach (var item in adocoesInstituicao)
                {
                    if (item?.Animal != null)
                        item.Animal = animais?.FirstOrDefault(k => k.Id == item.Animal.Id);
                }
            }

            return adocoesInstituicao;
        }

        /// <summary>
        /// Obtém todas adoções e os dados dos animais adotados para o mesmo CPF.
        /// </summary>
        /// <param name="entidadeId"></param>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static List<Adocao> GetAdocoesPorAdotante(int entidadeId, string cpf)
        {
            var registros = GetTodosRegistros(entidadeId).ToList();
            var adocoes = registros?.FindAll(k => k.Adotante.CPF == cpf).ToList();
            var animaisAdotados = new List<Animal>();

            if (adocoes.Any())
            {
                foreach (var adocao in adocoes)
                {
                    if (adocao.Animal != null)
                        adocao.Animal = AnimalDAO.GetById(adocao.Animal.Id);
                }
            }

            return adocoes;
        }
    }
}
