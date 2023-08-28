namespace ClientCS
{
    partial class Login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.l_title = new System.Windows.Forms.Label();
            this.btn_reg = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_login = new System.Windows.Forms.Label();
            this.l_mail = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.tbx_mail = new System.Windows.Forms.TextBox();
            this.tbx_pwd = new System.Windows.Forms.TextBox();
            this.cbx_mostraPwd = new System.Windows.Forms.CheckBox();
            this.l_pwd = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.l_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 80);
            this.panel1.TabIndex = 17;
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
            // btn_reg
            // 
            this.btn_reg.BackColor = System.Drawing.Color.DimGray;
            this.btn_reg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_reg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_reg.Location = new System.Drawing.Point(448, 416);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_reg.Size = new System.Drawing.Size(250, 54);
            this.btn_reg.TabIndex = 0;
            this.btn_reg.Text = "Registrati";
            this.btn_reg.UseVisualStyleBackColor = false;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_reg);
            this.panel2.Controls.Add(this.label_login);
            this.panel2.Controls.Add(this.l_mail);
            this.panel2.Controls.Add(this.btn_login);
            this.panel2.Controls.Add(this.tbx_mail);
            this.panel2.Controls.Add(this.tbx_pwd);
            this.panel2.Controls.Add(this.cbx_mostraPwd);
            this.panel2.Controls.Add(this.l_pwd);
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1082, 493);
            this.panel2.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(538, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 28);
            this.label1.TabIndex = 25;
            this.label1.Text = "oppure";
            // 
            // label_login
            // 
            this.label_login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_login.AutoSize = true;
            this.label_login.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_login.Location = new System.Drawing.Point(512, 23);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(97, 41);
            this.label_login.TabIndex = 24;
            this.label_login.Text = "Login";
            // 
            // l_mail
            // 
            this.l_mail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l_mail.AutoSize = true;
            this.l_mail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_mail.Location = new System.Drawing.Point(446, 85);
            this.l_mail.Name = "l_mail";
            this.l_mail.Size = new System.Drawing.Size(59, 28);
            this.l_mail.TabIndex = 18;
            this.l_mail.Text = "Email";
            // 
            // btn_login
            // 
            this.btn_login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_login.BackColor = System.Drawing.Color.DimGray;
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_login.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_login.Location = new System.Drawing.Point(448, 306);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(250, 54);
            this.btn_login.TabIndex = 23;
            this.btn_login.Text = "Entra";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // tbx_mail
            // 
            this.tbx_mail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbx_mail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbx_mail.Location = new System.Drawing.Point(448, 122);
            this.tbx_mail.Name = "tbx_mail";
            this.tbx_mail.PlaceholderText = "example@dominio.it";
            this.tbx_mail.Size = new System.Drawing.Size(244, 34);
            this.tbx_mail.TabIndex = 21;
            // 
            // tbx_pwd
            // 
            this.tbx_pwd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbx_pwd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbx_pwd.Location = new System.Drawing.Point(448, 201);
            this.tbx_pwd.Name = "tbx_pwd";
            this.tbx_pwd.PasswordChar = '•';
            this.tbx_pwd.Size = new System.Drawing.Size(250, 34);
            this.tbx_pwd.TabIndex = 20;
            // 
            // cbx_mostraPwd
            // 
            this.cbx_mostraPwd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbx_mostraPwd.AutoSize = true;
            this.cbx_mostraPwd.Location = new System.Drawing.Point(446, 264);
            this.cbx_mostraPwd.Name = "cbx_mostraPwd";
            this.cbx_mostraPwd.Size = new System.Drawing.Size(142, 24);
            this.cbx_mostraPwd.TabIndex = 22;
            this.cbx_mostraPwd.Text = "Mostra Password";
            this.cbx_mostraPwd.UseVisualStyleBackColor = true;
            this.cbx_mostraPwd.CheckedChanged += new System.EventHandler(this.cbx_mostraPwd_CheckedChanged);
            // 
            // l_pwd
            // 
            this.l_pwd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l_pwd.AutoSize = true;
            this.l_pwd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_pwd.Location = new System.Drawing.Point(446, 170);
            this.l_pwd.Name = "l_pwd";
            this.l_pwd.Size = new System.Drawing.Size(93, 28);
            this.l_pwd.TabIndex = 19;
            this.l_pwd.Text = "Password";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1082, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btn_reg;
        private Label l_title;
        private Panel panel2;
        private Label l_mail;
        private Button btn_login;
        private TextBox tbx_mail;
        private TextBox tbx_pwd;
        private CheckBox cbx_mostraPwd;
        private Label l_pwd;
        private Label label_login;
        private Label label1;
    }
}