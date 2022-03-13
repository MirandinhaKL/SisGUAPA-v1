using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormConsultaEntidade : Form
    {
        private List<Usuario> Usuarios = new List<Usuario>();

        public FormConsultaEntidade()
        {
            InitializeComponent();
            CarregarDadosEntidade();
            CarregarTooltips();
            CarregarColaboradores();
        }
        
        private void CarregarDadosEntidade()
        {
            var entidade = EntidadeDAO.GetEntidade(Global.Entidade.Id);
            txtNomeEntidade.Text = entidade.Nome;
            txtEmail.Text = entidade.Email;
            txtSenha.Text = entidade.Senha;
            txtCNPJ.Text = entidade.CNPJ;
            HabilitarCampos(false);
        }

        private void CarregarTooltips()
        {
            toolTip.SetToolTip(btnEditarEntidade, "Permite editas os dados da Entidade geridos por este sistema.");
            toolTip.SetToolTip(btnNovo, "Permite cadastrar um novo usuário ao sistema (funcionário, voluntário, etc.)."); 
            toolTip.SetToolTip(btnEditar, "Permite editar os dados de um usuário."); 
            toolTip.SetToolTip(btnExcluir, "Permite excluir os dados de um usuário."); 
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNomeEntidade.Enabled = txtEmail.Enabled = txtSenha.Enabled = txtCNPJ.Enabled = habilitar;
            txtLogradouro.Enabled = txtCidade.Enabled = txtCEP.Enabled = txtNum.Enabled = txtComp.Enabled = txtTelefone.Enabled = habilitar;
        }

        private void CarregarColaboradores()
        {
            this.Cursor = Cursors.WaitCursor;
            lvColaborador.Items.Clear();
            Usuarios.Clear();

            Usuarios = UsuarioDAO.GetTodosRegistrosSemAministrador(Global.Entidade.Id);

            foreach (var colaborador in Usuarios)
            {
                var lvi = new ListViewItem();
                lvi.Text = colaborador.Id.ToString();
                lvi.SubItems.Add(colaborador.Nome);
                lvi.SubItems.Add(colaborador.Email);
                lvi.SubItems.Add(colaborador.Cargo);
                lvi.SubItems.Add(colaborador.Telefone);
                lvi.SubItems.Add(FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumStatusUsuario)colaborador.Status));
                lvi.SubItems.Add(FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGrauAcesso)colaborador.GrauAcesso));

                lvColaborador.Items.Add(lvi);
            }
            this.Cursor = Cursors.Default;
        }

        private void EditarColaborador()
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvColaborador, "editar"))
            {
                var colaborador = GetColaboradorSelecionado();
                var formColaborador = new FormCadastroColaborador(colaborador);
                formColaborador.FormClosing += new FormClosingEventHandler(this.FormColaborador_FormClosing);
                formColaborador.ShowDialog();
            }
        }

        private Usuario GetColaboradorSelecionado()
        {
            if (Convert.ToInt32(lvColaborador.SelectedItems[0].SubItems[0].Text) is int idUsuario)
                return UsuarioDAO.LoadEntidadeById(idUsuario);
            return null;
        }

        #region Eventos


        private void btnNovo_Click(object sender, EventArgs e)
        {
            var formColaborador = new FormCadastroColaborador(new Usuario());
            formColaborador.FormClosing += new FormClosingEventHandler(this.FormColaborador_FormClosing);
            formColaborador.ShowDialog();
        }

        private void FormColaborador_FormClosing(object sender, FormClosingEventArgs e)
        {
            CarregarColaboradores();
        }

        private void btnEditarEntidade_Click(object sender, EventArgs e)
        {
            btnSalvar.Visible = true;
            HabilitarCampos(true);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void lvColaborador_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvColaborador.SelectedItems.Count > 0)
                btnEditar.Enabled = btnExcluir.Enabled = true;
            else
                btnEditar.Enabled = btnExcluir.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarColaborador();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvColaborador, "excluir"))
            {
                var solicitacao = FuncoesGerais.MensagemDesejaExcluir();

                if (solicitacao.Equals(DialogResult.OK) || solicitacao.Equals(DialogResult.Yes))
                {
                    var colaborador = GetColaboradorSelecionado();
                    var excluir = UsuarioDAO.Apagar(colaborador);

                    if (string.IsNullOrEmpty(excluir))
                    {
                        FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Excluir);
                        CarregarColaboradores();
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

        private void lvColaborador_DoubleClick(object sender, EventArgs e)
        {
            EditarColaborador();
        }

        #endregion Eventos
    }
}
