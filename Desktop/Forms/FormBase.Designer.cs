namespace SisGUAPA.Forms
{
    partial class FormBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnEntidades = new System.Windows.Forms.Button();
            this.btnLarTemporario = new System.Windows.Forms.Button();
            this.btnAdocao = new System.Windows.Forms.Button();
            this.btnAnimal = new System.Windows.Forms.Button();
            this.btnAtendimento = new System.Windows.Forms.Button();
            this.btnTratamento = new System.Windows.Forms.Button();
            this.btnEstatisticas = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnEvento = new System.Windows.Forms.Button();
            this.btnJuridico = new System.Windows.Forms.Button();
            this.btnDoacao = new System.Windows.Forms.Button();
            this.btnFinanceiro = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.popup = new Tulpep.NotificationWindow.PopupNotifier();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMenu.Controls.Add(this.btnEntidades);
            this.panelMenu.Controls.Add(this.btnLarTemporario);
            this.panelMenu.Controls.Add(this.btnAdocao);
            this.panelMenu.Controls.Add(this.btnAnimal);
            this.panelMenu.Controls.Add(this.btnAtendimento);
            this.panelMenu.Controls.Add(this.btnTratamento);
            this.panelMenu.Controls.Add(this.btnEstatisticas);
            this.panelMenu.Controls.Add(this.btnUsuario);
            this.panelMenu.Controls.Add(this.btnEvento);
            this.panelMenu.Controls.Add(this.btnJuridico);
            this.panelMenu.Controls.Add(this.btnDoacao);
            this.panelMenu.Controls.Add(this.btnFinanceiro);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(80, 664);
            this.panelMenu.TabIndex = 3;
            // 
            // btnEntidades
            // 
            this.btnEntidades.BackColor = System.Drawing.Color.Transparent;
            this.btnEntidades.BackgroundImage = global::Desktop.Properties.Resources.entidades_48;
            this.btnEntidades.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEntidades.FlatAppearance.BorderSize = 0;
            this.btnEntidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntidades.Location = new System.Drawing.Point(18, 383);
            this.btnEntidades.Name = "btnEntidades";
            this.btnEntidades.Size = new System.Drawing.Size(40, 44);
            this.btnEntidades.TabIndex = 21;
            this.btnEntidades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEntidades.UseVisualStyleBackColor = false;
            this.btnEntidades.Click += new System.EventHandler(this.btnEntidades_Click);
            // 
            // btnLarTemporario
            // 
            this.btnLarTemporario.BackColor = System.Drawing.Color.Transparent;
            this.btnLarTemporario.BackgroundImage = global::Desktop.Properties.Resources.lar_temporario;
            this.btnLarTemporario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLarTemporario.FlatAppearance.BorderSize = 0;
            this.btnLarTemporario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLarTemporario.Location = new System.Drawing.Point(18, 321);
            this.btnLarTemporario.Name = "btnLarTemporario";
            this.btnLarTemporario.Size = new System.Drawing.Size(40, 44);
            this.btnLarTemporario.TabIndex = 20;
            this.btnLarTemporario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLarTemporario.UseVisualStyleBackColor = false;
            this.btnLarTemporario.Click += new System.EventHandler(this.btnLar_Click);
            // 
            // btnAdocao
            // 
            this.btnAdocao.BackColor = System.Drawing.Color.Transparent;
            this.btnAdocao.BackgroundImage = global::Desktop.Properties.Resources.lar_temporario_481;
            this.btnAdocao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdocao.FlatAppearance.BorderSize = 0;
            this.btnAdocao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdocao.Location = new System.Drawing.Point(18, 135);
            this.btnAdocao.Name = "btnAdocao";
            this.btnAdocao.Size = new System.Drawing.Size(40, 44);
            this.btnAdocao.TabIndex = 19;
            this.btnAdocao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdocao.UseVisualStyleBackColor = false;
            this.btnAdocao.Click += new System.EventHandler(this.btnAdocao_Click);
            // 
            // btnAnimal
            // 
            this.btnAnimal.BackColor = System.Drawing.Color.Transparent;
            this.btnAnimal.BackgroundImage = global::Desktop.Properties.Resources.pata_botao_48;
            this.btnAnimal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAnimal.FlatAppearance.BorderSize = 0;
            this.btnAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnimal.Location = new System.Drawing.Point(18, 73);
            this.btnAnimal.Name = "btnAnimal";
            this.btnAnimal.Size = new System.Drawing.Size(40, 44);
            this.btnAnimal.TabIndex = 18;
            this.btnAnimal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAnimal.UseVisualStyleBackColor = false;
            this.btnAnimal.Click += new System.EventHandler(this.btnAnimal_Click);
            // 
            // btnAtendimento
            // 
            this.btnAtendimento.BackColor = System.Drawing.Color.Transparent;
            this.btnAtendimento.BackgroundImage = global::Desktop.Properties.Resources.atendimentos_48;
            this.btnAtendimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtendimento.FlatAppearance.BorderSize = 0;
            this.btnAtendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtendimento.Location = new System.Drawing.Point(18, 197);
            this.btnAtendimento.Name = "btnAtendimento";
            this.btnAtendimento.Size = new System.Drawing.Size(40, 44);
            this.btnAtendimento.TabIndex = 17;
            this.btnAtendimento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAtendimento.UseVisualStyleBackColor = false;
            this.btnAtendimento.Click += new System.EventHandler(this.btnAtendimento_Click);
            // 
            // btnTratamento
            // 
            this.btnTratamento.BackColor = System.Drawing.Color.Transparent;
            this.btnTratamento.BackgroundImage = global::Desktop.Properties.Resources.tratamento_48;
            this.btnTratamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTratamento.FlatAppearance.BorderSize = 0;
            this.btnTratamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTratamento.Location = new System.Drawing.Point(18, 259);
            this.btnTratamento.Name = "btnTratamento";
            this.btnTratamento.Size = new System.Drawing.Size(40, 44);
            this.btnTratamento.TabIndex = 16;
            this.btnTratamento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTratamento.UseVisualStyleBackColor = false;
            this.btnTratamento.Click += new System.EventHandler(this.btnTratamento_Click);
            // 
            // btnEstatisticas
            // 
            this.btnEstatisticas.BackColor = System.Drawing.Color.Transparent;
            this.btnEstatisticas.BackgroundImage = global::Desktop.Properties.Resources.estatistica_48;
            this.btnEstatisticas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEstatisticas.FlatAppearance.BorderSize = 0;
            this.btnEstatisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstatisticas.Location = new System.Drawing.Point(18, 11);
            this.btnEstatisticas.Name = "btnEstatisticas";
            this.btnEstatisticas.Size = new System.Drawing.Size(40, 44);
            this.btnEstatisticas.TabIndex = 6;
            this.btnEstatisticas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEstatisticas.UseVisualStyleBackColor = false;
            this.btnEstatisticas.Click += new System.EventHandler(this.btnEstatisticas_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(3, 608);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(117, 23);
            this.btnUsuario.TabIndex = 14;
            this.btnUsuario.Text = "Usuário";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Visible = false;
            // 
            // btnEvento
            // 
            this.btnEvento.Location = new System.Drawing.Point(3, 550);
            this.btnEvento.Name = "btnEvento";
            this.btnEvento.Size = new System.Drawing.Size(117, 23);
            this.btnEvento.TabIndex = 12;
            this.btnEvento.Text = "Evento";
            this.btnEvento.UseVisualStyleBackColor = true;
            this.btnEvento.Visible = false;
            // 
            // btnJuridico
            // 
            this.btnJuridico.Location = new System.Drawing.Point(3, 579);
            this.btnJuridico.Name = "btnJuridico";
            this.btnJuridico.Size = new System.Drawing.Size(117, 23);
            this.btnJuridico.TabIndex = 10;
            this.btnJuridico.Text = "Jurídico";
            this.btnJuridico.UseVisualStyleBackColor = true;
            this.btnJuridico.Visible = false;
            // 
            // btnDoacao
            // 
            this.btnDoacao.Location = new System.Drawing.Point(3, 521);
            this.btnDoacao.Name = "btnDoacao";
            this.btnDoacao.Size = new System.Drawing.Size(117, 23);
            this.btnDoacao.TabIndex = 8;
            this.btnDoacao.Text = "Doação";
            this.btnDoacao.UseVisualStyleBackColor = true;
            this.btnDoacao.Visible = false;
            // 
            // btnFinanceiro
            // 
            this.btnFinanceiro.Location = new System.Drawing.Point(3, 637);
            this.btnFinanceiro.Name = "btnFinanceiro";
            this.btnFinanceiro.Size = new System.Drawing.Size(117, 23);
            this.btnFinanceiro.TabIndex = 6;
            this.btnFinanceiro.Text = "Financeiro";
            this.btnFinanceiro.UseVisualStyleBackColor = true;
            this.btnFinanceiro.Visible = false;
            // 
            // popup
            // 
            this.popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            this.popup.ContentText = null;
            this.popup.Delay = 3000000;
            this.popup.Image = global::Desktop.Properties.Resources.calendario_48;
            this.popup.IsRightToLeft = false;
            this.popup.OptionsMenu = null;
            this.popup.Scroll = false;
            this.popup.Size = new System.Drawing.Size(400, 100);
            this.popup.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            this.popup.TitleText = "Tratamento agendado";
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 664);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SisGUAPA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBase_FormClosed);
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.Resize += new System.EventHandler(this.FormBase_Resize);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnEvento;
        private System.Windows.Forms.Button btnJuridico;
        private System.Windows.Forms.Button btnDoacao;
        private System.Windows.Forms.Button btnFinanceiro;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnEstatisticas;
        private System.Windows.Forms.ToolTip toolTip;
        private Tulpep.NotificationWindow.PopupNotifier popup;
        private System.Windows.Forms.Button btnTratamento;
        private System.Windows.Forms.Button btnAtendimento;
        private System.Windows.Forms.Button btnAnimal;
        private System.Windows.Forms.Button btnAdocao;
        private System.Windows.Forms.Button btnLarTemporario;
        private System.Windows.Forms.Button btnEntidades;
    }
}