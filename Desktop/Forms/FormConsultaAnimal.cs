using Desktop.Classes;
using Desktop.DependencyInjection;
using Desktop.Relatorios.PDFs;
using Repositorio.DAO;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormConsultaAnimal : Form
    {
        private IAnimalService _animalService;
        private List<Animal> _animais = new List<Animal>();
        private List<AnimalEspecie> Especies = new List<AnimalEspecie>();
        private List<AnimalPorte> Portes = new List<AnimalPorte>();
        private Dictionary<int, string> Generos = new Dictionary<int, string>();
        private Dictionary<int, string> CastradosStatus = new Dictionary<int, string>();
        private Dictionary<int, string> StatusAnimal = new Dictionary<int, string>();
        private Dictionary<int, string> FaixasEtarias = new Dictionary<int, string>();
        private Enumeracoes.EnumTipoTela EnumTipoTela;
        public Animal AnimalSelecionado;

        public FormConsultaAnimal(Enumeracoes.EnumTipoTela enumTipoTela)
        {
            InitializeComponent();
            EnumTipoTela = enumTipoTela;
            InitializeServices();
            AjustarExibicaoBotoes();
            CarregarTooltips();
            CarregarComboEspecie();
            CarregarComboGenero();
            CarregarComboPorte();
            CarregarComboStauts();
            CarregarComboCastrado();
            CarregarComboFaixaEtaria();
            CarregarAnimais();
        }

        private void InitializeServices()
        {
            _animalService = IocKernel.Get<IAnimalService>();
        } 
        
        private void CarregarTooltips()
        {
            toolTipNovo.SetToolTip(btnNovo, "Permite cadastrar um novo animal no sistema.");
            toolTipImprimir.SetToolTip(btnImprimir, "Gera um arquivo .pdf com os dados dos animais cadastrados no sistema.");
            toolTipExportar.SetToolTip(btnExportar, "Gera um arquivo .csv com os dados dos animais cadastrados no sistema.");
            toolTipEditar.SetToolTip(btnEditar, "Permite visualizar e editar os dados do animal selecionado na lista abaixo.");
            toolTipExcluir.SetToolTip(btnExcluir, "Permite excluir os dados do animal selecionado na lista abaixo.");
            toolTipPesquisar.SetToolTip(btnPesquisar, "Pesquisa os animais cadastados no sistema.");
            toolTipLimpar.SetToolTip(btnLimpar, "Limpa os filtros e a pesquisa dos animais cadastados no sistema.");
        }

        #region Combos

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

        private void CarregarComboPorte()
        {
            Portes = AnimalPorteDAO.GetTodosRegistros(Global.Entidade.Id).ToList();
            Portes.Add(new AnimalPorte { Id = 0, Descricao = string.Empty, Entidade = Global.Entidade });
            cboPorte.DataSource = Portes.OrderBy(k => k.Descricao).ToList();
            cboPorte.DisplayMember = "Descricao";
            cboPorte.SelectedIndex = 0;
        }

        private void CarregarComboStauts()
        {
            var statusAnimal = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumStatusAnimal>();

            foreach (var item in statusAnimal)
                StatusAnimal.Add((int)item, FuncoesGerais.GetDescricaoEnum(item));

            var valorMaximo = StatusAnimal.Values.Last().Length;

            StatusAnimal.Add(valorMaximo++, string.Empty);

            cboStatus.DataSource = StatusAnimal.OrderBy(k => k.Value).ToList();
            cboStatus.DisplayMember = "Value";
            cboStatus.SelectedIndex = 0;
        }

        private void CarregarComboCastrado()
        {
            var statusCastracao = FuncoesGerais.ConverterEnumParaLista<Enumeracoes.EnumPossibilidades>();

            foreach (var item in statusCastracao)
                CastradosStatus.Add((int)item, FuncoesGerais.GetDescricaoEnum(item));

            var valorMaximo = CastradosStatus.Values.Last().Length;
            CastradosStatus.Add(valorMaximo++, string.Empty);

            cboCastrado.DataSource = CastradosStatus.OrderBy(k => k.Value).ToList();
            cboCastrado.DisplayMember = "Value";
            cboCastrado.SelectedIndex = 0;
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

        /// <summary>
        /// Não exibir os botões se a tela for apenas para a consulta dos dados.
        /// </summary>
        private void AjustarExibicaoBotoes()
        {
            if (EnumTipoTela == Enumeracoes.EnumTipoTela.Consulta)
                btnEditar.Visible = btnExcluir.Visible = btnExportar.Visible = btnImprimir.Visible = btnNovo.Visible = btnImprimir.Visible = false;
        }

        #endregion

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FormCadastroAnimal formAnimal = new FormCadastroAnimal(new Animal());
            formAnimal.FormClosing += new FormClosingEventHandler(this.FormAnimal_FormClosing);
            formAnimal.ShowDialog();
            CarregarAnimais();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if(!CarregarAnimais())
                MessageBox.Show("Nenhum registro retornado.", "Status da ação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool CarregarAnimais()
        {
            this.Cursor = Cursors.WaitCursor;

            _animais = _animalService.GetAnimais(Global.Entidade.Id);
            List<Animal> animaisFiltrados = _animais.OrderBy(k => k.Identificacao).ToList();

            if (EnumTipoTela == Enumeracoes.EnumTipoTela.Consulta)
                animaisFiltrados = animaisFiltrados.Where(k => k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível).ToList();

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

            var porte = (AnimalPorte)cboPorte.Items[cboPorte.SelectedIndex];
            if (cboPorte.SelectedIndex > 0)
                animaisFiltrados = animaisFiltrados.Where(k => k.AnimalPorte != null && k.AnimalPorte.Id == porte.Id).ToList();

            var statusAnimal = cboStatus.Text;
            if (cboStatus.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(statusAnimal))
                {
                    var statusSelecionado = StatusAnimal.FirstOrDefault(k => k.Value == statusAnimal).Key;
                    animaisFiltrados = animaisFiltrados.Where(k => k.AnimalStatus == statusSelecionado).ToList();
                }
            }

            var castrado = cboCastrado.Text;
            if (cboCastrado.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(castrado))
                {
                    var statusCastrado = CastradosStatus.FirstOrDefault(k => k.Value == castrado).Key;
                    animaisFiltrados = animaisFiltrados.Where(k => k.Castrado == statusCastrado).ToList();
                }
            }

            var idade = cboIdade.Text;
            if (cboIdade.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(idade))
                    animaisFiltrados = AnimalAuxiliar.GetTodasIdadesClassificadas(animaisFiltrados, idade);
            }

            CarregarListViewAnimais(animaisFiltrados);

            this.Cursor = Cursors.Default;
            return animaisFiltrados?.Count > 0;
        }

        private void CarregarListViewAnimais(List<Animal> animais)
        {
            lvAnimal.Items.Clear();
            var contaLinha = 0;

            if (animais.Any())
            {
                foreach (var item in animais)
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

                    if (contaLinha % 2 == 0)
                        lvi.BackColor = Color.LightCyan;

                    contaLinha++;
                    lvAnimal.Items.Add(lvi);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparComponentesTela();
        }

        private void LimparComponentesTela()
        {
            txtID.Text = string.Empty;
            cboEspecie.SelectedIndex = 0;
            cboGenero.SelectedIndex = 0;
            cboPorte.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            cboCastrado.SelectedIndex = 0;
            cboIdade.SelectedIndex = 0;
            lvAnimal.Items.Clear();
            btnEditar.Enabled = btnExcluir.Enabled = btnImprimir.Visible = false;
        }

        private void lvAnimal_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (EnumTipoTela != Enumeracoes.EnumTipoTela.Consulta)
            {
                if (lvAnimal.SelectedItems.Count > 0)
                    btnEditar.Enabled = btnExcluir.Enabled = btnImprimir.Visible = true;
                else
                    btnEditar.Enabled = btnExcluir.Enabled = btnImprimir.Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (EnumTipoTela != Enumeracoes.EnumTipoTela.Consulta)
                EditarAnimal();
        }

        private void lvAnimal_DoubleClick(object sender, EventArgs e)
        {
            if (EnumTipoTela != Enumeracoes.EnumTipoTela.Consulta)
                EditarAnimal();
            else
            {
               AnimalSelecionado = GetAnimalSelecionado();
               this.Close();
            }
        }

        private void EditarAnimal()
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAnimal, "editar"))
            {
                var animal = GetAnimalSelecionado();
                var formAnimal = new FormCadastroAnimal(animal);
                formAnimal.FormClosing += new FormClosingEventHandler(this.FormAnimal_FormClosing);
                formAnimal.ShowDialog();
            }
            CarregarAnimais();
        }

        private void FormAnimal_FormClosing(object sender, FormClosingEventArgs e)
        {
            LimparComponentesTela();
            CarregarAnimais();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAnimal, "excluir"))
            {
                var solicitacao = FuncoesGerais.MensagemDesejaExcluir();

                if (solicitacao.Equals(DialogResult.OK) || solicitacao.Equals(DialogResult.Yes))
                {
                    var animal = new Animal();

                    if (Convert.ToInt32(lvAnimal.SelectedItems[0].SubItems[0].Text) is int idAnimal)
                    {
                        animal = _animais.Find(k => k.Id == idAnimal);
                        var excluir = AnimalDAO.Apagar(animal);

                        if (string.IsNullOrEmpty(excluir))
                        {
                            FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Excluir);
                            LimparComponentesTela();
                            CarregarAnimais();
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
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            var nomeArquivo = $"Animais_{DateTime.Today.ToShortDateString().Replace('/', '-')}";
            var opcaoUsuario = FuncoesGerais.HabilitaSaveFile(saveFileDialog, nomeArquivo, Enumeracoes.EnumFormatoArquivo.CSV);

            if (opcaoUsuario)
            {
                var arquivoExistente = File.Exists($"{saveFileDialog.FileName}.csv");
                this.Cursor = Cursors.WaitCursor;

                if (!arquivoExistente)
                {
                    bool resultado = CSVs.CSVAnimal.GetCSVCompleto(saveFileDialog);
                    if (!resultado)
                        FuncoesGerais.MensagemFalhaAoGerarArquivo();
                }
                else
                    FuncoesGerais.MensagemArquivoExistente();

                this.Cursor = Cursors.Default;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAnimal, "imprimir"))
            {
                var animal = GetAnimalSelecionado();
                var nomeArquivo = $"Cadastro - {animal.Identificacao} - {animal.Nome }";
                var opcaoUsuario = FuncoesGerais.HabilitaSaveFile(saveFileDialog, nomeArquivo, Enumeracoes.EnumFormatoArquivo.PDF);

                if (opcaoUsuario)
                {
                    this.Cursor = Cursors.WaitCursor;

                    var arquivoExistente = File.Exists($"{saveFileDialog.FileName}.pdf");
                    if (!arquivoExistente)
                    {
                        var itensPDF = new ItensPDF()
                        {
                            TituloRelatorio = "FICHA CADASTRAL DO ANIMAL",
                            Animal = animal,
                        };

                       //TODO: Adicionar mensagem caso de erro ao gerar relatorio
                        bool resultado = PDFs.PDFAdocao.OberRelatorio(saveFileDialog, itensPDF);

                    }
                    else
                    {
                        FuncoesGerais.MensagemArquivoExistente();
                    }

                    this.Cursor = Cursors.Default;
                }
            }
        }

        private Animal GetAnimalSelecionado()
        {
            var animal = new Animal();
            if (Convert.ToInt32(lvAnimal.SelectedItems[0].SubItems[0].Text) is int idAnimal)
                animal = _animais.FirstOrDefault(k => k.Id == idAnimal);
            return animal;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            var filtro = txtID.Text == string.Empty ? string.Empty : txtID.Text.ToLower();

            if (filtro.Length > 0)
            {
                var animaisFiltrados = _animais.FindAll(
                    animal => animal.Identificacao.ToLower().Contains(filtro) ||
                              animal.Nome.ToLower().Contains(txtID.Text));

                CarregarListViewAnimais(animaisFiltrados);
            }
            else
            {
                CarregarListViewAnimais(_animais);
            }
        }
    }
}