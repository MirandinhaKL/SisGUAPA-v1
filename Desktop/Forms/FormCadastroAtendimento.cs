using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

/*
 * Criado em: 12/11/
 */

namespace Desktop.Forms
{
    public partial class FormCadastroAtendimento : Form
    {

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
            CarregarTooltips();
            CarregarComboInterno();
            CarregarComboColaboradorExternos();
            CarregarComboTipoAtendimento();
            CarregarComboPatologia();
        }

        private void CarregarComboTipoAtendimento()
        {
            _tiposDeAtendimentos = TipoAtendimentoDAO.GetTodosRegistros(Global.Entidade.Id).ToList();
            comboTipoAtendimento.DataSource = _tiposDeAtendimentos.OrderBy(k => k.Nome).ToList();
            comboTipoAtendimento.DisplayMember = "Nome";
            comboTipoAtendimento.SelectedIndex = -1;
        }

        private void CarregarDadosAnimal()
        {
            var dadosAnimal = string.Empty;

            dadosAnimal += $"Identificação: {_animalSelecionado.Identificacao}, Nome: {_animalSelecionado.Nome}, Espécie: {_animalSelecionado.AnimalEspecie.Descricao}, " +
                $"Gênero: {FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)_animalSelecionado.Genero)}, Peso: {_animalSelecionado.Peso.ToString()} Kg, " +
                $"Castrado: {FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumPossibilidades)_animalSelecionado.Castrado)}, " +
                $"Idade: {GetIdade(_animalSelecionado.DataNascimento)}";
            rtbAnimal.Text = dadosAnimal;

            FuncoesGerais.SetImagemPictureBox(pbAnimal, _animalSelecionado.Imagem);
        }

        private string GetIdade(DateTime nascimento)
        {
            var idadeBruta = DateTime.Today.Subtract(nascimento);
            var anos = (int)Math.Truncate(idadeBruta.TotalDays / 365);
            var meses = (int)Math.Truncate((idadeBruta.TotalDays % 365) / 30);
            var dias = (int)Math.Truncate((idadeBruta.TotalDays % 365) % 30);

            var ano = string.Empty;
            if (anos == 1)
                ano = "ano";
            else if (anos > 1)
                ano = "anos";

            var mes = string.Empty;
            if (meses == 1)
                mes = "mês";
            else if (meses > 1)
                mes = "meses";

            if (anos == 0 && meses == 0)
                return $"{dias} dias";
            else if (anos == 0 && meses > 0)
                return $"{meses} {mes}";
            else if (anos > 0 && meses == 0)
                return $"{anos} {ano}";
            else
                return $"{anos} {ano} e {meses} {mes}";
        }

        private void CarregarTooltips()
        {
            toolTip.SetToolTip(btnNovoExterno, "Permite cadastrar e editar instituições/profissionais que façam atendimento veterinário.");
            toolTip.SetToolTip(btnNovoProcedimento, "Permite cadastrar e editar procedimentos médicos efetuados aos animais.");
        }

        private void CarregarComboInterno()
        {
            _usuarios = UsuarioDAO.GetTodosRegistros(Global.Entidade.Id).ToList().Where(k => k.Status != (int)Enumeracoes.EnumStatusUsuario.Inativo);
            comboInterno.DataSource = _usuarios.OrderBy(k => k.Nome).ToList();
            comboInterno.DisplayMember = "Nome";
            comboInterno.SelectedIndex = -1;
        }

        private void CarregarComboColaboradorExternos()
        {
            _colaboradores = ColaboradorExternoDAO.GetTodosRegistros(Global.Entidade.Id).ToList().Where(k => k.Status != (int)Enumeracoes.EnumStatusUsuario.Inativo);
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
            _patologias = PatologiaDAO.GetTodosRegistros(Global.Entidade.Id).ToList();
            comboPatologia.DataSource = _patologias.OrderBy(k => k.Nome).ToList();
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
                    enumStatusPreAtendimento = (int)Enumeracoes.EnumStatusPreAtendimento.naoRealizado,
                    TipoAtendimento = tipoAtendimento,
                    Entidade = Global.Entidade,
                    Atendimento = _atendimento
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
                _atendimento.StatusRealizacaoAtendimento = (int)Enumeracoes.StatusRealizacaoAtendimento.naoRealizado;
                _atendimento.PreAtendimento = preAtendimento;

                if (AtendimentoDAO.Salvar(_atendimento))
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
                mensagem = "Você deve selecionar um tipo de atendimento para efetuar o cadastro de um atendimento. Somente assim, o horário de encerramento poderá ser estimado corretamente.";
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
