using Dominio.Enums;
using Repositorio.Classes;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Servicos
{
    public class AtendimentoService : IAtendimentoService
    {
        private IAnimalService _animalService;
        private IUsuarioService _usuarioService;

        public AtendimentoService(IAnimalService animalService, IUsuarioService usuarioService)
        {
            _animalService = animalService;
            _usuarioService = usuarioService;
        }

        public void SalvarDadosIniciaisDoSistema(Entidade entidade)
        {
            var tiposAtendimentos = GetTiposAtemdimentosMoqDados(entidade);
            var patologias = GetPatologiasMoqDados(entidade);
            var medicamentos = GetMoqMedicamentos(entidade);

            foreach (var item in tiposAtendimentos)
                SalvarOuAtulizarTipoAtendimento(item);

            foreach (var item in patologias)
                SalvarOuAtualizarPatologia(item);

            foreach (var item in medicamentos)
                SalvarOuAtualizarMedicamento(item);

            var atendimentos = GetMoqAtendimentos(entidade);

            foreach (var item in atendimentos)
                SalvarOuAtualizarAtendimento(item);
        }

        public bool SalvarOuAtualizarAtendimento(Atendimento atendimento)
        {
            AtendimentoDAO atendimentoDAO = new AtendimentoDAO();
            return atendimentoDAO.SalvarOuAtualizar(atendimento);
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

        #region Patologia

        public List<Patologia> GetPatologiasOrdenadasPorNome(int idEntidade)
        {
            List<Patologia> patologias = PatologiaDAO
                                        .GetTodosRegistros(idEntidade)
                                        .OrderBy(pat => pat.Nome)
                                        .ToList();
            return patologias;
        }

        public bool SalvarOuAtualizarPatologia(Patologia patologia)
        {
            PatologiaDAO patologiaDAO = new PatologiaDAO();
            return patologiaDAO.SalvarOuAtualizar(patologia);
        }

        public string ExcluirPatologia(Patologia patologia)
        {
            PatologiaDAO patologiaDAO = new PatologiaDAO();
            return patologiaDAO.Excluir(patologia);
        }

        #endregion

        public bool SalvarOuAtualizarMedicamento(Medicamento medicamento)
        {
            MedicamentoDAO medicamentoDAO = new MedicamentoDAO();
            return medicamentoDAO.SalvarOuAtualizar(medicamento);
        }

        public List<Medicamento> GetMedicamentosOrdenadasPorNome(int idEntidade)
        {
            return MedicamentoDAO.GetTodosRegistros(idEntidade)
                                 .OrderBy(pat => pat.Nome)
                                 .ToList();
        }

        public string ExcluirMedicamento(Medicamento medicamento)
        {
            MedicamentoDAO medicamentoDAO = new MedicamentoDAO();
            return medicamentoDAO.Excluir(medicamento);
        }

        #region Medicamento

        #endregion

        #region DadosMoqados

        private List<TipoAtendimento> GetTiposAtemdimentosMoqDados(Entidade entidade)
        {
            return new List<TipoAtendimento>
            {
                new TipoAtendimento(){ Nome = "Aplicação de vacina", Entidade = entidade, 
                    DuracaoPadrao = (int)EnumAtendimento.EnumDuracaoPadrao.minutos15, 
                    EnumPreAtendimento = (int)EnumAtendimento.EnumPreAtendimento.NaoNecessario,
                    Frequencia = (int)EnumAtendimento.EnumFrequenciaRecomendada.naoRecorrente },
                new TipoAtendimento(){ Nome = "Consulta de rotina", Entidade = entidade, 
                    DuracaoPadrao = (int)EnumAtendimento.EnumDuracaoPadrao.minutos30, 
                    EnumPreAtendimento = (int)EnumAtendimento.EnumPreAtendimento.NaoNecessario,
                    Frequencia = (int)EnumAtendimento.EnumFrequenciaRecomendada.semestral },
                new TipoAtendimento(){ Nome = "Castração", Entidade = entidade,
                    DuracaoPadrao = (int)EnumAtendimento.EnumDuracaoPadrao.hora1, 
                    EnumPreAtendimento = (int)EnumAtendimento.EnumPreAtendimento.ComidaAguaNoiteAnterior,
                    Frequencia = (int)EnumAtendimento.EnumFrequenciaRecomendada.naoRecorrente },
                new TipoAtendimento(){ Nome = "Desverminação", Entidade = entidade,
                    DuracaoPadrao = (int)EnumAtendimento.EnumDuracaoPadrao.minutos10,
                    EnumPreAtendimento = (int)EnumAtendimento.EnumPreAtendimento.NaoNecessario,
                    Frequencia = (int)EnumAtendimento.EnumFrequenciaRecomendada.trimentral }
            };
        }

        private List<Patologia> GetPatologiasMoqDados(Entidade entidade)
        {
            return new List<Patologia>
            {
                new Patologia(){ Entidade = entidade, Nome = "Sarna", Descricao = "A sarna é uma infecção parasitária contagiosa da pele " +
                "que ocorre entre seres humanos e outros animais. É causada pelo ácaro Sarcoptes scabiei, que se refugia sob a pele do " +
                "hospedeiro, causando coceira alérgica intensa e borbulhas – como erupção cutânea." },
                new Patologia(){Entidade = entidade, Nome = "FeLV", Descricao = "A Leucemia felina é uma doença causada pelo vírus FeLV" +
                " que compromete as defesas imunológicas dos gatos domésticos e felídeos selvagens. Com o vírus, o felino fica vulnerável " +
                "a doenças infecciosas, lesões na pele, desnutrição, cicatrização mais lenta de feridas e problemas reprodutivos."},
                new Patologia(){Entidade = entidade, Nome = "Cinomose", Descricao = "É uma doença causada pelo vírus conhecido como CDV, ou" +
                " Canine Distemper Virus, traduzido para o português como “vírus da esgana canina”. A doença é conhecida por afetar " +
                "principalmente filhotes ou canídeos que possuem o sistema imunológico debilitado."}
            };
        }

        private List<Atendimento> GetMoqAtendimentos(Entidade entidade)
        {
            var animais = _animalService.GetAnimaisParaAdocao(entidade.Id);
            var usuarios = _usuarioService.GetUsuariosAtivos(entidade.Id).ToList();

            var tiposAtendimento = GetTiposAtendimentosOrdenadosPorNome(entidade.Id);
            var tipoCastracao = tiposAtendimento.Find(tip => tip.Nome == "Castração");
            var tipoDeseverminacao = tiposAtendimento.Find(tip => tip.Nome == "Desverminação");
           
            #region animal1

            var dataInicial1 = DateTime.Today;
            var dataFinal1 = dataInicial1.AddMinutes(tipoCastracao.DuracaoPadrao);

            var preAtendimento1 = new PreAtendimento()
            {
                DataPreAtendimento = dataInicial1.AddDays(-1),
                EnumStatusPreAtendimento = (int)EnumAtendimento.EnumStatusPreAtendimento.Realizado,
                TipoAtendimento = tipoCastracao,
                Entidade = entidade
            };

            var atendimento1 = new Atendimento()
            {
                Animal = animais[0],
                Observacao = "observação 1",
                DataAtendimentoInicio = dataInicial1,
                DataAtendimentoFim = dataFinal1,
                TipoAtendimento = tipoCastracao,
                ColaboradorExterno = null,
                ColaboradorInterno = usuarios[0],
                Entidade = entidade,
                Patologia = null,
                StatusRealizacaoAtendimento = (int)EnumAtendimento.StatusRealizacaoAtendimento.Realizado,
            };

            preAtendimento1.Atendimento = atendimento1;
            atendimento1.PreAtendimento = preAtendimento1;

            #endregion

            #region animal2

            var dataInicial2 = DateTime.Today.AddMinutes(30);
            var dataFinal2 = dataInicial2.AddMinutes(tipoDeseverminacao.DuracaoPadrao);

            var preAtendimento2 = new PreAtendimento()
            {
                DataPreAtendimento = dataInicial2.AddDays(-1),
                EnumStatusPreAtendimento = (int)EnumAtendimento.EnumStatusPreAtendimento.NaoRealizado,
                TipoAtendimento = tipoDeseverminacao,
                Entidade = entidade
            };

            var atendimento2 = new Atendimento()
            {
                Animal = animais[1],
                Observacao = "observação 2",
                DataAtendimentoInicio = dataInicial2,
                DataAtendimentoFim = dataFinal2,
                TipoAtendimento = tipoDeseverminacao,
                ColaboradorExterno = null,
                ColaboradorInterno = usuarios[0],
                Entidade = entidade,
                Patologia = null,
                StatusRealizacaoAtendimento = (int)EnumAtendimento.StatusRealizacaoAtendimento.Realizado,
            };

            preAtendimento2.Atendimento = atendimento2;
            atendimento2.PreAtendimento = preAtendimento2;

            #endregion

            #region animal3

            var dataInicial3 = DateTime.Today.AddMinutes(60);
            var dataFinal3 = dataInicial3.AddMinutes(tipoCastracao.DuracaoPadrao);

            var preAtendimento3 = new PreAtendimento()
            {
                DataPreAtendimento = dataInicial3.AddDays(-1),
                EnumStatusPreAtendimento = (int)EnumAtendimento.EnumStatusPreAtendimento.Realizado,
                TipoAtendimento = tipoCastracao,
                Entidade = entidade
            };

            var atendimento3 = new Atendimento()
            {
                Animal = animais[2],
                Observacao = "observação 3",
                DataAtendimentoInicio = dataInicial3,
                DataAtendimentoFim = dataFinal3,
                TipoAtendimento = tipoCastracao,
                ColaboradorExterno = null,
                ColaboradorInterno = usuarios[0],
                Entidade = entidade,
                Patologia = null,
                StatusRealizacaoAtendimento = (int)EnumAtendimento.StatusRealizacaoAtendimento.NaoRealizado,
            };

            preAtendimento3.Atendimento = atendimento3;
            atendimento3.PreAtendimento = preAtendimento3;

            #endregion

            var atendimentos = new List<Atendimento>()
            {
                atendimento1, atendimento2, atendimento3
            };

            return atendimentos;
        }
     
        private List<Medicamento> GetMoqMedicamentos(Entidade entidade)
        {
            var medicamentos = new List<Medicamento>();

            var medicamento1 = new Medicamento()
            {
                Entidade = entidade,
                Nome = "Anti-inflamatório",
                EnumUnidadeMedicamentos = (int)EnumAtendimento.EnumUnidadeMedicamentos.comprimido,
                Quantidade = 1,
                Duracao = 4,
                EnumFrequenciaIngestao = (int)EnumAtendimento.EnumFrequenciaIngestao.diariamenteXvezesDia,
                AuxiliarX = 3,
                AuxiliarY = 0,
                DiasDaSemana = string.Empty
            };

            var medicamento2 = new Medicamento()
            {
                Entidade = entidade,
                Nome = "Repositor Hormonal Cepav Tyrox 200 mcg",
                EnumUnidadeMedicamentos = (int)EnumAtendimento.EnumUnidadeMedicamentos.comprimido,
                Quantidade = 1,
                Duracao = 1,
                EnumFrequenciaIngestao = (int)EnumAtendimento.EnumFrequenciaIngestao.diariamenteXvezesDia,
                AuxiliarX = 3,
                AuxiliarY = 0,
                DiasDaSemana = string.Empty
            };

            medicamentos.Add(medicamento1);
            medicamentos.Add(medicamento2);

            return medicamentos;
        }

        #endregion
    }
}