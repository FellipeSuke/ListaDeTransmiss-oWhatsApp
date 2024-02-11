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
            textBox1 = new TextBox();
            cbEncerraSessao = new Button();
            tbSessionId = new TextBox();
            label1 = new Label();
            cbStats = new Button();
            pbQrCode = new PictureBox();
            labelResponse = new Label();
            cbRefreshQrCode = new Button();
            tbContato = new TextBox();
            labelContato = new Label();
            clbContatos = new CheckedListBox();
            cbAddContato = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
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
            // textBox1
            // 
            textBox1.AcceptsReturn = true;
            textBox1.AcceptsTab = true;
            textBox1.AllowDrop = true;
            textBox1.Location = new Point(181, 173);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(256, 220);
            textBox1.TabIndex = 30;
            // 
            // cbEncerraSessao
            // 
            cbEncerraSessao.Location = new Point(700, 399);
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
            tbSessionId.Location = new Point(700, 24);
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
            label1.Location = new Point(626, 24);
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
            pbQrCode.Location = new Point(443, 48);
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
            cbRefreshQrCode.Location = new Point(443, 399);
            cbRefreshQrCode.Name = "cbRefreshQrCode";
            cbRefreshQrCode.Size = new Size(88, 27);
            cbRefreshQrCode.TabIndex = 4;
            cbRefreshQrCode.Text = "Refresh";
            cbRefreshQrCode.UseVisualStyleBackColor = true;
            cbRefreshQrCode.Visible = false;
            cbRefreshQrCode.Click += cbRefreshQrCode_Click;
            // 
            // tbContato
            // 
            tbContato.Location = new Point(45, 104);
            tbContato.Name = "tbContato";
            tbContato.Size = new Size(92, 23);
            tbContato.TabIndex = 31;
            tbContato.Text = "11-91234-5678";
            tbContato.TextChanged += Campo_TextChanged;
            tbContato.KeyPress += Valida_KeyPress;
            tbContato.Leave += Campo_Leave;
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
            clbContatos.Size = new Size(120, 220);
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
            // 
            // textBox2
            // 
            textBox2.Location = new Point(45, 144);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(392, 23);
            textBox2.TabIndex = 35;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(cbAddContato);
            Controls.Add(clbContatos);
            Controls.Add(labelContato);
            Controls.Add(tbContato);
            Controls.Add(cbRefreshQrCode);
            Controls.Add(labelResponse);
            Controls.Add(pbQrCode);
            Controls.Add(cbStats);
            Controls.Add(label1);
            Controls.Add(tbSessionId);
            Controls.Add(cbEncerraSessao);
            Controls.Add(textBox1);
            Controls.Add(cbIniciarsessao);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbQrCode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cbIniciarsessao;
        private TextBox textBox1;
        private Button cbEncerraSessao;
        private TextBox tbSessionId;
        private Label label1;
        private Button cbStats;
        private PictureBox pbQrCode;
        private Label labelResponse;
        private Button cbRefreshQrCode;
        private TextBox tbContato;
        private Label labelContato;
        private CheckedListBox clbContatos;
        private Button cbAddContato;
        private TextBox textBox2;
        private Label label2;
    }
}