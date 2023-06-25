using Repositorio.Entidades;
using System.Collections.Generic;

namespace Repositorio.Interfaces
{
    public interface IAtendimentoService
    {
        void SalvarDadosIniciaisDoSistema(Entidade entidade);

        bool SalvarOuAtualizarAtendimento(Atendimento atendimento);

        List<TipoAtendimento> GetTiposAtendimentosOrdenadosPorNome(int idEntidade);

        bool SalvarOuAtulizarTipoAtendimento(TipoAtendimento tipoAtendimento);

        string ExcluirTipoAtendimento(TipoAtendimento tipoAtendimento);

        List<Patologia> GetPatologiasOrdenadasPorNome(int idEntidade);

        bool SalvarOuAtualizarPatologia(Patologia patologia);

        string ExcluirPatologia(Patologia patologia);

        List<Atendimento> GetAtendimentoComTratamento(int entidadeId);

        Medicamento GetMedicamento(Tratamento tratamento, int numeroMedicamento);

        bool SalvarOuAtualizarMedicamento(Medicamento medicamento);

        List<Medicamento> GetMedicamentosOrdenadasPorNome(int idEntidade);

        string ExcluirMedicamento(Medicamento medicamento);

        int GetStatusMedicacaoEmUmTratamento(int ordem, Tratamento tratamento);
    }
}