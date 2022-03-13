using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.Entidades;
using System;
using System.Windows.Forms;

namespace SisGUAPA.Forms
{
    public partial class FormLoginNovo : Form
    {
        public FormLoginNovo()
        {
            InitializeComponent();
            CarregarTooltips();
        }

        private void CarregarTooltips()
        {
            toolTip.SetToolTip(btnSair, "Fecha o sistema");
            toolTip.SetToolTip(btnLogin, "Efeuta o login no sistema");
            toolTip.SetToolTip(btnCadastro, "Cria o cadastro no sistema");
            toolTip.SetToolTip(BtnSenha, "Envia por e-mail a senha cadastrada");
        }

        private void linkCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void linkSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EnviarEmailComSenha();
        }

        private void EnviarEmailComSenha()
        {
            this.Cursor = Cursors.WaitCursor;
            var destinatario = txtEmail.Text;

            if (string.IsNullOrEmpty(destinatario))
            {
                MessageBox.Show("É necessário informar o e-mail utilixado para efetuar o login neste sistema.", "Erro de preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var senha = ObterSenha(destinatario);

            if (string.IsNullOrEmpty(senha))
                MessageBox.Show("O e-mail informado não está cadastrado neste sistema.", "Erro ao enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var titulo = "SisGUAPA - Recuperação da senha";
                var mensagem = "Olá, este é um e-mail automático enviado pelo SisGUAPA (Sistema de Gestão"
                    + "Unificado para Associações de Proteção Animal).\r\n" +
                    $"Conforme a sua solicitação a senha de acesso do sistema é: {senha}" +
                    "\r\n Obrigada pelo seu contato!";

                var resultado = Email.EnviarEmailAsync(destinatario, titulo, mensagem);

                if (!string.IsNullOrEmpty(resultado))
                    MessageBox.Show(resultado, "Erro ao enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("E-mail enviado com sucesso. Verifique a sua conta de e-mail para obter a sua senha.",
                        "E-mail enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default;
        }

        private string ObterSenha(string remetente)
        {
            return UsuarioDAO.GetPorLogin(remetente).Senha;
        }

        private void FormLoginNovo_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text;
            var senha = txtSenha.Text;

            this.Cursor = Cursors.WaitCursor;

            if (email == string.Empty)
                MessageBox.Show("Por favor, informe o e-mail utilizado no cadastro do sistema.", "Ausência do e-mail", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (senha == string.Empty)
                MessageBox.Show("Por favor, informe a senha utilizada no cadastro.", "Ausência da senha", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
            {
                var usuario = new UsuarioDAO().ValidarLogin(email, senha);

                if (usuario.Id == 0)
                    MessageBox.Show("O e-mail informado não está cadastrado no sistema.", "Falha ao logar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else if (usuario.Id == -1)
                    MessageBox.Show("A senha informada é inválida.", "Falha ao logar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else if (usuario.Id > 0)
                {
                    Global.UsuarioLogado = usuario;
                    Global.Entidade = new Entidade() { Id = usuario.Entidade.Id };
                    new FormBase().Show();
                    this.Hide();
                }
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
            formONG.Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}