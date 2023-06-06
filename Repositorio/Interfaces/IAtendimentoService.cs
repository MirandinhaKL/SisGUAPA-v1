using Repositorio.Entidades;
using System.Collections.Generic;

namespace Repositorio.Interfaces
{
    public interface IAtendimentoService
    {
        void SalvarDadosIniciaisDoSistema(Entidade entidade);

        List<TipoAtendimento> GetTiposAtendimentosOrdenadosPorNome(int idEntidade);

        bool SalvarOuAtulizarTipoAtendimento(TipoAtendimento tipoAtendimento);

        string ExcluirTipoAtendimento(TipoAtendimento tipoAtendimento);

        List<Patologia> GetPatologiasOrdenadasPorNome(int idEntidade);

        bool SalvarOuAtulizarPatologia(Patologia patologia);

        string ExcluirPatologia(Patologia patologia);

        List<Atendimento> GetAtendimentoComTratamento(int entidadeId);

        Medicamento GetMedicamento(Tratamento tratamento, int numeroMedicamento);

        int GetStatusMedicacaoEmUmTratamento(int ordem, Tratamento tratamento);

    }
}
