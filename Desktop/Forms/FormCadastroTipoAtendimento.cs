using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/*
 * Criado em: 15/11/21
 */

namespace Desktop.Forms
{
    public partial class FormCadastroTipoAtendimento : Form
    {
        private List<TipoAtendimento> _tiposDeAtendimentos;
        private TipoAtendimento _tipoAtendimento = new TipoAtendimento();
        private Dictionary<int, string> _duracoesTempo = new Dictionary<int, string>();
        private Dictionary<int, string> _frequencias = new Dictionary<int, string>();
        private Dictionary<int, string> _preAtendimentos = new Dictionary<int, string>();

        public FormCadastroTipoAtendimento()
        {
            InitializeComponent();
            CarregarToolTips();
            CarregarTiposAtendimentos();
        }

        private void CarregarTiposAtendimentos()
        {
            this.Cursor = Cursors.WaitCursor;
            lvAtendimentos.Items.Clear();
            _tiposDeAtendimentos = TipoAtendimentoDAO.GetTodosRegistros(Global.Entidade.Id).OrderBy(k => k.Nome).ToList();

            if (_tiposDeAtendimentos.Any())
            {
                var contaLinha = 0;

                foreach (var item in _tiposDeAtendimentos)
                {
                    var lvi = new ListViewItem();

                    lvi.Text = item.Id.ToString();
                    lvi.SubItems.Add(item.Nome == null ? string.Empty : item.Nome);
                    lvi.SubItems.Add(FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumDuracaoPadrao)item.DuracaoPadrao));
                    lvi.SubItems.Add(FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumFrequenciaRecomendada)item.Frequencia));
                    lvi.SubItems.Add(FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumPreAtendimento)item.enumPreAtendimento));

                    if (contaLinha % 2 == 0)
                        lvi.BackColor = Color.LightCyan;
                    contaLinha++;

                    lvAtendimentos.Items.Add(lvi);
                }
            }
            else
            {
                MessageBox.Show("Nenhum tipo de atendimento cadastrado.", "Status da ação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Cursor = Cursors.Default;
        }

        private void CarregarToolTips()
        {
            toolTipNovo.SetToolTip(btnNovo, "Permite cadastrar um novo tipo de atendimento veterinário no sistema.");
            toolTipEditar.SetToolTip(btnEditar, "Permite editar os dados de um tipo de atendimento veterinário no sistema.");
            toolTipExcluir.SetToolTip(btnExcluir, "Permite excluir um tipo de atendimento veterinário no sistema.");
        }

        private void CarregarComboDuracao()
        {
            if (_duracoesTempo == null || _duracoesTempo.Count == 0)
            {
                var duracoes = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumDuracaoPadrao>();
                foreach (var item in duracoes)
                    _duracoesTempo.Add((int)item, FuncoesGerais.GetDescricaoEnum(item));
            }
           
            cbDuracao.DataSource = _duracoesTempo.OrderBy(k => k.Key).ToList();
            cbDuracao.DisplayMember = "Value";

            if (_tipoAtendimento != null && _tipoAtendimento.Id > 0)
                cbDuracao.SelectedIndex = _tipoAtendimento.DuracaoPadrao;
            else
                cbDuracao.SelectedIndex = 0;
        }

        private void CarregarComboFrequencia()
        {
            if (_frequencias == null || _frequencias.Count == 0)
            {
                var frequencias = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumFrequenciaRecomendada>();
                foreach (var item in frequencias)
                    _frequencias.Add((int)item, FuncoesGerais.GetDescricaoEnum(item));
            }

            cbFrequencia.DataSource = _frequencias.OrderBy(k => k.Key).ToList();
            cbFrequencia.DisplayMember = "Value";

            if (_tipoAtendimento != null && _tipoAtendimento.Id > 0)
                cbFrequencia.SelectedIndex = _tipoAtendimento.Frequencia;
            else
                cbFrequencia.SelectedIndex = 0;
        }

        private void CarregarComboPreAtendimento()
        {
            if (_preAtendimentos == null || _preAtendimentos.Count == 0)
            {
                var preAtendimentos = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumPreAtendimento>();

                foreach (var item in preAtendimentos)
                    _preAtendimentos.Add((int)item, FuncoesGerais.GetDescricaoEnum(item));
            }

            cbPreAtendimento.DataSource = _preAtendimentos.OrderBy(k => k.Key).ToList();
            cbPreAtendimento.DisplayMember = "Value";

            if (_tipoAtendimento != null && _tipoAtendimento.Id > 0)
                cbPreAtendimento.SelectedIndex = _tipoAtendimento.enumPreAtendimento;
            else
                cbPreAtendimento.SelectedIndex = 0;
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            _tipoAtendimento = new TipoAtendimento();
        }

        private void HabilitarCampos()
        {
            panelTitulo.Visible = panelDados.Visible =  btnSalvar.Visible = true;
            CarregarComboDuracao();
            CarregarComboFrequencia();
            CarregarComboPreAtendimento();
        }

        private bool DadosValidos()
        {
            var dadosValidos = true;

            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                errorProvider.SetError(txtNome, "Informe o nome do tipo de atendimento. Por exemplo: atendimento médico, cirurgia, aplicação de vacina, etc.");
                dadosValidos = false;
            }

            return dadosValidos;
        }

        private void EditarDados()
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAtendimentos, "editar"))
            {
                HabilitarCampos();

                if (Convert.ToInt32(lvAtendimentos.SelectedItems[0].SubItems[0].Text) is int idAtendimento)
                {
                    _tipoAtendimento = _tiposDeAtendimentos.Find(k => k.Id == idAtendimento);
                    SetTipoAtendimento();
                }
            }
        }

        private void SetTipoAtendimento()
        {
            txtNome.Text = _tipoAtendimento.Nome;
            cbDuracao.SelectedIndex = _tipoAtendimento.DuracaoPadrao;
            cbFrequencia.SelectedIndex = _tipoAtendimento.Frequencia;
            cbPreAtendimento.SelectedIndex = _tipoAtendimento.enumPreAtendimento;
        }

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            HabilitarCampos();
        }

        private void lvAtendimentos_DoubleClick(object sender, EventArgs e)
        {
            EditarDados();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarDados();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (DadosValidos())
            {
                _tipoAtendimento.Nome = txtNome.Text;
                _tipoAtendimento.DuracaoPadrao = _duracoesTempo.FirstOrDefault(k => k.Value == cbDuracao.Text).Key;
                _tipoAtendimento.Frequencia = _frequencias.FirstOrDefault(k => k.Value == cbFrequencia.Text).Key;
                _tipoAtendimento.enumPreAtendimento = _preAtendimentos.FirstOrDefault(k => k.Value == cbPreAtendimento.Text).Key;
                _tipoAtendimento.Entidade = Global.Entidade;

                if (TipoAtendimentoDAO.Salvar(_tipoAtendimento))
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAtendimentos, "excluir"))
            {
                var solicitacao = FuncoesGerais.MensagemDesejaExcluir();

                if (solicitacao.Equals(DialogResult.OK) || solicitacao.Equals(DialogResult.Yes))
                {
                    if (Convert.ToInt32(lvAtendimentos.SelectedItems[0].SubItems[0].Text) is int idTipoAtendimento)
                    {
                        var tipoAtendimento = _tiposDeAtendimentos.Find(k => k.Id == idTipoAtendimento);
                        var status = TipoAtendimentoDAO.Apagar(tipoAtendimento);

                        if (string.IsNullOrEmpty(status))
                        {
                            FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Excluir);
                            this.Close();
                        }
                        else
                        {
                            var possuiChaveEstrangeira = status.ToLower().Contains("foreign key");
                            if (possuiChaveEstrangeira)
                                FuncoesGerais.MensagemFalhaRestricaoChave();
                            else
                                FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Excluir);
                        }
                    }
                }
            }
        }
        
        #endregion Eventos
    }
}
