using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/*
 * Criada em: 08/11/21
 */
namespace Desktop.Forms
{
    public partial class FormCadastroLarTemporario : Form
    {
        private List<LarTemporario> _laresTemporários;
        private LarTemporario _larTemporario = new LarTemporario();

        public FormCadastroLarTemporario()
        {
            InitializeComponent();
            CarregaComboBoxEstadosBrasil();
            CarregarLares();
            CarregarToolTips();
        }

        private void CarregarLares()
        {
            this.Cursor = Cursors.WaitCursor;
            lvLar.Items.Clear();
            _laresTemporários = LarTemporarioDAO.GetTodosRegistros(Global.Entidade.Id).OrderBy(k => k.Nome).ToList();

            if (_laresTemporários.Any())
            {
                var contaLinha = 0;

                foreach (var lar in _laresTemporários)
                {
                    var lvi = new ListViewItem();

                    lvi.Text = lar.Id.ToString();
                    lvi.SubItems.Add(lar.Nome == null ? string.Empty : lar.Nome);

                    if (lar.EnderecoLarTemporario != null)
                    {
                        var endereco = string.Empty;

                        if (!string.IsNullOrEmpty(lar.EnderecoLarTemporario.Cidade))
                            endereco = lar.EnderecoLarTemporario.Cidade;

                        if (!string.IsNullOrEmpty(lar.EnderecoLarTemporario.Bairro))
                            if (string.IsNullOrEmpty(endereco))
                                endereco = lar.EnderecoLarTemporario.Bairro;
                            else
                                endereco += $" - {lar.EnderecoLarTemporario.Bairro}";

                        if (!string.IsNullOrEmpty(lar.EnderecoLarTemporario.Logradouro))
                        {
                            if (string.IsNullOrEmpty(endereco))
                                endereco = lar.EnderecoLarTemporario.Logradouro;
                            else
                                endereco += $" - {lar.EnderecoLarTemporario.Logradouro}";

                            if (!string.IsNullOrEmpty(lar.EnderecoLarTemporario.Numero))
                            {
                                endereco += $", num: {lar.EnderecoLarTemporario.Numero}";

                                if (!string.IsNullOrEmpty(lar.EnderecoLarTemporario.Complemento))
                                    endereco += $", comp: {lar.EnderecoLarTemporario.Complemento}";
                            }
                        }
                        lvi.SubItems.Add(endereco);
                    }
                    else
                    {
                        lvi.SubItems.Add(string.Empty);
                    }

                    if (contaLinha % 2 == 0)
                        lvi.BackColor = Color.LightCyan;
                    contaLinha++;

                    lvLar.Items.Add(lvi);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void CarregarToolTips()
        {
            toolTipNovo.SetToolTip(btnNovo, "Permite cadastrar um novo lar temporário no sistema.");
            toolTipEditar.SetToolTip(btnEditar, "Permite editar os dados de um lar temporário no sistema.");
            toolTipExcluir.SetToolTip(btnExcluir, "Permite excluir um lar temporário no sistema.");
        }

        private void SetLarTemporario()
        {
            txtNome.Text = _larTemporario.Nome;
            dtpNascimento.Value = _larTemporario.DataNascimento == DateTime.MinValue ? DateTime.Today : _larTemporario.DataNascimento;
            txtCPF.Text = _larTemporario.CPF;
            txtRG.Text = _larTemporario.RG;
            txtTelefone.Text = _larTemporario.Telefone;
            txtEmail.Text = _larTemporario.Email;

            if (_larTemporario.EnderecoLarTemporario != null)
            {
                maskCEP.Text = _larTemporario.EnderecoLarTemporario.CEP;
                txtLogradouro.Text = _larTemporario.EnderecoLarTemporario.Logradouro;
                txtNumero.Text = _larTemporario.EnderecoLarTemporario.Numero;
                txtComplemento.Text = _larTemporario.EnderecoLarTemporario.Complemento;
                txtBairro.Text = _larTemporario.EnderecoLarTemporario.Bairro;
                txtCidade.Text = _larTemporario.EnderecoLarTemporario.Cidade;
                cbEstado.SelectedIndex = _larTemporario.EnderecoLarTemporario.Estado;
            }
        }

        private void CarregaComboBoxEstadosBrasil()
        {
            this.cbEstado.DataSource = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumEstadosBrasil>();
        }

        private void HabilitarComponentes(bool habilita)
        {
            btnEditar.Visible = habilita;
            btnExcluir.Visible = habilita;
        }

        private void EditarDados()
        {
            btnSalvar.Visible = true;

            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvLar, "editar"))
            {
                panelCadastro.Visible = true;

                if (Convert.ToInt32(lvLar.SelectedItems[0].SubItems[0].Text) is int idLar)
                {
                    _larTemporario = _laresTemporários.Find(k => k.Id == idLar);
                    SetLarTemporario();
                }
            }
        }

        private bool DadosValidos()
        {
            var dadosValidos = true;

            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                errorProvider.SetError(txtNome, "Informe o nome do responsável pelo lar temporário.");
                dadosValidos = false;
            }

            return dadosValidos;
        }

        #region Eventos

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarComponentes(false);
            panelCadastro.Visible = true;
            lvLar.Enabled = false;
            btnSalvar.Visible = true ;
        }

        private void lvLar_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvLar.SelectedItems.Count > 0)
                HabilitarComponentes(true);
            else
                HabilitarComponentes(false);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvLar, "excluir"))
            {
                var solicitacao = FuncoesGerais.MensagemDesejaExcluir();

                if (solicitacao.Equals(DialogResult.OK) || solicitacao.Equals(DialogResult.Yes))
                {
                    var lar = new LarTemporario();

                    if (Convert.ToInt32(lvLar.SelectedItems[0].SubItems[0].Text) is int idLar)
                    {
                        lar = _laresTemporários.Find(k => k.Id == idLar);
                        var excluir = LarTemporarioDAO.Apagar(lar);

                        if (string.IsNullOrEmpty(excluir))
                        {
                            FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Excluir);
                            this.Close();
                        }
                        else
                        {
                            var possuiChaveEstrangeira = excluir.ToLower().Contains("foreign key");
                            if (possuiChaveEstrangeira)
                                FuncoesGerais.MensagemFalhaRestricaoChave();
                            else
                                FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Excluir);
                        }
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarDados();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (DadosValidos())
            {
                var endereco = new EnderecoLarTemporario()
                {
                    Estado = cbEstado.SelectedIndex,
                    CEP = maskCEP.Text,
                    Logradouro = txtLogradouro.Text,
                    Numero = txtNumero.Text,
                    Complemento = txtComplemento.Text,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    Entidade = Global.Entidade
                };

                _larTemporario.Nome = txtNome.Text;
                _larTemporario.DataNascimento = dtpNascimento.Value;
                _larTemporario.CPF = txtCPF.Text;
                _larTemporario.RG = txtRG.Text;
                _larTemporario.Telefone = txtTelefone.Text;
                _larTemporario.Email = txtEmail.Text;
                _larTemporario.Entidade = Global.Entidade;
                _larTemporario.EnderecoLarTemporario = endereco;

                if (LarTemporarioDAO.Salvar(_larTemporario))
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

        private void lvLar_DoubleClick(object sender, EventArgs e)
        {
            EditarDados();
        }

        #endregion Eventos

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                if (!FuncoesGerais.EmailEhValido(txtEmail.Text))
                    MessageBox.Show("O e-mail informado é inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
