using Desktop.Classes;
using Repositorio.DAO;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormRegras : Form
    {
        private List<RegraAtendimento> _regras;

        public FormRegras()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            _regras = RegraAtendimentoDAO.GetTodosRegistros(Global.Entidade.Id).ToList();

            if (_regras != null && _regras.Count > 0)
            {
                txtAntipulga.Text = _regras.Where(k => k.Procedimento == "antipulga").Select(k => k.NumeroDias).First().ToString();
                txtVermifugo.Text = _regras.Where(k => k.Procedimento == "vermifugo").Select(k => k.NumeroDias).First().ToString();
                txtVacina.Text = _regras.Where(k => k.Procedimento == "vacina").Select(k => k.NumeroDias).First().ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarDados()
        {
            if (string.IsNullOrEmpty(txtAntipulga.Text) || string.IsNullOrEmpty(txtVacina.Text) || string.IsNullOrEmpty(txtVermifugo.Text))
            {
                MessageBox.Show("Todos os campos devem ter valor maior que 0 e menor que 1000 dias.",
                    "Falha ao atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarDados())
            {
                bool retorno1 = true;
                bool retorno2 = true;
                bool retorno3 = true;
                bool antiPulgaAlterado = Convert.ToInt32(txtAntipulga.Text) != _regras.Where(k => k.Procedimento == "antipulga").Select(k => k.NumeroDias).First();
                bool vermifugoAlterado = Convert.ToInt32(txtVermifugo.Text) != _regras.Where(k => k.Procedimento == "vermifugo").Select(k => k.NumeroDias).First();
                bool vacinaAlterado = Convert.ToInt32(txtVacina.Text) != _regras.Where(k => k.Procedimento == "vacina").Select(k => k.NumeroDias).First();

                if (antiPulgaAlterado)
                {
                    var antipulga = _regras.Where(k => k.Procedimento == "antipulga").FirstOrDefault();
                    antipulga.NumeroDias = Convert.ToInt32(txtAntipulga.Text);
                    retorno1 = RegraAtendimentoDAO.Salvar(antipulga);
                }
                if (vermifugoAlterado)
                {
                    var vermifugo = _regras.Where(k => k.Procedimento == "vermifugo").FirstOrDefault();
                    vermifugo.NumeroDias = Convert.ToInt32(txtVermifugo.Text);
                    retorno2 = RegraAtendimentoDAO.Salvar(vermifugo);
                }
                if (vacinaAlterado)
                {
                    var vacina = _regras.Where(k => k.Procedimento == "vacina").FirstOrDefault();
                    vacina.NumeroDias = Convert.ToInt32(txtVacina.Text);
                    retorno3 = RegraAtendimentoDAO.Salvar(vacina);
                }
                if (retorno1 && retorno2 && retorno3)
                {
                    FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Editar);
                    this.Close();
                }
                else
                    FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Editar);
            }
        }

        private void txtAntipulga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void txtVermifugo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void txtVacina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                e.Handled = true;
        }
    }
}
