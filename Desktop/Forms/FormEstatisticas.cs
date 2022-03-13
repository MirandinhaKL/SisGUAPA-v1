using Desktop.Classes;
using Repositorio.DAO;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormEstatisticas : Form
    {
        private List<Animal> AnimaisOriginal;
        private List<Adocao> AdocoesOriginal;

        private List<Animal> AnimaisFiltrado = new List<Animal>();
        private List<Adocao> AdocoesFiltradas = new List<Adocao>();

        private const string MensagemDadosAnimaisDisponiveis = "Dados calculados para os animais disponíveis para adoção conforme o período selecionado no filtro.";
        private const string MensagemDadosAnimaisAdotados = "Dados calculados para os animais adotados conforme o período selecionado no filtro.";
        
        public FormEstatisticas()
        {
            InitializeComponent();
            CarregarDados();
            FiltrarDados(EnumIntervalo.Mensal);
            CarregarGraficos();
        }

        private void CarregarDados()
        {
            AnimaisOriginal = AnimalDAO.GetTodosRegistros(Global.Entidade.Id).ToList();

            var adocoes = AdocaoDAO.GetTodosRegistros(Global.Entidade.Id);
            AdocoesOriginal = adocoes.Where(k => k.Adotante != null && k.Animal != null).ToList();
        }

        private void FiltrarDados(EnumIntervalo intervalo) 
        {
            AnimaisFiltrado.Clear();
            AdocoesFiltradas.Clear();

            if ((int)intervalo == (int)EnumIntervalo.Mensal)
            {
                AnimaisFiltrado = AnimaisOriginal.FindAll(k => k.Recolhimento.DataRecolhimento.Month == DateTime.Today.Month && k.Recolhimento.DataRecolhimento.Year == DateTime.Today.Year);
                AdocoesFiltradas = AdocoesOriginal.FindAll(k => k.DataAdocao.Month == DateTime.Today.Month && k.DataAdocao.Year == DateTime.Today.Year);
            }
            else if ((int)intervalo == (int)EnumIntervalo.Anual)
            {
                AnimaisFiltrado = AnimaisOriginal.FindAll(k => k.Recolhimento.DataRecolhimento.Year == DateTime.Today.Year);
                AdocoesFiltradas = AdocoesOriginal.FindAll(k => k.DataAdocao.Year == DateTime.Today.Year);
            }
            else
            {
                AnimaisFiltrado = AnimaisOriginal.Where(k =>
                    DateTime.Compare(k.Recolhimento.DataRecolhimento.Date, dtpInicioIntervalo.Value.Date) >= 0 &&
                    DateTime.Compare(k.Recolhimento.DataRecolhimento.Date, dtpFimIntervalo.Value.Date) <= 0).ToList();

                AdocoesFiltradas = AdocoesOriginal.Where(k =>
                    DateTime.Compare(k.DataAdocao.Date, dtpInicioIntervalo.Value.Date) >= 0 &&
                    DateTime.Compare(k.DataAdocao.Date, dtpFimIntervalo.Value.Date) <= 0).ToList();
            }
        }

        private enum EnumIntervalo
        {
            Mensal = 1,
            Anual = 2,
            Personalizado = 3
        }

        private void CarregarGraficos()
        {
            CarregarGraficoGenero();
            CarregarGraficoCastracao();
            CarregarGraficoIdade();

            CarregarGraficoGeneroAdotados();
            CarregarGraficoCastracaoAdotados();
            CarregarGraficoIdadeAdotados();
            
            CalcularNumerosAbsolutos();
        }

        private void CarregarGraficoGenero()
        {
            var rotulos = new string[3] { "Macho", "Fêmea", "Não informado" };
            var valores = new double[3] { 0, 0, 0 };

            if (AnimaisFiltrado.Any())
            {
                var generoMasculino = AnimaisFiltrado.Count(k =>
                      k.Genero == (int)Enumeracoes.EnumGenero.Masculino &&
                      k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível);

                var generoFeminino = AnimaisFiltrado.Count(k =>
                    k.Genero == (int)Enumeracoes.EnumGenero.Feminino &&
                    k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível);

                var generoNaoSabe = AnimaisFiltrado.Count(k =>
                    k.Genero == (int)Enumeracoes.EnumGenero.NaoSei &&
                    k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível);

                float total = generoMasculino + generoFeminino + generoNaoSabe;

                var percentMasculino = Math.Round((generoMasculino / total) * 100, 1);
                var percentFeminino = Math.Round((generoFeminino / total) * 100, 1);
                var percentNaoSabe = Math.Round((generoNaoSabe / total) * 100, 1);

                valores = new double[3] { percentMasculino, percentFeminino, percentNaoSabe };
            }

            chartGenero.Series["Genero"].Points.DataBindXY(rotulos, valores);
            chartGenero.Series["Genero"].ToolTip = MensagemDadosAnimaisDisponiveis;
        }

        private void CarregarGraficoCastracao()
        {
            var rotulos = new string[3] { "Castrado", "Não castrado", "Não informado" };
            var valores = new double[3] { 0, 0, 0 };

            if (AnimaisFiltrado.Any())
            {
                var castrado = AnimaisFiltrado.Count(k =>
                     k.Castrado == (int)Enumeracoes.EnumPossibilidades.Sim &&
                     k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível);

                var naoCastrado = AnimaisFiltrado.Count(k =>
                    k.Castrado == (int)Enumeracoes.EnumPossibilidades.Nao &&
                    k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível);

                var naoSabeCastrado = AnimaisFiltrado.Count(k =>
                   k.Castrado == (int)Enumeracoes.EnumPossibilidades.NaoSei &&
                   k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível);

                float total = castrado + naoCastrado + naoSabeCastrado;

                var percentCastrado = Math.Round((castrado / total) * 100, 1);
                var percentNaoCastrado = Math.Round((naoCastrado / total) * 100, 1);
                var percentNaoSabe = Math.Round((naoSabeCastrado / total) * 100, 1);
               
                 valores = new double[3] { percentCastrado, percentNaoCastrado, percentNaoSabe };
            }

            chartCastracao.Series["Castracao"].Points.DataBindXY(rotulos, valores);
            chartCastracao.Series["Castracao"].ToolTip = MensagemDadosAnimaisDisponiveis;
        }

        private void CarregarGraficoIdade()
        {
            var rotulos = new string[4] { "R.N.", "Filhote", "Adulto", "Idoso" };
            var valores = new double[4] { 0, 0, 0, 0 };

            if (AnimaisFiltrado.Any())
            {
                // < 0 − If date1 is earlier than date2, = 0 − If date1 is the same as date2,  > 0 − If date1 is later than date2
                int recemNascido = 0;
                int filhote = 0;
                int adulto = 0;
                int idoso = 0;

                var totalAnimaisDisponiveis = AnimaisFiltrado.Count(k => k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível);
                var animaisDisponiveisAdocao = AnimaisFiltrado.FindAll(k => k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível);

                foreach (var animal in animaisDisponiveisAdocao)
                {
                    var dataAtual = DateTime.Today.Date;
                    var testeRN = animal.DataNascimento.AddDays(60);
                    var testeFilhote = animal.DataNascimento.AddDays(365);
                    var testeAdulto = animal.DataNascimento.AddDays(365 * 8);

                    if (DateTime.Compare(testeRN, dataAtual) >= 0)
                        recemNascido++;

                    else if (DateTime.Compare(testeRN, dataAtual) < 0 && DateTime.Compare(testeFilhote, dataAtual) >= 0)
                        filhote++;

                    else if (DateTime.Compare(testeFilhote, dataAtual) < 0 && DateTime.Compare(testeAdulto, dataAtual) >= 0)
                        adulto++;

                    else
                        idoso++;
                }

                float total = recemNascido + filhote + adulto + idoso;

                var percentRecemNascido = Math.Round((recemNascido / total) * 100, 1);
                var percentFilhote = Math.Round((filhote / total) * 100, 1);
                var percentAdulto = Math.Round((adulto / total) * 100, 1);
                var percentIdoso = Math.Round((idoso / total) * 100, 1);
                             
                valores = new double[4] { percentRecemNascido, percentFilhote, percentAdulto, percentIdoso};
            }

            chartIdade.Series["Idade"].Points.DataBindXY(rotulos, valores);
            chartIdade.Series["Idade"].ToolTip = MensagemDadosAnimaisDisponiveis + 
                "\r\n - RN = Recém Nascido (idade menor que 2 meses); " +
                "\r\n - Filhote = Idade maior que dois meses e menor que 1 ano; " +
                "\r\n - Adulto = Idade maior que 1 ano e menor que 8 anos; " +
                "\r\n - Idoso = Idade maior que 8 anos.";
        }

        private void CarregarGraficoGeneroAdotados()
        {
            var rotulos = new string[3] { "Macho", "Fêmea", "Não informado" };
            var valores = new double[3] { 0, 0, 0 };

            if (AdocoesFiltradas.Any())
            {
                var generoMasculino = AdocoesFiltradas.Count(k => k.Animal.Genero == (int)Enumeracoes.EnumGenero.Masculino);
                var generoFeminino = AdocoesFiltradas.Count(k => k.Animal.Genero == (int)Enumeracoes.EnumGenero.Feminino);
                var generoNaoSabe = AdocoesFiltradas.Count(k => k.Animal.Genero == (int)Enumeracoes.EnumGenero.NaoSei);

                float total = generoMasculino + generoFeminino + generoNaoSabe;

                var percentMasculino = Math.Round((generoMasculino / total) * 100, 1);
                var percentFeminino = Math.Round((generoFeminino / total) * 100, 1);
                var percentNaoSabe = Math.Round((generoNaoSabe / total) * 100, 1);
              
                valores = new double[3] { percentMasculino, percentFeminino, percentNaoSabe };
            }

            chartGeneroAdotado.Series["Genero"].Points.DataBindXY(rotulos, valores);
            chartGeneroAdotado.Series["Genero"].ToolTip = MensagemDadosAnimaisAdotados;
        }

        private void CarregarGraficoCastracaoAdotados()
        {
            var rotulos = new string[3] { "Castrado", "Não castrado", "Não informado" };
            var valores = new double[3] { 0, 0, 0 };

            if (AdocoesFiltradas.Any())
            {
                var castrado = AdocoesFiltradas.Count(k =>
             k.Animal.Castrado == (int)Enumeracoes.EnumPossibilidades.Sim &&
             k.Animal.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Adotado);

                var naoCastrado = AdocoesFiltradas.Count(k =>
                    k.Animal.Castrado == (int)Enumeracoes.EnumPossibilidades.Nao &&
                    k.Animal.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Adotado);

                var naoSabeCastrado = AdocoesFiltradas.Count(k =>
                   k.Animal.Castrado == (int)Enumeracoes.EnumPossibilidades.NaoSei &&
                   k.Animal.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Adotado);

                float total = castrado + naoCastrado + naoSabeCastrado;

                var percentCastrado = Math.Round((castrado / total) * 100, 1);
                var percentNaoCastrado = Math.Round((naoCastrado / total) * 100, 1);
                var percentNaoSabe = Math.Round((naoSabeCastrado / total) * 100, 1);

                valores = new double[3] { percentCastrado,  percentNaoCastrado,  percentNaoSabe };
            }

            chartCastracaoAdotado.Series["Castracao"].Points.DataBindXY(rotulos, valores);
            chartCastracaoAdotado.Series["Castracao"].ToolTip = MensagemDadosAnimaisAdotados;
        }

        private void CarregarGraficoIdadeAdotados()
        {
            // < 0 − If date1 is earlier than date2, = 0 − If date1 is the same as date2,  > 0 − If date1 is later than date2
            int recemNascido = 0;
            int filhote = 0;
            int adulto = 0;
            int idoso = 0;
            var rotulos = new string[4] { "R.N.", "Filhote", "Adulto", "Idoso" };
            var valores = new double[4] { 0, 0, 0, 0 };

            if (AdocoesFiltradas.Any())
            {
                foreach (var adocao in AdocoesFiltradas)
                {
                    var dataAdocao = adocao.DataAdocao;
                    var testeRN = adocao.Animal.DataNascimento.AddDays(60);
                    var testeFilhote = adocao.Animal.DataNascimento.AddDays(365);
                    var testeAdulto = adocao.Animal.DataNascimento.AddDays(365 * 8);

                    if (DateTime.Compare(testeRN, dataAdocao) >= 0)
                        recemNascido++;

                    else if (DateTime.Compare(testeRN, dataAdocao) < 0 && DateTime.Compare(testeFilhote, dataAdocao) >= 0)
                        filhote++;

                    else if (DateTime.Compare(testeFilhote, dataAdocao) < 0 && DateTime.Compare(testeAdulto, dataAdocao) >= 0)
                        adulto++;

                    else
                        idoso++;
                }

                float total = recemNascido + filhote + adulto + idoso;

                var percentRecemNascido = Math.Round((recemNascido / total) * 100, 1);
                var percentFilhote = Math.Round((filhote / total) * 100, 1);
                var percentAdulto = Math.Round((adulto / total) * 100, 1);
                var percentIdoso = Math.Round((idoso / total) * 100, 1);

                valores = new double[4] { percentRecemNascido, percentFilhote, percentAdulto, percentIdoso};
            }

            chartIdadeAdotado.Series["Idade"].Points.DataBindXY(rotulos, valores);
            chartIdadeAdotado.Series["Idade"].ToolTip = MensagemDadosAnimaisAdotados +
                "\r\n - RN = Recém Nascido (idade menor que 2 meses); " +
                "\r\n - Filhote = Idade maior que dois meses e menor que 1 ano; " +
                "\r\n - Adulto = Idade maior que 1 ano e menor que 8 anos; " +
                "\r\n - Idoso = Idade maior que 8 anos.";
        }

        private void CalcularNumerosAbsolutos()
        {
            txtNumAnimaisAcolhidos.Text = string.Empty;
            txtNumAnimaisAbrigados.Text = string.Empty;
            txtAnimaisAdotados.Text = string.Empty;
            txtNumAnimaisEmLTs.Text = string.Empty;
            txtNumAnimaisFalecidos.Text = string.Empty;

            var numTotalAnimaisAcolhidos = AnimaisFiltrado.Count();
            var numAmimaisAdotados = AnimaisFiltrado.Where(k => k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Adotado).Count();
            var numAnimaisMortos = AnimaisFiltrado.Where(k => k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Morto).Count();
            var numAnimaisEmLTs = AnimaisFiltrado.Where(k => k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível && k.Hospedado).Count();
            var numAnimaisAbrigados = AnimaisFiltrado.Where(k => k.AnimalStatus == (int)Enumeracoes.EnumStatusAnimal.Disponível && !k.Hospedado).Count();
           
            txtNumAnimaisAcolhidos.Text = numTotalAnimaisAcolhidos.ToString();
            txtAnimaisAdotados.Text = numAmimaisAdotados.ToString();
            txtNumAnimaisFalecidos.Text = numAnimaisMortos.ToString();
            txtNumAnimaisEmLTs.Text = numAnimaisEmLTs.ToString();
            txtNumAnimaisAbrigados.Text = numAnimaisAbrigados.ToString();
        }

        private void rbIntervalo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIntervalo.Checked == true)
            {
                panelIntervalo.Visible = true;
                panelAnimal.Visible = false;
            }
            else
            {
                panelIntervalo.Visible = false;
                panelAnimal.Visible = true;
            }
        }

        private void rbMesAtual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMesAtual.Checked == true) 
            { 
                FiltrarDados(EnumIntervalo.Mensal);
                CarregarGraficos();
            }
        }

        private void rbAnoAtual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAnoAtual.Checked == true)
            {
                FiltrarDados(EnumIntervalo.Anual);
                CarregarGraficos();
            }
        }

        private void btnGerarGraficos_Click(object sender, EventArgs e)
        {
            if (dtpFimIntervalo.Value.Date >= dtpInicioIntervalo.Value.Date )
            {
                FiltrarDados(EnumIntervalo.Personalizado);
                CarregarGraficos();
                panelAnimal.Visible = true;
            }
            else
            {
                MessageBox.Show("A data fim deve ser igual ou maior que a data início", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelAnimal.Visible = false;
            }
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            toolTipNumAnimais.SetToolTip(panel5, "Dado calculado utilizando a data de recolhimento do animal.");
        }
    }
}
