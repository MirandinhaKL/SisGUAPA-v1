using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormRealizaAtendimento : Form
    {
        private List<Medicamento> _medicamentos;
        private Atendimento _atendimento;

        public FormRealizaAtendimento(Atendimento atendimento)
        {
            InitializeComponent();
            HabilitarCombos(false);
            CarregaCombosMedicamentos();
            SetAtendimento(atendimento);
        }

        private void SetAtendimento(Atendimento atendimento)
        {
            _atendimento = atendimento;

            var dadosAnimal = string.Empty;

            dadosAnimal += $"Identificação: {atendimento.Animal.Identificacao}, Nome: {atendimento.Animal.Nome}, Espécie: {atendimento.Animal.AnimalEspecie.Descricao}, " +
                $"Gênero: {FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)atendimento.Animal.Genero)}, Peso: {atendimento.Animal.Peso.ToString()} Kg, " +
                $"Castrado: {FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumPossibilidades)atendimento.Animal.Castrado)}, " +
                $"Idade: {FuncoesGerais.GetIdade(atendimento.Animal.DataNascimento)}";
            rtbAnimal.Text = dadosAnimal;

            FuncoesGerais.SetImagemPictureBox(pbAnimal, atendimento.Animal.Imagem);

            txtResponsavel.Text = atendimento.ColaboradorInterno != null ? atendimento.ColaboradorInterno.Nome : $"{atendimento.ColaboradorExterno.NomeEmpresa} - {atendimento.ColaboradorExterno.NomeColaborador}";
            txtAtendimento.Text = atendimento.TipoAtendimento?.Nome;
            txtPatologia.Text = atendimento.Patologia?.Nome;

            rtbObservacao.Text = atendimento.Observacao;
        }

        private void HabilitarCombos(bool habilitar)
        {
            cbMedicamento2.Enabled = cbMedicamento3.Enabled = cbMedicamento4.Enabled = cbMedicamento5.Enabled = habilitar;
        }

        private void CarregaCombosMedicamentos()
        {
            _medicamentos = MedicamentoDAO.GetTodosRegistros(Global.Entidade.Id).ToList();
            _medicamentos.Add(new Medicamento { Id = 0, Nome = string.Empty, Entidade = Global.UsuarioLogado.Entidade });

            SetComboMedicamentos(cbMedicamento1);
            SetComboMedicamentos(cbMedicamento2);
            SetComboMedicamentos(cbMedicamento3);
            SetComboMedicamentos(cbMedicamento4);
            SetComboMedicamentos(cbMedicamento5);
        }

        private void SetComboMedicamentos(ComboBox combo)
        {
            combo.DataSource = _medicamentos.OrderBy(k => k.Nome).ToList();
            combo.DisplayMember = "Nome";
        }

        #region Eventos


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            _atendimento.Observacao = rtbObservacao.Text;
            _atendimento.StatusRealizacaoAtendimento = (int)Enumeracoes.StatusRealizacaoAtendimento.realizado;
            
            var possuiTratamento = false;

            var tratamento = new Tratamento();
            tratamento.Entidade = Global.Entidade;

            if (cbMedicamento1.SelectedIndex > 0)
            {
                var medicamento = (Medicamento)cbMedicamento1.Items[cbMedicamento1.SelectedIndex];
                tratamento.Medicamento1 = medicamento;
                tratamento.EnumStatusMedicacao1 = (int)Enumeracoes.EnumStatusMedicacao.naoIniciado;
                possuiTratamento = true;
            }
            else
                tratamento.EnumStatusMedicacao1 = (int)Enumeracoes.EnumStatusMedicacao.naoPossui;

            if (cbMedicamento2.SelectedIndex > 0)
            {
                var medicamento = (Medicamento)cbMedicamento2.Items[cbMedicamento2.SelectedIndex];
                tratamento.Medicamento2 = medicamento;
                tratamento.EnumStatusMedicacao2 = (int)Enumeracoes.EnumStatusMedicacao.naoIniciado;
            }
            else
                tratamento.EnumStatusMedicacao2 = (int)Enumeracoes.EnumStatusMedicacao.naoPossui;

            if (cbMedicamento3.SelectedIndex > 0)
            {
                var medicamento = (Medicamento)cbMedicamento3.Items[cbMedicamento3.SelectedIndex];
                tratamento.Medicamento3 = medicamento;
                tratamento.EnumStatusMedicacao3 = (int)Enumeracoes.EnumStatusMedicacao.naoIniciado;
            }
            else
                tratamento.EnumStatusMedicacao3 = (int)Enumeracoes.EnumStatusMedicacao.naoPossui;

            if (cbMedicamento4.SelectedIndex > 0)
            {
                var medicamento = (Medicamento)cbMedicamento4.Items[cbMedicamento4.SelectedIndex];
                tratamento.Medicamento4 = medicamento;
                tratamento.EnumStatusMedicacao4 = (int)Enumeracoes.EnumStatusMedicacao.naoIniciado;
            }
            else
                tratamento.EnumStatusMedicacao4 = (int)Enumeracoes.EnumStatusMedicacao.naoPossui;

            if (cbMedicamento5.SelectedIndex > 0)
            {
                var medicamento = (Medicamento)cbMedicamento5.Items[cbMedicamento5.SelectedIndex];
                tratamento.Medicamento5 = medicamento;
                tratamento.EnumStatusMedicacao5 = (int)Enumeracoes.EnumStatusMedicacao.naoIniciado;
            }
            else
                tratamento.EnumStatusMedicacao5 = (int)Enumeracoes.EnumStatusMedicacao.naoPossui;

            if (possuiTratamento)
                tratamento.EnumStatusTratamento = (int)Enumeracoes.EnumStatusTratamento.naoIniciado;
            else
                tratamento.EnumStatusTratamento = (int)Enumeracoes.EnumStatusTratamento.naoPossui;

            _atendimento.Tratamento = tratamento;
            tratamento.Atendimento = _atendimento;

            if (AtendimentoDAO.Salvar(_atendimento))
            {
                FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
                this.Close();
            }
            else
            {
                FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Salvar);
            }
        }

        private void btnNovoMedicamento_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var form = new FormCadastroMedicamento();
            form.FormClosing += new FormClosingEventHandler(this.FormCadastroMedicamento_FormClosing);
            form.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void FormCadastroMedicamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            CarregaCombosMedicamentos();
        }

        private void cbMedicamento1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMedicamento1.SelectedIndex > 0)
                cbMedicamento2.Enabled = true;
            else
            {
                cbMedicamento2.Enabled = cbMedicamento3.Enabled = cbMedicamento4.Enabled = cbMedicamento5.Enabled = false;
                cbMedicamento2.SelectedIndex = cbMedicamento3.SelectedIndex = cbMedicamento4.SelectedIndex = cbMedicamento5.SelectedIndex = -1;
            }
        }

        private void cbMedicamento2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMedicamento2.SelectedIndex > 0)
                cbMedicamento3.Enabled = true;
            else
            {
                cbMedicamento3.Enabled = cbMedicamento4.Enabled = cbMedicamento5.Enabled = false;
                cbMedicamento3.SelectedIndex = cbMedicamento4.SelectedIndex = cbMedicamento5.SelectedIndex = -1;
            }
        }

        private void cbMedicamento3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMedicamento3.SelectedIndex > 0)
                cbMedicamento4.Enabled = true;
            else
            {
                cbMedicamento4.Enabled = cbMedicamento5.Enabled = false;
                cbMedicamento4.SelectedIndex = cbMedicamento5.SelectedIndex = -1;
            }
        }

        private void cbMedicamento4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMedicamento4.SelectedIndex > 0)
                cbMedicamento5.Enabled = true;
            else
            {
                cbMedicamento5.Enabled = false;
                cbMedicamento5.SelectedIndex = -1;
            }
        }

        #endregion Eventos
    }
}
