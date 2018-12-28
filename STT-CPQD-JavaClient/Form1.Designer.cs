namespace STT_CPQD_JavaClient
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.lblArquivo = new System.Windows.Forms.Label();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.btnTranscrever = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnTranscreverAsync = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.btnAbrirChamado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiretorio = new System.Windows.Forms.TextBox();
            this.btnAbrirDiretorio = new System.Windows.Forms.Button();
            this.btnTrascLote = new System.Windows.Forms.Button();
            this.btnTranscLoteGs1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(33, 162);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(517, 168);
            this.txtResultado.TabIndex = 0;
            // 
            // lblArquivo
            // 
            this.lblArquivo.AutoSize = true;
            this.lblArquivo.Location = new System.Drawing.Point(33, 28);
            this.lblArquivo.Name = "lblArquivo";
            this.lblArquivo.Size = new System.Drawing.Size(46, 13);
            this.lblArquivo.TabIndex = 1;
            this.lblArquivo.Text = "Arquivo:";
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(85, 25);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(177, 20);
            this.txtArquivo.TabIndex = 2;
            // 
            // btnTranscrever
            // 
            this.btnTranscrever.Location = new System.Drawing.Point(394, 25);
            this.btnTranscrever.Name = "btnTranscrever";
            this.btnTranscrever.Size = new System.Drawing.Size(75, 23);
            this.btnTranscrever.TabIndex = 3;
            this.btnTranscrever.Text = "Transcrever";
            this.btnTranscrever.UseVisualStyleBackColor = true;
            this.btnTranscrever.Click += new System.EventHandler(this.btnTranscrever_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(33, 336);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(22, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "OK";
            // 
            // btnTranscreverAsync
            // 
            this.btnTranscreverAsync.Location = new System.Drawing.Point(475, 25);
            this.btnTranscreverAsync.Name = "btnTranscreverAsync";
            this.btnTranscreverAsync.Size = new System.Drawing.Size(75, 23);
            this.btnTranscreverAsync.TabIndex = 5;
            this.btnTranscreverAsync.Text = "Async";
            this.btnTranscreverAsync.UseVisualStyleBackColor = true;
            this.btnTranscreverAsync.Click += new System.EventHandler(this.btnTranscreverAsync_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "arquivo.wav";
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(268, 25);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(75, 23);
            this.btnCarregar.TabIndex = 6;
            this.btnCarregar.Text = "Abrir";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // btnAbrirChamado
            // 
            this.btnAbrirChamado.Location = new System.Drawing.Point(458, 336);
            this.btnAbrirChamado.Name = "btnAbrirChamado";
            this.btnAbrirChamado.Size = new System.Drawing.Size(92, 23);
            this.btnAbrirChamado.TabIndex = 7;
            this.btnAbrirChamado.Text = "Abrir Chamado";
            this.btnAbrirChamado.UseVisualStyleBackColor = true;
            this.btnAbrirChamado.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Diretório:";
            // 
            // txtDiretorio
            // 
            this.txtDiretorio.Location = new System.Drawing.Point(85, 67);
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.Size = new System.Drawing.Size(177, 20);
            this.txtDiretorio.TabIndex = 10;
            // 
            // btnAbrirDiretorio
            // 
            this.btnAbrirDiretorio.Location = new System.Drawing.Point(268, 65);
            this.btnAbrirDiretorio.Name = "btnAbrirDiretorio";
            this.btnAbrirDiretorio.Size = new System.Drawing.Size(75, 23);
            this.btnAbrirDiretorio.TabIndex = 11;
            this.btnAbrirDiretorio.Text = "Abrir";
            this.btnAbrirDiretorio.UseVisualStyleBackColor = true;
            this.btnAbrirDiretorio.Click += new System.EventHandler(this.btnAbrirDiretorio_Click);
            // 
            // btnTrascLote
            // 
            this.btnTrascLote.Location = new System.Drawing.Point(394, 65);
            this.btnTrascLote.Name = "btnTrascLote";
            this.btnTrascLote.Size = new System.Drawing.Size(156, 23);
            this.btnTrascLote.TabIndex = 12;
            this.btnTrascLote.Text = "Transcrever Lote!";
            this.btnTrascLote.UseVisualStyleBackColor = true;
            this.btnTrascLote.Click += new System.EventHandler(this.btnTrascLote_Click);
            // 
            // btnTranscLoteGs1
            // 
            this.btnTranscLoteGs1.Location = new System.Drawing.Point(394, 105);
            this.btnTranscLoteGs1.Name = "btnTranscLoteGs1";
            this.btnTranscLoteGs1.Size = new System.Drawing.Size(156, 23);
            this.btnTranscLoteGs1.TabIndex = 13;
            this.btnTranscLoteGs1.Text = "Transcrever Lote - GSV1.1";
            this.btnTranscLoteGs1.UseVisualStyleBackColor = true;
            this.btnTranscLoteGs1.Click += new System.EventHandler(this.btnTranscLoteGs1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 371);
            this.Controls.Add(this.btnTranscLoteGs1);
            this.Controls.Add(this.btnTrascLote);
            this.Controls.Add(this.btnAbrirDiretorio);
            this.Controls.Add(this.txtDiretorio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAbrirChamado);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.btnTranscreverAsync);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnTranscrever);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.lblArquivo);
            this.Controls.Add(this.txtResultado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Intelliway";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lblArquivo;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.Button btnTranscrever;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnTranscreverAsync;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.Button btnAbrirChamado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiretorio;
        private System.Windows.Forms.Button btnAbrirDiretorio;
        private System.Windows.Forms.Button btnTrascLote;
        private System.Windows.Forms.Button btnTranscLoteGs1;
    }
}

