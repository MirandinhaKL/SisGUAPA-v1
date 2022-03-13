using Desktop.Classes;
using Repositorio.DAO;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormCadastroAnimalAuxiliar : Form
    {
        private List<AnimalCor> Cores = new List<AnimalCor>();
        private List<AnimalPorte> Portes = new List<AnimalPorte>();
        private List<AnimalEspecie> Especies = new List<AnimalEspecie>();
        private List<MotivoRecolhimento> MotivosRecolhimento = new List<MotivoRecolhimento>();
        private List<MotivoFalecimento> MotivosFalecimento = new List<MotivoFalecimento>();

        private int TelaSelecionada = FormCadastroAnimal.TelaSelecionada;
        private int AcaoBotao = 0;

        private AnimalCor AnimalCor;
        private AnimalPorte AnimalPorte;
        private AnimalEspecie AnimalEspecie;
        private MotivoRecolhimento MotivoRecolhimento;
        private MotivoFalecimento MotivoFalecimento;

        public FormCadastroAnimalAuxiliar()
        {
            InitializeComponent();
            ControlarEstadoComponentes(true);
            ControlarVisibilidadeBotoes(false);
            CarregarListView();
        }

        private void ControlarEstadoComponentes(bool habilita)
        {
            panelCadastro.Enabled = !habilita;
            btnNovo.Enabled = habilita;
            txtDescricao.Text = string.Empty;
            lvCadastrados.Enabled = habilita;
        }

        private void CarregarListView()
        {
            this.Cursor = Cursors.WaitCursor;
            switch (TelaSelecionada)
            {
                case (int)Enumeracoes.EnumTelaAuxiliar.Cor:
                    Cores.Clear();
                    Cores = AnimalCorDAO.GetTodosRegistros(Global.UsuarioLogado.Entidade.Id).OrderBy(k => k.Descricao).ToList();
                    MontaListView(Cores);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.Porte:
                    Portes.Clear();
                    Portes = AnimalPorteDAO.GetTodosRegistros(Global.UsuarioLogado.Entidade.Id).OrderBy(k => k.Descricao).ToList();
                    MontaListView(Portes);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.Especie:
                    Especies.Clear();
                    Especies = AnimalEspecieDAO.GetTodosRegistros(Global.UsuarioLogado.Entidade.Id).OrderBy(k => k.Descricao).ToList();
                    MontaListView(Especies);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento:
                    MotivosRecolhimento.Clear();
                    MotivosRecolhimento = MotivoRecolhimentoDAO.GetTodosRegistros(Global.UsuarioLogado.Entidade.Id).OrderBy(k => k.Descricao).ToList();
                    MontaListView(MotivosRecolhimento);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento:
                    MotivosFalecimento.Clear();
                    MotivosFalecimento = MotivoFalecimentoDAO.GetTodosRegistros(Global.UsuarioLogado.Entidade.Id).OrderBy(k => k.Descricao).ToList();
                    MontaListView(MotivosFalecimento);
                    break;

                default:
                    break;
            }
            this.Cursor = Cursors.Default;
        }

        private void MontaListView(dynamic lista)
        {
            int contaLinha = 0;
            lvCadastrados.Items.Clear();
            foreach (var item in lista)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.Id.ToString();
                lvi.SubItems.Add(item.Descricao.ToUpper());
                lvi.ForeColor = Color.Black;

                if (contaLinha % 2 == 0)
                    lvi.BackColor = Color.LightCyan;

                contaLinha++;
                lvCadastrados.Items.Add(lvi);
            }
        }

        private void ControlarVisibilidadeBotoes(bool visivel)
        {
            btnEditar.Visible = visivel;
            btnExcluir.Visible = visivel;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            AcaoBotaoNovo();
        }

        private void AcaoBotaoNovo()
        {
            ControlarEstadoComponentes(false);
            ControlarVisibilidadeBotoes(false);
            txtDescricao.Focus();
            txtDescricao.Select();
            AcaoBotao = (int)Enumeracoes.EnumAcaoBotao.Novo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            errTxtDescricao.Clear();
            ControlarEstadoComponentes(true);
            ControlarVisibilidadeBotoes(false);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            errTxtDescricao.Clear();
            errTxtDescricao.Clear();
            if (txtDescricao.Text == string.Empty)
            {
                errTxtDescricao.SetError(txtDescricao, "Informe uma descrição para salvar o registro.");
                return;
            }
            else
            {
                string descricao = txtDescricao.Text;

                if (AcaoBotao == (int)Enumeracoes.EnumAcaoBotao.Novo)
                {
                    var resultado = (int)Enumeracoes.EnumStatusDaAcao.FALHA;

                    switch (TelaSelecionada)
                    {

                        case (int)Enumeracoes.EnumTelaAuxiliar.Cor:
                            AnimalCor cor = new AnimalCor()
                            {
                                Entidade = Global.UsuarioLogado.Entidade,
                                Descricao = descricao
                            };
                            
                            resultado = AnimalCorDAO.Salvar(cor);
                            break;

                        case (int)Enumeracoes.EnumTelaAuxiliar.Porte:
                            AnimalPorte porte = new AnimalPorte()
                            {
                                Entidade = Global.UsuarioLogado.Entidade,
                                Descricao = descricao
                            };
                            resultado = AnimalPorteDAO.Salvar(porte);
                            break;

                        case (int)Enumeracoes.EnumTelaAuxiliar.Especie:
                            AnimalEspecie especie = new AnimalEspecie()
                            {
                                Entidade = Global.UsuarioLogado.Entidade,
                                Descricao = descricao
                            };
                            resultado = AnimalEspecieDAO.Salvar(especie);
                            break;

                        case (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento:
                            MotivoRecolhimento motivo = new MotivoRecolhimento()
                            {
                                Entidade = Global.UsuarioLogado.Entidade,
                                Descricao = descricao
                            };
                            resultado = MotivoRecolhimentoDAO.Salvar(motivo);
                            break;

                        case (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento:
                            MotivoFalecimento motivoFalecimento = new MotivoFalecimento()
                            {
                                Entidade = Global.UsuarioLogado.Entidade,
                                Descricao = descricao
                            };
                            resultado = MotivoFalecimentoDAO.Salvar(motivoFalecimento);
                            break;

                        default:
                            break;
                    }

                    if (resultado != (int)Enumeracoes.EnumStatusDaAcao.FALHA)
                        FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
                    else
                        FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Salvar);
                }
                else
                {
                    var resultado = false;

                    switch (TelaSelecionada)
                    {
                        case (int)Enumeracoes.EnumTelaAuxiliar.Cor:
                            AnimalCor.Descricao = descricao;
                            resultado = AnimalCorDAO.Atualizar(AnimalCor);
                            break;

                        case (int)Enumeracoes.EnumTelaAuxiliar.Porte:
                            AnimalPorte.Descricao = descricao;
                            resultado = AnimalPorteDAO.Atualizar(AnimalPorte);
                            break;

                        case (int)Enumeracoes.EnumTelaAuxiliar.Especie:
                            AnimalEspecie.Descricao = descricao;
                            resultado = AnimalEspecieDAO.Atualizar(AnimalEspecie);
                            break;

                        case (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento:
                            MotivoRecolhimento.Descricao = descricao;
                            resultado = MotivoRecolhimentoDAO.Atualizar(MotivoRecolhimento);
                            break;

                        case (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento:
                            MotivoFalecimento.Descricao = descricao;
                            resultado = MotivoFalecimentoDAO.Atualizar(MotivoFalecimento);
                            break;

                        default:
                            break;
                    }

                    if (resultado)
                        FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Editar);
                    else
                        FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Editar);
                }

                CarregarListView();
                ControlarEstadoComponentes(true);
                ControlarVisibilidadeBotoes(false);
            }
        }

        private void lvCadastrados_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvCadastrados.SelectedItems.Count > 0)
                ControlarVisibilidadeBotoes(true);
            else
                ControlarVisibilidadeBotoes(false);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvCadastrados, "excluir"))
            {
                var resultado = FuncoesGerais.MensagemDesejaExcluir();

                if (resultado == DialogResult.OK || resultado == DialogResult.Yes)
                    Excluir();
                else
                {
                    ControlarEstadoComponentes(true);
                    ControlarVisibilidadeBotoes(false);
                }
            }
        }

        private void Excluir()
        {
            var linhaSelecionada = lvCadastrados.SelectedItems[0];
            var codigo = Convert.ToInt32(linhaSelecionada.SubItems[0].Text);
            var resultado = string.Empty;

            switch (TelaSelecionada)
            {
                case (int)Enumeracoes.EnumTelaAuxiliar.Cor:
                    var corAtual = Cores.Find(k => k.Id == codigo);
                    resultado = AnimalCorDAO.Apagar(corAtual);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.Porte:
                    var porteAtual = Portes.Find(k => k.Id == codigo);
                    resultado = AnimalPorteDAO.Apagar(porteAtual);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.Especie:
                    var especieAtual = Especies.Find(k => k.Id == codigo);
                    resultado = AnimalEspecieDAO.Apagar(especieAtual);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento:
                    var motivo = MotivosRecolhimento.Find(k => k.Id == codigo);
                    resultado = MotivoRecolhimentoDAO.Apagar(motivo);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento:
                    var motivoFalecimento = MotivosFalecimento.Find(k => k.Id == codigo);
                    resultado = MotivoFalecimentoDAO.Apagar(motivoFalecimento);
                    break;

                default:
                    break;
            }

            if (string.IsNullOrEmpty(resultado))
            {
                FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Excluir);
                CarregarListView();
                ControlarEstadoComponentes(true);
                ControlarVisibilidadeBotoes(false);
            }
            else
            {
                var possuiChaveEstrangeira = resultado.ToLower().Contains("foreign key");
                if (possuiChaveEstrangeira)
                    FuncoesGerais.MensagemFalhaRestricaoChave();
                else
                    FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Excluir);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvCadastrados, "editar"))
            {
                AcaoBotao = (int)Enumeracoes.EnumAcaoBotao.Editar;
                ControlarEstadoComponentes(false);
                ControlarVisibilidadeBotoes(true);
                txtDescricao.Focus();
                txtDescricao.Select();

                var linhaSelecionada = lvCadastrados.SelectedItems[0];
                var codigo = Convert.ToInt32(linhaSelecionada.SubItems[0].Text);

                switch (TelaSelecionada)
                {
                    case (int)Enumeracoes.EnumTelaAuxiliar.Cor:
                       
                        AnimalCor = Cores.Find(k => k.Id == codigo);
                        txtDescricao.Text = AnimalCor.Descricao;
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.Porte:
                        AnimalPorte = Portes.Find(k => k.Id == codigo);
                        txtDescricao.Text = AnimalPorte.Descricao;
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.Especie:
                        AnimalEspecie = Especies.Find(k => k.Id == codigo);
                        txtDescricao.Text = AnimalEspecie.Descricao;
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento:
                        MotivoRecolhimento = MotivosRecolhimento.Find(k => k.Id == codigo);
                        txtDescricao.Text = MotivoRecolhimento.Descricao;
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento:
                        MotivoFalecimento = MotivosFalecimento.Find(k => k.Id == codigo);
                        txtDescricao.Text = MotivoFalecimento.Descricao;
                        break;

                    default:
                        break;
                }
            }
        }

        private void FormAnimalAuxiliar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    AcaoBotaoNovo();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
