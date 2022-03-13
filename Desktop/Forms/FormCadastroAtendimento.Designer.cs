namespace Desktop.Forms
{
    partial class FormCadastroAtendimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroAtendimento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAnimal = new System.Windows.Forms.Panel();
            this.rtbAnimal = new System.Windows.Forms.RichTextBox();
            this.pbAnimal = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpHorario = new System.Windows.Forms.DateTimePicker();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPatologia = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboPatologia = new System.Windows.Forms.ComboBox();
            this.btnNovoProcedimento = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboTipoAtendimento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbObservacao = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNovoExterno = new System.Windows.Forms.Button();
            this.comboExterno = new System.Windows.Forms.ComboBox();
            this.rbExterno = new System.Windows.Forms.RadioButton();
            this.comboInterno = new System.Windows.Forms.ComboBox();
            this.rbInterno = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelAnimal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimal)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelAnimal);
            this.panel1.Controls.Add(this.btnPesquisar);
            this.panel1.Location = new System.Drawing.Point(10, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 220);
            this.panel1.TabIndex = 30;
            // 
            // panelAnimal
            // 
            this.panelAnimal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelAnimal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAnimal.Controls.Add(this.rtbAnimal);
            this.panelAnimal.Controls.Add(this.pbAnimal);
            this.panelAnimal.Location = new System.Drawing.Point(11, 47);
            this.panelAnimal.Name = "panelAnimal";
            this.panelAnimal.Size = new System.Drawing.Size(324, 162);
            this.panelAnimal.TabIndex = 32;
            // 
            // rtbAnimal
            // 
            this.rtbAnimal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbAnimal.Location = new System.Drawing.Point(9, 23);
            this.rtbAnimal.MaxLength = 1000;
            this.rtbAnimal.Name = "rtbAnimal";
            this.rtbAnimal.ReadOnly = true;
            this.rtbAnimal.Size = new System.Drawing.Size(214, 104);
            this.rtbAnimal.TabIndex = 33;
            this.rtbAnimal.Text = "";
            // 
            // pbAnimal
            // 
            this.pbAnimal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAnimal.Enabled = false;
            this.pbAnimal.Location = new System.Drawing.Point(229, 23);
            this.pbAnimal.Name = "pbAnimal";
            this.pbAnimal.Size = new System.Drawing.Size(78, 104);
            this.pbAnimal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAnimal.TabIndex = 31;
            this.pbAnimal.TabStop = false;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(10, 9);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(128, 30);
            this.btnPesquisar.TabIndex = 31;
            this.btnPesquisar.Text = "Pesquisar animal";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCyan;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(10, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 25);
            this.panel2.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Dados do animal";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.dtpHorario);
            this.panel4.Controls.Add(this.monthCalendar);
            this.panel4.Location = new System.Drawing.Point(364, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 220);
            this.panel4.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Horário";
            // 
            // dtpHorario
            // 
            this.dtpHorario.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHorario.Location = new System.Drawing.Point(108, 15);
            this.dtpHorario.Name = "dtpHorario";
            this.dtpHorario.ShowUpDown = true;
            this.dtpHorario.Size = new System.Drawing.Size(82, 20);
            this.dtpHorario.TabIndex = 36;
            this.dtpHorario.Value = new System.DateTime(2021, 11, 17, 8, 0, 0, 0);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(9, 47);
            this.monthCalendar.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowTodayCircle = false;
            this.monthCalendar.TabIndex = 35;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightCyan;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Location = new System.Drawing.Point(364, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(245, 34);
            this.panel6.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agendamento";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnPatologia);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.comboPatologia);
            this.panel3.Controls.Add(this.btnNovoProcedimento);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.comboTipoAtendimento);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.rtbObservacao);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(10, 291);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 196);
            this.panel3.TabIndex = 36;
            // 
            // btnPatologia
            // 
            this.btnPatologia.BackColor = System.Drawing.Color.Transparent;
            this.btnPatologia.BackgroundImage = global::Desktop.Properties.Resources.Novo_24;
            this.btnPatologia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPatologia.FlatAppearance.BorderSize = 0;
            this.btnPatologia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatologia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatologia.Location = new System.Drawing.Point(243, 162);
            this.btnPatologia.Name = "btnPatologia";
            this.btnPatologia.Size = new System.Drawing.Size(27, 24);
            this.btnPatologia.TabIndex = 38;
            this.btnPatologia.UseVisualStyleBackColor = false;
            this.btnPatologia.Click += new System.EventHandler(this.btnPatologia_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Patologia";
            // 
            // comboPatologia
            // 
            this.comboPatologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPatologia.FormattingEnabled = true;
            this.comboPatologia.Location = new System.Drawing.Point(10, 163);
            this.comboPatologia.Name = "comboPatologia";
            this.comboPatologia.Size = new System.Drawing.Size(229, 21);
            this.comboPatologia.TabIndex = 37;
            // 
            // btnNovoProcedimento
            // 
            this.btnNovoProcedimento.BackColor = System.Drawing.Color.Transparent;
            this.btnNovoProcedimento.BackgroundImage = global::Desktop.Properties.Resources.Novo_24;
            this.btnNovoProcedimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNovoProcedimento.FlatAppearance.BorderSize = 0;
            this.btnNovoProcedimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoProcedimento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoProcedimento.Location = new System.Drawing.Point(243, 115);
            this.btnNovoProcedimento.Name = "btnNovoProcedimento";
            this.btnNovoProcedimento.Size = new System.Drawing.Size(27, 24);
            this.btnNovoProcedimento.TabIndex = 4;
            this.btnNovoProcedimento.UseVisualStyleBackColor = false;
            this.btnNovoProcedimento.Click += new System.EventHandler(this.btnNovoProcedimento_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Tipo de atendimento";
            // 
            // comboTipoAtendimento
            // 
            this.comboTipoAtendimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoAtendimento.FormattingEnabled = true;
            this.comboTipoAtendimento.Location = new System.Drawing.Point(10, 116);
            this.comboTipoAtendimento.Name = "comboTipoAtendimento";
            this.comboTipoAtendimento.Size = new System.Drawing.Size(229, 21);
            this.comboTipoAtendimento.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Observação";
            // 
            // rtbObservacao
            // 
            this.rtbObservacao.Location = new System.Drawing.Point(289, 102);
            this.rtbObservacao.MaxLength = 1000;
            this.rtbObservacao.Name = "rtbObservacao";
            this.rtbObservacao.Size = new System.Drawing.Size(301, 80);
            this.rtbObservacao.TabIndex = 34;
            this.rtbObservacao.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNovoExterno);
            this.groupBox1.Controls.Add(this.comboExterno);
            this.groupBox1.Controls.Add(this.rbExterno);
            this.groupBox1.Controls.Add(this.comboInterno);
            this.groupBox1.Controls.Add(this.rbInterno);
            this.groupBox1.Location = new System.Drawing.Point(11, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Responsável";
            // 
            // btnNovoExterno
            // 
            this.btnNovoExterno.BackColor = System.Drawing.Color.Transparent;
            this.btnNovoExterno.BackgroundImage = global::Desktop.Properties.Resources.Novo_24;
            this.btnNovoExterno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNovoExterno.FlatAppearance.BorderSize = 0;
            this.btnNovoExterno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoExterno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoExterno.Location = new System.Drawing.Point(519, 41);
            this.btnNovoExterno.Name = "btnNovoExterno";
            this.btnNovoExterno.Size = new System.Drawing.Size(27, 24);
            this.btnNovoExterno.TabIndex = 3;
            this.btnNovoExterno.UseVisualStyleBackColor = false;
            this.btnNovoExterno.Click += new System.EventHandler(this.btnNovoExterno_Click);
            // 
            // comboExterno
            // 
            this.comboExterno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboExterno.Enabled = false;
            this.comboExterno.FormattingEnabled = true;
            this.comboExterno.Location = new System.Drawing.Point(278, 43);
            this.comboExterno.Name = "comboExterno";
            this.comboExterno.Size = new System.Drawing.Size(238, 21);
            this.comboExterno.TabIndex = 3;
            // 
            // rbExterno
            // 
            this.rbExterno.AutoSize = true;
            this.rbExterno.Location = new System.Drawing.Point(279, 23);
            this.rbExterno.Name = "rbExterno";
            this.rbExterno.Size = new System.Drawing.Size(166, 17);
            this.rbExterno.TabIndex = 2;
            this.rbExterno.Text = "Externo (clínicas/veterinários)";
            this.rbExterno.UseVisualStyleBackColor = true;
            this.rbExterno.CheckedChanged += new System.EventHandler(this.rbExterno_CheckedChanged);
            // 
            // comboInterno
            // 
            this.comboInterno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInterno.FormattingEnabled = true;
            this.comboInterno.Location = new System.Drawing.Point(10, 43);
            this.comboInterno.Name = "comboInterno";
            this.comboInterno.Size = new System.Drawing.Size(238, 21);
            this.comboInterno.TabIndex = 1;
            // 
            // rbInterno
            // 
            this.rbInterno.AutoSize = true;
            this.rbInterno.Checked = true;
            this.rbInterno.Location = new System.Drawing.Point(10, 23);
            this.rbInterno.Name = "rbInterno";
            this.rbInterno.Size = new System.Drawing.Size(124, 17);
            this.rbInterno.TabIndex = 0;
            this.rbInterno.TabStop = true;
            this.rbInterno.Text = "Interno (Colaborador)";
            this.rbInterno.UseVisualStyleBackColor = true;
            this.rbInterno.CheckedChanged += new System.EventHandler(this.rbInterno_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightCyan;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(10, 267);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(600, 34);
            this.panel5.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Atendimento";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BackgroundImage = global::Desktop.Properties.Resources.cancelar_241;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(510, 493);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 38;
            this.btnCancelar.Text = "     Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.Transparent;
            this.btnSalvar.BackgroundImage = global::Desktop.Properties.Resources.salvar_24;
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(401, 493);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 34);
            this.btnSalvar.TabIndex = 37;
            this.btnSalvar.Text = "     Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FormCadastroAtendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 541);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCadastroAtendimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de atendimento";
            this.panel1.ResumeLayout(false);
            this.panelAnimal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimal)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelAnimal;
        private System.Windows.Forms.PictureBox pbAnimal;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpHorario;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNovoExterno;
        private System.Windows.Forms.ComboBox comboExterno;
        private System.Windows.Forms.RadioButton rbExterno;
        private System.Windows.Forms.ComboBox comboInterno;
        private System.Windows.Forms.RadioButton rbInterno;
        private System.Windows.Forms.Button btnNovoProcedimento;
        private System.Windows.Forms.ComboBox comboTipoAtendimento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbObservacao;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnPatologia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboPatologia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbAnimal;
    }
}