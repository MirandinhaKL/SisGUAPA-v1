using Desktop.Classes;
using Desktop.Forms;
//using Repositorio.Entidades;
using System;
using System.Windows.Forms;

namespace SisGUAPA.Forms
{
    public partial class FormBase : Form
    {
        private FormConsultaAnimal _formConsultaAnimal;
        private FormEstatisticas _formEstatisticas;
        private FormConsultaAdocao _formConsultaAdotante;
        private FormConsultaEntidade _formConsultaEntidade;
        private FormAgendamentoAtendimento _formAgendamentoAtendimento;
        private FormConsultaHospedagem _formConsultaLar;
        private FormConsultaTratamento _formConsultaTratamento;

        private System.Timers.Timer timerAgenda = new System.Timers.Timer();
        //private List<Atendimento> _atendimentos = new List<Atendimento>();
        //private List<Tratamento> _tratamentos = new List<Tratamento>();
        //private List<ControleMedicamento> _controlesMedicamento = new List<ControleMedicamento>();

        public FormBase()
        {
            InitializeComponent();
            CarregarTooltips();
            AjustaTimer();
        }

        private void CarregarTooltips()
        {
            toolTip.SetToolTip(btnEstatisticas, "Habilita a tela com as informações estatísitcas do sistema");
            toolTip.SetToolTip(btnAnimal, "Permite consultar, salvar, editar, imprimir e exportar dados dos animais.");
            toolTip.SetToolTip(btnAdocao, "Permite consultar, salvar, editar e imprimir os dados referentes a adoção de um animal.");
            toolTip.SetToolTip(btnAtendimento, "Permite agendar, realizar e consultar atendimentos médicos dos animais.");
            toolTip.SetToolTip(btnTratamento, "Permite agendar, realizar e consultar trtamentos médicos dos animais.");
            toolTip.SetToolTip(btnLarTemporario, "Permite cadastrar lares temporários e hospedagens.");
            toolTip.SetToolTip(btnEntidades, "Permite cadastrar, editar e consultar usuários no sistema.");
        }

        private void AjustaTimer()
        {
            timerAgenda.Elapsed += new System.Timers.ElapsedEventHandler(timerAgenda_Elapsed);
            timerAgenda.Interval = 60000;
            timerAgenda.Start();
        }
        private void timerAgenda_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //CarregarTratamentos();
        }

        //private void CarregarTratamentos()
        //{
        //    //_atendimentos.Clear();
        //    //_tratamentos.Clear();
        //    //_atendimentos = AtendimentoDAO.GetAtendimentoComTratamento(Global.Entidade.Id);

        //    _controlesMedicamento = ControleMedicamentoDAO.GetControlesMedicamentoDiaEspecifico(DateTime.Now, Global.Entidade.Id);

        //    if (_controlesMedicamento.Any())
        //    {
        //        foreach (var medicamento in _controlesMedicamento)
        //        {

        //            var hora = medicamento.DataExecucao.Hour;
        //            var minuto = medicamento.DataExecucao.Minute;
        //            var horaAtual = DateTime.Now.Hour;
        //            var minutoAtual = DateTime.Now.Minute;

        //            if (horaAtual.Equals(hora) && minutoAtual.Equals(minuto))
        //            {

        //                this.popup = new Tulpep.NotificationWindow.PopupNotifier();
        //                this.popup.ContentText = $"Tratamento médico agendado para às {hora}h e {minuto}min";
        //                this.popup.TitleText = "Tratamento médico agendado";
        //                this.popup.Popup();
        //                break;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Abre o form com as informações dos animais.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimal_Click(object sender, EventArgs e)
        {
            FecharTodasJanelas();
            _formConsultaAnimal = new FormConsultaAnimal(Enumeracoes.EnumTipoTela.ConsultaECadastro);
            AbrirFormulario(_formConsultaAnimal, this);
        }

        private void AbrirFormulario(Form janela, Form janelaBase)
        {
            this.Cursor = Cursors.WaitCursor;
            janela.MdiParent = janelaBase;
            janela.Show();
            AjustarTamanhoJanelaFilha();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Fecha todas as possíveis janelas em aberto, com exceção da janela base do sistema;
        /// </summary>
        private void FecharTodasJanelas()
        {
            if (_formConsultaAnimal != null)
                _formConsultaAnimal.Close();
            if (_formEstatisticas != null)
                _formEstatisticas.Close();
            if (_formConsultaAdotante != null)
                _formConsultaAdotante.Close();
            if (_formConsultaEntidade != null)
                _formConsultaEntidade.Close();
            if (_formAgendamentoAtendimento != null)
                _formAgendamentoAtendimento.Close();
            if (_formConsultaLar != null)
                _formConsultaLar.Close();
            if (_formConsultaTratamento != null)
                _formConsultaTratamento.Close();
        }

        private void btnAdocao_Click(object sender, EventArgs e)
        {
            FecharTodasJanelas();
            _formConsultaAdotante = new FormConsultaAdocao();
            AbrirFormulario(_formConsultaAdotante, this);
        }

        private void btnEstatisticas_Click(object sender, EventArgs e)
        {
            FecharTodasJanelas();
            _formEstatisticas = new FormEstatisticas();
            AbrirFormulario(_formEstatisticas, this);
        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {

        }

        private void btnAtendimento_Click(object sender, EventArgs e)
        {
            FecharTodasJanelas();
            _formAgendamentoAtendimento = new FormAgendamentoAtendimento();
            AbrirFormulario(_formAgendamentoAtendimento, this);
        }

        private void btnLar_Click(object sender, EventArgs e)
        {
            FecharTodasJanelas();
            _formConsultaLar = new FormConsultaHospedagem();
            AbrirFormulario(_formConsultaLar, this);
        }

        private void FormBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnTratamento_Click(object sender, EventArgs e)
        {
            FecharTodasJanelas();
            _formConsultaTratamento = new FormConsultaTratamento();
            AbrirFormulario(_formConsultaTratamento, this);
        }

        private void btnEntidades_Click(object sender, EventArgs e)
        {
            FecharTodasJanelas();
            _formConsultaEntidade = new FormConsultaEntidade();
            AbrirFormulario(_formConsultaEntidade, this);
        }

        private void FormBase_Load(object sender, EventArgs e)
        {

        }

        private void FormBase_Resize(object sender, EventArgs e)
        {
            AjustarTamanhoJanelaFilha();
        }

        private void AjustarTamanhoJanelaFilha()
        {
            var filho = this.ActiveMdiChild;
            if (filho != null)
            {
                var largura = this.Width;
                var altura = this.Height;
                var size = panelMenu.Size;
                filho.Width = largura - size.Width - 23;
                filho.Height = altura - 45;
            }
        }
    }
}