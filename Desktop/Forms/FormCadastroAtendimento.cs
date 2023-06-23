using Desktop.Classes;
using Desktop.DependencyInjection;
using Dominio.Enums;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

/*
 * Criado em: 12/11/20
 * Alterado em: 15/06/23
 */

namespace Desktop.Forms
{
    public partial class FormCadastroAtendimento : Form
    {
        private IAnimalService _animalService;
        private IAtendimentoService _atendimentoService;
        private IUsuarioService _usuarioService;
        private IColaboradorExternoService _colaboradorExternoService;

        private IEnumerable<Usuario> _usuarios = new List<Usuario>();
        private IEnumerable<ColaboradorExterno> _colaboradores = new List<ColaboradorExterno>();
        private IEnumerable<TipoAtendimento> _tiposDeAtendimentos = new List<TipoAtendimento>();
        private IEnumerable<Patologia> _patologias = new List<Patologia>();
        private IEnumerable<Atendimento> _atendimentos;

        private Atendimento _atendimento = new Atendimento();
        private Animal _animalSelecionado;

        public FormCadastroAtendimento()
        {
            InitializeComponent();
            InitializeServices();
            CarregarTooltips();
            CarregarComboInterno();
            CarregarComboColaboradorExternos();
            CarregarComboTipoAtendimento();
            CarregarComboPatologia();
        }

        private void InitializeServices()
        {
            _animalService = IocKernel.Get<IAnimalService>();
            _atendimentoService = IocKernel.Get<IAtendimentoService>();
            _usuarioService = IocKernel.Get<IUsuarioService>();
            _colaboradorExternoService = IocKernel.Get<IColaboradorExternoService>();
        }

        private void CarregarComboTipoAtendimento()
        {
            _tiposDeAtendimentos = _atendimentoService.GetTiposAtendimentosOrdenadosPorNome(Global.Entidade.Id);
            comboTipoAtendimento.DataSource = _tiposDeAtendimentos;
            comboTipoAtendimento.DisplayMember = "Nome";
            comboTipoAtendimento.SelectedIndex = -1;
        }

        private void CarregarDadosAnimal()
        {
            rtbAnimal.Text = _animalService.GetDadosResumidos(_animalSelecionado);
            FuncoesGerais.SetImagemPictureBox(pbAnimal, _animalSelecionado.Imagem);
        }

        private void CarregarTooltips()
        {
            toolTip.SetToolTip(btnNovoExterno, "Permite cadastrar e editar instituições/profissionais que façam atendimento veterinário.");
            toolTip.SetToolTip(btnNovoProcedimento, "Permite cadastrar e editar procedimentos médicos efetuados aos animais.");
        }

        private void CarregarComboInterno()
        {
            _usuarios = _usuarioService.GetUsuariosAtivos(Global.Entidade.Id);
            comboInterno.DataSource = _usuarios.OrderBy(k => k.Nome).ToList();
            comboInterno.DisplayMember = "Nome";
            comboInterno.SelectedIndex = -1;
        }

        private void CarregarComboColaboradorExternos()
        {
            _colaboradores = _colaboradorExternoService.GetColaboradorExternosAtivos(Global.Entidade.Id);
            comboExterno.DataSource = _colaboradores.OrderBy(k => k.NomeEmpresa).ThenBy(k => k.NomeColaborador).ToList();
            comboExterno.DisplayMember = "NomeColaborador";
            //foreach (var item in _colaboradores)
            //{
            //    comboExterno.DisplayMember = $"{item.NomeEmpresa} - {item.NomeColaborador}";
            //    //comboExterno.ValueMember = "Id";
            //}
            comboExterno.SelectedIndex = -1;
        }

        private void AjustaCombosResponsavel(bool ehInterno)
        {
            if (ehInterno)
            {
                comboExterno.Enabled = btnNovoExterno.Enabled = false;
                comboInterno.Enabled = true;
            }
            else
            {
                btnNovoExterno.Enabled = comboExterno.Enabled = true;
                comboInterno.Enabled = false;
            }
            comboExterno.SelectedIndex = comboInterno.SelectedIndex = -1;
        }

        private void CarregarComboPatologia()
        {
            _patologias = _atendimentoService.GetPatologiasOrdenadasPorNome(Global.Entidade.Id);
            comboPatologia.DataSource = _patologias;
            comboPatologia.DisplayMember = "Nome";
            comboPatologia.SelectedIndex = -1;
        }

        #region Eventos

        private void rbInterno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInterno.Checked)
                AjustaCombosResponsavel(true);
            else
                AjustaCombosResponsavel(false);
        }

        private void rbExterno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExterno.Checked)
                AjustaCombosResponsavel(false);
            else
                AjustaCombosResponsavel(true);
        }

        private void btnNovoExterno_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var form = new FormCadastroColaboradorExterno();
            form.FormClosing += new FormClosingEventHandler(this.FormCadastroColaborador_FormClosing);
            form.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void FormCadastroColaborador_FormClosing(object sender, FormClosingEventArgs e)
        {
            CarregarComboColaboradorExternos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var formConsulta = new FormConsultaAnimal(Enumeracoes.EnumTipoTela.Consulta);
            formConsulta.StartPosition = FormStartPosition.CenterScreen;
            formConsulta.FormBorderStyle = FormBorderStyle.Fixed3D;
            formConsulta.ControlBox = true;
            formConsulta.ClientSize = new System.Drawing.Size(900, 729);
            formConsulta.ShowDialog();

            _animalSelecionado = formConsulta.AnimalSelecionado;
            if (_animalSelecionado != null)
                CarregarDadosAnimal();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (DadosValidos())
            {
                var horario = dtpHorario.Value.TimeOfDay;
                var dataInicial = monthCalendar.SelectionRange.Start.AddHours(horario.Hours).AddMinutes(horario.Minutes);
                var tipoAtendimento = comboTipoAtendimento.SelectedIndex == -1 ? null : (TipoAtendimento)comboTipoAtendimento.Items[comboTipoAtendimento.SelectedIndex];
                var dataFinal = dataInicial.AddMinutes(tipoAtendimento.DuracaoPadrao);

                var preAtendimento = new PreAtendimento()
                {
                    DataPreAtendimento = monthCalendar.SelectionRange.Start.AddDays(-1),
                    EnumStatusPreAtendimento = (int)EnumAtendimento.EnumStatusPreAtendimento.NaoRealizado,
                    TipoAtendimento = tipoAtendimento,
                    Entidade = Global.Entidade,
                    //Atendimento = _atendimento
                };

                _atendimento.Animal = _animalSelecionado;
                _atendimento.Observacao = rtbObservacao.Text;
                _atendimento.DataAtendimentoInicio = dataInicial;
                _atendimento.DataAtendimentoFim = dataFinal;
                _atendimento.TipoAtendimento = tipoAtendimento;
                _atendimento.ColaboradorExterno = comboExterno.SelectedIndex == -1 ? null : (ColaboradorExterno)comboExterno.Items[comboExterno.SelectedIndex];
                _atendimento.ColaboradorInterno = comboInterno.SelectedIndex == -1 ? null : (Usuario)comboInterno.Items[comboInterno.SelectedIndex];
                _atendimento.Entidade = Global.Entidade;
                _atendimento.Patologia = comboPatologia.SelectedIndex == -1 ? null : (Patologia)comboPatologia.Items[comboPatologia.SelectedIndex];
                _atendimento.StatusRealizacaoAtendimento = (int)EnumAtendimento.StatusRealizacaoAtendimento.NaoRealizado;

                preAtendimento.Atendimento = _atendimento;
                _atendimento.PreAtendimento = preAtendimento;

                if (_atendimentoService.SalvarOuAtualizarAtendimento(_atendimento))
                {
                    FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
                    this.Close();
                }
                else
                {
                    FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Salvar);
                }
            }
        }

        //private bool ValidaColisaoAgendaPorUsuario()
        //{
        //    var resultado = false;

        //    if (_atendimentos == null)
        //    {

        //    }
        //    AtendimentoDAO.GetTodosRegistros().ToList();
        //    return resultado;
        //}

        private bool DadosValidos()
        {
            var mensagem = string.Empty;

            if (_animalSelecionado == null || _animalSelecionado?.Id <= 0)
            {
                mensagem = "Você deve selecionar um animal para efetuar o cadastro de um atendimento.";
                MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (rbExterno.Checked && string.IsNullOrEmpty(comboExterno.SelectedItem?.ToString()))
            {
                mensagem = "Você deve selecionar um responsável externo para efetuar o cadastro de um atendimento.";
                MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (rbInterno.Checked && string.IsNullOrEmpty(comboInterno.SelectedItem?.ToString()))
            {
                mensagem = "Você deve selecionar um responsável interno para efetuar o cadastro de um atendimento.";
                MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(comboTipoAtendimento.SelectedItem?.ToString()))
            {
                mensagem = "Você deve selecionar um tipo de atendimento para efetuar o cadastro de um atendimento. " +
                           "Somente assim, o horário de encerramento poderá ser estimado corretamente.";
                MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void btnNovoProcedimento_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var form = new FormCadastroTipoAtendimento();
            form.FormClosing += new FormClosingEventHandler(this.FormCadastroTipoAtendimento_FormClosing);
            form.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void FormCadastroTipoAtendimento_FormClosing(object sender, FormClosingEventArgs e)
        {
            CarregarComboTipoAtendimento();
        }

        private void btnPatologia_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var form = new FormCadastroPatologia();
            form.FormClosing += new FormClosingEventHandler(this.FormCadastroTopologia_FormClosing);
            form.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void FormCadastroTopologia_FormClosing(object sender, FormClosingEventArgs e)
        {
            CarregarComboPatologia();
        }

        #endregion Eventos
    }
}
