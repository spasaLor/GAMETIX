namespace ClientCS
{
    partial class Reg
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
            this.btn_log = new System.Windows.Forms.Button();
            this.l_title = new System.Windows.Forms.Label();
            this.l_nome = new System.Windows.Forms.Label();
            this.l_reg = new System.Windows.Forms.Label();
            this.l_cognome = new System.Windows.Forms.Label();
            this.l_eta = new System.Windows.Forms.Label();
            this.l_tel = new System.Windows.Forms.Label();
            this.l_mail = new System.Windows.Forms.Label();
            this.l_pwd = new System.Windows.Forms.Label();
            this.l_conf = new System.Windows.Forms.Label();
            this.tbx_nome = new System.Windows.Forms.TextBox();
            this.tbx_cogn = new System.Windows.Forms.TextBox();
            this.tbx_eta = new System.Windows.Forms.TextBox();
            this.tbx_tel = new System.Windows.Forms.TextBox();
            this.tbx_mail = new System.Windows.Forms.TextBox();
            this.tbx_pwd = new System.Windows.Forms.TextBox();
            this.tbx_conf = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_reg = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_log
            // 
            this.btn_log.BackColor = System.Drawing.Color.DimGray;
            this.btn_log.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_log.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_log.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_log.Location = new System.Drawing.Point(70, 22);
            this.btn_log.Name = "btn_log";
            this.btn_log.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_log.Size = new System.Drawing.Size(114, 41);
            this.btn_log.TabIndex = 0;
            this.btn_log.Text = "Login";
            this.btn_log.UseVisualStyleBackColor = false;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // l_title
            // 
            this.l_title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.l_title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.l_title.Location = new System.Drawing.Point(486, 17);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(153, 41);
            this.l_title.TabIndex = 1;
            this.l_title.Text = "GAMETIX";
            this.l_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_nome
            // 
            this.l_nome.AutoSize = true;
            this.l_nome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_nome.Location = new System.Drawing.Point(353, 91);
            this.l_nome.Name = "l_nome";
            this.l_nome.Size = new System.Drawing.Size(66, 28);
            this.l_nome.TabIndex = 2;
            this.l_nome.Text = "Nome";
            // 
            // l_reg
            // 
            this.l_reg.AutoSize = true;
            this.l_reg.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.l_reg.Location = new System.Drawing.Point(464, 23);
            this.l_reg.Name = "l_reg";
            this.l_reg.Size = new System.Drawing.Size(209, 41);
            this.l_reg.TabIndex = 3;
            this.l_reg.Text = "Registrazione";
            // 
            // l_cognome
            // 
            this.l_cognome.AutoSize = true;
            this.l_cognome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_cognome.Location = new System.Drawing.Point(353, 135);
            this.l_cognome.Name = "l_cognome";
            this.l_cognome.Size = new System.Drawing.Size(98, 28);
            this.l_cognome.TabIndex = 4;
            this.l_cognome.Text = "Cognome";
            // 
            // l_eta
            // 
            this.l_eta.AutoSize = true;
            this.l_eta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_eta.Location = new System.Drawing.Point(353, 183);
            this.l_eta.Name = "l_eta";
            this.l_eta.Size = new System.Drawing.Size(140, 28);
            this.l_eta.TabIndex = 5;
            this.l_eta.Text = "Data di nascita";
            // 
            // l_tel
            // 
            this.l_tel.AutoSize = true;
            this.l_tel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_tel.Location = new System.Drawing.Point(353, 232);
            this.l_tel.Name = "l_tel";
            this.l_tel.Size = new System.Drawing.Size(177, 28);
            this.l_tel.TabIndex = 6;
            this.l_tel.Text = "Numero Telefonico";
            // 
            // l_mail
            // 
            this.l_mail.AutoSize = true;
            this.l_mail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_mail.Location = new System.Drawing.Point(353, 286);
            this.l_mail.Name = "l_mail";
            this.l_mail.Size = new System.Drawing.Size(68, 28);
            this.l_mail.TabIndex = 7;
            this.l_mail.Text = "E-Mail";
            // 
            // l_pwd
            // 
            this.l_pwd.AutoSize = true;
            this.l_pwd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_pwd.Location = new System.Drawing.Point(353, 339);
            this.l_pwd.Name = "l_pwd";
            this.l_pwd.Size = new System.Drawing.Size(93, 28);
            this.l_pwd.TabIndex = 8;
            this.l_pwd.Text = "Password";
            // 
            // l_conf
            // 
            this.l_conf.AutoSize = true;
            this.l_conf.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_conf.Location = new System.Drawing.Point(353, 392);
            this.l_conf.Name = "l_conf";
            this.l_conf.Size = new System.Drawing.Size(183, 28);
            this.l_conf.TabIndex = 9;
            this.l_conf.Text = "Conferma Password";
            // 
            // tbx_nome
            // 
            this.tbx_nome.Location = new System.Drawing.Point(599, 92);
            this.tbx_nome.Name = "tbx_nome";
            this.tbx_nome.Size = new System.Drawing.Size(189, 27);
            this.tbx_nome.TabIndex = 10;
            // 
            // tbx_cogn
            // 
            this.tbx_cogn.Location = new System.Drawing.Point(599, 136);
            this.tbx_cogn.Name = "tbx_cogn";
            this.tbx_cogn.Size = new System.Drawing.Size(189, 27);
            this.tbx_cogn.TabIndex = 11;
            // 
            // tbx_eta
            // 
            this.tbx_eta.Location = new System.Drawing.Point(599, 184);
            this.tbx_eta.Name = "tbx_eta";
            this.tbx_eta.PlaceholderText = "GG/MM/AAAA";
            this.tbx_eta.Size = new System.Drawing.Size(189, 27);
            this.tbx_eta.TabIndex = 12;
            // 
            // tbx_tel
            // 
            this.tbx_tel.Location = new System.Drawing.Point(599, 236);
            this.tbx_tel.Name = "tbx_tel";
            this.tbx_tel.PlaceholderText = "Opzionale";
            this.tbx_tel.Size = new System.Drawing.Size(189, 27);
            this.tbx_tel.TabIndex = 13;
            // 
            // tbx_mail
            // 
            this.tbx_mail.Location = new System.Drawing.Point(599, 290);
            this.tbx_mail.Name = "tbx_mail";
            this.tbx_mail.Size = new System.Drawing.Size(189, 27);
            this.tbx_mail.TabIndex = 14;
            // 
            // tbx_pwd
            // 
            this.tbx_pwd.Location = new System.Drawing.Point(599, 343);
            this.tbx_pwd.Name = "tbx_pwd";
            this.tbx_pwd.PasswordChar = '*';
            this.tbx_pwd.Size = new System.Drawing.Size(189, 27);
            this.tbx_pwd.TabIndex = 15;
            // 
            // tbx_conf
            // 
            this.tbx_conf.Location = new System.Drawing.Point(599, 396);
            this.tbx_conf.Name = "tbx_conf";
            this.tbx_conf.PasswordChar = '*';
            this.tbx_conf.Size = new System.Drawing.Size(189, 27);
            this.tbx_conf.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.l_title);
            this.panel1.Controls.Add(this.btn_log);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 86);
            this.panel1.TabIndex = 17;
            // 
            // btn_reg
            // 
            this.btn_reg.BackColor = System.Drawing.Color.DimGray;
            this.btn_reg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reg.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_reg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_reg.Location = new System.Drawing.Point(464, 459);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(231, 46);
            this.btn_reg.TabIndex = 18;
            this.btn_reg.Text = "Invia";
            this.btn_reg.UseVisualStyleBackColor = false;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.l_reg);
            this.panel2.Controls.Add(this.btn_reg);
            this.panel2.Controls.Add(this.l_nome);
            this.panel2.Controls.Add(this.l_cognome);
            this.panel2.Controls.Add(this.tbx_conf);
            this.panel2.Controls.Add(this.l_eta);
            this.panel2.Controls.Add(this.tbx_pwd);
            this.panel2.Controls.Add(this.l_tel);
            this.panel2.Controls.Add(this.tbx_mail);
            this.panel2.Controls.Add(this.l_mail);
            this.panel2.Controls.Add(this.tbx_tel);
            this.panel2.Controls.Add(this.l_pwd);
            this.panel2.Controls.Add(this.tbx_eta);
            this.panel2.Controls.Add(this.l_conf);
            this.panel2.Controls.Add(this.tbx_cogn);
            this.panel2.Controls.Add(this.tbx_nome);
            this.panel2.Location = new System.Drawing.Point(0, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1082, 513);
            this.panel2.TabIndex = 19;
            // 
            // Reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1082, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Reg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAMETIX";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        
        private Button btn_log;
        private Label l_title;
        private Label l_nome;
        private Label l_reg;
        private Label l_cognome;
        private Label l_eta;
        private Label l_tel;
        private Label l_mail;
        private Label l_pwd;
        private Label l_conf;
        private TextBox tbx_nome;
        private TextBox tbx_cogn;
        private TextBox tbx_eta;
        private TextBox tbx_tel;
        private TextBox tbx_mail;
        private TextBox tbx_pwd;
        private TextBox tbx_conf;
        private Panel panel1;
        private Button btn_reg;
        private Panel panel2;
    }
}