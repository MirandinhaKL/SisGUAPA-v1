using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.DAO;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

/*
 * Criado em: 09/11/21
 */

namespace Desktop.Forms
{
    public partial class FormCadastroHospedagem : Form
    {
        private List<LarTemporario> _laresTemporarios;
        private List<Animal> Animais = new List<Animal>();
        private List<AnimalEspecie> Especies = new List<AnimalEspecie>();
        private Dictionary<int, string> Generos = new Dictionary<int, string>();
        private Dictionary<int, string> FaixasEtarias = new Dictionary<int, string>();

        public Animal AnimalSelecionado;

        public FormCadastroHospedagem()
        {
            InitializeComponent();
            CarregarTooltips();
            CarregarComboLares();
            CarregarComboEspecie();
            CarregarComboGenero();
            CarregarComboFaixaEtaria();
        }

        private void CarregarTooltips()
        {
            toolTipPesquisar.SetToolTip(btnPesquisar, "Pesquisa os animais cadastados no sistema.");
            toolTipLimpar.SetToolTip(btnLimpar, "Limpa os filtros e a pesquisa dos animais cadastados no sistema.");
            toolTipNovo.SetToolTip(btnNovo, "Permite cadastrar/edita um lar temporário no sistema.");
        }

        private void CarregarComboLares()
        {
            _laresTemporarios = LarTemporarioDAO.GetTodosRegistros(Global.Entidade.Id).ToList();
            _laresTemporarios.Add(new LarTemporario { Id = 0, Nome = string.Empty, Entidade = Global.UsuarioLogado.Entidade });
            cboLarTemporario.DataSource = _laresTemporarios.OrderBy(k => k.Nome).ToList();
            cboLarTemporario.DisplayMember = "Nome";
            cboLarTemporario.SelectedIndex = 0;
        }

        private bool CarregarAnimais()
        {
            this.Cursor = Cursors.WaitCursor;
            Animais = AnimalDAO.GetTodosRegistros(Global.Entidade.Id).OrderBy(k => k.Nome).ToList();

            var animaisFiltrados = Animais.OrderBy(k => k.Identificacao).ToList();

            animaisFiltrados = animaisFiltrados.Where(k => k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível).ToList();
            animaisFiltrados = animaisFiltrados.Where(k => k.Hospedado == false).ToList();

            if (!string.IsNullOrEmpty(txtID.Text))
                animaisFiltrados = animaisFiltrados.Where(k => k.Identificacao.ToString() == txtID.Text.ToLower() || k.Nome.ToLower() == txtID.Text.ToLower()).ToList();

            var especie = (AnimalEspecie)cboEspecie.Items[cboEspecie.SelectedIndex];
            if (cboEspecie.SelectedIndex > 0)
                animaisFiltrados = animaisFiltrados.Where(k => k.AnimalEspecie != null && k.AnimalEspecie.Id == especie.Id).ToList();

            var genero = cboGenero.Text;
            if (cboGenero.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(genero))
                {
                    var generoSelecionado = Generos.FirstOrDefault(k => k.Value == genero).Key;
                    animaisFiltrados = animaisFiltrados.Where(k => k.Genero == generoSelecionado).ToList();
                }
            }

            var idade = cboIdade.Text;
            if (cboIdade.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(idade))
                    animaisFiltrados = AnimalAuxiliar.GetTodasIdadesClassificadas(animaisFiltrados, idade);
            }

            lvAnimal.Items.Clear();

            if (animaisFiltrados.Any())
            {
                foreach (var item in animaisFiltrados)
                {
                    var lvi = new ListViewItem();

                    lvi.Text = item.Id.ToString();
                    lvi.SubItems.Add(item.Identificacao == null ? string.Empty : item.Identificacao);
                    lvi.SubItems.Add(item.Nome == null ? string.Empty : item.Nome);
                    lvi.SubItems.Add(item.AnimalEspecie == null ? string.Empty : item.AnimalEspecie.Descricao);
                    lvi.SubItems.Add((FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)item.Genero)));
                    lvi.SubItems.Add(item.AnimalPorte == null ? string.Empty : item.AnimalPorte.Descricao);
                    lvi.SubItems.Add((FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumStatusAnimal)item.AnimalStatus)));
                    lvi.SubItems.Add((FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumPossibilidades)item.Castrado)));
                    lvi.SubItems.Add(AnimalAuxiliar.GetClassificaoIdade(item.DataNascimento, item.DataFalecimento, item.AnimalStatus));
              
                    lvAnimal.Items.Add(lvi);
                }
            }

            this.Cursor = Cursors.Default;
            return animaisFiltrados?.Count > 0;
        }

        private void CarregarComboEspecie()
        {
            Especies = AnimalEspecieDAO.GetTodosRegistros(Global.Entidade.Id).ToList();
            Especies.Add(new AnimalEspecie { Id = 0, Descricao = string.Empty, Entidade = Global.UsuarioLogado.Entidade });
            cboEspecie.DataSource = Especies.OrderBy(k => k.Descricao).ToList();
            cboEspecie.DisplayMember = "Descricao";
            cboEspecie.SelectedIndex = 0;
        }

        private void CarregarComboGenero()
        {
            var generos = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumGenero>();

            foreach (var item in generos)
                Generos.Add((int)item, FuncoesGerais.GetDescricaoEnum(item));

            cboGenero.DataSource = Generos.OrderBy(k => k.Value).ToList();
            cboGenero.DisplayMember = "Value";
            cboGenero.SelectedIndex = 0;
        }

        private void CarregarComboFaixaEtaria()
        {
            var faixasEtarias = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumFaixasEtarias>();

            foreach (var item in faixasEtarias)
                FaixasEtarias.Add((int)item, FuncoesGerais.GetDescricaoEnum(item));

            cboIdade.DataSource = FaixasEtarias.ToList();
            cboIdade.DisplayMember = "Value";
            cboIdade.SelectedIndex = 0;
        }

        private void SetAnimalSelecionado()
        {
            panelCadastro.Visible = true;
            btnSalvar.Visible = true;
            if (AnimalSelecionado != null)
                txtIdAnimal.Text = $"{AnimalSelecionado.Identificacao} - {AnimalSelecionado.Nome}";
        }

        private bool DadosValidos()
        {
            if (AnimalSelecionado == null)
            {
                MessageBox.Show("Selecione um animal na lista. Clique no botão 'Pesquisar' para carregar os animais cadastrados no sistema.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboLarTemporario.SelectedIndex <= 0)
            {
                MessageBox.Show("Selecione um lar temporário para o animal. Clique no botão com símbolo de '+' para cadastrar/editar um lar temporário.",
                  "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            decimal valorMes = 0;
            if (!string.IsNullOrEmpty(txtValor.Text) && !decimal.TryParse(txtValor.Text, out valorMes))
            {
                MessageBox.Show("O valor mensal informado não é válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #region Eventos

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var formLar = new FormCadastroLarTemporario();
            formLar.FormClosing += new FormClosingEventHandler(this.FormLar_FormClosing);
            formLar.ShowDialog();
        }

        private void FormLar_FormClosing(object sender, FormClosingEventArgs e)
        {
            CarregarComboLares();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!CarregarAnimais())
                MessageBox.Show("Nenhum registro retornado.", "Status da ação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void lvAnimal_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvAnimal.SelectedItems.Count == 1)
            {
                if (Convert.ToInt32(lvAnimal.SelectedItems[0].SubItems[0].Text) is int idAnimal)
                {
                    AnimalSelecionado = Animais.Find(k => k.Id == idAnimal);
                    SetAnimalSelecionado();
                }
            }
            else
            {
                panelCadastro.Visible = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            cboEspecie.SelectedIndex = 0;
            cboGenero.SelectedIndex = 0;
            cboIdade.SelectedIndex = 0;
            lvAnimal.Items.Clear();
            txtIdAnimal.Text = string.Empty;
            cboLarTemporario.SelectedIndex = 0;
            dtpDataInicio.Value = DateTime.Today;
            txtValor.Text = string.Empty;
            panelCadastro.Visible = false;
            btnSalvar.Visible = false;
        }

        #endregion Eventos

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)) && !e.KeyChar.Equals(','))
                e.Handled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (DadosValidos())
            {
                var hospedagem = new Hospedagem()
                {
                    Animal = this.AnimalSelecionado,
                    DataInicio = dtpDataInicio.Value,
                    ValorMensal = string.IsNullOrEmpty(txtValor.Text) ? 0 : Convert.ToDecimal(txtValor.Text),
                    Entidade = Global.Entidade,
                    LarTemporario = cboLarTemporario.SelectedIndex == -1 ? null : (LarTemporario)cboLarTemporario.Items[cboLarTemporario.SelectedIndex]
                };

                if (HospedagemDAO.Salvar(hospedagem))
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
    }
}
