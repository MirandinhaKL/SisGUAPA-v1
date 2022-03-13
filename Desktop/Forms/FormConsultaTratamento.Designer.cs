namespace Desktop.Forms
{
    partial class FormConsultaTratamento
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRealizar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNaoRealizados = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumRealizados = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumAgendados = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdiar = new System.Windows.Forms.Button();
            this.lvTratamentos = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelDados.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados
            // 
            this.panelDados.BackColor = System.Drawing.Color.LightCyan;
            this.panelDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados.Controls.Add(this.btnCancelar);
            this.panelDados.Controls.Add(this.btnRealizar);
            this.panelDados.Controls.Add(this.panel1);
            this.panelDados.Controls.Add(this.btnAdiar);
            this.panelDados.Controls.Add(this.lvTratamentos);
            this.panelDados.Controls.Add(this.panel6);
            this.panelDados.Controls.Add(this.monthCalendar);
            this.panelDados.Controls.Add(this.panel4);
            this.panelDados.Location = new System.Drawing.Point(8, 39);
            this.panelDados.Name = "panelDados";
            this.panelDados.Size = new System.Drawing.Size(906, 680);
            this.panelDados.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BackgroundImage = global::Desktop.Properties.Resources.realizar_cancelar_24;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(814, 210);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 25);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "       Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRealizar
            // 
            this.btnRealizar.BackColor = System.Drawing.Color.Transparent;
            this.btnRealizar.BackgroundImage = global::Desktop.Properties.Resources.realizar_ok_24;
            this.btnRealizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRealizar.FlatAppearance.BorderSize = 0;
            this.btnRealizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizar.Location = new System.Drawing.Point(723, 211);
            this.btnRealizar.Name = "btnRealizar";
            this.btnRealizar.Size = new System.Drawing.Size(85, 25);
            this.btnRealizar.TabIndex = 24;
            this.btnRealizar.Text = "       Realizar";
            this.btnRealizar.UseVisualStyleBackColor = false;
            this.btnRealizar.Click += new System.EventHandler(this.btnRealizar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(244, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 160);
            this.panel1.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNaoRealizados);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNumRealizados);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNumAgendados);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Números de tratamentos";
            // 
            // txtNaoRealizados
            // 
            this.txtNaoRealizados.Location = new System.Drawing.Point(104, 95);
            this.txtNaoRealizados.MaxLength = 5;
            this.txtNaoRealizados.Name = "txtNaoRealizados";
            this.txtNaoRealizados.ReadOnly = true;
            this.txtNaoRealizados.Size = new System.Drawing.Size(100, 20);
            this.txtNaoRealizados.TabIndex = 5;
            this.txtNaoRealizados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Não realizado(s)";
            // 
            // txtNumRealizados
            // 
            this.txtNumRealizados.Location = new System.Drawing.Point(104, 62);
            this.txtNumRealizados.MaxLength = 5;
            this.txtNumRealizados.Name = "txtNumRealizados";
            this.txtNumRealizados.ReadOnly = true;
            this.txtNumRealizados.Size = new System.Drawing.Size(100, 20);
            this.txtNumRealizados.TabIndex = 3;
            this.txtNumRealizados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Realizado(s)";
            // 
            // txtNumAgendados
            // 
            this.txtNumAgendados.Location = new System.Drawing.Point(104, 29);
            this.txtNumAgendados.MaxLength = 5;
            this.txtNumAgendados.Name = "txtNumAgendados";
            this.txtNumAgendados.ReadOnly = true;
            this.txtNumAgendados.Size = new System.Drawing.Size(100, 20);
            this.txtNumAgendados.TabIndex = 1;
            this.txtNumAgendados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Agendado(s)";
            // 
            // btnAdiar
            // 
            this.btnAdiar.Location = new System.Drawing.Point(629, 211);
            this.btnAdiar.Name = "btnAdiar";
            this.btnAdiar.Size = new System.Drawing.Size(75, 23);
            this.btnAdiar.TabIndex = 22;
            this.btnAdiar.Text = "Adiar";
            this.btnAdiar.UseVisualStyleBackColor = true;
            this.btnAdiar.Visible = false;
            // 
            // lvTratamentos
            // 
            this.lvTratamentos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader13,
            this.columnHeader1,
            this.columnHeader2});
            this.lvTratamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTratamentos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lvTratamentos.FullRowSelect = true;
            this.lvTratamentos.GridLines = true;
            this.lvTratamentos.HideSelection = false;
            this.lvTratamentos.Location = new System.Drawing.Point(7, 240);
            this.lvTratamentos.MultiSelect = false;
            this.lvTratamentos.Name = "lvTratamentos";
            this.lvTratamentos.Size = new System.Drawing.Size(888, 392);
            this.lvTratamentos.TabIndex = 15;
            this.lvTratamentos.UseCompatibleStateImageBehavior = false;
            this.lvTratamentos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "Atendimento Id";
            this.columnHeader0.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tratamento Id";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ordem Medicamento";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Controle Tratamento Id";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Horário";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 51;
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
            // columnHeader13
            // 
            this.columnHeader13.Text = "Patologia";
            this.columnHeader13.Width = 115;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tratamento";
            this.columnHeader1.Width = 85;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descrição tratamento";
            this.columnHeader2.Width = 340;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnImprimir);
            this.panel6.Location = new System.Drawing.Point(-6, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(988, 37);
            this.panel6.TabIndex = 14;
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
            this.btnImprimir.Location = new System.Drawing.Point(11, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(72, 29);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "       Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(7, 69);
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
            this.panel4.Size = new System.Drawing.Size(904, 25);
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
            this.panel7.Size = new System.Drawing.Size(1172, 29);
            this.panel7.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tratamentos";
            // 
            // FormConsultaTratamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 732);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panelDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConsultaTratamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormConsultaTratamento";
            this.panelDados.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDados;
        private System.Windows.Forms.Button btnAdiar;
        private System.Windows.Forms.ListView lvTratamentos;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNumRealizados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumAgendados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNaoRealizados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnRealizar;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnCancelar;
    }
}