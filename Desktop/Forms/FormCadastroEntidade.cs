using Desktop.Classes;
using Desktop.DependencyInjection;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SisGUAPA.Forms
{
    public partial class FormEntidade : Form
    {
        private IEntidadeService _entidadeService;
        private IControleSistemaService _sistemaService;
        private IAnimalService _animalService;

        public FormEntidade()
        {
            InitializeComponent();
            InitializeServices();
            CarregaComboBoxTipoEntidade();
            CarregaComboBoxEstadosBrasil();
        }

        private void InitializeServices()
        {
            _entidadeService = IocKernel.Get<IEntidadeService>();
            _sistemaService = IocKernel.Get<IControleSistemaService>();
            _animalService = IocKernel.Get<IAnimalService>();
        }

        private bool SalvarEntidade()
        {
            var entidade = new Entidade()
            {
                TipoEntidade = comboTipoEntidade.SelectedIndex,
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                DataCadastro = DateTime.Now,
                Estado = cbEstado.SelectedIndex,
                Senha = txtSenha1.Text,
                Telefone = txtTelefone.Text,
                CNPJ = txtCNPJ.Text,
            };

            var endereco = new EnderecoEntidade()
            {
                Estado = cbEstado.SelectedIndex,
                CEP = txtCEP.Text,
                Logradouro = txtLogradouro.Text,
                Numero = txtNumero.Text,
                Complemento = txtComplemento.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Entidade = entidade
            };

            var usuario = new Usuario()
            {
                Email = txtEmail.Text,
                Nome = txtNome.Text,
                Senha = txtSenha1.Text,
                GrauAcesso = (int)Enumeracoes.EnumGrauAcesso.Administrador,
                DataIngresso = DateTime.Now
            };

            entidade.SetEnderecoEntidade(endereco);
            entidade.AddUsuario(usuario);

            entidade.Id = _entidadeService.SalvarEntidade(entidade);
            if (entidade.Id == (int)Enumeracoes.EnumStatusDaAcao.FALHA)
                return false;

            Global.UsuarioLogado = usuario;
            Global.Entidade = entidade;

            return true;
        }

        private void CarregaComboBoxTipoEntidade()
        {
            if (comboTipoEntidade.Items.Count == 0)
            {
                foreach (Enumeracoes.EnumTipoEntidades item in FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumTipoEntidades>())
                    this.comboTipoEntidade.Items.Add(item.GetDescricaoEnum());

                this.comboTipoEntidade.SelectedIndex = (int)Enumeracoes.EnumTipoEntidades.ONG;
            }
        }

        private void CarregaComboBoxEstadosBrasil()
        {
            this.cbEstado.DataSource = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumEstadosBrasil>();
            this.cbEstado.SelectedIndex = -1;
        }

        private bool DadosValidos()
        {
            Dictionary<string, string> mensagensErro = _entidadeService.GetMensagemDadosInvalidos();
            bool dadosValidos = true;

            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                errorProvider.SetError(txtNome, mensagensErro["NOME"]);
                dadosValidos = false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, mensagensErro["EMAIL"]);
                dadosValidos = false;
            }
            if (string.IsNullOrEmpty(txtSenha1.Text))
            {
                errorProvider.SetError(txtSenha1, mensagensErro["SENHA"]);
                dadosValidos = false;
            }
            if (string.IsNullOrEmpty(txtSenha2.Text))
            {
                errorProvider.SetError(txtSenha2, mensagensErro["SENHA_REP"]);
                dadosValidos = false;
            }
            if (!txtSenha1.Text.Equals(txtSenha2.Text))
            {
                errorProvider.SetError(txtSenha2, mensagensErro["SENHA_REP_DIFERENTE"]);
                dadosValidos = false;
            }
            return dadosValidos;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!DadosValidos())
                return;

            string emailJaCadastrado = _entidadeService.EntidadeJaSalva(txtEmail.Text);
            if (!string.IsNullOrEmpty(emailJaCadastrado))
            {
                MessageBox.Show(emailJaCadastrado, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            if (SalvarEntidade())
            {
                _sistemaService.RegistrarCriacaoBaseDados();
                _sistemaService.RegistrarCriacaoEntidade(Global.Entidade);
                _animalService.SalvarDadosIniciaisDoSistema(Global.Entidade);
                new FormBase().Show();
                this.Hide();
            }
            else
            {
                string mensagem = _entidadeService.GetMensagemDeErro()["SALVAR"];
                MessageBox.Show(mensagem, "Erro de cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        #region Eventos associados ao fechamento da janela

        public delegate void CustomFormCloseHandler(object sender, FormClosedEventArgs e);
        public event CustomFormCloseHandler CustomFormClose;
        private void FormEntidade_FormClosed(object sender, FormClosedEventArgs e)
        {
            CustomFormClose(sender, e);
        }

        #endregion
    }
}