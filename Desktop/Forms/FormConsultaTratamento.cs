using Desktop.Classes;
using Desktop.DependencyInjection;
using Repositorio.Classes;
using Repositorio.ClassesGerais;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormConsultaTratamento : Form
    {
        private ITratamentoService _tratamentoService;
        private IAtendimentoService _atendimentoService;
        private IMedicamentoService _medicamentoService;

        private Atendimento _atendimento;


        private List<Tratamento> _tratamentos = new List<Tratamento>();
        private List<Atendimento> _atendimentos = new List<Atendimento>();

        private int _numAgendamentos = 0;
        private int _numTratamentosRealizados = 0;
        private int _numTratamentosNaoRealizados = 0;

        public FormConsultaTratamento()
        {
            InitializeComponent();
            InitializeServices();
            CarregarTooltips();
            CarregarTratamentos(monthCalendar.SelectionRange.Start);
        }

        private void InitializeServices()
        {
            _tratamentoService = IocKernel.Get<ITratamentoService>();
            _atendimentoService = IocKernel.Get<IAtendimentoService>();
            _medicamentoService = IocKernel.Get<IMedicamentoService>();
        }

        private void AdicionarItemNoListView(Atendimento atendimento, Medicamento medicamento, int ordemMedicamento, int idControleTratamento, DateTime data, string stautsTratamento)
        {
            var lvi = new ListViewItem();

            lvi.Text = atendimento.Id.ToString();
            lvi.SubItems.Add(atendimento.Tratamento.Id.ToString());
            lvi.SubItems.Add(ordemMedicamento.ToString());
            lvi.SubItems.Add(idControleTratamento.ToString());
            lvi.SubItems.Add(AjustarHorarioInicio(data));
            lvi.SubItems.Add(atendimento.Animal == null ? string.Empty : $"{atendimento.Animal?.Identificacao} - {atendimento.Animal?.Nome} - {atendimento.Animal?.AnimalEspecie?.Descricao}");
            lvi.SubItems.Add(atendimento.TipoAtendimento.Nome);
            lvi.SubItems.Add(atendimento.Patologia != null ? atendimento.Patologia.Descricao : string.Empty);
            lvi.SubItems.Add(stautsTratamento);
            lvi.SubItems.Add(GetDestricaoTratamento(medicamento));

            if (stautsTratamento.ToLower() == "não iniciado")
                lvi.BackColor = Color.Yellow;

            else if (stautsTratamento.ToLower() == "realizado")
                lvi.BackColor = Color.LightGreen;

            else if (stautsTratamento.ToLower() == "não realizado")
                lvi.BackColor = Color.LightPink;

            lvTratamentos.Items.Add(lvi);
        }

        private string GetDestricaoTratamento(Medicamento medicamento)
        {
            var descricao = string.Empty;

            descricao += $"{medicamento.Nome}: {medicamento.Quantidade.ToString("N2")} {FuncoesGerais.GetDescricaoEnum((EnumeracoesClasses.EnumUnidadeMedicamentos)medicamento.EnumUnidadeMedicamentos).ToLower()} ";

            var duracao = medicamento.Duracao > 0 ? $"por {medicamento.Duracao} dias - " : "sem previsão de término - ";
            descricao += duracao;

            var frequencia = EnumeracoesClasses.GetDescricaoFrequenciaIngestao(medicamento.EnumFrequenciaIngestao, medicamento.AuxiliarX, medicamento.AuxiliarY, medicamento.DiasDaSemana).ToLower();
            descricao += frequencia;

            return descricao;
        }

        private void AdicionarTratamentosNaoIniciadosNoListView(Atendimento atendimento)
        {
            var statusNaoIniciado = (int)EnumeracoesClasses.EnumStatusMedicacao.naoIniciado;
            var descricaoStatusNaoIniciado = FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumStatusTratamento.naoIniciado);

            if (atendimento.Tratamento.EnumStatusMedicacao1 == statusNaoIniciado)
                AdicionarItemNoListView(atendimento.Tratamento.Atendimento, atendimento.Tratamento.Medicamento1, 1, 0, new DateTime(), descricaoStatusNaoIniciado);

            if (atendimento.Tratamento.EnumStatusMedicacao2 == statusNaoIniciado)
                AdicionarItemNoListView(atendimento.Tratamento.Atendimento, atendimento.Tratamento.Medicamento2, 2, 0, new DateTime(), descricaoStatusNaoIniciado);

            if (atendimento.Tratamento.EnumStatusMedicacao3 == statusNaoIniciado)
                AdicionarItemNoListView(atendimento.Tratamento.Atendimento, atendimento.Tratamento.Medicamento3, 3, 0, new DateTime(), descricaoStatusNaoIniciado);

            if (atendimento.Tratamento.EnumStatusMedicacao4 == statusNaoIniciado)
                AdicionarItemNoListView(atendimento.Tratamento.Atendimento, atendimento.Tratamento.Medicamento4, 4, 0, new DateTime(), descricaoStatusNaoIniciado);

            if (atendimento.Tratamento.EnumStatusMedicacao5 == statusNaoIniciado)
                AdicionarItemNoListView(atendimento.Tratamento.Atendimento, atendimento.Tratamento.Medicamento5, 5, 0, new DateTime(), descricaoStatusNaoIniciado);

        }

        private bool PodeAdicionarItem(int enumStatusMedicacao)
        {
            return enumStatusMedicacao == (int)EnumeracoesClasses.EnumStatusMedicacao.agendado ||
                   enumStatusMedicacao == (int)EnumeracoesClasses.EnumStatusMedicacao.encerrado ||
                   enumStatusMedicacao == (int)EnumeracoesClasses.EnumStatusMedicacao.iniciado;
        }

        private string GetDescricaoStatusTratamento(int enumStatusControleMedicação)
        {
            SetNumerosTratamentos(enumStatusControleMedicação);
            return FuncoesGerais.GetDescricaoEnum((EnumeracoesClasses.EnumStatusControleMedicação)enumStatusControleMedicação);
        }

        private void SetNumerosTratamentos(int enumStatusControleMedicação)
        {
            if (enumStatusControleMedicação == (int)EnumeracoesClasses.EnumStatusControleMedicação.realizado)
            {
                _numTratamentosRealizados++;
                _numAgendamentos++;
            }

            if (enumStatusControleMedicação == (int)EnumeracoesClasses.EnumStatusControleMedicação.naoRealizado)
            {
                _numTratamentosNaoRealizados++;
                _numAgendamentos++;
            }
        }

        private void AdicionarTratamentosIniciadosNoListView(Atendimento atendimento, DateTime dataFiltro)
        {
            var enumStatusCancelado = (int)EnumeracoesClasses.EnumStatusControleMedicação.cancelado;

            if (PodeAdicionarItem(atendimento.Tratamento.EnumStatusMedicacao1))
            {
                foreach (var controle in atendimento.Tratamento.ControlesMedicamento1)
                {
                    if (controle.DataExecucao.Date == dataFiltro.Date && controle.EnumStatusControleMedicação != enumStatusCancelado)
                    {
                        var status = GetDescricaoStatusTratamento(controle.EnumStatusControleMedicação);
                        AdicionarItemNoListView(atendimento, atendimento.Tratamento.Medicamento1, 1, controle.Id, controle.DataExecucao, status);
                    }
                }
            }

            if (PodeAdicionarItem(atendimento.Tratamento.EnumStatusMedicacao2))
            {
                foreach (var controle in atendimento.Tratamento.ControlesMedicamento2)
                {
                    if (controle.DataExecucao.Date == dataFiltro.Date && controle.EnumStatusControleMedicação != enumStatusCancelado)
                    {
                        var status = GetDescricaoStatusTratamento(controle.EnumStatusControleMedicação);
                        AdicionarItemNoListView(atendimento.Tratamento.Atendimento, atendimento.Tratamento.Medicamento2, 2, controle.Id, controle.DataExecucao, status);
                    }
                }
            }

            if (PodeAdicionarItem(atendimento.Tratamento.EnumStatusMedicacao3))
            {
                foreach (var controle in atendimento.Tratamento.ControlesMedicamento3)
                {
                    if (controle.DataExecucao.Date == dataFiltro.Date && controle.EnumStatusControleMedicação != enumStatusCancelado)
                    {
                        var status = GetDescricaoStatusTratamento(controle.EnumStatusControleMedicação);
                        AdicionarItemNoListView(atendimento.Tratamento.Atendimento, atendimento.Tratamento.Medicamento3, 3, controle.Id, controle.DataExecucao, status);
                    }
                }
            }

            if (PodeAdicionarItem(atendimento.Tratamento.EnumStatusMedicacao4))
            {
                foreach (var controle in atendimento.Tratamento.ControlesMedicamento4)
                {
                    if (controle.DataExecucao.Date == dataFiltro.Date && controle.EnumStatusControleMedicação != enumStatusCancelado)
                    {
                        var status = GetDescricaoStatusTratamento(controle.EnumStatusControleMedicação);
                        AdicionarItemNoListView(atendimento.Tratamento.Atendimento, atendimento.Tratamento.Medicamento4, 4, controle.Id, controle.DataExecucao, status);
                    }
                }
            }

            if (PodeAdicionarItem(atendimento.Tratamento.EnumStatusMedicacao5))
            {
                foreach (var controle in atendimento.Tratamento.ControlesMedicamento5)
                {
                    if (controle.DataExecucao.Date == dataFiltro.Date && controle.EnumStatusControleMedicação != enumStatusCancelado)
                    {
                        var status = GetDescricaoStatusTratamento(controle.EnumStatusControleMedicação);
                        AdicionarItemNoListView(atendimento.Tratamento.Atendimento, atendimento.Tratamento.Medicamento5, 5, controle.Id, controle.DataExecucao, status);
                    }
                }
            }
        }

        private void CarregarTratamentos(DateTime dataFiltro)
        {
            this.Cursor = Cursors.WaitCursor;
            lvTratamentos.Items.Clear();
            _atendimentos.Clear();
            _tratamentos.Clear();

            _numAgendamentos = 0;
            _numTratamentosRealizados = 0;
            _numTratamentosNaoRealizados = 0;

            _atendimentos = _atendimentoService.GetAtendimentoComTratamento(Global.Entidade.Id);

            foreach (var atendimento in _atendimentos)
                _tratamentos.Add(atendimento.Tratamento);


            if (_tratamentos.Any())
            {
                foreach (var atendimento in _atendimentos)
                {
                    if (dataFiltro.Date == DateTime.Today)
                        AdicionarTratamentosNaoIniciadosNoListView(atendimento);

                    AdicionarTratamentosIniciadosNoListView(atendimento, dataFiltro);
                }
            }

            ExibirNumerosTratamentos();
            this.Cursor = Cursors.Default;
        }

        private void ExibirNumerosTratamentos()
        {
            txtNumAgendados.Text = _numAgendamentos.ToString();
            txtNumRealizados.Text = _numTratamentosRealizados.ToString();
            txtNaoRealizados.Text = _numTratamentosNaoRealizados.ToString();
        }

        private string AjustarHorarioInicio(DateTime data)
        {
            if (data == DateTime.MinValue)
                return string.Empty;
            else
                return data.ToShortTimeString();
        }

        private void CarregarTooltips()
        {
            toolTip.SetToolTip(btnImprimir, _tratamentoService.MensagemTooltip);
        }

        private void ConfirmarTratamento(int ordemMedicamento, int controleId)
        {
            var statusRealizado = (int)EnumeracoesClasses.EnumStatusControleMedicação.realizado;

            if (ordemMedicamento == 1)
            {
                _atendimento.Tratamento.ControlesMedicamento1.FirstOrDefault(k => k.Id == controleId).EnumStatusControleMedicação = statusRealizado;

                //var controle = _atendimento.Tratamento.ControlesMedicamento1.FirstOrDefault(k => k.Id == controleId );
                //controle.EnumStatusControleMedicação = statusRealizado;
            }
            else if (ordemMedicamento == 2)
            {
                _atendimento.Tratamento.ControlesMedicamento2.FirstOrDefault(k => k.Id == controleId).EnumStatusControleMedicação = statusRealizado;

                //var controle = _atendimento.Tratamento.ControlesMedicamento2.FirstOrDefault(k => k.Id == controleId);
                //controle.EnumStatusControleMedicação = statusRealizado;
            }
            else if (ordemMedicamento == 3)
            {
                _atendimento.Tratamento.ControlesMedicamento3.FirstOrDefault(k => k.Id == controleId).EnumStatusControleMedicação = statusRealizado;

                //var controle = _atendimento.Tratamento.ControlesMedicamento3.FirstOrDefault(k => k.Id == controleId);
                //controle.EnumStatusControleMedicação = statusRealizado;
            }
            else if (ordemMedicamento == 4)
            {
                _atendimento.Tratamento.ControlesMedicamento4.FirstOrDefault(k => k.Id == controleId).EnumStatusControleMedicação = statusRealizado;

                //var controle = _atendimento.Tratamento.ControlesMedicamento4.FirstOrDefault(k => k.Id == controleId);
                //controle.EnumStatusControleMedicação = statusRealizado;
            }
            else if (ordemMedicamento == 5)
            {
                //var controle = _atendimento.Tratamento.ControlesMedicamento5.FirstOrDefault(k => k.Id == controleId);
                //controle.EnumStatusControleMedicação = statusRealizado;
                _atendimento.Tratamento.ControlesMedicamento5.FirstOrDefault(k => k.Id == controleId).EnumStatusControleMedicação = statusRealizado;

            }

            if (TratamentoDAO.Salvar(_atendimento.Tratamento))
            //if (AtendimentoDAO.Salvar(_atendimento))
            {
                FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
                CarregarTratamentos(monthCalendar.SelectionRange.Start);
            }

            //if (TratamentoDAO.Salvar(tratamento))
            //{
            //    FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
            //    CarregarTratamentos(monthCalendar.SelectionRange.Start);
            //}
        }

        private List<ControleMedicamento> GetControleMedicamentosAserCancelados(Tratamento tratamento, int indexMedicamento, int controleMedicamentoId)
        {
            var controlesACancelar = new List<ControleMedicamento>();

            //if (indexMedicamento == 1)
            //    controlesACancelar.AddRange(tratamento.ControlesMedicamento1.Where(k => k.Id >= controleMedicamentoId).ToList());
            //else if (indexMedicamento == 2)
            //    controlesACancelar.AddRange(tratamento.ControlesMedicamento2.Where(k => k.Id >= controleMedicamentoId).ToList());
            //else if (indexMedicamento == 3)
            //    controlesACancelar.AddRange(tratamento.ControlesMedicamento3.Where(k => k.Id >= controleMedicamentoId).ToList());
            //else if (indexMedicamento == 4)
            //    controlesACancelar.AddRange(tratamento.ControlesMedicamento4.Where(k => k.Id >= controleMedicamentoId).ToList());
            //else if (indexMedicamento == 5)
            //    controlesACancelar.AddRange(tratamento.ControlesMedicamento5.Where(k => k.Id >= controleMedicamentoId).ToList());

            return controlesACancelar;
        }

        private void AlterStatusParaCanceladoDoControleDosMedicamentos(Tratamento tratamento, int indexMedicamento, int controleMedicamentoId)
        {
            var controle = GetControleMedicamentosAserCancelados(tratamento, indexMedicamento, controleMedicamentoId);

            if (controle.Any())
            {
                foreach (var item in controle)
                    item.EnumStatusControleMedicação = (int)EnumeracoesClasses.EnumStatusControleMedicação.cancelado;
            }
        }

        private void CancelarTratamento(Atendimento atendimento, int ordemMedicamento, int controleId)
        {
            if (ordemMedicamento == 1)
                AlterStatusParaCanceladoDoControleDosMedicamentos(atendimento.Tratamento, 1, controleId);

            else if (ordemMedicamento == 2)
                AlterStatusParaCanceladoDoControleDosMedicamentos(atendimento.Tratamento, 2, controleId);

            else if (ordemMedicamento == 3)
                AlterStatusParaCanceladoDoControleDosMedicamentos(atendimento.Tratamento, 3, controleId);

            else if (ordemMedicamento == 4)
                AlterStatusParaCanceladoDoControleDosMedicamentos(atendimento.Tratamento, 4, controleId);

            else if (ordemMedicamento == 5)
                AlterStatusParaCanceladoDoControleDosMedicamentos(atendimento.Tratamento, 5, controleId);

            if (AtendimentoDAO.Salvar(atendimento))
            {
                FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
                CarregarTratamentos(monthCalendar.SelectionRange.Start);
            }
        }

        private void GeraAgendamentoDiarioPorXvezesAoDia(int index)
        {
            int numeroDeVezeAoDia = 0, duracaoEmDiasDoTratamento = 0;

            if (index == 1)
            {
                numeroDeVezeAoDia = _atendimento.Tratamento.Medicamento1.AuxiliarX;
                duracaoEmDiasDoTratamento = _atendimento.Tratamento.Medicamento1.Duracao;
            }
            else if (index == 2)
            {
                numeroDeVezeAoDia = _atendimento.Tratamento.Medicamento2.AuxiliarX;
                duracaoEmDiasDoTratamento = _atendimento.Tratamento.Medicamento2.Duracao;
            }
            else if (index == 3)
            {
                numeroDeVezeAoDia = _atendimento.Tratamento.Medicamento3.AuxiliarX;
                duracaoEmDiasDoTratamento = _atendimento.Tratamento.Medicamento3.Duracao;
            }
            else if (index == 4)
            {
                numeroDeVezeAoDia = _atendimento.Tratamento.Medicamento4.AuxiliarX;
                duracaoEmDiasDoTratamento = _atendimento.Tratamento.Medicamento4.Duracao;
            }
            else if (index == 5)
            {
                numeroDeVezeAoDia = _atendimento.Tratamento.Medicamento5.AuxiliarX;
                duracaoEmDiasDoTratamento = _atendimento.Tratamento.Medicamento5.Duracao;
            }

            var intervaloDeTempo = 1d;

            if (numeroDeVezeAoDia > 0)
                intervaloDeTempo = 86400000 / numeroDeVezeAoDia;

            var totalDeInsercoes = duracaoEmDiasDoTratamento * numeroDeVezeAoDia;
            var data = DateTime.Now;

            for (int i = 1; i <= totalDeInsercoes; i++)
            {
                var controle = new ControleMedicamento()
                {
                    Entidade = Global.Entidade,
                    EnumStatusControleMedicação = (int)EnumeracoesClasses.EnumStatusControleMedicação.naoRealizado,
                    DataExecucao = data
                };

                AdicionaControleMedicamento(index, controle);

                data = data.AddMilliseconds(intervaloDeTempo);
            }
        }

        private Medicamento GeraAgendamentoDiarioAcadaXhoras(Tratamento tratamento, Medicamento medicamento, int index)
        {
            var intervaloMilisegundos = medicamento.AuxiliarX * 3600000;
            var duracaoEmDiasDoTratamento = medicamento.Duracao;
            var frequenicaPorDia = (decimal)86400000 / intervaloMilisegundos;
            var numeroDeVezeAoDiaArredodando = Math.Ceiling(frequenicaPorDia);

            var totalDeInsercoes = duracaoEmDiasDoTratamento * numeroDeVezeAoDiaArredodando;
            var data = DateTime.Now;

            for (int i = 1; i <= totalDeInsercoes; i++)
            {
                var controle = new ControleMedicamento()
                {
                    Entidade = Global.Entidade,
                    EnumStatusControleMedicação = (int)EnumeracoesClasses.EnumStatusControleMedicação.naoRealizado,
                    DataExecucao = data
                };

                //AdicionaControleMedicamento(index, tratamento, controle);

                data = data.AddMilliseconds(intervaloMilisegundos);
            }

            return medicamento;
        }

        private Medicamento GeraAgendamentoAcadaXdias(Tratamento tratamento, Medicamento medicamento, int index)
        {
            var intervaloDias = medicamento.AuxiliarX;
            var duracaoEmDiasDoTratamento = medicamento.Duracao;
            var numeroVezes = (decimal)duracaoEmDiasDoTratamento / intervaloDias;
            var numeroVezeArredodando = Math.Ceiling(numeroVezes);

            var data = DateTime.Now;

            for (int i = 1; i <= numeroVezeArredodando; i++)
            {
                var controle = new ControleMedicamento()
                {
                    Entidade = Global.Entidade,
                    EnumStatusControleMedicação = (int)EnumeracoesClasses.EnumStatusControleMedicação.naoRealizado,
                    DataExecucao = data
                };

                //AdicionaControleMedicamento(index, tratamento, controle);

                data = data.AddDays(intervaloDias);
            }

            return medicamento;
        }

        private Medicamento GeraAgendamentoEmCertosDiasDaSemana(Tratamento tratamento, Medicamento medicamento, int index)
        {
            var diasSemana = medicamento.DiasDaSemana;
            var duracaoEmDiasDoTratamento = medicamento.Duracao;

            bool segundaFeira = diasSemana.Contains('2');
            bool tercaFeira = diasSemana.Contains('3');
            bool quartaFeira = diasSemana.Contains('4');
            bool quintaFeira = diasSemana.Contains('5');
            bool sextaFeira = diasSemana.Contains('6');
            bool sabado = diasSemana.Contains('S');
            bool domingo = diasSemana.Contains('D');

            var data = DateTime.Now;

            for (int i = 0; i < duracaoEmDiasDoTratamento; i++)
            {
                bool possuiTratamento = false;

                if (segundaFeira && (int)data.DayOfWeek == 1)
                    possuiTratamento = true;

                else if (tercaFeira && (int)data.DayOfWeek == 2)
                    possuiTratamento = true;

                else if (quartaFeira && (int)data.DayOfWeek == 3)
                    possuiTratamento = true;

                else if (quintaFeira && (int)data.DayOfWeek == 4)
                    possuiTratamento = true;

                else if (sextaFeira && (int)data.DayOfWeek == 5)
                    possuiTratamento = true;

                else if (sabado && (int)data.DayOfWeek == 6)
                    possuiTratamento = true;

                else if (domingo && (int)data.DayOfWeek == 0)
                    possuiTratamento = true;

                if (possuiTratamento)
                {
                    var controle = new ControleMedicamento()
                    {
                        Entidade = Global.Entidade,
                        EnumStatusControleMedicação = (int)EnumeracoesClasses.EnumStatusControleMedicação.naoRealizado,
                        DataExecucao = data
                    };

                    //AdicionaControleMedicamento(index, tratamento, controle);
                }
                data = data.AddDays(1);
            }
            return medicamento;
        }

        private void GeraAgendamentoEmCiclosDeDiasAtivosEinativos(Tratamento tratamento, Medicamento medicamento, int index)
        {
            var numDiasAtivos = medicamento.AuxiliarX;
            var numDiasInativos = medicamento.AuxiliarY;
            var duracaoEmDiasDoTratamento = medicamento.Duracao;

            var data = DateTime.Now;
            var contaDiasAtivos = 1;
            var contaDiasInativos = 1;

            for (int i = 1; i <= duracaoEmDiasDoTratamento; i++)
            {
                if (contaDiasAtivos <= numDiasAtivos)
                {
                    var controle = new ControleMedicamento()
                    {
                        Entidade = Global.Entidade,
                        EnumStatusControleMedicação = (int)EnumeracoesClasses.EnumStatusControleMedicação.naoRealizado,
                        DataExecucao = data
                    };

                    AdicionaControleMedicamento(index, controle);

                    data = data.AddDays(1);
                    contaDiasAtivos++;
                }
                else if (contaDiasInativos <= numDiasInativos)
                {
                    data = data.AddDays(1);
                    contaDiasInativos++;
                }
                else if (contaDiasInativos > numDiasInativos)
                {
                    contaDiasAtivos = 1;
                    contaDiasInativos = 1;
                }
            }
        }

        private void AdicionaControleMedicamento(int index, ControleMedicamento controle)
        {
            if (index == 1)
            {
                controle.Medicamento = _atendimento.Tratamento.Medicamento1;
                _atendimento.Tratamento.AddControleMedicamento1(controle);
            }
            else if (index == 2)
            {
                controle.Medicamento = _atendimento.Tratamento.Medicamento2;
                _atendimento.Tratamento.AddControleMedicamento2(controle);
            }

            else if (index == 3)
                _atendimento.Tratamento.ControlesMedicamento3.Add(controle);
            else if (index == 4)
                _atendimento.Tratamento.ControlesMedicamento4.Add(controle);
            else if (index == 5)
                _atendimento.Tratamento.ControlesMedicamento5.Add(controle);
        }

        private void SelecionaTipoAgendamentoConfigurado(int frequenciaIngestaoMedicamento, int index)
        {
            switch (frequenciaIngestaoMedicamento)
            {
                case (int)EnumeracoesClasses.EnumFrequenciaIngestao.diariamenteXvezesDia:
                    GeraAgendamentoDiarioPorXvezesAoDia(index);
                    break;

                    //case (int)EnumeracoesClasses.EnumFrequenciaIngestao.diariamenteCadaXhoras:
                    //    GeraAgendamentoDiarioAcadaXhoras(tratamento, medicamento, index);
                    //    break;

                    //case (int)EnumeracoesClasses.EnumFrequenciaIngestao.cadaXdias:
                    //    GeraAgendamentoAcadaXdias(tratamento, medicamento, index);
                    //    break;

                    //case (int)EnumeracoesClasses.EnumFrequenciaIngestao.diasDaSemana:
                    //    GeraAgendamentoEmCertosDiasDaSemana(tratamento, medicamento, index);
                    //    break;

                    //case (int)EnumeracoesClasses.EnumFrequenciaIngestao.ciclosXativosYinativos:
                    //    GeraAgendamentoEmCiclosDeDiasAtivosEinativos(tratamento, medicamento, index);
                    //    break;
            }
        }

        private void GerarAgendamentosMedicacao(int ordemMedicamento)
        {
            if (ordemMedicamento == 1)
            {
                _atendimento.Tratamento.InicioMedicacao1 = DateTime.Now;
                _atendimento.Tratamento.EnumStatusMedicacao1 = (int)EnumeracoesClasses.EnumStatusMedicacao.agendado;

                var frequenciaIngestao = (int)_atendimento.Tratamento.Medicamento1.EnumFrequenciaIngestao;

                SelecionaTipoAgendamentoConfigurado(frequenciaIngestao, 1);
            }
            else if (ordemMedicamento == 2)
            {
                _atendimento.Tratamento.InicioMedicacao2 = DateTime.Now;
                _atendimento.Tratamento.EnumStatusMedicacao2 = (int)EnumeracoesClasses.EnumStatusMedicacao.agendado;

                var frequenciaIngestao = (int)_atendimento.Tratamento.Medicamento2.EnumFrequenciaIngestao;

                SelecionaTipoAgendamentoConfigurado(frequenciaIngestao, 2);
            }
            else if (ordemMedicamento == 3)
            {
                _atendimento.Tratamento.InicioMedicacao3 = DateTime.Now;
                _atendimento.Tratamento.EnumStatusMedicacao3 = (int)EnumeracoesClasses.EnumStatusMedicacao.agendado;

                var frequenciaIngestao = (int)_atendimento.Tratamento.Medicamento3.EnumFrequenciaIngestao;

                //SelecionaTipoAgendamentoConfigurado(_atendimento.Tratamento, _atendimento.Tratamento.Medicamento3, frequenciaIngestao, 3);
            }
            else if (ordemMedicamento == 4)
            {
                _atendimento.Tratamento.InicioMedicacao4 = DateTime.Now;
                _atendimento.Tratamento.EnumStatusMedicacao4 = (int)EnumeracoesClasses.EnumStatusMedicacao.agendado;

                var frequenciaIngestao = (int)_atendimento.Tratamento.Medicamento4.EnumFrequenciaIngestao;

                //SelecionaTipoAgendamentoConfigurado(_atendimento.Tratamento, _atendimento.Tratamento.Medicamento4, frequenciaIngestao, 4);
            }
            else if (ordemMedicamento == 5)
            {
                _atendimento.Tratamento.InicioMedicacao5 = DateTime.Now;
                _atendimento.Tratamento.EnumStatusMedicacao5 = (int)EnumeracoesClasses.EnumStatusMedicacao.agendado;

                var frequenciaIngestao = (int)_atendimento.Tratamento.Medicamento5.EnumFrequenciaIngestao;

                //SelecionaTipoAgendamentoConfigurado(_atendimento.Tratamento, _atendimento.Tratamento.Medicamento5, frequenciaIngestao, 5);
            }

            // TODO: VERIFICAR SE ESSE SALVAR ESTÁ OK = 05/07/22
            if (AtendimentoDAO.Salvar(_atendimento))
            {
                FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
                CarregarTratamentos(monthCalendar.SelectionRange.Start);
            }
        }

        private int GetStatusTratamento(int ordem, Tratamento tratamento)
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

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvTratamentos, "realizar o tratamento"))
            {
                if (Convert.ToInt32(lvTratamentos.SelectedItems[0].SubItems[0].Text) is int idAtendimento)
                {
                    if (Convert.ToInt32(lvTratamentos.SelectedItems[0].SubItems[1].Text) is int idTratamento)
                    {
                        _atendimento = _atendimentos.Find(k => k.Id == idAtendimento && k.Tratamento.Id == idTratamento);
                        //var tratamento = atendimento.Tratamento;
                        var ordemMedicamento = Convert.ToInt32(lvTratamentos.SelectedItems[0].SubItems[2].Text);

                        var medicamento = _atendimentoService.GetMedicamento(_atendimento.Tratamento, ordemMedicamento);
                        var enumStatusMedicamento = _atendimentoService.GetStatusMedicacaoEmUmTratamento(ordemMedicamento, _atendimento.Tratamento);

                        if (enumStatusMedicamento == (int)EnumeracoesClasses.EnumStatusMedicacao.naoIniciado)
                        {
                            var mensagem = "Você tem certeza que deseja realizar o início do tratamento? Serão agendados todos os tratamentos baseados na data e hora atual.";
                            var resultado = MessageBox.Show(mensagem, "Agendamento do(s) tratamento(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (resultado.Equals(DialogResult.OK) || resultado.Equals(DialogResult.Yes))
                                GerarAgendamentosMedicacao(ordemMedicamento);
                        }
                        else if (enumStatusMedicamento == (int)EnumeracoesClasses.EnumStatusMedicacao.agendado || enumStatusMedicamento == (int)EnumeracoesClasses.EnumStatusMedicacao.iniciado)
                        {
                            var mensagem = "Você confirma que o tratamento foi realizado na data e hora agendada?";
                            var resultado = MessageBox.Show(mensagem, "Tratamento realizado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (resultado.Equals(DialogResult.OK) || resultado.Equals(DialogResult.Yes))
                            {
                                if (Convert.ToInt32(lvTratamentos.SelectedItems[0].SubItems[3].Text) is int controleId)
                                {
                                    ConfirmarTratamento(ordemMedicamento, controleId);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            var dataSelecionada = monthCalendar.SelectionRange.Start;
            CarregarTratamentos(dataSelecionada);

            if (dataSelecionada.Date == DateTime.Today.Date)
                btnRealizar.Enabled = true;
            else
                btnRealizar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvTratamentos, "cancelar o tratamento"))
            {
                if (Convert.ToInt32(lvTratamentos.SelectedItems[0].SubItems[0].Text) is int idAtendimento)
                {
                    var tratamentoId = Convert.ToInt32(lvTratamentos.SelectedItems[0].SubItems[1].Text);
                    var atendimento = _atendimentos.Where(k => k.Id == idAtendimento && k.Tratamento.Id == tratamentoId).FirstOrDefault();

                    if (Convert.ToInt32(lvTratamentos.SelectedItems[0].SubItems[2].Text) is int ordemMedicamento)
                    {
                        var medicamento = _atendimentoService.GetMedicamento(atendimento.Tratamento, ordemMedicamento);
                        var mensagem = "Você tem certeza que deseja cancelar o tratamento? Todos os demais horários agendados para este tratamento serão cancelados.";
                        var resultado = MessageBox.Show(mensagem, "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (resultado.Equals(DialogResult.OK) || resultado.Equals(DialogResult.Yes))
                        {
                            if (Convert.ToInt32(lvTratamentos.SelectedItems[0].SubItems[3].Text) is int controleId)
                            {
                                CancelarTratamento(atendimento, ordemMedicamento, controleId);
                            }
                        }
                    }
                }
            }
        }

        private void btnAdiar_Click(object sender, EventArgs e)
        {

        }
    }
}
