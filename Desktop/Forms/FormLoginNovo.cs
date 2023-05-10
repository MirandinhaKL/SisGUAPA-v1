using Desktop.Classes;
using Desktop.DependencyInjection;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SisGUAPA.Forms
{
    public partial class FormLoginNovo : Form
    {
        private IUsuarioService _usuarioService;
        private IEmailService _emailService;

        public FormLoginNovo()
        {
            InitializeComponent();
            InitializeServices();
            CarregarTooltips();
        }

        private void InitializeServices()
        {
            _usuarioService = IocKernel.Get<IUsuarioService>();
            _emailService = IocKernel.Get<IEmailService>();
        }

        private void CarregarTooltips()
        {
            toolTip.SetToolTip(btnSair, "Fecha o sistema.");
            toolTip.SetToolTip(btnLogin, "Efeuta o login no sistema.");
            toolTip.SetToolTip(btnCadastro, "Cria o cadastro no sistema.");
            toolTip.SetToolTip(BtnSenha, "Envia por e-mail a senha cadastrada.");
        }

        //TODO: Envio do e-mail não esta funcionando.
        private async void EnviarEmailComSenha()
        {
            this.Cursor = Cursors.WaitCursor;

            string destinatario = txtEmail.Text;

            (bool, string) resultadoSenha = _usuarioService.GetSenha(destinatario);
            if (!resultadoSenha.Item1)
            {
                MessageBox.Show(resultadoSenha.Item2, "Erro de preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                txtEmail.Focus();
                return;
            }

            (string destinatario, string titulo, string mensagem) camposEmail = _usuarioService.GetDadosEmailRecuperacaoSenha(destinatario, resultadoSenha.Item2);

            string resultado = await _emailService.EnviarEmailAsync(camposEmail.destinatario, camposEmail.titulo, camposEmail.mensagem);

            if (!string.IsNullOrEmpty(resultado))
                MessageBox.Show(resultado, "Erro ao enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(_usuarioService.GetMensagemEnvioSenha(), "E-mail enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Cursor = Cursors.Default;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            Dictionary<string, string> mensagensErro = _usuarioService.GetMensagemDadosInvalidos();

            if (email == string.Empty)
            {
                MessageBox.Show(mensagensErro["EMAIL"], "Ausência do e-mail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (senha == string.Empty)
            {
                MessageBox.Show(mensagensErro["SENHA"], "Ausência da senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            Usuario usuario = _usuarioService.GetUsuario(email, senha);

            string mensagemErro = _usuarioService.UsuarioEhValido(usuario.Id);
            if (!string.IsNullOrEmpty(mensagemErro))
            {
                MessageBox.Show(mensagemErro, "Falha ao logar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Global.UsuarioLogado = usuario;
                Global.Entidade = new Entidade() { Id = usuario.Entidade.Id };
                new FormBase().Show();
                this.Hide();
            }
            this.Cursor = Cursors.Default;
        }

        private void BtnSenha_Click(object sender, EventArgs e)
        {
            EnviarEmailComSenha();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            FormEntidade formONG = new FormEntidade();
            formONG.CustomFormClose += CloseListener;
            formONG.Show();
            this.Hide();
        }

        private void CloseListener(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}