using Desktop.Classes;
using Repositorio.Classes;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class FormAgendamentoAtendimento : Form
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Atendimento> _atendimentos = new List<Atendimento>();
        private List<PreAtendimento> _preAtendimentos = new List<PreAtendimento>();
        private Atendimento _atendimento = new Atendimento();

        public FormAgendamentoAtendimento()
        {
            InitializeComponent();
            CarregarTooltips();
            CarregarAgendamentos(monthCalendar.SelectionRange.Start);
            CarregarPreAtendimentos(monthCalendar.SelectionRange.Start);
        }

        private void CarregarTooltips()
        {
            toolTip.SetToolTip(btnNovoAgendamento, "Permite cadastrar um novo agendamento de atendimento veterinário.");
            toolTip.SetToolTip(btnEditarAgendamento, "Permite editar um agendamento de atendimento veterinário.");
            toolTip.SetToolTip(btnExcluir, "Permite excluir um agendamento de atendimento veterinário.");
            toolTip.SetToolTip(btnImprimir, "Imprime um arquivo com os compromissos agendados na data selecionada no calendário.");
            toolTip.SetToolTip(btnRealizarPreAtendimento, "Permite alterar o status do pré-atendimento para 'Realizado'. Isso habilitará o atendimento para ser realizado na data agendada.");
            toolTip.SetToolTip(btnRealizarAtendimento, "Permite realizar um atendimento e associar tratamento médico.");
            toolTip.SetToolTip(btnCancelarPreAtendimento, "Permite cancelar o pré-atendimento. Isso cancelará o atendimento associado a este pré-atendimento.");
            toolTip.SetToolTip(btnCancelarAtedimento, "Cancela o atendimento.");

            //toolTip.SetToolTip(btnPoliticas, "Permite alterar o período em dias que um procedimento recorrente será efetuado.");
            //toolTip.SetToolTip(btnPesquisar, "Abre a tela que permite selecionar o animal que será atendido.");
            //toolTip.SetToolTip(btnSalvar, "Salvar os dados do agendamento.");
            //toolTip.SetToolTip(btnCancelar, "Cancela a ação.");
        }

        private void CarregarAgendamentos(DateTime dataFiltro)
        {
            this.Cursor = Cursors.WaitCursor;
            lvAtendimentos.Items.Clear();
            _atendimentos.Clear();
            _atendimentos = AtendimentoDAO.GetAtendimentoDiaEspecifico(dataFiltro, Global.Entidade.Id); ;

            if (_atendimentos.Any())
            {
                var contaLinha = 0;

                foreach (var atendimento in _atendimentos)
                {
                    if (atendimento.PreAtendimento.EnumStatusPreAtendimento != (int)Enumeracoes.EnumStatusPreAtendimento.cancelado)
                    {
                        var lvi = new ListViewItem();

                        lvi.Text = atendimento.Id.ToString();
                        lvi.SubItems.Add(atendimento.DataAtendimentoInicio == null ? string.Empty : atendimento.DataAtendimentoInicio.ToShortTimeString());
                        lvi.SubItems.Add(atendimento.DataAtendimentoFim == null ? string.Empty : atendimento.DataAtendimentoFim.ToShortTimeString());
                        lvi.SubItems.Add(atendimento.Animal == null ? string.Empty : $"{atendimento.Animal?.Identificacao} - {atendimento.Animal?.Nome} - {atendimento.Animal?.AnimalEspecie?.Descricao}");
                        lvi.SubItems.Add(atendimento.TipoAtendimento.Nome);

                        var responsavel = atendimento.ColaboradorInterno != null ? atendimento.ColaboradorInterno.Nome :
                            (atendimento.ColaboradorExterno != null ? $"{atendimento.ColaboradorExterno.NomeEmpresa} - {atendimento.ColaboradorExterno.NomeColaborador}" : string.Empty);
                        lvi.SubItems.Add(responsavel);

                        lvi.SubItems.Add(atendimento.Patologia != null ? atendimento.Patologia.Descricao : string.Empty);
                        lvi.SubItems.Add(GetStatusPreAtendimento(atendimento));
                        lvi.SubItems.Add(FuncoesGerais.GetDescricaoEnum((Enumeracoes.StatusRealizacaoAtendimento)atendimento.StatusRealizacaoAtendimento));

                        if (atendimento.StatusRealizacaoAtendimento == (int)Enumeracoes.StatusRealizacaoAtendimento.cancelado)
                            lvi.BackColor = Color.Pink;

                        else if (atendimento.StatusRealizacaoAtendimento == (int)Enumeracoes.StatusRealizacaoAtendimento.realizado)
                            lvi.BackColor = Color.LightGreen;

                        else if (atendimento.TipoAtendimento?.EnumPreAtendimento > 0 && atendimento.PreAtendimento?.EnumStatusPreAtendimento == (int)Enumeracoes.EnumStatusPreAtendimento.naoRealizado)
                            lvi.BackColor = Color.Yellow;
                        
                        lvAtendimentos.Items.Add(lvi);
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private string GetStatusPreAtendimento(Atendimento atendimento)
        {
            if (atendimento.TipoAtendimento?.EnumPreAtendimento == (int) Enumeracoes.EnumPreAtendimento.naoNecessario)
                return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumPreAtendimento.naoNecessario);
            else 
            {
                if (atendimento.PreAtendimento != null)
                   return FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumStatusPreAtendimento)atendimento.PreAtendimento.EnumStatusPreAtendimento);
            }
            return string.Empty;
        }

        private void CarregarPreAtendimentos(DateTime dataFiltro)
        {
            this.Cursor = Cursors.WaitCursor;
            lvPreAtendimento.Items.Clear();

            _preAtendimentos = PreAtendimentoDAO.GetPreAtendimentoDiaEspecifico(dataFiltro, Global.Entidade.Id);

            if (_preAtendimentos.Any())
            {
                foreach (var pre in _preAtendimentos)
                {
                    // É o valor do enumerador, e não da classe.
                    if (pre.Atendimento?.TipoAtendimento.EnumPreAtendimento > 0)
                    {
                        var lvi = new ListViewItem();
                        lvi.Text = pre.Id.ToString();
                        lvi.SubItems.Add(pre.Atendimento.Animal == null ? string.Empty : $"{pre.Atendimento.Animal?.Identificacao} - {pre.Atendimento.Animal?.Nome} - {pre.Atendimento.Animal?.AnimalEspecie?.Descricao}");
                        lvi.SubItems.Add(pre.TipoAtendimento.Nome);
                        lvi.SubItems.Add(FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumPreAtendimento)pre.Atendimento.TipoAtendimento.EnumPreAtendimento));
                        lvi.SubItems.Add(FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumStatusPreAtendimento)pre.EnumStatusPreAtendimento));

                        if (pre.EnumStatusPreAtendimento == (int)Enumeracoes.EnumStatusPreAtendimento.cancelado)
                            lvi.BackColor = Color.Pink;

                        else if (pre.EnumStatusPreAtendimento == (int)Enumeracoes.EnumStatusPreAtendimento.realizado)
                            lvi.BackColor = Color.LightGreen;

                        lvPreAtendimento.Items.Add(lvi);
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        #region Eventos

        private void btnPoliticas_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var form = new FormRegras();
            form.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var form = new FormCadastroAtendimento();
            form.FormClosing += new FormClosingEventHandler(this.FormCadastroAtendimento_FormClosing);
            form.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void FormCadastroAtendimento_FormClosing(object sender, FormClosingEventArgs e)
        {
            CarregarAgendamentos(monthCalendar.SelectionRange.Start);
            CarregarPreAtendimentos(monthCalendar.SelectionRange.Start);
        }

        private void btnEditarAgendamento_Click(object sender, EventArgs e)
        {
            //CarregarAgendamentos();
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (monthCalendar.SelectionRange.Start < DateTime.Today)
                btnCancelarAtedimento.Enabled = btnCancelarPreAtendimento.Enabled = btnRealizarPreAtendimento.Enabled = btnRealizarAtendimento.Enabled = btnReagendar.Enabled = false;
            else
                btnCancelarAtedimento.Enabled = btnCancelarPreAtendimento.Enabled = btnRealizarPreAtendimento.Enabled = btnRealizarAtendimento.Enabled = btnReagendar.Enabled = true;

            CarregarAgendamentos(monthCalendar.SelectionRange.Start);
            CarregarPreAtendimentos(monthCalendar.SelectionRange.Start);
        }

        private void lvAtendimentos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (Convert.ToInt32(lvAtendimentos.SelectedItems[0].SubItems[0].Text) is int idAtendimento)
            {
                var atendimento = _atendimentos.First(k => k.Id == idAtendimento);
                var form = new FormConsultaAtendimento(atendimento, false);
                form.ShowDialog();
                this.Cursor = Cursors.Default;
            }
        }
        #endregion Eventos

        private void btnCancelarAtedimento_Click(object sender, EventArgs e)
        {
         
        }

        private void btnReagendar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnRealizarAtedimento_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAtendimentos, "realizar o atendimento"))
            {
                if (Convert.ToInt32(lvAtendimentos.SelectedItems[0].SubItems[0].Text) is int idAtendimento)
                {
                    var atendimento = _atendimentos.First(k => k.Id == idAtendimento);

                    if ( atendimento.TipoAtendimento.EnumPreAtendimento != (int)Enumeracoes.EnumPreAtendimento.naoNecessario && atendimento.PreAtendimento?.EnumStatusPreAtendimento == (int)Enumeracoes.EnumStatusPreAtendimento.naoRealizado)
                    {
                        var mensagem = "O pré-atendimento não foi realizado, por essa razão não é possível realizar o atendimento. Aconhcelha-se a reagendar o mesmo.";
                        MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var form = new FormRealizaAtendimento(atendimento);
                        form.FormClosing += new FormClosingEventHandler(this.FormCadastroAtendimento_FormClosing);
                        form.ShowDialog();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void btnRealizarAtendimentoVerde_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAtendimentos, "realizar o atendimento"))
            {
                if (Convert.ToInt32(lvAtendimentos.SelectedItems[0].SubItems[0].Text) is int idAtendimento)
                {
                    var atendimento = _atendimentos.First(k => k.Id == idAtendimento);

                    if (atendimento.TipoAtendimento.EnumPreAtendimento != (int)Enumeracoes.EnumPreAtendimento.naoNecessario && atendimento.PreAtendimento?.EnumStatusPreAtendimento == (int)Enumeracoes.EnumStatusPreAtendimento.naoRealizado)
                    {
                        var mensagem = "O pré-atendimento não foi realizado, por essa razão não é possível realizar o atendimento. Aconhcelha-se a reagendar o mesmo.";
                        MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var form = new FormRealizaAtendimento(atendimento);
                        form.FormClosing += new FormClosingEventHandler(this.FormCadastroAtendimento_FormClosing);
                        form.ShowDialog();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvAtendimentos, "realizar o cancelamento"))
            {
                if (Convert.ToInt32(lvAtendimentos.SelectedItems[0].SubItems[0].Text) is int idAtendimento)
                {
                    var atendimento = _atendimentos.First(k => k.Id == idAtendimento);

                    var mensagem = $"Você tem certeza que deseja cacelar o atendimento do(a) animal {_atendimento.Animal?.Nome}?";
                    var titulo = "Cancelamento do atendimento";
                    var icone = MessageBoxIcon.Exclamation;
                    var botoes = MessageBoxButtons.YesNo;

                    var solicitacao = MessageBox.Show(mensagem, titulo, botoes, icone);

                    if (solicitacao.Equals(DialogResult.OK) || solicitacao.Equals(DialogResult.Yes))
                    {
                        var status = AtendimentoDAO.Apagar(atendimento);
                        if (string.IsNullOrEmpty(status))
                        {
                            CarregarPreAtendimentos(monthCalendar.SelectionRange.Start);
                            FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
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

        private void btnCancelarPreAtendimento_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvPreAtendimento, "cancelar o pré atendimento"))
            {
                if (Convert.ToInt32(lvPreAtendimento.SelectedItems[0].SubItems[0].Text) is int idPreAtendimento)
                {
                    var preAtendimento = _preAtendimentos.First(k => k.Id == idPreAtendimento);

                    if (preAtendimento.EnumStatusPreAtendimento == (int)Enumeracoes.EnumStatusPreAtendimento.cancelado)
                    {
                        MessageBox.Show($"O pré-atendimento do(a) animal {preAtendimento.Atendimento.Animal.Nome} já foi cancelado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var mensagem = $"Você tem certeza que deseja cancelar o pré-atendimento do(a) animal {preAtendimento.Atendimento.Animal.Nome}? O atendimento também será cancelado e removido da agenda.";
                    var titulo = "Cancelamente de pré-atendimento";
                    var icone = MessageBoxIcon.Exclamation;
                    var botoes = MessageBoxButtons.YesNo;

                    var solicitacao = MessageBox.Show(mensagem, titulo, botoes, icone);

                    if (solicitacao.Equals(DialogResult.OK) || solicitacao.Equals(DialogResult.Yes))
                    {
                        preAtendimento.EnumStatusPreAtendimento = (int)Enumeracoes.EnumStatusPreAtendimento.cancelado;

                        if (PreAtendimentoDAO.Salvar(preAtendimento))
                        {
                            CarregarPreAtendimentos(monthCalendar.SelectionRange.Start);
                            CarregarAgendamentos(monthCalendar.SelectionRange.Start);
                            MessageBox.Show("O pré-atendimento foi cancelado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Falha ao salvar os dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnRealizarPreAtendimento_Click(object sender, EventArgs e)
        {
            if (FuncoesGerais.LinhFoiSelecionadaNaListView(lvPreAtendimento, "confirmar a realização do pré-atendimento"))
            {
                if (Convert.ToInt32(lvPreAtendimento.SelectedItems[0].SubItems[0].Text) is int idPreAtendimento)
                {
                    var preAtendimento = _preAtendimentos.First(k => k.Id == idPreAtendimento);

                    if (preAtendimento.EnumStatusPreAtendimento == (int)Enumeracoes.EnumStatusPreAtendimento.realizado)
                    {
                        MessageBox.Show($"A confirmação do pré-atendimento do(a) animal {preAtendimento.Atendimento.Animal.Nome} já foi efetuada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (preAtendimento.EnumStatusPreAtendimento == (int)Enumeracoes.EnumStatusPreAtendimento.cancelado)
                    {
                        MessageBox.Show($"O pré-atendimento do(a) animal {preAtendimento.Atendimento.Animal.Nome} já foi cancelado previamente. Não é possível realizar esse pré-atendimento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    var mensagem = $"Você deseja confirmar que o pré-atendimento do(a) animal {preAtendimento.Atendimento.Animal.Nome} foi efetuado?";
                    var titulo = "Confirmação do pré-atendimento";
                    var icone = MessageBoxIcon.Exclamation;
                    var botoes = MessageBoxButtons.YesNo;

                    var solicitacao = MessageBox.Show(mensagem, titulo, botoes, icone);

                    if (solicitacao.Equals(DialogResult.OK) || solicitacao.Equals(DialogResult.Yes))
                    {
                        preAtendimento.EnumStatusPreAtendimento = (int)Enumeracoes.EnumStatusPreAtendimento.realizado;

                        if (PreAtendimentoDAO.Salvar(preAtendimento))
                        {
                            FuncoesGerais.MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario.Salvar);
                            CarregarPreAtendimentos(monthCalendar.SelectionRange.Start);
                            CarregarAgendamentos(monthCalendar.SelectionRange.Start);
                        }
                        else
                        {
                            FuncoesGerais.MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario.Salvar);
                        }
                    }
                }
            }
        }
    }
}
