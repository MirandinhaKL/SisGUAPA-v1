using Desktop.Classes;
using Desktop.DependencyInjection;
using Dominio.Enums;
using Repositorio.Classes;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/*
 * Criado em: 15/11/21
 * Alterado em: 23/06/23
 */

namespace Desktop.Forms
{
    public partial class FormCadastroMedicamento : Form
    {
        private IAtendimentoService _atendimentoService;

        private List<Medicamento> _medicamentos;
        private Medicamento _medicamento = new Medicamento();
        private Dictionary<int, string> _unidades = new Dictionary<int, string>();

        public FormCadastroMedicamento()
        {
            InitializeComponent();
            InitializeServices();
            CarregarUnidades();
            CarregarToolTips();
            CarregarMedicamentos();
        }

        private void InitializeServices()
        {
            _atendimentoService = IocKernel.Get<IAtendimentoService>();
        }

        private void CarregarUnidades()
        {
            if (_unidades == null || _unidades.Count == 0)
            {
                var unidades = FuncoesGerais.ConverterEnumParaLista<EnumAtendimento.EnumUnidadeMedicamentos>();
                foreach (var item in unidades)
                    _unidades.Add((int)item, FuncoesGerais.GetDescricaoEnum(item));
            }

            comboUnidade.DataSource = _unidades.OrderBy(k => k.Key).ToList();
            comboUnidade.DisplayMember = "Value";
        }

        private void CarregarMedicamentos()
        {
            this.Cursor = Cursors.WaitCursor;
            lvMedicamento.Items.Clear();
            _medicamentos = _atendimentoService.GetMedicamentosOrdenadasPorNome(Global.Entidade.Id);

            if (_medicamentos.Any())
            {
                var contaLinha = 0;

                foreach (var item in _medicamentos)
                {
                    var lvi = new ListViewItem();

                    lvi.Text = item.Id.ToString();
                    lvi.SubItems.Add(item.Nome == null ? string.Empty : item.Nome);
                    lvi.SubItems.Add($"{item.Quantidade} {FuncoesGerais.GetDescricaoEnum((EnumAtendimento.EnumUnidadeMedicamentos)item.EnumUnidadeMedicamentos)}");
                    lvi.SubItems.Add(item.Duracao == 0 ? "Sem fim" : $"Por {item.Duracao} dia(s)");
                    lvi.SubItems.Add(EnumAtendimento.GetDescricaoFrequenciaIngestao(item.EnumFrequenciaIngestao, item.AuxiliarX, item.AuxiliarY, item.DiasDaSemana));

                    if (contaLinha % 2 == 0)
                        lvi.BackColor = Color.LightCyan;
                    contaLinha++;

                    lvMedicamento.Items.Add(lvi);
                }
            }
            else
            {
                MessageBox.Show("Nenhum medicamento cadastrado.", "Status da ação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Cursor = Cursors.Default;
        }

        private void CarregarToolTips()
        {
            toolTipNovo.SetToolTip(btnNovo, "Permite cadastrar um novo medicamento no sistema.");
            toolTipEditar.SetToolTip(btnEditar, "Permite editar os dados de um medicamento no sistema.");
            toolTipExcluir.SetToolTip(btnExcluir, "Permite excluir um medicamento no sistema.");
        }

        private bool DadosValidos()
        {
            var dadosValidos = true;

            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                errorProvider.SetError(txtNome, "Informe o nome do medicamento.");
                dadosValidos = false;
            }
            if (comboUnidade.SelectedIndex < 0)
            {
                errorProvider.SetError(comboUnidade, "Informe a unidade do medicamento.");
                dadosValidos = false;
            }
            if (!rbDuracaoSemData.Checked && !rbDuracaoXdia.Checked)
            {
                errorProvider.SetError(groupBox1, "Selecione a duração do medicamento.");
                dadosValidos = false;
            }
            if (rbDuracaoXdia.Checked)
            {
                if (numDuracaoDia.Value <= 0)
                {
                    errorProvider.SetError(label4, "O múmero de dias deve ser maior que zero.");
                    dadosValidos = false;
                }
            }
            if (!rbDiariamenteXvezDia.Checked && !rbDiariamenteXhora.Checked && !rbCadaXdia.Checked &&
                !rbDiaDaSemana.Checked && !rbCiclo.Checked)
            {
                errorProvider.SetError(groupBox2, "Selecione a frequência de ingestão do medicamento.");
                dadosValidos = false;
            }
            if (rbDiariamenteXvezDia.Checked)
            {
                if (numDiariamenteXvez.Value <= 0)
                {
                    errorProvider.SetError(label5, "O múmero de dias deve ser maior que zero.");
                    dadosValidos = false;
                }
            }
            if (rbDiariamenteXhora.Checked)
            {
                if (numDiariamenteXhora.Value <= 0)
                {
                    errorProvider.SetError(label6, "O múmero de dias deve ser maior que zero.");
                    dadosValidos = false;
                }
            }
            if (rbCadaXdia.Checked)
            {
                if (numCadaXdia.Value <= 0)
                {
                    errorProvider.SetError(label8, "O múmero de dias deve ser maior que zero.");
                    dadosValidos = false;
                }
            }
            if (rbDiaDaSemana.Checked)
            {
                if (!cbSegunda.Checked && !cbTerca.Checked && !cbQuarta.Checked && !cbQuinta.Checked &&
                    !cbSexta.Checked && !cbSabado.Checked && !cbDom.Checked)
                {
                    errorProvider.SetError(panelDiasDaSemana, "É necessário selecionar um dia da semana.");
                    dadosValidos = false;
                }
            }
            if (rbCiclo.Checked)
            {
                if (numCicloX.Value <= 0)
                {
                    errorProvider.SetError(label10, "O múmero de dias X deve ser maior que zero.");
                    dadosValidos = false;
                }
                if (numCicloY.Value <= 0)
                {
                    errorProvider.SetError(label10, "O múmero de dias Y deve ser maior que zero.");
                    dadosValidos = false;
                }
            }

            return dadosValidos;
        }

        private void EscondePaineisFrequencia()
        {
            panelDiariamenteDias.Visible = panelDiariamenteHoras.Visible = panelCadaXdias.Visible =
            panelDiasDaSemana.Visible = panelCiclo.Visible = false;
        }

        private void EscondePainelDuracao()
        {
            panelDuracao.Visible = false;
        }

        private int GetEnumFrequencia()
        {
            if (rbDiariamenteXvezDia.Checked)
                return (int)EnumAtendimento.EnumFrequenciaIngestao.diariamenteXvezesDia;
            if (rbDiariamenteXhora.Checked)
                return (int)EnumAtendimento.EnumFrequenciaIngestao.diariamenteCadaXhoras;
            if (rbCadaXdia.Checked)
                return (int)EnumAtendimento.EnumFrequenciaIngestao.cadaXdias;
            if (rbDiaDaSemana.Checked)
                return (int)EnumAtendimento.EnumFrequenciaIngestao.diasDaSemana;
            if (rbCiclo.Checked)
                return (int)EnumAtendimento.EnumFrequenciaIngestao.ciclosXativosYinativos;
            return -1;
        }

        private int GetAuxiliarX(int enumFrequenciaIngestao)
        {
            if (rbDiariamenteXvezDia.Checked)
                return (int)numDiariamenteXvez.Value;
            if (rbDiariamenteXhora.Checked)
                return (int)numDiariamenteXhora.Value;
            if (rbCadaXdia.Checked)
                return (int)numCadaXdia.Value;
            if (rbCiclo.Checked)
                return (int)numCicloX.Value;
            return 0;
        }

        private int GetAuxiliarY(int enumFrequenciaIngestao)
        {
            if (rbCiclo.Checked)
                return (int)numCicloY.Value;
            return 0;
        }

        private string GetDiasDaSemana(int enumFrequenciaIngestao)
        {
            var dias = string.Empty;
            if (rbDiaDaSemana.Checked)
            {
                if (cbSegunda.Checked)
                    dias += "2";
                if (cbTerca.Checked)
                    dias += "3";
                if (cbQuarta.Checked)
                    dias += "4";
                if (cbQuinta.Checked)
                    dias += "5";
                if (cbSexta.Checked)
                    dias += "6";
                if (cbSabado.Checked)
                    dias += "S";
                if (cbDom.Checked)
                    dias += "D";
            }
            return dias;
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            comboUnidade.SelectedIndex = -1;
            numQuantidade.Value = 1;

            rbDuracaoSemData.Checked = rbDuracaoXdia.Checked = false;
            numDuracaoDia.Value = 0;

            rbDiariamenteXvezDia.Checked = rbDiariamenteXhora.Checked = rbCadaXdia.Checked = rbDiaDaSemana.Checked = rbCiclo.Checked = false;
            numDiariamenteXvez.Value = numDiariamenteXhora.Value = numCadaXdia.Value = numCicloX.Value = numCicloY.Value = 0;
            cbSegunda.Checked = cbTerca.Checked = cbQuarta.Checked = cbQuinta.Checked = cbSexta.Checked = cbSabado.Checked = cbDom.Checked = false;

            errorProvider.Clear();

            txtNome.Focus();
            txtNome.Select();
        }

        private void SetMedicamento()
        {
            txtNome.Text = _medicamento.Nome;
            comboUnidade.SelectedIndex = _medicamento.EnumUnidadeMedicamentos;
            numQuantidade.Value = _medicamento.Quantidade;

            rbDuracaoSemData.Checked = _medicamento.Duracao == 0;
            rbDuracaoXdia.Checked = _medicamento.Duracao > 0;
            numDuracaoDia.Value = _medicamento.Duracao;

            if (_medicamento.EnumFrequenciaIngestao == (int)EnumAtendimento.EnumFrequenciaIngestao.diariamenteXvezesDia)
            {
                rbDiariamenteXvezDia.Checked = true;
                numDiariamenteXvez.Value = _medicamento.AuxiliarX;
            }
            else if (_medicamento.EnumFrequenciaIngestao == (int)EnumAtendimento.EnumFrequenciaIngestao.diariamenteCadaXhoras)
            {
                rbDiariamenteXhora.Checked = true;
                numDiariamenteXhora.Value = _medicamento.AuxiliarX;
            }
            else if (_medicamento.EnumFrequenciaIngestao == (int)EnumAtendimento.EnumFrequenciaIngestao.cadaXdias)
            {
                rbCadaXdia.Checked = true;
                numCadaXdia.Value = _medicamento.AuxiliarX;
            }
            else if (_medicamento.EnumFrequenciaIngestao == (int)EnumAtendimento.EnumFrequenciaIngestao.diasDaSemana)
            {
                rbDiaDaSemana.Checked = true;
                var dias = _medicamento.DiasDaSemana;
                if (!string.IsNullOrEmpty(dias))
                {
                    if (dias.Contains('2'))
                        cbSegunda.Checked = true;
                    if (dias.Contains('3'))
                        cbTerca.Checked = true;
                    if (dias.Contains('4'))
                        cbQuarta.Checked = true;
                    if (dias.Contains('5'))
                        cbQuinta.Checked = true;
                    if (dias.Contains('6'))
                        cbSexta.Checked = true;
                    if (dias.Contains('S'))
                        cbSabado.Checked = true;
                    if (dias.Contains('D'))
                        cbDom.Checked = true;
                }
            }
            else if (_medicamento.EnumFrequenciaIngestao == (int)EnumAtendimento.EnumFrequenciaIngestao.ciclosXativosYinativos)
            {
                rbCiclo.Checked = true;
                numCicloX.Value = _medicamento.AuxiliarX;
                numCicloY.Value = _medicamento.AuxiliarY;
            }
        }

        private void EditarDados()
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvMedicamento, "editar"))
            {
                EscondePaineisFrequencia();
                EscondePainelDuracao();

                LimparCampos();
                if (Convert.ToInt32(lvMedicamento.SelectedItems[0].SubItems[0].Text) is int idMedicamento)
                {
                    panelDados.Visible = btnSalvar.Visible = true;

                    _medicamento = _medicamentos.Find(k => k.Id == idMedicamento);
                    SetMedicamento();
                }
            }
        }

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            panelDados.Visible = btnSalvar.Visible = true;
            LimparCampos();
            EscondePaineisFrequencia();
            EscondePainelDuracao();
        }

        private void rbDuracaoSemData_CheckedChanged(object sender, EventArgs e)
        {
            EscondePainelDuracao();
        }

        private void rbDuracaoXdia_CheckedChanged(object sender, EventArgs e)
        {
            EscondePainelDuracao();
            panelDuracao.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            EscondePaineisFrequencia();
            panelDiariamenteDias.Visible = true;
        }

        private void rbDiariamenteXhora_CheckedChanged(object sender, EventArgs e)
        {
            EscondePaineisFrequencia();
            panelDiariamenteHoras.Visible = true;
        }

        private void rbCadaXdia_CheckedChanged(object sender, EventArgs e)
        {
            EscondePaineisFrequencia();
            panelCadaXdias.Visible = true;
        }

        private void rbDiaDaSemana_CheckedChanged(object sender, EventArgs e)
        {
            EscondePaineisFrequencia();
            panelDiasDaSemana.Visible = true;
        }

        private void rbCiclo_CheckedChanged(object sender, EventArgs e)
        {
            EscondePaineisFrequencia();
            panelCiclo.Visible = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (DadosValidos())
            {
                _medicamento.Nome = txtNome.Text;
                _medicamento.EnumUnidadeMedicamentos = _unidades.FirstOrDefault(k => k.Value == comboUnidade.Text).Key;
                _medicamento.Quantidade = numQuantidade.Value;

                _medicamento.Duracao = rbDuracaoXdia.Checked == true ? (int)numDuracaoDia.Value : 0;
                _medicamento.EnumFrequenciaIngestao = GetEnumFrequencia();
                _medicamento.AuxiliarX = GetAuxiliarX(_medicamento.EnumFrequenciaIngestao);
                _medicamento.AuxiliarY = GetAuxiliarY(_medicamento.EnumFrequenciaIngestao);
                _medicamento.DiasDaSemana = GetDiasDaSemana(_medicamento.EnumFrequenciaIngestao);
                _medicamento.Entidade = Global.Entidade;

                if (_atendimentoService.SalvarOuAtualizarMedicamento(_medicamento))
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
     
        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarDados();
        }
       
        private void lvMedicamento_DoubleClick(object sender, EventArgs e)
        {
            EditarDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvMedicamento, "excluir"))
            {
                var solicitacao = FuncoesGerais.MensagemDesejaExcluir();

                if (solicitacao.Equals(DialogResult.OK) || solicitacao.Equals(DialogResult.Yes))
                {
                    if (Convert.ToInt32(lvMedicamento.SelectedItems[0].SubItems[0].Text) is int idMedicamento)
                    {
                        _medicamento = _medicamentos.Find(k => k.Id == idMedicamento);

                        var status = _atendimentoService.ExcluirMedicamento(_medicamento);
                        if (string.IsNullOrEmpty(status))
                        {
                            FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Excluir);
                            this.Close();
                        }
                        else
                        {
                            var possuiChaveEstrangeira = status.ToLower().Contains("foreign key");
                            if (possuiChaveEstrangeira)
                                FuncoesGerais.MensagemFalhaRestricaoChave();
                            else
                                FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Excluir);
                        }
                    }
                }
            }
        }
        #endregion Eventos
    }
}