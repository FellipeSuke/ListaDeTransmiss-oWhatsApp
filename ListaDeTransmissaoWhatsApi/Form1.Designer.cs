namespace ListaDeTransmissaoWhatsApi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbIniciarsessao = new Button();
            tbCampoMessage = new TextBox();
            cbEncerraSessao = new Button();
            tbSessionId = new TextBox();
            label1 = new Label();
            cbStats = new Button();
            pbQrCode = new PictureBox();
            labelResponse = new Label();
            cbRefreshQrCode = new Button();
            tbNumeroContato = new TextBox();
            labelContato = new Label();
            clbContatos = new CheckedListBox();
            cbAddContato = new Button();
            tbNomeContato = new TextBox();
            label2 = new Label();
            cbEnviarMensagem = new Button();
            LabelServidor = new Label();
            cbConnectar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbQrCode).BeginInit();
            SuspendLayout();
            // 
            // cbIniciarsessao
            // 
            cbIniciarsessao.Location = new Point(45, 16);
            cbIniciarsessao.Name = "cbIniciarsessao";
            cbIniciarsessao.Size = new Size(92, 23);
            cbIniciarsessao.TabIndex = 1;
            cbIniciarsessao.Text = "iniciarSessão";
            cbIniciarsessao.UseVisualStyleBackColor = true;
            cbIniciarsessao.Click += cbIniciarsessao_Click;
            // 
            // tbCampoMessage
            // 
            tbCampoMessage.AcceptsReturn = true;
            tbCampoMessage.AcceptsTab = true;
            tbCampoMessage.AllowDrop = true;
            tbCampoMessage.Location = new Point(45, 309);
            tbCampoMessage.Multiline = true;
            tbCampoMessage.Name = "tbCampoMessage";
            tbCampoMessage.ScrollBars = ScrollBars.Vertical;
            tbCampoMessage.Size = new Size(392, 84);
            tbCampoMessage.TabIndex = 30;
            // 
            // cbEncerraSessao
            // 
            cbEncerraSessao.Location = new Point(710, 421);
            cbEncerraSessao.Name = "cbEncerraSessao";
            cbEncerraSessao.Size = new Size(88, 27);
            cbEncerraSessao.TabIndex = 5;
            cbEncerraSessao.Text = "Stop Sessão";
            cbEncerraSessao.UseVisualStyleBackColor = true;
            cbEncerraSessao.Click += cbEncerraSessao_Click;
            // 
            // tbSessionId
            // 
            tbSessionId.CharacterCasing = CharacterCasing.Lower;
            tbSessionId.Location = new Point(710, 44);
            tbSessionId.MaxLength = 14;
            tbSessionId.Name = "tbSessionId";
            tbSessionId.Size = new Size(88, 23);
            tbSessionId.TabIndex = 0;
            tbSessionId.Text = "11-91234-5678";
            tbSessionId.TextChanged += Campo_TextChanged;
            tbSessionId.KeyPress += Valida_KeyPress;
            tbSessionId.Leave += Campo_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(636, 44);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 4;
            label1.Text = "Nº Telefone";
            // 
            // cbStats
            // 
            cbStats.Location = new Point(45, 44);
            cbStats.Name = "cbStats";
            cbStats.Size = new Size(92, 23);
            cbStats.TabIndex = 2;
            cbStats.Text = "Status";
            cbStats.UseVisualStyleBackColor = true;
            cbStats.Click += cbStats_Click;
            // 
            // pbQrCode
            // 
            pbQrCode.Location = new Point(453, 70);
            pbQrCode.Name = "pbQrCode";
            pbQrCode.Size = new Size(345, 345);
            pbQrCode.SizeMode = PictureBoxSizeMode.StretchImage;
            pbQrCode.TabIndex = 6;
            pbQrCode.TabStop = false;
            pbQrCode.Visible = false;
            // 
            // labelResponse
            // 
            labelResponse.AutoSize = true;
            labelResponse.BackColor = SystemColors.ActiveCaption;
            labelResponse.Location = new Point(153, 20);
            labelResponse.Name = "labelResponse";
            labelResponse.Size = new Size(12, 15);
            labelResponse.TabIndex = 7;
            labelResponse.Text = "_";
            // 
            // cbRefreshQrCode
            // 
            cbRefreshQrCode.Location = new Point(453, 421);
            cbRefreshQrCode.Name = "cbRefreshQrCode";
            cbRefreshQrCode.Size = new Size(88, 27);
            cbRefreshQrCode.TabIndex = 4;
            cbRefreshQrCode.Text = "Refresh";
            cbRefreshQrCode.UseVisualStyleBackColor = true;
            cbRefreshQrCode.Visible = false;
            cbRefreshQrCode.Click += cbRefreshQrCode_Click;
            // 
            // tbNumeroContato
            // 
            tbNumeroContato.Location = new Point(45, 104);
            tbNumeroContato.Name = "tbNumeroContato";
            tbNumeroContato.Size = new Size(92, 23);
            tbNumeroContato.TabIndex = 31;
            tbNumeroContato.Text = "67-98457-8078";
            tbNumeroContato.TextChanged += Campo_TextChanged;
            tbNumeroContato.KeyPress += Valida_KeyPress;
            tbNumeroContato.Leave += Campo_Leave;
            // 
            // labelContato
            // 
            labelContato.AutoSize = true;
            labelContato.Location = new Point(45, 85);
            labelContato.Name = "labelContato";
            labelContato.Size = new Size(50, 15);
            labelContato.TabIndex = 32;
            labelContato.Text = "Contato";
            // 
            // clbContatos
            // 
            clbContatos.FormattingEnabled = true;
            clbContatos.Location = new Point(45, 173);
            clbContatos.Name = "clbContatos";
            clbContatos.Size = new Size(334, 130);
            clbContatos.TabIndex = 33;
            // 
            // cbAddContato
            // 
            cbAddContato.Location = new Point(153, 103);
            cbAddContato.Name = "cbAddContato";
            cbAddContato.Size = new Size(75, 23);
            cbAddContato.TabIndex = 34;
            cbAddContato.Text = "ADD";
            cbAddContato.UseVisualStyleBackColor = true;
            cbAddContato.Click += cbAddContato_Click;
            // 
            // tbNomeContato
            // 
            tbNomeContato.Location = new Point(45, 144);
            tbNomeContato.Name = "tbNomeContato";
            tbNomeContato.Size = new Size(334, 23);
            tbNomeContato.TabIndex = 35;
            tbNomeContato.Text = "Fellipe Pereira Pires";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 130);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 36;
            label2.Text = "Nome";
            // 
            // cbEnviarMensagem
            // 
            cbEnviarMensagem.Location = new Point(208, 399);
            cbEnviarMensagem.Name = "cbEnviarMensagem";
            cbEnviarMensagem.Size = new Size(88, 27);
            cbEnviarMensagem.TabIndex = 37;
            cbEnviarMensagem.Text = "Enviar Msg";
            cbEnviarMensagem.UseVisualStyleBackColor = true;
            cbEnviarMensagem.Click += cbEnviarMensagem_Click;
            // 
            // LabelServidor
            // 
            LabelServidor.AutoSize = true;
            LabelServidor.BackColor = SystemColors.Control;
            LabelServidor.Location = new Point(551, 9);
            LabelServidor.Name = "LabelServidor";
            LabelServidor.Size = new Size(169, 15);
            LabelServidor.TabIndex = 38;
            LabelServidor.Text = "Status Servidor:                           ";
            // 
            // cbConnectar
            // 
            cbConnectar.Location = new Point(453, 5);
            cbConnectar.Name = "cbConnectar";
            cbConnectar.RightToLeft = RightToLeft.Yes;
            cbConnectar.Size = new Size(92, 23);
            cbConnectar.TabIndex = 39;
            cbConnectar.Text = "Conectar";
            cbConnectar.UseVisualStyleBackColor = true;
            cbConnectar.Click += cbConnectar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbConnectar);
            Controls.Add(LabelServidor);
            Controls.Add(cbEnviarMensagem);
            Controls.Add(label2);
            Controls.Add(tbNomeContato);
            Controls.Add(cbAddContato);
            Controls.Add(clbContatos);
            Controls.Add(labelContato);
            Controls.Add(tbNumeroContato);
            Controls.Add(cbRefreshQrCode);
            Controls.Add(labelResponse);
            Controls.Add(pbQrCode);
            Controls.Add(cbStats);
            Controls.Add(label1);
            Controls.Add(tbSessionId);
            Controls.Add(cbEncerraSessao);
            Controls.Add(tbCampoMessage);
            Controls.Add(cbIniciarsessao);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbQrCode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cbIniciarsessao;
        private TextBox tbCampoMessage;
        private Button cbEncerraSessao;
        private TextBox tbSessionId;
        private Label label1;
        private Button cbStats;
        private PictureBox pbQrCode;
        private Label labelResponse;
        private Button cbRefreshQrCode;
        private TextBox tbNumeroContato;
        private Label labelContato;
        private CheckedListBox clbContatos;
        private Button cbAddContato;
        private TextBox tbNomeContato;
        private Label label2;
        private Button cbEnviarMensagem;
        private Label LabelServidor;
        private Button cbConnectar;
    }
}