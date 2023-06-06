using Desktop.Classes;
using Desktop.DependencyInjection;
using Repositorio.Classes;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using Repositorio.Servicos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/*
 * Início em: 15/11/21
 * Atualizado em: 02/06/23
 */

namespace Desktop.Forms
{
    public partial class FormCadastroPatologia : Form
    {
        private IAtendimentoService _atendimentoService;
        private List<Patologia> _patologias;
        private Patologia _patologia = new Patologia();

        public FormCadastroPatologia()
        {
            InitializeComponent();
            InitializeServices();
            CarregarToolTips();
            CarregarPatologias();
        }

        private void InitializeServices()
        {
            _atendimentoService = IocKernel.Get<IAtendimentoService>();
        }

        private void CarregarPatologias()
        {
            this.Cursor = Cursors.WaitCursor;
            lvPatologia.Items.Clear();
            _patologias = _atendimentoService.GetPatologiasOrdenadasPorNome(Global.Entidade.Id);

            if (_patologias.Any())
            {
                var contaLinha = 0;

                foreach (var item in _patologias)
                {
                    var lvi = new ListViewItem();

                    lvi.Text = item.Id.ToString();
                    lvi.SubItems.Add(item.Nome == null ? string.Empty : item.Nome);
                    lvi.SubItems.Add(item.Descricao == null ? string.Empty : item.Descricao);

                    if (contaLinha % 2 == 0)
                        lvi.BackColor = Color.LightCyan;
                    contaLinha++;

                    lvPatologia.Items.Add(lvi);
                }
            }
            else
            {
                MessageBox.Show("Nenhuma patologia cadastrada.", "Status da ação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Cursor = Cursors.Default;
        }

        private void CarregarToolTips()
        {
            toolTipNovo.SetToolTip(btnNovo, "Permite cadastrar uma patologia no sistema.");
            toolTipEditar.SetToolTip(btnEditar, "Permite editar os dados de um tipo de uma patologia no sistema.");
            toolTipExcluir.SetToolTip(btnExcluir, "Permite excluir uma patologia no sistema.");
        }

        private void HabilitarCampos()
        {
            panelTitulo.Visible = panelDados.Visible = btnSalvar.Visible = true;
        }

        private bool DadosValidos()
        {
            var dadosValidos = true;

            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                errorProvider.SetError(txtNome, "Informe o nome da patologia. Por exemplo: Raiva, Leucemia Felina - FELV, ETC.");
                dadosValidos = false;
            }

            return dadosValidos;
        }

        private void EditarDados()
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvPatologia, "editar"))
            {
                HabilitarCampos();

                if (Convert.ToInt32(lvPatologia.SelectedItems[0].SubItems[0].Text) is int idPatologia)
                {
                    _patologia = _patologias.Find(k => k.Id == idPatologia);
                    SetPatologia();
                }
            }
        }

        private void SetPatologia()
        {
            txtNome.Text = _patologia.Nome;
            rtbDescricao.Text = _patologia.Descricao;
        }

        private void LimparCampos()
        {
            _patologia = new Patologia();
            txtNome.Text = rtbDescricao.Text = string.Empty;
        }

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (DadosValidos())
            {
                _patologia.Nome = txtNome.Text;
                _patologia.Descricao = rtbDescricao.Text;
                _patologia.Entidade = Global.Entidade;

                var statusSave = _atendimentoService.SalvarOuAtulizarPatologia(_patologia);
                if (statusSave)
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            HabilitarCampos();
        }

        private void lvPatologia_DoubleClick(object sender, EventArgs e)
        {
            EditarDados();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvPatologia, "excluir"))
            {
                var solicitacao = FuncoesGerais.MensagemDesejaExcluir();

                if (solicitacao.Equals(DialogResult.OK) || solicitacao.Equals(DialogResult.Yes))
                {
                    if (Convert.ToInt32(lvPatologia.SelectedItems[0].SubItems[0].Text) is int idPatologia)
                    {
                        var patologia = _patologias.Find(k => k.Id == idPatologia);
                        var status = _atendimentoService.ExcluirPatologia(patologia);

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

        #endregion
    }
}
