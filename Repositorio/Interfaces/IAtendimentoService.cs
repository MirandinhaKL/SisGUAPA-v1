using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IAtendimentoService
    {
        List<Atendimento> GetAtendimentoComTratamento(int entidadeId);

        Medicamento GetMedicamento(Tratamento tratamento, int numeroMedicamento);

        int GetStatusMedicacaoEmUmTratamento(int ordem, Tratamento tratamento);

    }
}
