using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.Entidades;
using System;
using System.Windows.Forms;

/*
 * Criado em: 10/11/21 
 */

namespace Desktop.Forms
{
    public partial class FormEncerraHospedagem : Form
    {
        private Hospedagem _hospedagem;

        public FormEncerraHospedagem(Hospedagem hospedagem)
        {
            _hospedagem = hospedagem;
            InitializeComponent();
            CarregarDadosHospedagem();
        }

        private void CarregarDadosHospedagem()
        {
            if (_hospedagem != null)
            {
                txtIdAnimal.Text = $"{_hospedagem.Animal?.Id} - {_hospedagem.Animal?.Nome}";
                txtResponsavel.Text = _hospedagem.LarTemporario?.Nome;
                dtpDataInicio.Value = _hospedagem.DataInicio;
                rtbObservacao.Text = _hospedagem.ObservacaoFinal;

                if (_hospedagem.DataFinal != null && _hospedagem.DataFinal > DateTime.MinValue)
                    dtpDataFinal.Value = _hospedagem.DataFinal;
            }
        }

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            _hospedagem.DataFinal = dtpDataFinal.Value;
            _hospedagem.ObservacaoFinal = rtbObservacao.Text;

            if (HospedagemDAO.Salvar(_hospedagem))
            {
                FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
                this.Close();
            }
            else
            {
                FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Salvar);
            }
        }

        #endregion Eventos
    }
}
