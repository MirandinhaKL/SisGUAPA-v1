using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormCadastroColaborador : Form
    {
        private Dictionary<int, string> GrausDeAcesso = new Dictionary<int, string>();
        private bool _isEdicao = false;
        private Usuario _usuario;

        public FormCadastroColaborador(Usuario usuario)
        {
            this.Cursor = Cursors.WaitCursor;
            
            InitializeComponent();
            CarregaComboBoxEstadosBrasil();
            CarregarComboAcesso();

            SetColaborador(usuario);

            this.Cursor = Cursors.Default;
        }

        private void SetColaborador(Usuario usuario)
        {
            _usuario = usuario;
            _isEdicao = _usuario != null && _usuario.Id > 0;

            if (_isEdicao)
            {
                txtNome.Text = _usuario.Nome;
                txtCargo.Text = _usuario.Cargo;
                dtpDataAdmissao.Value = _usuario.DataIngresso;
                dtpNascimento.Value = _usuario.DataNascimento == DateTime.MinValue ? DateTime.Today : _usuario.DataNascimento;
                txtCPF.Text = _usuario.CPF;
                txtRG.Text = _usuario.RG;
                txtTelefone.Text = _usuario.Telefone;

                SetStatus(_usuario.Status);

                if (_usuario.EnderecoUsuario != null)
                {
                    txtCEP.Text = _usuario.EnderecoUsuario.CEP;
                    txtLogradouro.Text = _usuario.EnderecoUsuario.Logradouro;
                    txtNumero.Text = _usuario.EnderecoUsuario.Numero;
                    txtComplemento.Text = _usuario.EnderecoUsuario.Complemento;
                    txtBairro.Text = _usuario.EnderecoUsuario.Bairro;
                    txtCidade.Text = _usuario.EnderecoUsuario.Cidade;
                }

                txtEmail.Text = _usuario.Email;
                txtSenha.Text = _usuario.Senha;
                cbGrauAcesso.SelectedIndex = _usuario.GrauAcesso;
            }
        }

        private void SetStatus(int enumStatus)
    {
            rbAtivo.Checked = rbAtivo.Checked = false;

            if (enumStatus == (int)Enumeracoes.EnumStatusUsuario.Ativo)
                rbAtivo.Checked = true;
            else
                rbInativo.Checked = true;
        }

        private void CarregarComboAcesso()
        {
            var acessos = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumGrauAcesso>();

            foreach (var item in acessos)
                GrausDeAcesso.Add((int)item, FuncoesGerais.GetDescricaoEnum(item));

            cbGrauAcesso.DataSource = GrausDeAcesso.OrderBy(k => k.Value).ToList();
            cbGrauAcesso.DisplayMember = "Value";

            if (_isEdicao && _usuario != null)
                cbGrauAcesso.SelectedIndex = _usuario.GrauAcesso;
            else
                cbGrauAcesso.SelectedIndex = 1;
        }

        private void CarregaComboBoxEstadosBrasil()
        {
            this.cbEstado.DataSource = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumEstadosBrasil>();
            if (_isEdicao && _usuario?.EnderecoUsuario != null)
                cbEstado.SelectedIndex = _usuario.EnderecoUsuario.Estado;
            else
                cbEstado.SelectedIndex = 19;
        }
        //TODO: Validar campos obrigatórios

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var endereco = new EnderecoUsuario()
            {
                Estado = cbEstado.SelectedIndex,
                CEP = txtCEP.Text,
                Logradouro = txtLogradouro.Text,
                Numero = txtNumero.Text,
                Complemento = txtComplemento.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Entidade = Global.Entidade
            };

            _usuario.Nome = txtNome.Text;
            _usuario.Cargo = txtCargo.Text;
            _usuario.DataIngresso = dtpDataAdmissao.Value;
            _usuario.DataNascimento = dtpNascimento.Value;
            _usuario.CPF = txtCPF.Text;
            _usuario.RG = txtRG.Text;
            _usuario.Telefone = txtTelefone.Text;
            _usuario.Email = txtEmail.Text;
            _usuario.GrauAcesso = GrausDeAcesso.FirstOrDefault(k => k.Value == cbGrauAcesso.Text).Key;
            _usuario.Senha = txtSenha.Text;
            _usuario.Status = rbAtivo.Checked == true ? (int)Enumeracoes.EnumStatusUsuario.Ativo : (int)Enumeracoes.EnumStatusUsuario.Inativo;
            _usuario.Entidade = Global.Entidade;
            _usuario.EnderecoUsuario = endereco;

            if (UsuarioDAO.Salvar(_usuario))
            {
                FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
                this.Close();
            }
            else
            {
                FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Salvar);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
