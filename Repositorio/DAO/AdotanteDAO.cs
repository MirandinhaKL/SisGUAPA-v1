using Repositorio.Entidades;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
 * Criado em: 23/09/21
 */
namespace Repositorio.DAO
{
    public class AdotanteDAO : RepositorioCrudDao<Adotante>
    {
        public static string Apagar(Adotante adotante)
        {
            if (adotante.Adocoes == null || adotante.Adocoes.Count == 0)
            {
                return new AdotanteDAO().Excluir(adotante);
            }
            else
            {
                var adocao = adotante.Adocoes.First();
                var query = $" where Animal_id = {adocao.Animal.Id} and Adotante_Id = {adotante.Id};";
                var resultado = new AdocaoDAO().ExcluirComQuery(query, adocao);

                if (string.IsNullOrEmpty(resultado))
                {
                    adocao.Animal.AnimalStatus = 1; // status disponível
                    var animal = adocao.Animal;
                    var status = new AnimalDAO().SalvarOuAtualizar(animal);
                    resultado = status == true ? string.Empty : "Falha ao apagar os dados da adoção.";
                }
                return resultado;
            }
        }

        public static bool Salvar(Adotante adotante)
            => new AdotanteDAO().SalvarOuAtualizar(adotante);

        public static List<Adotante> GetTodosRegistros(int entidadeId)
        {
            var adotantes = new AdotanteDAO().Consultar(entidadeId).ToList();
            var adotantesInstituicao = adotantes?.Where(k => k.Entidade?.Id == entidadeId);
            return adotantesInstituicao.ToList();
        }

        //TODO: VERIFICAR SE COM 3 REGISTROS, SÓ UM TERÁ ADOÇÕES COM DADOS
        public static Adotante GetAdotanteByCPF(Adotante adotante)
        {
            var retorno = new AdotanteDAO().GetDadoComWhere(adotante, "CPF", adotante.CPF);
            var adotantes = ((IEnumerable)retorno).Cast<Adotante>().ToList();
            var adotanteComAdocoes = adotantes.Where(k => k.Adocoes.Any()).FirstOrDefault();
            return adotanteComAdocoes != null ? adotanteComAdocoes : adotantes.FirstOrDefault(); 
        }
    }
}
