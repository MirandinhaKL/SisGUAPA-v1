using Repositorio.Entidades;
using System.Collections.Generic;

namespace Repositorio.Interfaces
{
    public interface IAtendimentoService
    {
        List<Atendimento> GetAtendimentoComTratamento(int entidadeId);

        Medicamento GetMedicamento(Tratamento tratamento, int numeroMedicamento);

        int GetStatusMedicacaoEmUmTratamento(int ordem, Tratamento tratamento);
    }
}
