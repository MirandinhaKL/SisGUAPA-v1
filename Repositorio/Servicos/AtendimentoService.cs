using Repositorio.Classes;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System.Collections.Generic;

namespace Repositorio.Servicos
{
    public class AtendimentoService : IAtendimentoService
    {
        public List<Atendimento> GetAtendimentoComTratamento(int entidadeId)
            => AtendimentoDAO.GetAtendimentoComTratamento(entidadeId);

        public Medicamento GetMedicamento(Tratamento tratamento, int ordemMedicamento)
        {
            var medicamento = new Medicamento();
            if (ordemMedicamento == 1)
                medicamento = tratamento.Medicamento1;
            else if (ordemMedicamento == 2)
                medicamento = tratamento.Medicamento2;
            else if (ordemMedicamento == 3)
                medicamento = tratamento.Medicamento3;
            else if (ordemMedicamento == 4)
                medicamento = tratamento.Medicamento4;
            else if (ordemMedicamento == 5)
                medicamento = tratamento.Medicamento5;

            return medicamento;
        }

        public int GetStatusMedicacaoEmUmTratamento(int ordem, Tratamento tratamento)
        {
            var statusTratamento = 0;

            if (ordem == 1)
                statusTratamento = tratamento.EnumStatusMedicacao1;
            else if (ordem == 2)
                statusTratamento = tratamento.EnumStatusMedicacao2;
            else if (ordem == 3)
                statusTratamento = tratamento.EnumStatusMedicacao3;
            else if (ordem == 4)
                statusTratamento = tratamento.EnumStatusMedicacao4;
            else if (ordem == 5)
                statusTratamento = tratamento.EnumStatusMedicacao5;

            return statusTratamento;
        }
    }
}