using Desktop.Classes;
using Desktop.Relatorios.PDFs;
using Repositorio.DAO;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Forms
{
    /// <summary>
    /// Criado em: 22/09/2021
    /// </summary>
    public partial class FormConsultaAdocao : Form
    {
        private List<Adotante> Adotantes = new List<Adotante>();
        private List<AnimalEspecie> Especies = new List<AnimalEspecie>();
        private Dictionary<int, string> Generos = new Dictionary<int, string>();

        public FormConsultaAdocao()
        {
            InitializeComponent();
            CarregarTooltips();
            CarregarComboEspecie();
            CarregarComboGenero();
        }

        private void CarregarTooltips()
        {
            toolTipNovo.SetToolTip(btnNovo, "Permite cadastrar um novo adotante/adoção no sistema.");
            toolTipImprimir.SetToolTip(btnImprimir, "Gera um arquivo .pdf com os dados dos adotantes/adoções cadastrados no sistema.");
            toolTipExportar.SetToolTip(btnExportar, "Gera um arquivo .csv com os dados dos adotantes/adoções cadastrados no sistema.");
            toolTipEditar.SetToolTip(btnEditar, "Permite visualizar e editar os dados do adotante/adoção selecionado na lista abaixo.");
            toolTipExcluir.SetToolTip(btnExcluir, "Permite excluir os dados do adotante/adoção selecionado na lista abaixo.");
            toolTipPesquisar.SetToolTip(btnPesquisar, "Pesquisa os do adotantes/adoções cadastados no sistema.");
            toolTipLimpar.SetToolTip(btnLimpar, "Limpa os filtros e a pesquisa dos adotantes/adoções cadastados no sistema.");
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

        private void LimparComponentesTela()
        {
            txtCPFNome.Text = txtIdAnimal.Text = string.Empty;
            cboGenero.SelectedIndex = cboEspecie.SelectedIndex = 0;
            lvAdocao.Items.Clear();
            btnEditar.Enabled = btnExcluir.Enabled = btnImprimir.Visible = false;
        }

        private bool CarregarAdotantes()
        {
            this.Cursor = Cursors.WaitCursor;
            lvAdocao.Items.Clear();
            Adotantes = AdotanteDAO.GetTodosRegistros(Global.Entidade.Id).OrderBy(k => k.Nome).ToList();

            var adotantesFiltrados = Adotantes.ToList();

            var filtroNomeOuIdAnimalSetado = false;
            var idAnimalFiltro = txtIdAnimal.Text == null ? string.Empty : txtIdAnimal.Text.ToLower();

            var filtroEspecieSetado = false;
            var especieSelecionada = (AnimalEspecie)cboEspecie.Items[cboEspecie.SelectedIndex];

            var filtroGeneroSetado = false;
            var generoSelecionado = cboGenero.Text;
            var idGeneroSelecionado = -1;

            if (adotantesFiltrados != null)
            {
                if (!string.IsNullOrEmpty(txtCPFNome.Text))
                {
                    adotantesFiltrados = adotantesFiltrados.Where(k => k.Nome.ToLower().Equals(txtCPFNome.Text?.ToLower()) ||
                                                                  k.CPF.ToLower().Equals(txtCPFNome.Text?.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(idAnimalFiltro))
                {
                    adotantesFiltrados = adotantesFiltrados.Where(adotante => adotante.Adocoes
                                                           .Any(adocao => adocao.Animal.Id.ToString().Equals(idAnimalFiltro) ||
                                                                          adocao.Animal.Nome.ToLower().Equals(idAnimalFiltro)))
                                                           .ToList();
                    filtroNomeOuIdAnimalSetado = true;
                }

                if (cboEspecie.SelectedIndex > 0)
                {
                    adotantesFiltrados = adotantesFiltrados.Where(adotante => adotante.Adocoes
                                                           .Any(adocao => adocao.Animal.AnimalEspecie != null && adocao.Animal.AnimalEspecie.Id == especieSelecionada.Id))
                                                           .ToList();
                    filtroEspecieSetado = true;
                }

                if (cboGenero.SelectedIndex > 0)
                {
                    if (!string.IsNullOrEmpty(generoSelecionado))
                    {
                        idGeneroSelecionado = Generos.FirstOrDefault(k => k.Value == generoSelecionado).Key;
                        adotantesFiltrados = adotantesFiltrados.Where(adotante => adotante.Adocoes
                                                               .Any(adocao => adocao.Animal.Genero == idGeneroSelecionado))
                                                               .ToList();
                        filtroGeneroSetado = true;
                    }
                }

                if (adotantesFiltrados.Any())
                {
                    var preAdocoes = adotantesFiltrados.Where(adocao => adocao.Adocoes == null || adocao.Adocoes.Count == 0).ToList();
                    var adocoes = adotantesFiltrados.Where(adocao => adocao.Adocoes != null || adocao.Adocoes.Count > 0).ToList();

                    if (preAdocoes.Any())
                    {
                        foreach (var item in preAdocoes)
                        {
                            var lvi = new ListViewItem();
                            lvi.Text = item.Id.ToString();
                            lvi.SubItems.Add(string.Empty);
                            lvi.SubItems.Add(item.Nome);
                            lvAdocao.Items.Add(lvi);
                        }
                    }

                    if (adocoes.Any())
                    {
                        foreach (var item in adocoes)
                        {
                            foreach (var adocao in item.Adocoes)
                            {
                                var nomeOuIdAnimal = adocao.Animal == null ? string.Empty : adocao.Animal.Nome;
                                var especie = adocao.Animal.AnimalEspecie == null ? string.Empty : adocao.Animal.AnimalEspecie.Descricao;
                                var idGenero = adocao.Animal.Genero;

                                if (filtroNomeOuIdAnimalSetado && !string.IsNullOrEmpty(nomeOuIdAnimal) && !nomeOuIdAnimal.ToLower().Equals(idAnimalFiltro))
                                    continue;

                                if (filtroEspecieSetado && !string.IsNullOrEmpty(especie) && !especie.ToLower().Equals(especieSelecionada.Descricao.ToLower()))
                                    continue;

                                if (filtroGeneroSetado && idGeneroSelecionado >= 0 && idGenero != idGeneroSelecionado)
                                    continue;

                                var lvi = new ListViewItem();
                                lvi.Text = item.Id.ToString();
                                lvi.SubItems.Add(adocao.Animal.Id.ToString());
                                lvi.SubItems.Add(item.Nome);
                                lvi.SubItems.Add(adocao.Animal == null ? string.Empty : adocao.Animal.Nome);
                                lvi.SubItems.Add(especie);
                                lvi.SubItems.Add(FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)idGenero));
                                lvi.SubItems.Add(FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumPossibilidades)adocao.Animal.Castrado));
                                lvi.SubItems.Add(adocao.DoadorAnimal == null ? string.Empty : adocao.DoadorAnimal);
                                lvi.SubItems.Add(adocao.DataAdocao == null ? string.Empty : adocao.DataAdocao.ToShortDateString());
                                lvi.SubItems.Add(adocao.LocalAdocao == null ? string.Empty : adocao.LocalAdocao);

                                lvAdocao.Items.Add(lvi);
                            }
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
            return adotantesFiltrados?.Count > 0;
        }

        private Adotante GetAdotanteSelecionado()
        {
            var adotanteAdocoes = new List<Adotante>();

            if (Convert.ToInt32(lvAdocao.SelectedItems[0].SubItems[0].Text) is int idAdotante)
            {
                adotanteAdocoes = Adotantes.Where(k => k.Id == idAdotante).ToList();
                var possuiAdocao = adotanteAdocoes?.Any(k => k.Adocoes.Any());

                if (possuiAdocao != true)
                {
                    return adotanteAdocoes.FirstOrDefault();
                }
                else if (possuiAdocao == true)
                {
                    if (Convert.ToInt32(lvAdocao.SelectedItems[0].SubItems[1].Text) is int idAnimal)
                    {
                        foreach (var adotante in adotanteAdocoes)
                        {
                            foreach(var adocao in adotante.Adocoes)
                            {
                                if (adocao.Animal.Id == idAnimal)
                                {
                                    var adocaoUnica = adotante;
                                    adocaoUnica.Adocoes.Clear();
                                    adocaoUnica.Adocoes.Add(adocao);
                                    return adocaoUnica;
                                }
                            }
                        }
                    }
                      
                }
            }
            return null;
        }

        private void EditarAdotante()
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAdocao, "editar"))
            {
                var adotante = GetAdotanteSelecionado();
                var formAdocao = new FormCadastroAdocao(adotante);
                formAdocao.FormClosing += new FormClosingEventHandler(this.FormAdotante_FormClosing);
                formAdocao.ShowDialog();
            }
            CarregarAdotantes();
        }

        #region Eventos

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var formAdotante = new FormCadastroAdocao(new Adotante());
            formAdotante.FormClosing += new FormClosingEventHandler(this.FormAdotante_FormClosing);
            formAdotante.ShowDialog();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!CarregarAdotantes())
                MessageBox.Show("Nenhum registro retornado.", "Status da ação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarAdotante();  
        }

        private void FormAdotante_FormClosing(object sender, FormClosingEventArgs e)
        {
            LimparComponentesTela();
            CarregarAdotantes();
        }


        private void lvAdocao_DoubleClick(object sender, EventArgs e)
        {
            EditarAdotante();
        }

        private void lvAdocao_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvAdocao.SelectedItems.Count > 0)
                btnEditar.Enabled = btnExcluir.Enabled = btnImprimir.Visible = true;
            else
                btnEditar.Enabled = btnExcluir.Enabled = btnImprimir.Visible = false;
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAdocao, "excluir"))
            {
                var solicitacao = FuncoesGerais.MensagemDesejaExcluir();

                if (solicitacao.Equals(DialogResult.OK) || solicitacao.Equals(DialogResult.Yes))
                {
                    var adotante = GetAdotanteSelecionado();
                    var excluir = AdotanteDAO.Apagar(adotante);

                    if (string.IsNullOrEmpty(excluir))
                    {
                        FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Excluir);
                        LimparComponentesTela();
                        CarregarAdotantes();
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparComponentesTela();
        }

        #endregion Eventos

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAdocao, "imprimir"))
            {
                var adotante = GetAdotanteSelecionado();

                var nomeArquivo = $"Cadastro adotante - {adotante.Nome}";
                var opcaoUsuario = FuncoesGerais.HabilitaSaveFile(saveFileImpressao, nomeArquivo, Enumeracoes.EnumFormatoArquivo.PDF);

                if (opcaoUsuario)
                {
                    this.Cursor = Cursors.WaitCursor;
                    var arquivoExistente = File.Exists($"{saveFileImpressao.FileName}.pdf");
                    if (!arquivoExistente)
                    {
                        var animal = adotante.Adocoes?.FirstOrDefault()?.Animal;
                        var adocao = adotante.Adocoes?.FirstOrDefault();
                        var titulo = adocao != null ? "FICHA CADASTRAL DA ADOÇÃO" : "FICHA CADASTRAL DO ADOTANTE";

                        var itensPDF = new ItensPDF()
                        {
                            TituloRelatorio = titulo,
                            Animal = animal,
                            Adocao = adocao,
                            Adotante = adotante,
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            var nomeArquivo = $"Adocoes_{DateTime.Today.ToShortDateString().Replace('/', '-')}";
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

        //private void List<ImpAdotante> DadosAimprimir()
        //{
        //    private static List<ImpAnimal> DadosAjustados()
        //    {
        //        var animaisOriginal = AnimalDAO.GetTodosRegistros(Global.UsuarioLogado.Entidade.Id);
        //        var animaisImpressao = new List<ImpAnimal>();

        //        var titlulo = ImpAnimal.GetCabecalho();
        //        animaisImpressao.Add(titlulo);

        //        if (animaisOriginal.Count > 0)
        //        {
        //            foreach (var item in animaisOriginal)
        //            {
        //                var animal = new ImpAnimal()
        //                {
        //                    Identificacao = item.Identificacao,
        //                    Nome = item.Nome,
        //                    DataNascimento = item.DataNascimento.ToShortDateString(),
        //                    Peso = item.Peso.ToString(),
        //                    Castrado = (FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumPossibilidades)item.Castrado)),
        //                    Deficiencia = item.Deficiencia,
        //                    Genero = (FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)item.Genero)),
        //                    Status = (FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumStatusAnimal)item.AnimalStatus)),
        //                    Raca = item.Raca,
        //                    Cor = item.AnimalCor?.Descricao,
        //                    Especie = item.AnimalEspecie?.Descricao,
        //                    Porte = item.AnimalPorte?.Descricao,
        //                    DataRecolhimento = item.Recolhimento?.DataRecolhimento.ToShortDateString(),
        //                    MotivoRecolhimento = item.MotivoRecolhimento?.Descricao,
        //                    Recolhedor = item.Recolhimento?.Recolhedor,
        //                    Observacao = item.Recolhimento?.Observacao,
        //                    DataFalecimento = item.DataFalecimento == DateTime.MinValue ? string.Empty : item.DataFalecimento.ToShortDateString(),
        //                    MotivoFalecimento = item.MotivoFalecimento?.Descricao,
        //                };

        //                animaisImpressao.Add(animal);
        //            }
        //        }
        //        return animaisImpressao;
        //    }
    }
}
