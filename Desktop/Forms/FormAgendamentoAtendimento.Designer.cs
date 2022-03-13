namespace Desktop.Forms
{
    partial class FormAgendamentoAtendimento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelDados = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lvPreAtendimento = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.lvAtendimentos = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel6 = new System.Windows.Forms.Panel();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnRealizarAtendimento = new System.Windows.Forms.Button();
            this.btnCancelarAtedimento = new System.Windows.Forms.Button();
            this.btnReagendar = new System.Windows.Forms.Button();
            this.btnPoliticas = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovoAgendamento = new System.Windows.Forms.Button();
            this.btnEditarAgendamento = new System.Windows.Forms.Button();
            this.btnRealizarPreAtendimento = new System.Windows.Forms.Button();
            this.btnCancelarPreAtendimento = new System.Windows.Forms.Button();
            this.panelDados.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados
            // 
            this.panelDados.BackColor = System.Drawing.Color.LightCyan;
            this.panelDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados.Controls.Add(this.btnRealizarPreAtendimento);
            this.panelDados.Controls.Add(this.btnCancelarPreAtendimento);
            this.panelDados.Controls.Add(this.btnRealizarAtendimento);
            this.panelDados.Controls.Add(this.btnCancelarAtedimento);
            this.panelDados.Controls.Add(this.btnReagendar);
            this.panelDados.Controls.Add(this.label4);
            this.panelDados.Controls.Add(this.lvPreAtendimento);
            this.panelDados.Controls.Add(this.label3);
            this.panelDados.Controls.Add(this.lvAtendimentos);
            this.panelDados.Controls.Add(this.panel6);
            this.panelDados.Controls.Add(this.monthCalendar);
            this.panelDados.Controls.Add(this.panel4);
            this.panelDados.Location = new System.Drawing.Point(7, 37);
            this.panelDados.Name = "panelDados";
            this.panelDados.Size = new System.Drawing.Size(909, 680);
            this.panelDados.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(244, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Pré-atendimentos agendados";
            // 
            // lvPreAtendimento
            // 
            this.lvPreAtendimento.CheckBoxes = true;
            this.lvPreAtendimento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader11});
            this.lvPreAtendimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPreAtendimento.ForeColor = System.Drawing.Color.Black;
            this.lvPreAtendimento.FullRowSelect = true;
            this.lvPreAtendimento.GridLines = true;
            this.lvPreAtendimento.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPreAtendimento.HideSelection = false;
            this.lvPreAtendimento.Location = new System.Drawing.Point(244, 98);
            this.lvPreAtendimento.MultiSelect = false;
            this.lvPreAtendimento.Name = "lvPreAtendimento";
            this.lvPreAtendimento.Size = new System.Drawing.Size(653, 133);
            this.lvPreAtendimento.TabIndex = 17;
            this.lvPreAtendimento.UseCompatibleStateImageBehavior = false;
            this.lvPreAtendimento.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Id";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Animal";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Atendimento";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Pré-atendimento";
            this.columnHeader10.Width = 220;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Realizado";
            this.columnHeader11.Width = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Atendimentos agendados";
            // 
            // lvAtendimentos
            // 
            this.lvAtendimentos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader4,
            this.columnHeader5});
            this.lvAtendimentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAtendimentos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lvAtendimentos.FullRowSelect = true;
            this.lvAtendimentos.GridLines = true;
            this.lvAtendimentos.HideSelection = false;
            this.lvAtendimentos.Location = new System.Drawing.Point(7, 275);
            this.lvAtendimentos.MultiSelect = false;
            this.lvAtendimentos.Name = "lvAtendimentos";
            this.lvAtendimentos.Size = new System.Drawing.Size(888, 392);
            this.lvAtendimentos.TabIndex = 15;
            this.lvAtendimentos.UseCompatibleStateImageBehavior = false;
            this.lvAtendimentos.View = System.Windows.Forms.View.Details;
            this.lvAtendimentos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAtendimentos_MouseDoubleClick);
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "Código";
            this.columnHeader0.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Início";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 51;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Fim";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 54;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Animal";
            this.columnHeader7.Width = 128;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Atendimento";
            this.columnHeader9.Width = 158;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Responsável";
            this.columnHeader12.Width = 152;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Patologia";
            this.columnHeader13.Width = 115;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pré-atendimento";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status atendimento";
            this.columnHeader5.Width = 101;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnPoliticas);
            this.panel6.Controls.Add(this.btnImprimir);
            this.panel6.Controls.Add(this.btnExcluir);
            this.panel6.Controls.Add(this.btnNovoAgendamento);
            this.panel6.Controls.Add(this.btnEditarAgendamento);
            this.panel6.Location = new System.Drawing.Point(-6, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(988, 37);
            this.panel6.TabIndex = 14;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(5, 69);
            this.monthCalendar.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowTodayCircle = false;
            this.monthCalendar.TabIndex = 5;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightCyan;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(907, 25);
            this.panel4.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Agendamentos";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Teal;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1188, 29);
            this.panel7.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agendamento de atendimento dos animais";
            // 
            // btnRealizarAtendimento
            // 
            this.btnRealizarAtendimento.BackColor = System.Drawing.Color.Transparent;
            this.btnRealizarAtendimento.BackgroundImage = global::Desktop.Properties.Resources.realizar_ok_24;
            this.btnRealizarAtendimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRealizarAtendimento.FlatAppearance.BorderSize = 0;
            this.btnRealizarAtendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealizarAtendimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizarAtendimento.Location = new System.Drawing.Point(727, 249);
            this.btnRealizarAtendimento.Name = "btnRealizarAtendimento";
            this.btnRealizarAtendimento.Size = new System.Drawing.Size(85, 25);
            this.btnRealizarAtendimento.TabIndex = 28;
            this.btnRealizarAtendimento.Text = "       Realizar";
            this.btnRealizarAtendimento.UseVisualStyleBackColor = false;
            this.btnRealizarAtendimento.Click += new System.EventHandler(this.btnRealizarAtendimentoVerde_Click);
            // 
            // btnCancelarAtedimento
            // 
            this.btnCancelarAtedimento.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelarAtedimento.BackgroundImage = global::Desktop.Properties.Resources.realizar_cancelar_24;
            this.btnCancelarAtedimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelarAtedimento.FlatAppearance.BorderSize = 0;
            this.btnCancelarAtedimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarAtedimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarAtedimento.Location = new System.Drawing.Point(818, 249);
            this.btnCancelarAtedimento.Name = "btnCancelarAtedimento";
            this.btnCancelarAtedimento.Size = new System.Drawing.Size(85, 25);
            this.btnCancelarAtedimento.TabIndex = 27;
            this.btnCancelarAtedimento.Text = "       Cancelar";
            this.btnCancelarAtedimento.UseVisualStyleBackColor = false;
            this.btnCancelarAtedimento.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnReagendar
            // 
            this.btnReagendar.BackColor = System.Drawing.Color.Transparent;
            this.btnReagendar.BackgroundImage = global::Desktop.Properties.Resources.reagendar_azul_24;
            this.btnReagendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReagendar.FlatAppearance.BorderSize = 0;
            this.btnReagendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReagendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReagendar.Location = new System.Drawing.Point(485, 247);
            this.btnReagendar.Name = "btnReagendar";
            this.btnReagendar.Size = new System.Drawing.Size(90, 25);
            this.btnReagendar.TabIndex = 26;
            this.btnReagendar.Text = "       Reagendar";
            this.btnReagendar.UseVisualStyleBackColor = false;
            this.btnReagendar.Visible = false;
            // 
            // btnPoliticas
            // 
            this.btnPoliticas.BackColor = System.Drawing.Color.Transparent;
            this.btnPoliticas.BackgroundImage = global::Desktop.Properties.Resources.prontuario_24;
            this.btnPoliticas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPoliticas.FlatAppearance.BorderSize = 0;
            this.btnPoliticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPoliticas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPoliticas.Location = new System.Drawing.Point(188, 6);
            this.btnPoliticas.Name = "btnPoliticas";
            this.btnPoliticas.Size = new System.Drawing.Size(91, 24);
            this.btnPoliticas.TabIndex = 5;
            this.btnPoliticas.Text = "  Regras";
            this.btnPoliticas.UseVisualStyleBackColor = false;
            this.btnPoliticas.Visible = false;
            this.btnPoliticas.Click += new System.EventHandler(this.btnPoliticas_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.BackgroundImage = global::Desktop.Properties.Resources.Pdf_24;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(100, 5);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(72, 29);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "       Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Visible = false;
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Transparent;
            this.btnExcluir.BackgroundImage = global::Desktop.Properties.Resources.Lixeira_24;
            this.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(517, 8);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(91, 24);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Visible = false;
            // 
            // btnNovoAgendamento
            // 
            this.btnNovoAgendamento.BackColor = System.Drawing.Color.Transparent;
            this.btnNovoAgendamento.BackgroundImage = global::Desktop.Properties.Resources.Novo_24;
            this.btnNovoAgendamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNovoAgendamento.FlatAppearance.BorderSize = 0;
            this.btnNovoAgendamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoAgendamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoAgendamento.Location = new System.Drawing.Point(17, 5);
            this.btnNovoAgendamento.Name = "btnNovoAgendamento";
            this.btnNovoAgendamento.Size = new System.Drawing.Size(77, 24);
            this.btnNovoAgendamento.TabIndex = 0;
            this.btnNovoAgendamento.Text = "     Novo";
            this.btnNovoAgendamento.UseVisualStyleBackColor = false;
            this.btnNovoAgendamento.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnEditarAgendamento
            // 
            this.btnEditarAgendamento.BackColor = System.Drawing.Color.Transparent;
            this.btnEditarAgendamento.BackgroundImage = global::Desktop.Properties.Resources.Editar_241;
            this.btnEditarAgendamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEditarAgendamento.Enabled = false;
            this.btnEditarAgendamento.FlatAppearance.BorderSize = 0;
            this.btnEditarAgendamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarAgendamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarAgendamento.Location = new System.Drawing.Point(434, 8);
            this.btnEditarAgendamento.Name = "btnEditarAgendamento";
            this.btnEditarAgendamento.Size = new System.Drawing.Size(78, 24);
            this.btnEditarAgendamento.TabIndex = 1;
            this.btnEditarAgendamento.Text = "     Editar";
            this.btnEditarAgendamento.UseVisualStyleBackColor = false;
            this.btnEditarAgendamento.Visible = false;
            this.btnEditarAgendamento.Click += new System.EventHandler(this.btnEditarAgendamento_Click);
            // 
            // btnRealizarPreAtendimento
            // 
            this.btnRealizarPreAtendimento.BackColor = System.Drawing.Color.Transparent;
            this.btnRealizarPreAtendimento.BackgroundImage = global::Desktop.Properties.Resources.realizar_ok_24;
            this.btnRealizarPreAtendimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRealizarPreAtendimento.FlatAppearance.BorderSize = 0;
            this.btnRealizarPreAtendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealizarPreAtendimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizarPreAtendimento.Location = new System.Drawing.Point(727, 72);
            this.btnRealizarPreAtendimento.Name = "btnRealizarPreAtendimento";
            this.btnRealizarPreAtendimento.Size = new System.Drawing.Size(85, 25);
            this.btnRealizarPreAtendimento.TabIndex = 30;
            this.btnRealizarPreAtendimento.Text = "       Realizar";
            this.btnRealizarPreAtendimento.UseVisualStyleBackColor = false;
            this.btnRealizarPreAtendimento.Click += new System.EventHandler(this.btnRealizarPreAtendimento_Click);
            // 
            // btnCancelarPreAtendimento
            // 
            this.btnCancelarPreAtendimento.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelarPreAtendimento.BackgroundImage = global::Desktop.Properties.Resources.realizar_cancelar_24;
            this.btnCancelarPreAtendimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelarPreAtendimento.FlatAppearance.BorderSize = 0;
            this.btnCancelarPreAtendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarPreAtendimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarPreAtendimento.Location = new System.Drawing.Point(818, 72);
            this.btnCancelarPreAtendimento.Name = "btnCancelarPreAtendimento";
            this.btnCancelarPreAtendimento.Size = new System.Drawing.Size(85, 25);
            this.btnCancelarPreAtendimento.TabIndex = 29;
            this.btnCancelarPreAtendimento.Text = "       Cancelar";
            this.btnCancelarPreAtendimento.UseVisualStyleBackColor = false;
            this.btnCancelarPreAtendimento.Click += new System.EventHandler(this.btnCancelarPreAtendimento_Click);
            // 
            // FormAgendamentoAtendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 729);
            this.ControlBox = false;
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panelDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAgendamentoAtendimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormCadastroAtendimento";
            this.panelDados.ResumeLayout(false);
            this.panelDados.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelDados;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovoAgendamento;
        private System.Windows.Forms.Button btnEditarAgendamento;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ListView lvAtendimentos;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvPreAtendimento;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button btnPoliticas;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnCancelarAtedimento;
        private System.Windows.Forms.Button btnReagendar;
        private System.Windows.Forms.Button btnRealizarAtendimento;
        private System.Windows.Forms.Button btnRealizarPreAtendimento;
        private System.Windows.Forms.Button btnCancelarPreAtendimento;
    }
}