using Desktop.Classes;
using Desktop.DependencyInjection;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormCadastroAnimalAuxiliar : Form
    {
        private IAnimalService _animalService;

        private List<AnimalCor> _cores = new List<AnimalCor>();
        private List<AnimalPorte> _portes = new List<AnimalPorte>();
        private List<AnimalEspecie> _especies = new List<AnimalEspecie>();
        private List<MotivoRecolhimento> _motivosRecolhimento = new List<MotivoRecolhimento>();
        private List<MotivoFalecimento> _motivosFalecimento = new List<MotivoFalecimento>();

        private int _telaSelecionada = FormCadastroAnimal.TelaSelecionada;
        private int _acaoBotao = 0;

        private AnimalCor _animalCor;
        private AnimalPorte _animalPorte;
        private AnimalEspecie _animalEspecie;
        private MotivoRecolhimento _motivoRecolhimento;
        private MotivoFalecimento _motivoFalecimento;

        public FormCadastroAnimalAuxiliar()
        {
            InitializeComponent();
            InitializeServices();
            ControlarEstadoComponentes(true);
            ControlarVisibilidadeBotoes(false);
            CarregarListView();
        }

        private void InitializeServices()
        {
            _animalService = IocKernel.Get<IAnimalService>();
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
            switch (_telaSelecionada)
            {
                case (int)Enumeracoes.EnumTelaAuxiliar.Cor:
                    _cores.Clear();
                    _cores = _animalService.GetCoresOrdenadasPorNome(Global.Entidade.Id);
                    MontaListView(_cores);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.Porte:
                    _portes.Clear();
                    _portes = _animalService.GetPortesOrdenadosPorNome(Global.Entidade.Id);
                    MontaListView(_portes);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.Especie:
                    _especies.Clear();
                    _especies = _animalService.GetEspeciesOrdenadasPorNome(Global.Entidade.Id);
                    MontaListView(_especies);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento:
                    _motivosRecolhimento.Clear();
                    _motivosRecolhimento = _animalService.GetMotivosRecolhimentosOrdenadosPorNome(Global.Entidade.Id);
                    MontaListView(_motivosRecolhimento);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento:
                    _motivosFalecimento.Clear();
                    _motivosFalecimento = _animalService.GetMotivosFalecimentoOrdenadosPorNome(Global.Entidade.Id);
                    MontaListView(_motivosFalecimento);
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
            _acaoBotao = (int)Enumeracoes.EnumAcaoBotao.Novo;
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
            string descricao = txtDescricao.Text;
            bool resultado = false;

            if (_acaoBotao == (int)Enumeracoes.EnumAcaoBotao.Novo)
            {
                switch (_telaSelecionada)
                {
                    case (int)Enumeracoes.EnumTelaAuxiliar.Cor:
                        AnimalCor cor = new AnimalCor()
                        {
                            Entidade = Global.Entidade,
                            Descricao = descricao
                        };
                        resultado = _animalService.SalvarOuAtualizarCor(cor);
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.Porte:
                        AnimalPorte porte = new AnimalPorte()
                        {
                            Entidade = Global.Entidade,
                            Descricao = descricao
                        };
                        resultado = _animalService.SalvarOuAtualizarPorte(porte);
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.Especie:
                        AnimalEspecie especie = new AnimalEspecie()
                        {
                            Entidade = Global.Entidade,
                            Descricao = descricao
                        };
                        resultado = _animalService.SalvarOuAtualizarEspecie(especie);
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento:
                        MotivoRecolhimento motivo = new MotivoRecolhimento()
                        {
                            Entidade = Global.UsuarioLogado.Entidade,
                            Descricao = descricao
                        };
                        resultado = _animalService.SalvarOuAtualizarMotivoRecolhimento(motivo);
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento:
                        MotivoFalecimento motivoFalecimento = new MotivoFalecimento()
                        {
                            Entidade = Global.UsuarioLogado.Entidade,
                            Descricao = descricao
                        };
                        resultado = _animalService.SalvarOuAtualizarMotivoFalecimento(motivoFalecimento);
                        break;

                    default:
                        break;
                }
                if (resultado)
                    FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
                else
                    FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Salvar);
            }
            else
            {
                switch (_telaSelecionada)
                {
                    case (int)Enumeracoes.EnumTelaAuxiliar.Cor:
                        _animalCor.Descricao = descricao;
                        resultado = _animalService.SalvarOuAtualizarCor(_animalCor);
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.Porte:
                        _animalPorte.Descricao = descricao;
                        resultado = _animalService.SalvarOuAtualizarPorte(_animalPorte);
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.Especie:
                        _animalEspecie.Descricao = descricao;
                        resultado = _animalService.SalvarOuAtualizarEspecie(_animalEspecie);
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento:
                        _motivoRecolhimento.Descricao = descricao;
                        resultado = _animalService.SalvarOuAtualizarMotivoRecolhimento(_motivoRecolhimento);
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento:
                        _motivoFalecimento.Descricao = descricao;
                        resultado = _animalService.SalvarOuAtualizarMotivoFalecimento(_motivoFalecimento);
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
            ListViewItem linhaSelecionada = lvCadastrados.SelectedItems[0];
            int codigo = Convert.ToInt32(linhaSelecionada.SubItems[0].Text);
            string resultado = string.Empty;

            switch (_telaSelecionada)
            {
                case (int)Enumeracoes.EnumTelaAuxiliar.Cor:
                    AnimalCor corAtual = _cores.Find(k => k.Id == codigo);
                    resultado = _animalService.ExcluirCor(corAtual);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.Porte:
                    AnimalPorte porteAtual = _portes.Find(k => k.Id == codigo);
                    resultado = _animalService.ExcluirPorte(porteAtual);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.Especie:
                    AnimalEspecie especieAtual = _especies.Find(k => k.Id == codigo);
                    resultado = _animalService.ExcluirEspecie(especieAtual);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento:
                    MotivoRecolhimento motivo = _motivosRecolhimento.Find(k => k.Id == codigo);
                    resultado = _animalService.ExcluirMotivoRecolhimento(motivo);
                    break;

                case (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento:
                    MotivoFalecimento motivoFalecimento = _motivosFalecimento.Find(k => k.Id == codigo);
                    resultado =  _animalService.ExcluirMotivoFalecimento(motivoFalecimento);
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
                bool possuiChaveEstrangeira = resultado.ToLower().Contains("foreign key");
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
                _acaoBotao = (int)Enumeracoes.EnumAcaoBotao.Editar;
                ControlarEstadoComponentes(false);
                ControlarVisibilidadeBotoes(true);
                txtDescricao.Focus();
                txtDescricao.Select();

                ListViewItem linhaSelecionada = lvCadastrados.SelectedItems[0];
                int codigo = Convert.ToInt32(linhaSelecionada.SubItems[0].Text);

                switch (_telaSelecionada)
                {
                    case (int)Enumeracoes.EnumTelaAuxiliar.Cor:
                       
                        _animalCor = _cores.Find(k => k.Id == codigo);
                        txtDescricao.Text = _animalCor.Descricao;
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.Porte:
                        _animalPorte = _portes.Find(k => k.Id == codigo);
                        txtDescricao.Text = _animalPorte.Descricao;
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.Especie:
                        _animalEspecie = _especies.Find(k => k.Id == codigo);
                        txtDescricao.Text = _animalEspecie.Descricao;
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.MotivoRecolhimento:
                        _motivoRecolhimento = _motivosRecolhimento.Find(k => k.Id == codigo);
                        txtDescricao.Text = _motivoRecolhimento.Descricao;
                        break;

                    case (int)Enumeracoes.EnumTelaAuxiliar.MotivoFalecimento:
                        _motivoFalecimento = _motivosFalecimento.Find(k => k.Id == codigo);
                        txtDescricao.Text = _motivoFalecimento.Descricao;
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
