using Desktop.Classes;
using Desktop.Relatorios.PDFs;
using Repositorio.DAO;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormCadastroAdocao : Form
    {
        private bool _isEdicaoAdotante = false;
        private bool _btnEditarSelecionado = false;

        private Adotante _adotante;
        private Animal _animalNovoSelecionado;
        private Animal _animalEdicaoSelecionado;
        private EnderecoAdotante _enderecoAdotante;

        public FormCadastroAdocao(Adotante adotante)
        {
            this.Cursor = Cursors.WaitCursor;
            this._btnEditarSelecionado = adotante.Id > 0;

            InitializeComponent();
            AjustarVisibilidadeButtonExcluirImagem(false);

            SetAdotante(adotante);

            CarregaComboBoxEstadosBrasil();
            txtCPF.Focus();
            txtCPF.Select();
            this.Cursor = Cursors.Default;
        }

        private void SetAdotante(Adotante adotante)
        {
            _adotante = adotante;
            _isEdicaoAdotante = _adotante != null && !string.IsNullOrEmpty(adotante.CPF);

            if (_isEdicaoAdotante)
            {
                CarregarDadosDoBD(_adotante);
                HabilitarPaineis(true);
                txtCPF.Enabled = false;
            }
            else
            {
                HabilitarPaineis(false);
            }
        }

        private void SetAdocoes()
        {
            if (_adotante.Adocoes != null && _adotante.Adocoes.Any())
                CarregaListViewAdocoes(_adotante.Adocoes);
        }

        private void CarregaListViewAdocoes(IList<Adocao> adocoes)
        {
            var contaLinha = 0;
            lvAdocao.Items.Clear();

            foreach (var item in adocoes)
            {
                var lvi = new ListViewItem();

                lvi.Text = item.Animal?.Id == null ? string.Empty : item.Animal.Id.ToString();
                lvi.SubItems.Add(item.Animal?.Identificacao == null ? string.Empty : item.Animal.Identificacao);
                lvi.SubItems.Add(item.Animal?.Nome == null ? string.Empty : item.Animal.Nome);
                lvi.SubItems.Add(item.Animal?.AnimalEspecie?.Descricao == null ? string.Empty : item.Animal.AnimalEspecie.Descricao);
                lvi.SubItems.Add(item.Animal?.Genero != null ? (FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)item.Animal.Genero)) : string.Empty);
                lvi.SubItems.Add(item.Animal?.DataNascimento == null ? string.Empty : item.Animal.DataNascimento.ToShortDateString());
                lvi.SubItems.Add(item.DataAdocao == null ? string.Empty : item.DataAdocao.ToShortDateString());

                if (contaLinha % 2 == 0)
                    lvi.BackColor = Color.LightCyan;

                contaLinha++;
                lvAdocao.Items.Add(lvi);
            }
        }

        private void CarregarDadosDoBD(Adotante adotante)
        {
            // Painel Adotante

            txtCPF.Text = adotante.CPF;
            txtCPF.Enabled = false;
            txtRG.Text = adotante.RG;
            txtNome.Text = adotante.Nome;
            dtpNascimento.Value = adotante.DataNascimento;
            txtEmail.Text = adotante.Email;
            txtProfissao.Text = adotante.Profissao;
            txtTelefone1.Text = adotante.Telefone1;
            txtTelefone2.Text = adotante.Telefone2;
            txtFacebook.Text = adotante.Facebook;
            txtInstagram.Text = adotante.Instagram;

            SetGenero(adotante.Genero);
            SetEstadoCivi(adotante.EstadoCivil);
            SetImagem(adotante.ImagemAdotante, pbAdotante, true);

            // Painel endereço
            SetEndereco(adotante.EnderecoAdotante);
            SetAdocoes();
        }

        private void SetEndereco(EnderecoAdotante enderecoAdotante)
        {
            if (enderecoAdotante?.Id != null)
            {
                _enderecoAdotante = EnderecoAdotanteDAO.GetById(enderecoAdotante.Id);
                txtCidade.Text = _enderecoAdotante.Cidade;
                txtBairro.Text = _enderecoAdotante.Bairro;
                txtComplemento.Text = _enderecoAdotante.Complemento;
                txtLogradouro.Text = _enderecoAdotante.Logradouro;
                txtNumero.Text = _enderecoAdotante.Numero;
                txtCEP.Text = _enderecoAdotante.CEP;
                rtbObservacao.Text = _enderecoAdotante.Observacao;
            }
        }

        private void SetImagem(byte[] imagem, PictureBox pictureBox, bool isAdotante)
        {
            if (imagem != null && imagem.Length > 0)
            {
                pictureBox.Image = FuncoesGerais.ConverteByteParaBitmap(imagem);

                if (isAdotante)
                    AjustarVisibilidadeButtonExcluirImagem(true);
            }
        }

        private void AjustarVisibilidadeButtonExcluirImagem(bool visivel)
        {
            btnExcluir.Visible = visivel;
        }

        private void SetEstadoCivi(int enumEstadoCivil)
        {
            rbSolteiro.Checked = rbCasado.Checked = rbEstCivilOutros.Checked = false;

            if ((int)Enumeracoes.EnumEstadoCivil.Solteiro == enumEstadoCivil)
                rbSolteiro.Checked = true;
            else if ((int)Enumeracoes.EnumEstadoCivil.Casado == enumEstadoCivil)
                rbCasado.Checked = true;
            else
                rbEstCivilOutros.Checked = true;
        }

        private void SetGenero(int enumGenero)
        {
            rbFeminino.Checked = rbMasculino.Checked = rbGeneroOutros.Checked = false;

            if ((int)Enumeracoes.EnumGenero.Feminino == enumGenero)
                rbFeminino.Checked = true;
            else if ((int)Enumeracoes.EnumGenero.Masculino == enumGenero)
                rbMasculino.Checked = true;
            else
                rbGeneroOutros.Checked = true;
        }

        private void HabilitarPaineis(bool status)
        {
            #region PainelAdotante
            btnEditarAdocao.Enabled = pbAdotante.Enabled = btnSelecionar.Enabled = txtRG.Enabled = txtNome.Enabled = dtpNascimento.Enabled =
            gbGenero.Enabled = gbEstadoCivil.Enabled = txtEmail.Enabled = txtProfissao.Enabled = txtTelefone1.Enabled = txtTelefone2.Enabled =
            txtFacebook.Enabled = txtInstagram.Enabled = lblImagem.Enabled = lblRG.Enabled = lblNome.Enabled = lblNascimento.Enabled =
            lblEmail.Enabled = lblProfissao.Enabled = lblTelefone1.Enabled = lblTelefone2.Enabled = lblFacebook.Enabled = lblInstagram.Enabled = status;
            #endregion PainelAdotante
            panelAbaAdocao.Enabled = panelEndereco.Enabled = status;
        }

        private void CarregaComboBoxEstadosBrasil()
        {
            this.cbEstado.DataSource = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumEstadosBrasil>();
            if (_isEdicaoAdotante && _enderecoAdotante != null)
                cbEstado.SelectedIndex = _enderecoAdotante.Estado;
            else
                cbEstado.SelectedIndex = 19;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (DadosAdotanteValidos() && DadosAdocaoValidos())
            {
                var endereco = new EnderecoAdotante()
                {
                    Entidade = Global.UsuarioLogado.Entidade,
                    Estado = cbEstado.SelectedIndex,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    Complemento = txtComplemento.Text,
                    Logradouro = txtLogradouro.Text,
                    Numero = txtNumero.Text,
                    CEP = txtCEP.Text,
                    Observacao = rtbObservacao.Text
                };

                _adotante.CPF = txtCPF.Text;
                _adotante.RG = txtRG.Text;
                _adotante.Nome = txtNome.Text;
                _adotante.DataNascimento = Convert.ToDateTime(dtpNascimento.Text);
                _adotante.Genero = GetGenero();
                _adotante.EstadoCivil = GetEstadoCivil();
                _adotante.Email = txtEmail.Text;
                _adotante.Profissao = txtProfissao.Text;
                _adotante.Telefone1 = txtTelefone1.Text;
                _adotante.Telefone2 = txtTelefone2.Text;
                _adotante.Facebook = txtFacebook.Text;
                _adotante.Instagram = txtInstagram.Text;
                _adotante.EnderecoAdotante = endereco;
                _adotante.Entidade = Global.Entidade;
                _adotante.ImagemAdotante = FuncoesGerais.ConverterBitmapParaByte(pbAdotante.Image);

                var dataAdocao = Convert.ToDateTime(dtpAdocao.Text);

                if (_animalNovoSelecionado != null)
                {
                    if (!IdadeNascimentoMaiorQueAdocao(_animalNovoSelecionado.DataNascimento, dataAdocao))
                        return;
                   
                    _animalNovoSelecionado.AnimalStatus = (int)Enumeracoes.EnumStatusAnimal.Adotado;

                    var adocao = new Adocao()
                    {
                        Adotante = _adotante,
                        Animal = _animalNovoSelecionado,
                        DataAdocao = Convert.ToDateTime(dtpAdocao.Text),
                        DoadorAnimal = txtResponsavelAdocao.Text,
                        LocalAdocao = txtLocal.Text,
                        Observacao = rtbObservacaoAdocao.Text,
                        Entidade = Global.Entidade
                    };

                    _adotante.Adocoes.Add(adocao);
                }

                if (_animalEdicaoSelecionado != null)
                {
                    if (!IdadeNascimentoMaiorQueAdocao(_animalEdicaoSelecionado.DataNascimento, dataAdocao))
                        return;

                    var adocaoSelecionada = _adotante.Adocoes.Where(item => item.Animal.Id == _animalEdicaoSelecionado.Id).FirstOrDefault();
                    adocaoSelecionada.DataAdocao = dataAdocao;
                    adocaoSelecionada.DoadorAnimal = txtResponsavelAdocao.Text;
                    adocaoSelecionada.LocalAdocao = txtLocal.Text;
                    adocaoSelecionada.Observacao = rtbObservacaoAdocao.Text;
                    adocaoSelecionada.Entidade = Global.Entidade;
                    _adotante.Adocoes.Remove(adocaoSelecionada);
                    _adotante.Adocoes.Add(adocaoSelecionada);
                }
                if (AdotanteDAO.Salvar(_adotante))
                {
                    FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
                    CarregaListViewAdocoes(_adotante.Adocoes);
                    LimparCamposAdocao();
                }
                else
                {
                    FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Salvar);
                }
            }
        }

        private int GetEstadoCivil()
        {
        if (rbSolteiro.Checked)
            return (int)Enumeracoes.EnumEstadoCivil.Solteiro;

        else if (rbCasado.Checked)
            return (int)Enumeracoes.EnumEstadoCivil.Casado;

        else
            return (int)Enumeracoes.EnumEstadoCivil.Outros;
        }

        private int GetGenero()
        {
            if (rbFeminino.Checked)
                return (int)Enumeracoes.EnumGenero.Feminino;

            else if (rbMasculino.Checked)
                return (int)Enumeracoes.EnumGenero.Masculino;

            else
                return (int)Enumeracoes.EnumGenero.NaoSei;
        }

        private bool DadosAdotanteValidos()
        {
            var dadosValidos = true;

            errorTxt.Clear();

            if (string.IsNullOrEmpty(txtCPF.Text))
            {
                errorTxt.SetError(txtCPF, "Informe o CPF do adotante.");
                dadosValidos = false;
            }

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                errorTxt.SetError(txtNome, "Informe o nome do adotante.");
                dadosValidos = false;
            }

            if (string.IsNullOrEmpty(txtLogradouro.Text))
            {
                errorTxt.SetError(txtLogradouro, "Informe o logradouro do adotante.");
                dadosValidos = false;
            }

            if (!dadosValidos)
                tabCadastroAdotante.SelectedTab = tabAdotante;

            return dadosValidos;
        }

        private bool DadosAdocaoValidos()
        {
            if (_animalNovoSelecionado == null && _animalEdicaoSelecionado == null && (!string.IsNullOrEmpty(txtResponsavelAdocao.Text) || 
                !string.IsNullOrEmpty(txtLocal.Text) || !string.IsNullOrEmpty(rtbObservacaoAdocao.Text)))
            {
                var mensagem = "É possível salvar os dados do adotante sem ter um animal associado na adoção. " +
                    "Porém, é necessário para isso que os campos: " +
                    "'Responsável pela adoção', 'Local' e 'Observação' não contenham nenhuma informação. " +
                    "Deseja apagar esses dados e salvar as informações somente do adotante? ";

                var resultado = MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK || resultado == DialogResult.Yes)
                {
                    txtResponsavelAdocao.Text = rtbObservacao.Text = txtLocal.Text = string.Empty;
                    dtpAdocao.Value = DateTime.Today;
                    return true;
                }
                else
                {
                    var informacao = "As informações não foram salvas. Selecione um animal clicando no botão 'pesquisar' e salve novamente para não " +
                        "perder nenhuma informação.";

                    MessageBox.Show(informacao, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    return false;
                }
            }
            return true;
        }

        private bool IdadeNascimentoMaiorQueAdocao(DateTime dataNascimento, DateTime dataAdocao)
        {

            if (DateTime.Compare(dataNascimento.Date, dataAdocao.Date) <= 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show($"A data de nascimento do animal ({dataNascimento.Date.ToShortDateString()}) deve ser maior que a data da adoção do mesmo. Os dados não foram salvos.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
             

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var formAnimal = new FormCadastroAnimal(new Animal());
            formAnimal.FormClosing += new FormClosingEventHandler(this.FormAdocao_FormClosing);
            formAnimal.ShowDialog();
        }

        private void FormAdocao_FormClosing(object sender, FormClosingEventArgs e)
        {
            //LimparComponentesTela();
            //CarregarAnimais();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var formConsulta = new FormConsultaAnimal(Enumeracoes.EnumTipoTela.Consulta);
            formConsulta.StartPosition = FormStartPosition.CenterScreen;
            formConsulta.FormBorderStyle = FormBorderStyle.Fixed3D;
            formConsulta.ControlBox = true;
            formConsulta.ClientSize = new System.Drawing.Size(900, 729);
            formConsulta.ShowDialog();
            _animalNovoSelecionado = formConsulta.AnimalSelecionado;
            CarregarAdocao();
          
        }

        private void CarregarAdocao()
        {
            if (_animalNovoSelecionado != null && !AnimalJaCadastradoParaEssaAodcao())
            {
                txtIdAnimal.Text = _animalNovoSelecionado.Identificacao;
                txtEspecie.Text = _animalNovoSelecionado.AnimalEspecie.Descricao;
                txtGenero.Text = (FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)_animalNovoSelecionado.Genero));
                txtNomeAnimal.Text = _animalNovoSelecionado.Nome;
                SetImagem(pbAnimal, _animalNovoSelecionado.Imagem);
            }
        }

        private bool AnimalJaCadastradoParaEssaAodcao()
        {
            var animalCadastrado = _adotante.Adocoes.Count > 0 && _adotante.Adocoes.Any(k => k.Animal.Id == _animalNovoSelecionado.Id);
            if (animalCadastrado)
            {
                var mensagem = "Este animal já foi cadastrado para este adotante. Se deseja editar os dados da adoção, " +
                    "dê um duplo clique sobre os dados do animal na lista abaixo (Animais adotados).";
                MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _animalNovoSelecionado = null;
            }
            return animalCadastrado;
        }

        private void SetImagem(PictureBox picture, byte[] imagem)
        {
            if (imagem != null && imagem.Length > 0)
                picture.Image = FuncoesGerais.ConverteByteParaBitmap(imagem);
        }

        private bool AdotanteJaCadastrado(Adotante adotante)
        {
            var retorno = AdotanteDAO.GetAdotanteByCPF(adotante);
            if (retorno == null)
            {
                _adotante = new Adotante();
                return false;
            }
            else
            {
                _adotante = retorno;
                return true;
            }
        }

        private Adocao GetAdocaoSelecionada()
        {
            var adocao = new Adocao();
            if (Convert.ToInt32(lvAdocao.SelectedItems[0].SubItems[0].Text) is int idAnimal)
                adocao = _adotante.Adocoes.FirstOrDefault(k => k.Animal.Id == idAnimal);
            return adocao;
        }

        private void HabilitarPainelAnimaisAdotados(bool habilitar)
        {
            btnEditarAdocao.Visible = btnImprimir.Visible = lvAdocao.Visible = habilitar;
        }

        private void EditarAdocao()
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAdocao, "editar"))
            {
                var adocao = GetAdocaoSelecionada();
                txtIdAnimal.Text = adocao.Animal.Identificacao;
                txtEspecie.Text = adocao.Animal.AnimalEspecie.Descricao;
                txtGenero.Text = (FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)adocao.Animal.Genero));
                txtNomeAnimal.Text = adocao.Animal.Nome;
                SetImagem(pbAnimal, adocao.Animal.Imagem);

                txtResponsavelAdocao.Text = adocao.DoadorAnimal;
                txtLocal.Text = adocao.LocalAdocao;
                rtbObservacaoAdocao.Text = adocao.Observacao;
                dtpAdocao.Value = adocao.DataAdocao;

                _animalEdicaoSelecionado = adocao.Animal;
                HabilitarPainelAnimaisAdotados(false);
                btnPesquisar.Enabled = false;
            }
        }

        private void LimparCamposAdocao()
        {
            txtIdAnimal.Text = txtEspecie.Text = txtGenero.Text = txtNomeAnimal.Text = string.Empty;
            pbAnimal.Image = null;
            txtResponsavelAdocao.Text = txtLocal.Text = rtbObservacaoAdocao.Text = string.Empty;
            dtpAdocao.Value = DateTime.Today;
            _animalEdicaoSelecionado = null;
            _animalNovoSelecionado = null;
            HabilitarPainelAnimaisAdotados(true);
            btnPesquisar.Enabled = true;
        }

        #region Eventos

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCamposAdocao();
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            if (txtCPF.TextLength == 11)
            {
                HabilitarPaineis(true);
                var adotante = new Adotante() { CPF = txtCPF.Text };
               
                if (AdotanteJaCadastrado(adotante))
                {
                    CarregarDadosDoBD(_adotante);
                    if (!_btnEditarSelecionado)
                        MessageBox.Show("Este CPF já está cadastrado no sistema.", "Adotante cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtCPF.Enabled = false;
                txtRG.Focus();
                txtRG.Select();
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            ofdAdotante.Filter = "Imagem (*.jpg, *.png)| *.jpg; *.png";

            if (ofdAdotante.ShowDialog() == DialogResult.OK)
            {
                var imagem = new Bitmap(ofdAdotante.FileName);
                var size = new Size(300, 400);
                var imagemReduzida = FuncoesGerais.ResizeImagem(imagem, size);
                pbAdotante.Image = imagemReduzida;
                AjustarVisibilidadeButtonExcluirImagem(true);
            }
            else
            {
                AjustarVisibilidadeButtonExcluirImagem(false);
            }
        }

        private void lvAdocao_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvAdocao.SelectedItems.Count > 0)
                btnEditarAdocao.Enabled = btnImprimir.Visible = true;
            else
            {
                btnEditarAdocao.Enabled = btnImprimir.Visible = false;
                LimparCamposAdocao();
            }
        }

        private void btnEditarAdocao_Click(object sender, EventArgs e)
        {
            EditarAdocao();
        }

        private void lvAdocao_DoubleClick(object sender, EventArgs e)
        {
            EditarAdocao();
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAdocao, "imprimir"))
            {
                var adocao = GetAdocaoSelecionada();
                var nomeArquivo = $"Adocao - {adocao.Animal.Nome}";
                var opcaoUsuario = FuncoesGerais.HabilitaSaveFile(saveFileImpressao, nomeArquivo, Enumeracoes.EnumFormatoArquivo.PDF);

                if (opcaoUsuario)
                {
                    this.Cursor = Cursors.WaitCursor;
                    var arquivoExistente = File.Exists($"{saveFileImpressao.FileName}.pdf");
                    if (!arquivoExistente)
                    {
                        var itensPDF = new ItensPDF()
                        {
                            TituloRelatorio = "FICHA CADASTRAL DA ADOÇÃO",
                            Animal = adocao.Animal,
                            Adocao = adocao,
                            Adotante = adocao.Adotante,
                        };

                        bool resultado = PDFs.PDFAdocao.OberRelatorio(saveFileImpressao, itensPDF);
                    }
                    else
                    {
                        FuncoesGerais.MensagemArquivoExistente();
                    }
                    this.Cursor = Cursors.Default;

                }
            }
        }

        private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        #endregion Eventos
    }
}


