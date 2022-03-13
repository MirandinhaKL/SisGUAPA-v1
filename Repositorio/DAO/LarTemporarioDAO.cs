using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 22/11/2020
* Última alteração em: 
*/

namespace Repositorio.Classes
{
    public class MedicamentoDAO : RepositorioCrudDao<Medicamento>
    {
        public static bool Salvar(Medicamento medicamento)
              => new MedicamentoDAO().SalvarOuAtualizar(medicamento);

        public static string Apagar(Medicamento medicamento)
            => new MedicamentoDAO().Excluir(medicamento);

        public static List<Medicamento> GetTodosRegistros(int entidadeId)
            => new MedicamentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static Medicamento GetById(int medicamentoId)
            => new MedicamentoDAO().GetPorId(medicamentoId);
    }
}
