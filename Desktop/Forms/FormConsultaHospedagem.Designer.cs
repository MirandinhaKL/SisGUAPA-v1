namespace Desktop.Forms
{
    partial class FormConsultaHospedagem
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboEspecie = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdAnimal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lvLar = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCPFNome = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnEncerrarHospedagem = new System.Windows.Forms.Button();
            this.btnAdicionarHospedagem = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTipNovo = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipImprimir = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipExportar = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipEditar = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipExcluir = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPesquisar = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipLimpar = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.paneLaranja = new System.Windows.Forms.Panel();
            this.lblAnimalFalecido = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboEspecie);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtIdAnimal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboGenero);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Location = new System.Drawing.Point(217, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(639, 72);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados do animal";
            // 
            // cboEspecie
            // 
            this.cboEspecie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspecie.FormattingEnabled = true;
            this.cboEspecie.Location = new System.Drawing.Point(53, 27);
            this.cboEspecie.Name = "cboEspecie";
            this.cboEspecie.Size = new System.Drawing.Size(133, 21);
            this.cboEspecie.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Gênero";
            // 
            // txtIdAnimal
            // 
            this.txtIdAnimal.Location = new System.Drawing.Point(514, 29);
            this.txtIdAnimal.Name = "txtIdAnimal";
            this.txtIdAnimal.Size = new System.Drawing.Size(118, 20);
            this.txtIdAnimal.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Espécie";
            // 
            // cboGenero
            // 
            this.cboGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Location = new System.Drawing.Point(244, 27);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(133, 21);
            this.cboGenero.TabIndex = 1;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(392, 32);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(116, 13);
            this.label32.TabIndex = 18;
            this.label32.Text = "Identificação do animal";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightCyan;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(871, 23);
            this.panel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filtros";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightCyan;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblAnimalFalecido);
            this.panel5.Controls.Add(this.paneLaranja);
            this.panel5.Controls.Add(this.lvLar);
            this.panel5.Location = new System.Drawing.Point(9, 188);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(871, 504);
            this.panel5.TabIndex = 15;
            // 
            // lvLar
            // 
            this.lvLar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader8,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader5});
            this.lvLar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLar.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lvLar.FullRowSelect = true;
            this.lvLar.GridLines = true;
            this.lvLar.HideSelection = false;
            this.lvLar.Location = new System.Drawing.Point(9, 8);
            this.lvLar.MultiSelect = false;
            this.lvLar.Name = "lvLar";
            this.lvLar.Size = new System.Drawing.Size(852, 432);
            this.lvLar.TabIndex = 1;
            this.lvLar.UseCompatibleStateImageBehavior = false;
            this.lvLar.View = System.Windows.Forms.View.Details;
            this.lvLar.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvLar_ItemSelectionChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Código";
            this.columnHeader9.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "idAnimal";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Responsável do lar";
            this.columnHeader2.Width = 176;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Nome do animal";
            this.columnHeader8.Width = 169;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Espécie";
            this.columnHeader3.Width = 121;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Gênero";
            this.columnHeader4.Width = 99;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Início";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 99;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Fim";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 83;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "R$ mensal";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 92;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.txtCPFNome);
            this.panel3.Controls.Add(this.label34);
            this.panel3.Controls.Add(this.btnLimpar);
            this.panel3.Controls.Add(this.btnPesquisar);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(8, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(873, 100);
            this.panel3.TabIndex = 14;
            // 
            // txtCPFNome
            // 
            this.txtCPFNome.Location = new System.Drawing.Point(82, 34);
            this.txtCPFNome.Name = "txtCPFNome";
            this.txtCPFNome.Size = new System.Drawing.Size(119, 20);
            this.txtCPFNome.TabIndex = 0;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(14, 37);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(66, 13);
            this.label34.TabIndex = 15;
            this.label34.Text = "Nome / CPF";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(112, 61);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(89, 23);
            this.btnLimpar.TabIndex = 2;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(17, 61);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(89, 23);
            this.btnPesquisar.TabIndex = 1;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnEncerrarHospedagem);
            this.panel6.Controls.Add(this.btnAdicionarHospedagem);
            this.panel6.Controls.Add(this.btnEditar);
            this.panel6.Location = new System.Drawing.Point(9, 153);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(871, 37);
            this.panel6.TabIndex = 16;
            // 
            // btnEncerrarHospedagem
            // 
            this.btnEncerrarHospedagem.BackColor = System.Drawing.Color.Transparent;
            this.btnEncerrarHospedagem.BackgroundImage = global::Desktop.Properties.Resources.icons8_sair_24;
            this.btnEncerrarHospedagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEncerrarHospedagem.FlatAppearance.BorderSize = 0;
            this.btnEncerrarHospedagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncerrarHospedagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncerrarHospedagem.Location = new System.Drawing.Point(712, 5);
            this.btnEncerrarHospedagem.Name = "btnEncerrarHospedagem";
            this.btnEncerrarHospedagem.Size = new System.Drawing.Size(149, 24);
            this.btnEncerrarHospedagem.TabIndex = 2;
            this.btnEncerrarHospedagem.Text = "      Encerrar hospedagem";
            this.btnEncerrarHospedagem.UseVisualStyleBackColor = false;
            this.btnEncerrarHospedagem.Visible = false;
            this.btnEncerrarHospedagem.Click += new System.EventHandler(this.btnEncerrarHospedagem_Click);
            // 
            // btnAdicionarHospedagem
            // 
            this.btnAdicionarHospedagem.BackColor = System.Drawing.Color.Transparent;
            this.btnAdicionarHospedagem.BackgroundImage = global::Desktop.Properties.Resources.Novo_24;
            this.btnAdicionarHospedagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdicionarHospedagem.FlatAppearance.BorderSize = 0;
            this.btnAdicionarHospedagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarHospedagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarHospedagem.Location = new System.Drawing.Point(9, 5);
            this.btnAdicionarHospedagem.Name = "btnAdicionarHospedagem";
            this.btnAdicionarHospedagem.Size = new System.Drawing.Size(70, 24);
            this.btnAdicionarHospedagem.TabIndex = 0;
            this.btnAdicionarHospedagem.Text = "       Novo";
            this.btnAdicionarHospedagem.UseVisualStyleBackColor = false;
            this.btnAdicionarHospedagem.Click += new System.EventHandler(this.btnAdicionarAnimal_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.BackgroundImage = global::Desktop.Properties.Resources.Editar_241;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(94, 5);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(71, 24);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "      Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 29);
            this.panel2.TabIndex = 17;
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
            this.label1.Text = "Animais hospedados em lares temporários";
            // 
            // toolTipNovo
            // 
            this.toolTipNovo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipNovo.ToolTipTitle = "Botão \"Novo\"";
            // 
            // toolTipImprimir
            // 
            this.toolTipImprimir.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipImprimir.ToolTipTitle = "Botão \"Imprimir\"";
            // 
            // toolTipExportar
            // 
            this.toolTipExportar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipExportar.ToolTipTitle = "Botão \"Exportar\"";
            // 
            // toolTipEditar
            // 
            this.toolTipEditar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipEditar.ToolTipTitle = "Botão \"Editar\"";
            // 
            // toolTipExcluir
            // 
            this.toolTipExcluir.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipExcluir.ToolTipTitle = "Botão \"Excluir\"";
            // 
            // toolTipPesquisar
            // 
            this.toolTipPesquisar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipPesquisar.ToolTipTitle = "Botão \"Pesquisar\"";
            // 
            // toolTipLimpar
            // 
            this.toolTipLimpar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipLimpar.ToolTipTitle = "Botão \"Limpar\"";
            // 
            // paneLaranja
            // 
            this.paneLaranja.BackColor = System.Drawing.Color.Orange;
            this.paneLaranja.Location = new System.Drawing.Point(646, 447);
            this.paneLaranja.Name = "paneLaranja";
            this.paneLaranja.Size = new System.Drawing.Size(22, 20);
            this.paneLaranja.TabIndex = 2;
            this.paneLaranja.Visible = false;
            // 
            // lblAnimalFalecido
            // 
            this.lblAnimalFalecido.AutoSize = true;
            this.lblAnimalFalecido.Location = new System.Drawing.Point(671, 450);
            this.lblAnimalFalecido.Name = "lblAnimalFalecido";
            this.lblAnimalFalecido.Size = new System.Drawing.Size(194, 13);
            this.lblAnimalFalecido.TabIndex = 3;
            this.lblAnimalFalecido.Text = "Animal falecido - encerrar hospedagem*";
            this.lblAnimalFalecido.Visible = false;
            // 
            // FormConsultaHospedagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 729);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConsultaHospedagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormLarTemporario";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboEspecie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdAnimal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboGenero;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView lvLar;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCPFNome;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTipNovo;
        private System.Windows.Forms.ToolTip toolTipImprimir;
        private System.Windows.Forms.ToolTip toolTipExportar;
        private System.Windows.Forms.ToolTip toolTipEditar;
        private System.Windows.Forms.ToolTip toolTipExcluir;
        private System.Windows.Forms.ToolTip toolTipPesquisar;
        private System.Windows.Forms.ToolTip toolTipLimpar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnAdicionarHospedagem;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnEncerrarHospedagem;
        private System.Windows.Forms.Label lblAnimalFalecido;
        private System.Windows.Forms.Panel paneLaranja;
    }
}