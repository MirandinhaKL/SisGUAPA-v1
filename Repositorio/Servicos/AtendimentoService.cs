using Dominio.Enums;
using Repositorio.Classes;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Servicos
{
    public class AtendimentoService : IAtendimentoService
    {
        public void SalvarDadosIniciaisDoSistema(Entidade entidade)
        {
            var tiposAtendimentos = GetTiposAtemdimentosMoqDados(entidade);

            foreach (var item in tiposAtendimentos)
                SalvarOuAtulizarTipoAtendimento(item);
        }

        public List<Patologia> GetPatologiasOrdenadasPorNome(int idEntidade)
        {
            List<Patologia> patologias = PatologiaDAO
                                        .GetTodosRegistros(idEntidade)
                                        .OrderBy(pat => pat.Nome)
                                        .ToList();
            return patologias;
        }


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

        #region TipoAtendimento

        public bool SalvarOuAtulizarTipoAtendimento(TipoAtendimento tipoAtendimento)
        {
            TipoAtendimentoDAO tipoDAO = new TipoAtendimentoDAO();
            return tipoDAO.SalvarOuAtualizar(tipoAtendimento);
        }

        public List<TipoAtendimento> GetTiposAtendimentosOrdenadosPorNome(int idEntidade)
        {
            List<TipoAtendimento> tipos = TipoAtendimentoDAO
                                         .GetTodosRegistros(idEntidade)
                                         .OrderBy(a => a.Nome)
                                         .ToList();
            return tipos;
        }

        public string ExcluirTipoAtendimento(TipoAtendimento tipoAtendimento)
        {
            TipoAtendimentoDAO tipoDAO = new TipoAtendimentoDAO();
            return tipoDAO.Excluir(tipoAtendimento);
        }

        #endregion

        #region DadosMoqados

        private List<TipoAtendimento> GetTiposAtemdimentosMoqDados(Entidade entidade)
        {
            return new List<TipoAtendimento>
            {
                new TipoAtendimento(){ Nome = "Aplicação de vacina", Entidade = entidade, 
                    DuracaoPadrao = (int)EnumAtendimento.EnumDuracaoPadrao.minutos15, 
                    EnumPreAtendimento = (int)EnumAtendimento.EnumPreAtendimento.naoNecessario,
                    Frequencia = (int)EnumAtendimento.EnumFrequenciaRecomendada.naoRecorrente },
                new TipoAtendimento(){ Nome = "Consulta de rotina", Entidade = entidade, 
                    DuracaoPadrao = (int)EnumAtendimento.EnumDuracaoPadrao.minutos30, 
                    EnumPreAtendimento = (int)EnumAtendimento.EnumPreAtendimento.naoNecessario,
                    Frequencia = (int)EnumAtendimento.EnumFrequenciaRecomendada.semestral },
                new TipoAtendimento(){ Nome = "Castração", Entidade = entidade,
                    DuracaoPadrao = (int)EnumAtendimento.EnumDuracaoPadrao.hora1, 
                    EnumPreAtendimento = (int)EnumAtendimento.EnumPreAtendimento.comidaAguaNoiteAnterior,
                    Frequencia = (int)EnumAtendimento.EnumFrequenciaRecomendada.naoRecorrente },
                new TipoAtendimento(){ Nome = "Desverminação", Entidade = entidade,
                    DuracaoPadrao = (int)EnumAtendimento.EnumDuracaoPadrao.minutos10,
                    EnumPreAtendimento = (int)EnumAtendimento.EnumPreAtendimento.naoNecessario,
                    Frequencia = (int)EnumAtendimento.EnumFrequenciaRecomendada.trimentral }
            };
        }

        #endregion
    }
}