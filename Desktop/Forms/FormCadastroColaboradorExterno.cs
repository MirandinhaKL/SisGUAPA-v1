using Desktop.Classes;
using Desktop.DependencyInjection;
using Repositorio.Classes;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/*
 * Criado em: 12/11/21 
 * Alterado em: 05/06/23
 */

namespace Desktop.Forms
{
    public partial class FormCadastroColaboradorExterno : Form
    {
        private IColaboradorExternoService _colaboradorService;
        private List<ColaboradorExterno> _colaboradoresExternos;
        private ColaboradorExterno _colaboradorExterno = new ColaboradorExterno();

        public FormCadastroColaboradorExterno()
        {
            InitializeComponent();
            InitializeServices();
            CarregarToolTips();
            CarregaComboBoxEstadosBrasil();
            CarregarColaboradores();
        }
        private void InitializeServices()
        {
            _colaboradorService = IocKernel.Get<IColaboradorExternoService>();
        }
        private void CarregarColaboradores()
        {
            this.Cursor = Cursors.WaitCursor;
            lvColaboradores.Items.Clear();
            _colaboradoresExternos = _colaboradorService.GetColaboradorExternosAtivos(Global.Entidade.Id);

            if (_colaboradoresExternos.Any())
            {
                var contaLinha = 0;

                foreach (var colaborador in _colaboradoresExternos)
                {
                    var lvi = new ListViewItem();

                    lvi.Text = colaborador.Id.ToString();
                    lvi.SubItems.Add(colaborador.NomeEmpresa == null ? string.Empty : colaborador.NomeEmpresa);
                    lvi.SubItems.Add(colaborador.NomeColaborador == null ? string.Empty : colaborador.NomeColaborador);
                    lvi.SubItems.Add(colaborador.Cargo == null ? string.Empty : colaborador.Cargo);
                    lvi.SubItems.Add(colaborador.Telefone == null ? string.Empty : colaborador.Telefone);
                    lvi.SubItems.Add(colaborador.Email == null ? string.Empty : colaborador.Email);

                    if (contaLinha % 2 == 0)
                        lvi.BackColor = Color.LightCyan;
                    contaLinha++;

                    lvColaboradores.Items.Add(lvi);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void CarregaComboBoxEstadosBrasil()
        {
            this.cbEstado.DataSource = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumEstadosBrasil>();
        }

        private bool DadosValidos()
        {
            var dadosValidos = true;

            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtNomeEmpresa.Text))
            {
                errorProvider.SetError(txtNomeEmpresa, "Informe o nome da empresa onde trabalha o colaborador.");
                dadosValidos = false;
            }
            if (string.IsNullOrEmpty(txtNomeColaborador.Text))
            {
                errorProvider.SetError(txtNomeColaborador, "Informe o nome do colaborador responsável pelo atendimento.");
                dadosValidos = false;
            }
            if (string.IsNullOrEmpty(txtCargo.Text))
            {
                errorProvider.SetError(txtCargo, "Informe o cargo ou função do colaborador.");
                dadosValidos = false;
            }

            return dadosValidos;
        }

        private void CarregarToolTips()
        {
            toolTipNovo.SetToolTip(btnNovo, "Permite cadastrar um novo colaborador externo no sistema.");
            toolTipEditar.SetToolTip(btnEditar, "Permite editar os dados de um colaborador externo selecionado na lista abaixo.");
            toolTipExcluir.SetToolTip(btnExcluir, "Permite excluir os dados de um colaborador externo selecionado na lista abaixo.");
        }

        private void HabilitarComponentes(bool habilitar)
        {
            panelCadastro1.Visible = panelCadastro.Visible = panelCadastro0.Visible = habilitar;
            panelCadastro.Visible = habilitar;
            btnSalvar.Visible = habilitar;
        }

        private void EditarDados()
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvColaboradores, "editar"))
            {
                HabilitarComponentes(true);
                
                if (Convert.ToInt32(lvColaboradores.SelectedItems[0].SubItems[0].Text) is int idColaborador)
                {
                    _colaboradorExterno = _colaboradoresExternos.Find(k => k.Id == idColaborador);
                    SetColaborador();
                }
            }
        }

        private void SetColaborador()
        {
            txtNomeEmpresa.Text = _colaboradorExterno.NomeEmpresa;
            txtNomeColaborador.Text = _colaboradorExterno.NomeColaborador;
            txtCargo.Text = _colaboradorExterno.Cargo;
            txtEmail.Text = _colaboradorExterno.Email;
            txtTelefone.Text = _colaboradorExterno.Telefone;

            if (_colaboradorExterno.EnderecoColaboradorExterno != null)
            {
                maskCEP.Text = _colaboradorExterno.EnderecoColaboradorExterno.CEP;
                txtLogradouro.Text = _colaboradorExterno.EnderecoColaboradorExterno.Logradouro;
                txtNumero.Text = _colaboradorExterno.EnderecoColaboradorExterno.Numero;
                txtComplemento.Text = _colaboradorExterno.EnderecoColaboradorExterno.Complemento;
                txtBairro.Text = _colaboradorExterno.EnderecoColaboradorExterno.Bairro;
                txtCidade.Text = _colaboradorExterno.EnderecoColaboradorExterno.Cidade;
                cbEstado.SelectedIndex = _colaboradorExterno.EnderecoColaboradorExterno.Estado;
            }
            else
            {
                LimparCamposEndereco();
            }
        }

        private void LimparCampos()
        {
            _colaboradorExterno = new ColaboradorExterno();
            txtNomeEmpresa.Text = string.Empty;
            txtNomeColaborador.Text = string.Empty;
            txtCargo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
        }

        private void LimparCamposEndereco()
        {
            maskCEP.Text = string.Empty;
            txtLogradouro.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            cbEstado.SelectedIndex = -1;
        }

        #region Eventos

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (DadosValidos())
            {
                var endereco = new EnderecoColaboradorExterno()
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

                _colaboradorExterno.NomeEmpresa = txtNomeEmpresa.Text;
                _colaboradorExterno.NomeColaborador = txtNomeColaborador.Text;
                _colaboradorExterno.Cargo = txtCargo.Text;
                _colaboradorExterno.Telefone = txtTelefone.Text;
                _colaboradorExterno.Email = txtEmail.Text;
                _colaboradorExterno.Entidade = Global.Entidade;
                _colaboradorExterno.Status = (int)Enumeracoes.EnumStatusUsuario.Ativo;

                _colaboradorExterno.SetEnderecoColaborador(endereco);

                var isSaved = _colaboradorService.SalvarOuAtualizarColaborador(_colaboradorExterno);
                if (isSaved)
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
            LimparCamposEndereco();
            HabilitarComponentes(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarDados();
        }

        private void lvColaboradores_DoubleClick(object sender, EventArgs e)
        {
            EditarDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvColaboradores, "excluir"))
            {
                var solicitacao = FuncoesGerais.MensagemDesejaExcluir();

                if (solicitacao.Equals(DialogResult.OK) || solicitacao.Equals(DialogResult.Yes))
                {
                    if (Convert.ToInt32(lvColaboradores.SelectedItems[0].SubItems[0].Text) is int idColaborador)
                    {
                        var colaborador = _colaboradoresExternos.Find(k => k.Id == idColaborador);
                        var status = _colaboradorService.InativarColaborador(colaborador);

                        if (status)
                        {
                            FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Excluir);
                            this.Close();
                        }
                        else
                        {
                            FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Excluir);
                        }
                    }
                    this.Close(); 
                }
            }
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

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #endregion Eventos
    }
}
