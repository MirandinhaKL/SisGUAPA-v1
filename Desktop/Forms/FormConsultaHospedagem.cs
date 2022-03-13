using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.DAO;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Criado em: 07/11/2021
/// </summary>
namespace Desktop.Forms
{
    public partial class FormConsultaHospedagem : Form
    {
        private List<AnimalEspecie> Especies = new List<AnimalEspecie>();
        private Dictionary<int, string> Generos = new Dictionary<int, string>();
        private List<Hospedagem> Hospedagens = new List<Hospedagem>();
        private List<Animal> AnimaisHospedados = new List<Animal>();
        public FormConsultaHospedagem()
        {
            InitializeComponent();
            CarregarTooltips();
            CarregarComboEspecie();
            CarregarComboGenero();
        }

        private void CarregarTooltips()
        {
            toolTipNovo.SetToolTip(btnAdicionarHospedagem, "Permite cadastrar um nova hospedagem de um animal cadastro no sistema em um lar temporário.");
            //toolTipImprimir.SetToolTip(btnImprimir, "Gera um arquivo .pdf com os dados de lares temporários cadastrados no sistema.");
            //toolTipExportar.SetToolTip(btnExportar, "Gera um arquivo .csv com os dados de todos os lares temporários cadastrados no sistema.");
            //toolTipEditar.SetToolTip(btnEditar, "Permite visualizar e editar os dados do lar temporário selecionado na lista abaixo.");
            //toolTipExcluir.SetToolTip(btnExcluir, "Permite excluir os dados do lar temporário selecionado na lista abaixo.");
            toolTipPesquisar.SetToolTip(btnPesquisar, "Pesquisa os lares temporários cadastados no sistema.");
            toolTipLimpar.SetToolTip(btnLimpar, "Limpa os filtros e a pesquisa dos lares temporários cadastados no sistema.");
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

        private bool CarregarHospedagens()
        {
            lvLar.Items.Clear();
            Hospedagens = HospedagemDAO.GetTodosRegistros(Global.Entidade.Id).OrderBy(k => k.LarTemporario.Nome).ToList();

            if (!Hospedagens.Any())
                return false;

            this.Cursor = Cursors.WaitCursor;
            var hospesagensFiltradas = Hospedagens.ToList();

            foreach (var hospedagem in Hospedagens)
                AnimaisHospedados.Add(hospedagem.Animal);

            if (!string.IsNullOrEmpty(txtCPFNome.Text))
                hospesagensFiltradas = Hospedagens.Where(k => k.LarTemporario.CPF == txtCPFNome.Text.ToLower() || k.LarTemporario.Nome.ToLower().Contains(txtCPFNome.Text.ToLower())).ToList();

            var especie = (AnimalEspecie)cboEspecie.Items[cboEspecie.SelectedIndex];
            if (cboEspecie.SelectedIndex > 0)
                AnimaisHospedados = AnimaisHospedados.Where(k => k.AnimalEspecie != null && k.AnimalEspecie.Id == especie.Id).ToList();

            var genero = cboGenero.Text;
            if (cboGenero.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(genero))
                {
                    var generoSelecionado = Generos.FirstOrDefault(k => k.Value == genero).Key;
                    AnimaisHospedados = AnimaisHospedados.Where(k => k.Genero == generoSelecionado).ToList();
                }
            }

            if (!string.IsNullOrEmpty(txtIdAnimal.Text))
                AnimaisHospedados = AnimaisHospedados.Where(k => k.Nome.ToLower().Contains(txtIdAnimal.Text.ToLower())).ToList();
            
            var contaLinha = 0;
            bool algumAnimalMorto = false;

            if (hospesagensFiltradas.Any())
            {
                foreach (var hospedagem in hospesagensFiltradas)
                {
                    if (AnimaisHospedados.Contains(hospedagem.Animal))
                    {
                        var lvi = new ListViewItem();
                        lvi.Text = hospedagem.Id.ToString();
                        lvi.SubItems.Add(hospedagem.Animal.Id.ToString());
                        lvi.SubItems.Add(hospedagem.LarTemporario?.Nome);
                        lvi.SubItems.Add(hospedagem.Animal?.Nome);
                        lvi.SubItems.Add(hospedagem.Animal?.AnimalEspecie == null ? string.Empty : hospedagem.Animal?.AnimalEspecie.Descricao);
                        lvi.SubItems.Add(FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)hospedagem.Animal?.Genero));
                        lvi.SubItems.Add(hospedagem.DataInicio == null ? string.Empty : hospedagem.DataInicio.ToShortDateString());
                        lvi.SubItems.Add(hospedagem.DataFinal == null ? string.Empty : (hospedagem.DataFinal.Date == DateTime.MinValue ? string.Empty : hospedagem.DataFinal.ToShortDateString()));
                        lvi.SubItems.Add(hospedagem.ValorMensal.ToString("N2"));

                        if (hospedagem.Animal?.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Morto && 
                            (hospedagem.DataFinal == null || (hospedagem.DataFinal != null && hospedagem.DataFinal == DateTime.MinValue)))
                        {
                            lvi.BackColor = Color.Orange;
                            algumAnimalMorto = true;
                        }
                        else if (contaLinha % 2 == 0)
                        {
                            lvi.BackColor = Color.LightCyan;
                        }

                        contaLinha++;
                        lvLar.Items.Add(lvi);
                    }
                }
            }

            if (algumAnimalMorto)
            {
                lblAnimalFalecido.Visible = true;
                paneLaranja.Visible = true;
            }

            this.Cursor = Cursors.Default;
            return true;
        }

        private void LimparComponentesTela()
        {
            txtCPFNome.Text = txtIdAnimal.Text = string.Empty;
            cboGenero.SelectedIndex = cboEspecie.SelectedIndex = 0;
            lvLar.Items.Clear();
            lblAnimalFalecido.Visible = false;
            paneLaranja.Visible = false;
            //btnEditar.Enabled = /*btnExcluir.Enabled = btnImprimir.Visible =*/ false;
        }

        #region Eventos

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!CarregarHospedagens())
                MessageBox.Show("Nenhum registro retornado.", "Status da ação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparComponentesTela();
        }

        private void FormLar_FormClosing(object sender, FormClosingEventArgs e)
        {
            LimparComponentesTela();
            CarregarHospedagens();
        }

        private void btnAdicionarAnimal_Click(object sender, EventArgs e)
        {
            var formAnimalLar = new FormCadastroHospedagem();
            formAnimalLar.FormClosing += new FormClosingEventHandler(this.FormLar_FormClosing);
            formAnimalLar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void lvLar_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvLar.SelectedItems.Count > 0)
                btnEncerrarHospedagem.Visible = /*btnEditar.Visible =*/ true;
            else
                btnEncerrarHospedagem.Visible = /*btnEditar.Visible = */false;
        }

        private void btnEncerrarHospedagem_Click(object sender, EventArgs e)
        {
            if (lvLar.SelectedItems.Count == 1)
            {
                if (Convert.ToInt32(lvLar.SelectedItems[0].SubItems[0].Text) is int idHospesagem)
                {
                    var hospesagem = Hospedagens.Find(k => k.Id == idHospesagem);

                    var formEncerramento = new FormEncerraHospedagem(hospesagem);
                    formEncerramento.FormClosing += new FormClosingEventHandler(this.FormLar_FormClosing);
                    formEncerramento.ShowDialog();
                }
            }
        }
       
        #endregion Eventos
    }
}
