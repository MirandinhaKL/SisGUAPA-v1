using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 15/11/2020
* Última alteração em: 
*/

namespace Repositorio.Classes
{
    public class TratamentoDAO : RepositorioCrudDao<Tratamento>
    {
        public static bool Salvar(Tratamento tratamento)
              => new TratamentoDAO().SalvarOuAtualizar(tratamento);

        public static string Apagar(Tratamento tratamento)
            => new TratamentoDAO().Excluir(tratamento);

        public static List<Tratamento> GetTodosRegistros(int entidadeId)
            => new TratamentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static Tratamento GetById(int tratamentoId)
            => new TratamentoDAO().GetPorId(tratamentoId);

        public static List<Tratamento> GetValidos(int entidadeId)
        {
           var tratamentos = new TratamentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

            if (tratamentos.Any())
                return tratamentos.Where(k => k.EnumStatusTratamento != 0).ToList();

            return new List<Tratamento>();
        }
    }
}
