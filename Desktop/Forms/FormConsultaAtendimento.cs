using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.Entidades;
using System;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormConsultaAtendimento : Form
    {
        private Atendimento _atendimento = new Atendimento();

        public FormConsultaAtendimento(Atendimento atendimento, bool reagendar)
        {
            InitializeComponent();
            _atendimento = atendimento;
            CarregarAtendimento(reagendar);
        }

        private void CarregarAtendimento(bool reagendar)
        {
            var dadosAnimal = string.Empty;

            dadosAnimal += $"Identificação: {_atendimento.Animal.Identificacao}, Nome: {_atendimento.Animal.Nome}, Espécie: {_atendimento.Animal.AnimalEspecie.Descricao}, " +
                $"Gênero: {FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)_atendimento.Animal.Genero)}, Peso: {_atendimento.Animal.Peso.ToString()} Kg, " +
                $"Castrado: {FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumPossibilidades)_atendimento.Animal.Castrado)}, " +
                $"Idade: {FuncoesGerais.GetIdade(_atendimento.Animal.DataNascimento)}";
            rtbAnimal.Text = dadosAnimal;

            FuncoesGerais.SetImagemPictureBox(pbAnimal, _atendimento.Animal.Imagem);

            dtpHorario.Value = _atendimento.DataAtendimentoInicio;
            dtpData.Value = _atendimento.DataAtendimentoInicio;

            txtResponsavel.Text = _atendimento.ColaboradorExterno != null ? ($"{_atendimento.ColaboradorExterno.NomeEmpresa} - {_atendimento.ColaboradorExterno.NomeColaborador}") : (_atendimento.ColaboradorInterno != null ? _atendimento.ColaboradorInterno.Nome : string.Empty);
            txtAtendimento.Text = _atendimento.TipoAtendimento?.Nome;
            txtPatologia.Text = _atendimento.Patologia?.Nome;
            rtbObservacao.Text = _atendimento.Observacao;

            if (reagendar)
            {
                rtbObservacao.ReadOnly = false;
                rtbObservacao.Enabled = true;
                dtpData.Enabled = dtpHorario.Enabled = true;
                btnSalvar.Visible = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool DadosValidos()
        {
            if (dtpData.Value >= DateTime.Today)
                return true;
            else
            {
                MessageBox.Show("A data de agendamento deve ser maior ou igual ao dia de hoje.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (DadosValidos())
            {
                var horario = dtpHorario.Value.TimeOfDay;
                var dataInicial = dtpData.Value.AddMinutes(horario.Minutes);
                var dataFinal = dataInicial.AddMinutes(_atendimento.TipoAtendimento.DuracaoPadrao);

                _atendimento.DataAtendimentoInicio = dataInicial;
                _atendimento.DataAtendimentoFim = dataFinal;
                _atendimento.Observacao = rtbObservacao.Text;

                _atendimento.PreAtendimento.DataPreAtendimento = dataInicial.AddDays(-1);
                _atendimento.PreAtendimento.enumStatusPreAtendimento = (int)Enumeracoes.EnumStatusPreAtendimento.naoRealizado;
                _atendimento.PreAtendimento.TipoAtendimento = _atendimento.TipoAtendimento;

                if (AtendimentoDAO.Salvar(_atendimento))
                {
                    FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Editar);
                    this.Close();
                }
                else
                {
                    FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Editar);
                }
            }
        }
    }
}
