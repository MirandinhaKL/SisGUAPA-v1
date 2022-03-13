using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.Entidades;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SisGUAPA.Forms
{
    public partial class FormEntidade : Form
    {
        public FormEntidade()
        {
            InitializeComponent();
            CarregaComboBoxTipoEntidade();
            CarregaComboBoxEstadosBrasil();
        }

        private int SalvarEntidade()
        {
            if (DadosValidos())
            {
                var usuarioDAO = new UsuarioDAO();
                var entidadeDAO = new EntidadeDAO();

                var endereco = new EnderecoEntidade()
                {
                    Estado = cbEstado.SelectedIndex,
                    CEP = txtCEP.Text,
                    Logradouro = txtLogradouro.Text,
                    Numero = txtNumero.Text,
                    Complemento = txtComplemento.Text,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                };

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
                    //EnderecoEntidade = endereco
                };

                var idEntidade = (int) entidadeDAO.Inserir(entidade);

                if (idEntidade != (int)Enumeracoes.EnumStatusDaAcao.FALHA)
                {
                    Usuario usuario = new Usuario()
                    {
                        Email = txtEmail.Text,
                        Nome = txtNome.Text,
                        Senha = txtSenha1.Text,
                        GrauAcesso = (int)Enumeracoes.EnumGrauAcesso.Administrador,
                        DataIngresso = DateTime.Now,
                        Entidade = new Entidade { Id = idEntidade}
                    };

                    usuario.Id = (int) usuarioDAO.Inserir(usuario);
                    Global.UsuarioLogado = usuario;
                    Global.Entidade = usuario.Entidade;
                    return Global.UsuarioLogado.Id;
                }
                else
                {
                    return (int)Enumeracoes.EnumStatusDaAcao.FALHA;
                }

            }
            else
            {
                return (int)Enumeracoes.EnumStatusDaAcao.FALHA;
            }
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
            bool dadosValidos = true;

            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                errorProvider.SetError(txtNome, "Informe o nome da Entidade a qual este sistema irá gernciar os dados.");
                dadosValidos = false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Informe o e-mail da entidade que será utilizado para efetuar login neste sistema.");
                dadosValidos = false;
            }
            if (string.IsNullOrEmpty(txtSenha1.Text))
            {
                errorProvider.SetError(txtSenha1, "Informe a senha para utilização deste sistema.");
                dadosValidos = false;
            }
            if (string.IsNullOrEmpty(txtSenha2.Text))
            {
                errorProvider.SetError(txtSenha2, "Repita a senha informada no campo 'Senha'.");
                dadosValidos = false;
            }
            if (!txtSenha1.Text.Equals(txtSenha2.Text))
            {
                errorProvider.SetError(txtSenha2, "A repetição da senha não confere.");
                dadosValidos = false;
            }
            return dadosValidos;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (SalvarEntidade() != (int)Enumeracoes.EnumStatusDaAcao.FALHA)
            {
                new FormBase().Show();
                this.Hide();
            }
            else
            {
                var caminhoExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string caminhoArquivo = Path.Combine(caminhoExe, "ArquivoLogErros");
                MessageBox.Show("Falha ao cadastrar uma nova entidade no sistema. Verifique detalhes do erro em: " + caminhoArquivo,
                    "Erro de cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}