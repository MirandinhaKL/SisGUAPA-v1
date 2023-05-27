using Desktop.Classes;
using Desktop.DependencyInjection;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormCadastroAnimal : Form
    {
        public static int TelaSelecionada;

        private IAnimalService _animalService;

        private int _idAnimal;
        private bool _isEdicao = false;
        private Animal _animal;
        private EnderecoRecolhimento _enderecoRecolhimento;
        private Recolhimento _recolhimento;

        private List<AnimalCor> _cores = new List<AnimalCor>();
        private List<AnimalPorte> _portes = new List<AnimalPorte>();
        private List<AnimalEspecie> _especies = new List<AnimalEspecie>();
        private Dictionary<int, string> _statusAnimal = new Dictionary<int, string>();
        private List<MotivoRecolhimento> _motivosRecolhimento = new List<MotivoRecolhimento>();
        private List<MotivoFalecimento> _motivosFalecimento = new List<MotivoFalecimento>();

        public FormCadastroAnimal(Animal animalEditato)
        {
            this.Cursor = Cursors.WaitCursor;

            InitializeComponent();
            InitializeServices();
            AjustarVisibilidadeButtonExcluirImagem(false);
            this.txtID.Focus();
            this.txtID.Select();

            SetAnimal(animalEditato);
            CarregarToolTip();

            // Aba animal
            CarregarComboCor();
            CarregarComboPorte();
            CarregarComboEspecie();
            CarregarComboStauts();
            CarregaComboMotivoFalecimento();
            
            // Aba origem
            CarregaComboBoxEstadosBrasil();
            CarregaComboMotivoRecolhimento();
            
            this.Cursor = Cursors.Default;
        }

        private void InitializeServices()
        {
            _animalService = IocKernel.Get<IAnimalService>();
        }

        private void CarregarToolTip()
        {
            toolTipCor.SetToolTip(btnCor, "Permite consultar, cadastrar, editar e excluir cores referentes aos animais.");
            toolTipPorte.SetToolTip(btnPorte, "Permite consultar, cadastrar, editar e excluir portes (tamanho) dos animais.");
            toolTipEspecie.SetToolTip(btnEspecie, "Permite consultar, cadastrar, editar e excluir espécies de animais.");
            toolTipFalecimento.SetToolTip(btnFalecimento, "Permite consultar, cadastrar, editar e excluir motivos de falecimento dos animais.");
            toolTipLimparImagem.SetToolTip(btnExcluir, "Exclui a imagem selecionada.");
            toolTipSelecionarImagem.SetToolTip(btnSelecionar, "Pemite cadastrar uma imagem no formato .jpg ou .png.");
            toolTipMotivoRecolhimento.SetToolTip(btnMotivo, "Pemite cadastrar justificativas sobre o recolhimento dos animais.");
        }

        private void SetAnimal(Animal animal)
        {
            _animal = animal;
            _enderecoRecolhimento = animal?.DadosRecolhimento?.EnderecoRecolhimento;
            _recolhimento = animal?.DadosRecolhimento;
            _isEdicao = animal != null && animal.Id > 0;

            if (_isEdicao) 
                CarregarDadosAnimal(_animal);
        }

        private void CarregarDadosAnimal(Animal animal)
        {
            this._idAnimal = animal.Id;

            // Aba animal
            txtID.Text = animal.Identificacao;
            txtNome.Text = animal.Nome;
            dtpNascimento.Value = animal.DataNascimento;
            txtRaca.Text = animal.Raca;
            numPeso.Value = animal.Peso;
            txtDeficiencia.Text = animal.Deficiencia;

            SetGenero(animal.Genero);
            SetDeficiente(animal.Deficiencia);
            SetCastrado(animal.Castrado);
            SetImagemAnimal(animal.Imagem);

            // Aba origem
            SetOrigemRecolhimento(animal.DadosRecolhimento); // ver se a consulta do método precisa ser feita novamente, ou ao buscar os dados do animal essa info já vem. - 
            SetEndereco(animal.DadosRecolhimento?.EnderecoRecolhimento);
        }

        private void SetImagemAnimal(byte[] imagem)
        {
            if (imagem != null && imagem.Length > 0)
            {
                picAnimal.Image = FuncoesGerais.ConverteByteParaBitmap(imagem);
                AjustarVisibilidadeButtonExcluirImagem(true);
            }
        }

        private void SetOrigemRecolhimento(Recolhimento recolhimento)
        {
            if (recolhimento?.Id != null)
            {
                _recolhimento = _animalService.GetDadosRecolhimentoById(recolhimento.Id);
                rtbObservacao.Text = _recolhimento.Observacao;
                txtTelefone.Text = _recolhimento.Telefone;
                txtRecolhedor.Text = _recolhimento.Recolhedor;
                dtpRecolhimento.Value = _recolhimento.DataRecolhimento;
            }
        }

        private void SetEndereco(EnderecoRecolhimento enderecoRecolhimento)
        {
            if (enderecoRecolhimento?.Id != null)
            {
                _enderecoRecolhimento = _animalService.GetEnderecoRecolhimentoById(enderecoRecolhimento.Id);
                txtCidade.Text = _enderecoRecolhimento.Cidade;
                txtBairro.Text = _enderecoRecolhimento.Bairro;
                txtComplemento.Text = _enderecoRecolhimento.Complemento;
                txtEndereco.Text = _enderecoRecolhimento.Logradouro;
                txtNumero.Text = _enderecoRecolhimento.Numero;
                maskCEP.Text = _enderecoRecolhimento.CEP;
            }
        }

        private void AjustarVisibilidadeButtonExcluirImagem(bool visivel)
        {
            btnExcluir.Visible = visivel;
        }

        private bool DadosValidos()
        {
            bool dadosValidos = true;

            errorTxt.Clear();
         
            if (txtNome.Text == string.Empty)
            {
                errorTxt.SetError(txtNome, "Informe um nome para o animal.");
                dadosValidos = false;
            }
            if (cbCor.SelectedIndex == -1)
            {
                errorTxt.SetError(cbCor, "Selecione uma cor para o animal.");
                dadosValidos = false;
            }
            if (cbEspecie.SelectedIndex == -1)
            {
                errorTxt.SetError(cbEspecie, "Selecione uma espécie para o animal.");
                dadosValidos = false;
            }
            if (cbStatus.SelectedIndex == -1)
            {
                errorTxt.SetError(cbStatus, "Selecione um status para o animal.");
                dadosValidos = false;
            }

            if (dtpNascimento.Value > DateTime.Now)
            {
                errorTxt.SetError(dtpNascimento, "A data de nascimento dever ser anterior ou iagual ao dia de hoje.");
                dadosValidos = false;
            }

            if (!dadosValidos)
                tabCadastroAnimal.SelectedTab = tabAnimal;

            return dadosValidos;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (DadosValidos())
            {
                var recolhimento = new Recolhimento()
                {
                    DataRecolhimento = dtpRecolhimento.Value,
                    Observacao = rtbObservacao.Text,
                    Recolhedor = txtRecolhedor.Text,
                    Entidade = Global.UsuarioLogado.Entidade,
                    Telefone = txtTelefone.Text,
                };

                var motivoRecolhimento = cbMotivo.SelectedIndex == -1 ? null : (MotivoRecolhimento)cbMotivo.Items[cbMotivo.SelectedIndex];
                recolhimento.SetMotivoRecolhimento(motivoRecolhimento);

                var enderecoRecolhimento = new EnderecoRecolhimento()
                {
                    Entidade = Global.UsuarioLogado.Entidade,
                    Estado = cbEstado.SelectedIndex,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    Complemento = txtComplemento.Text,
                    Logradouro = txtEndereco.Text,
                    Numero = txtNumero.Text,
                    CEP = maskCEP.Text
                };

                recolhimento.SetEnderecoRecolhimento(enderecoRecolhimento);

                _animal.Identificacao = txtID.Text;
                _animal.Nome = txtNome.Text;
                _animal.DataNascimento = Convert.ToDateTime(dtpNascimento.Text);
                _animal.Peso = Convert.ToInt32(numPeso.Value);
                _animal.Castrado = GetCastrado();
                _animal.Deficiencia = txtDeficiencia.Text;
                _animal.Genero = GetGenero();
                _animal.Raca = txtRaca.Text;
                _animal.Imagem = ConverterPictureParaByte(picAnimal.Image);
                _animal.Usuario = Global.UsuarioLogado;
                _animal.AnimalCor = (AnimalCor)cbCor.Items[cbCor.SelectedIndex];
                _animal.AnimalPorte = cbPorte.SelectedIndex == -1 ? null : (AnimalPorte)cbPorte.Items[cbPorte.SelectedIndex];
                _animal.AnimalEspecie = (AnimalEspecie)cbEspecie.Items[cbEspecie.SelectedIndex];
                _animal.AnimalStatus = GetStatusAnimal();
                _animal.DataFalecimento = new DateTime();
                _animal.SetDadosRecolhimento(recolhimento);
                //_animal.MotivoRecolhimento = cbMotivo.SelectedIndex == -1 ? null : (MotivoRecolhimento)cbMotivo.Items[cbMotivo.SelectedIndex];
                _animal.MotivoFalecimento = GetMotivoFalecimento();
                //_animal.EnderecoRecolhimento = enderecoRecolhimento;
                _animal.Entidade = Global.Entidade;

                if (!_isEdicao)
                    _animal.DataCadastro = DateTime.Today;

                if (_animalService.SalvarOuAtualizarAnimal(_animal))
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int GetCastrado()
        {
            if (rbCastradoNao.Checked)
                return (int)Enumeracoes.EnumPossibilidades.Nao;
            else if (rbCastradoSim.Checked)
                return (int)Enumeracoes.EnumPossibilidades.Sim;
            else
                return (int)Enumeracoes.EnumPossibilidades.NaoSei;
        }

        private void SetCastrado(int enuCastrado)
        {
            rbCastradoNao.Checked = rbCastradoNaoSabe.Checked = rbCastradoSim.Checked = false;

            if ((int)Enumeracoes.EnumPossibilidades.Nao == enuCastrado)
                rbCastradoNao.Checked = true;
            else if ((int)Enumeracoes.EnumPossibilidades.Sim == enuCastrado)
                rbCastradoSim.Checked = true;
            else
                rbCastradoNaoSabe.Checked = true;
        }

        private void SetDeficiente(string deficiencia)
        {
            rbDeficienteNao.Checked = rbDeficienteSim.Checked = false;

            if (string.IsNullOrEmpty(deficiencia))
                rbDeficienteNao.Checked = true;
            else
                rbDeficienteSim.Checked = true;
        }

        private int GetGenero()
        {
            if (rbFemea.Checked)
                return (int)Enumeracoes.EnumGenero.Feminino;
            else if(rbMacho.Checked)
                return (int)Enumeracoes.EnumGenero.Masculino;
            else
                return (int)Enumeracoes.EnumGenero.NaoSei;
        }

        private void SetGenero(int enumGenero)
        {
            rbFemea.Checked = rbMacho.Checked = rbGeneroNaoSabe.Checked = false;

            if ((int)Enumeracoes.EnumGenero.Feminino == enumGenero)
                rbFemea.Checked = true;
            else if ((int)Enumeracoes.EnumGenero.Masculino == enumGenero)
                rbMacho.Checked = true;
            else
                rbGeneroNaoSabe.Checked = true;
        }

        private int GetStatusAnimal()
        {
           return _statusAnimal.FirstOrDefault(k => k.Value == cbStatus.Text).Key;
        }

        private MotivoFalecimento GetMotivoFalecimento()
        {
            int statusAnimal = GetStatusAnimal();

            if (cbMotivoFalecimento.SelectedIndex == -1)
                return null;

            else if (statusAnimal == (int)Enumeracoes.EnumStatusAnimal.Morto)
                return (MotivoFalecimento)cbMotivoFalecimento.Items[cbMotivoFalecimento.SelectedIndex];
           
            return null;
        }

        private void rbDeficienteSim_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDeficienteSim.Checked)
                txtDeficiencia.Enabled = true;
        }

        private void rbDeficienteNao_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDeficienteNao.Checked)
            {
                txtDeficiencia.Text = string.Empty;
                txtDeficiencia.Enabled = false;
            }
        }

        public void CarregarComboCor()
        {
            _cores = _animalService.GetCoresOrdenadasPorNome(Global.Entidade.Id);
            cbCor.DataSource = _cores;
            cbCor.DisplayMember = "Descricao";

            if (_isEdicao && _animal.AnimalCor != null)
                cbCor.SelectedItem = _cores.Find(k => k.Id == _animal.AnimalCor.Id);
            else
                cbCor.SelectedIndex = -1;
        }

        private void CarregarComboPorte()
        {
            _portes = _animalService.GetPortesOrdenadosPorNome(Global.Entidade.Id);
            cbPorte.DataSource = _portes;
            cbPorte.DisplayMember = "Descricao";

            if (_isEdicao && _animal.AnimalPorte != null)
                cbPorte.SelectedItem = _portes.Find(k => k.Id == _animal.AnimalPorte.Id);
            else
                cbPorte.SelectedIndex = -1;
        }

        private void CarregarComboEspecie()
        {
            _especies = _animalService.GetEspeciesOrdenadasPorNome(Global.Entidade.Id);
            cbEspecie.DataSource = _especies;
            cbEspecie.DisplayMember = "Descricao";

            if (_isEdicao && _animal.AnimalEspecie != null)
                cbEspecie.SelectedItem = _especies.Find(k => k.Id == _animal.AnimalEspecie.Id);
            else
                cbEspecie.SelectedIndex = -1;
        }

        private void CarregarComboStauts()
        {
            IList<Enumeracoes.EnumStatusAnimal> status = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumStatusAnimal>();

            foreach (var item in status)
                _statusAnimal.Add((int)item, FuncoesGerais.GetDescricaoEnum(item));

            cbStatus.DataSource = _statusAnimal.OrderBy(k => k.Value).ToList();
            cbStatus.DisplayMember = "Value";

            if (_isEdicao && _animal != null)
            {
                cbStatus.SelectedIndex = _animal.AnimalStatus;
                if (_animal.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Adotado)
                    cbStatus.Enabled = false;
            }
            else
            {
                cbStatus.SelectedIndex = 1;
                cbStatus.Enabled = true;
            }
        }
     
        // Salvar o endereço de recolhimento e carregar demais dados da edição.
        private void CarregaComboMotivoRecolhimento()
        {
            _motivosRecolhimento = _animalService.GetMotivosRecolhimentosOrdenadosPorNome(Global.Entidade.Id);
            cbMotivo.DataSource = _motivosRecolhimento;
            cbMotivo.DisplayMember = "Descricao";

            if (_isEdicao && _animal.DadosRecolhimento?.MotivoRecolhimento != null)
                cbMotivo.SelectedItem = _motivosRecolhimento.Find(k => k.Id == _animal.DadosRecolhimento.MotivoRecolhimento.Id);
            else
                cbMotivo.SelectedIndex = -1;
        }

        private void CarregaComboMotivoFalecimento()
        {
            _motivosFalecimento = _animalService.GetMotivosFalecimentoOrdenadosPorNome(Global.Entidade.Id);
            cbMotivoFalecimento.DataSource = _motivosFalecimento;
            cbMotivoFalecimento.DisplayMember = "Descricao";

            if (_isEdicao && _animal.MotivoFalecimento != null)
                cbMotivoFalecimento.SelectedItem = _motivosFalecimento.Find(k => k.Id == _animal.MotivoFalecimento.Id);
            else
                cbMotivoFalecimento.SelectedIndex = -1;
        }

        private void CarregaComboBoxEstadosBrasil()
        {
            this.cbEstado.DataSource = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumEstadosBrasil>();
            if (_isEdicao && _enderecoRecolhimento != null)
                cbEstado.SelectedIndex = _enderecoRecolhimento.Estado;
            else
                cbEstado.SelectedIndex = 19;
        }

        #region TelasAuxiliares

        private void btnCor_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TelaSelecionada = (int)Enumeracoes.EnumTelaAuxiliar.Cor;
            FormCadastroAnimalAuxiliar form = new FormCadastroAnimalAuxiliar();
            form.FormClosing += new FormClosingEventHandler(FormAuxilarFecha);
            form.Text = "Cor do animal";
            form.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnPorte_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TelaSelecionada = (int)Enumeracoes.EnumTelaAuxiliar.Porte;
            FormCadastroAnimalAuxiliar form = new FormCadastroAnimalAuxiliar();
            form.FormClosing += new FormClosingEventHandler(FormAuxilarFecha);
            form.Text = "Porte do animal";
            form.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnEspecie_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TelaSelecionada = (int)Enumeracoes.EnumTelaAuxiliar.Especie;
            FormCadastroAnimalAuxiliar form = new FormCadastroAnimalAuxiliar();
            form.FormClosing += new FormClosingEventHandler(FormAuxilarFecha);
            form.Text = "Espécie do animal";
            form.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnMotivo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TelaSelecionada = (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento;
            FormCadastroAnimalAuxiliar form = new FormCadastroAnimalAuxiliar();
            form.FormClosing += new FormClosingEventHandler(FormAuxilarFecha);
            form.Text = "Motivo do recolhimento do animal";
            form.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnFalecimento_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TelaSelecionada = (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento;
            FormCadastroAnimalAuxiliar form = new FormCadastroAnimalAuxiliar();
            form.FormClosing += new FormClosingEventHandler(FormAuxilarFecha);
            form.Text = "Motivo do falecimento do animal";
            form.Show();
            this.Cursor = Cursors.Default;
        }

        private void FormAuxilarFecha(object sender, FormClosingEventArgs e)
        {
            switch (TelaSelecionada)
            {
                case (int)Enumeracoes.EnumTelaAuxiliar.Cor:
                    CarregarComboCor();
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.Especie:
                    CarregarComboEspecie();
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.Porte:
                    CarregarComboPorte();
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento:
                    CarregaComboMotivoRecolhimento();
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento:
                    CarregaComboMotivoFalecimento();
                    break;

                default:
                    break;
            }
        }

        #endregion TelasAuxiliares

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            picAnimal.Image = null;
            AjustarVisibilidadeButtonExcluirImagem(false);
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            ofdImagemAnimal.Filter = "Imagem (*.jpg, *.png)| *.jpg; *.png";

            if (ofdImagemAnimal.ShowDialog() == DialogResult.OK)
            {
                var imagem = new Bitmap(ofdImagemAnimal.FileName);
                var size = new Size(300, 400);
                var imagemReduzida = FuncoesGerais.ResizeImagem(imagem, size);
                picAnimal.Image = imagemReduzida;
                AjustarVisibilidadeButtonExcluirImagem(true);
            }
            else
            {
                AjustarVisibilidadeButtonExcluirImagem(false);
            }
        }

        private byte[] ConverterPictureParaByte(Image imagem)
        {
            if (imagem != null )
            {
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(imagem, typeof(byte[]));
            }
            else
                return new byte[0];
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.Text == FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumStatusAnimal.Morto))
            {
                lblRazaoFalecimento.Visible = true;
                cbMotivoFalecimento.Visible = true;
                btnFalecimento.Visible = true;
            }
            else
            {
                lblRazaoFalecimento.Visible = false;
                cbMotivoFalecimento.Visible = false;
                btnFalecimento.Visible = false;
                cbMotivoFalecimento.SelectedIndex = -1;

                if (cbStatus.Text == FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumStatusAnimal.Adotado))
                {
                    if (!_isEdicao)
                    {
                        string mensagem = "Um novo animal cadastrado no sistema não pode ter o status de adotado. Para alterar o status " +
                            "para adotado é necessário cadastrar no módulo ADOÇÃO os dados do adotante.";
                       
                        MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string mensagem = "Para alterar o status para adotado é necessário cadastrar no módulo ADOÇÃO os dados do adotante.";
                        MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    cbStatus.SelectedIndex = 1;
                }
            }
        }

        // ver como seta o estado
        private void tabCadastroAnimal_Enter(object sender, EventArgs e)
        {
            cbEstado.Focus();
            cbEstado.Select();
        }
    }
}

//testar dados recolhimento
//    tesar endereco recolhimento