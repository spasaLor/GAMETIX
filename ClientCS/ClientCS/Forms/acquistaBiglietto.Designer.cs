namespace ClientCS.Forms
{
    partial class acquistaBiglietto
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
            this.lbl_top = new System.Windows.Forms.Label();
            this.lbl_Partita = new System.Windows.Forms.Label();
            this.btn_acquista = new System.Windows.Forms.Button();
            this.lbl_settore = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbl_Prezzo = new System.Windows.Forms.Label();
            this.lbl_Posti = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_info = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_top
            // 
            this.lbl_top.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_top.AutoSize = true;
            this.lbl_top.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_top.Location = new System.Drawing.Point(360, 20);
            this.lbl_top.Name = "lbl_top";
            this.lbl_top.Size = new System.Drawing.Size(220, 32);
            this.lbl_top.TabIndex = 0;
            this.lbl_top.Text = "Evento selezionato:";
            // 
            // lbl_Partita
            // 
            this.lbl_Partita.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Partita.AutoSize = true;
            this.lbl_Partita.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Partita.Location = new System.Drawing.Point(264, 73);
            this.lbl_Partita.Name = "lbl_Partita";
            this.lbl_Partita.Size = new System.Drawing.Size(78, 32);
            this.lbl_Partita.TabIndex = 1;
            this.lbl_Partita.Text = "label1";
            // 
            // btn_acquista
            // 
            this.btn_acquista.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_acquista.BackColor = System.Drawing.Color.DimGray;
            this.btn_acquista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_acquista.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_acquista.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_acquista.Location = new System.Drawing.Point(375, 403);
            this.btn_acquista.Name = "btn_acquista";
            this.btn_acquista.Size = new System.Drawing.Size(198, 69);
            this.btn_acquista.TabIndex = 2;
            this.btn_acquista.Text = "Acquista";
            this.btn_acquista.UseVisualStyleBackColor = false;
            this.btn_acquista.Click += new System.EventHandler(this.btn_acquista_Click);
            // 
            // lbl_settore
            // 
            this.lbl_settore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_settore.AutoSize = true;
            this.lbl_settore.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_settore.Location = new System.Drawing.Point(382, 193);
            this.lbl_settore.Name = "lbl_settore";
            this.lbl_settore.Size = new System.Drawing.Size(177, 32);
            this.lbl_settore.TabIndex = 3;
            this.lbl_settore.Text = "Scegli il settore";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(235, 267);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 28);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbl_Prezzo
            // 
            this.lbl_Prezzo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Prezzo.AutoSize = true;
            this.lbl_Prezzo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Prezzo.Location = new System.Drawing.Point(550, 261);
            this.lbl_Prezzo.Name = "lbl_Prezzo";
            this.lbl_Prezzo.Size = new System.Drawing.Size(78, 32);
            this.lbl_Prezzo.TabIndex = 5;
            this.lbl_Prezzo.Text = "label3";
            // 
            // lbl_Posti
            // 
            this.lbl_Posti.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Posti.AutoSize = true;
            this.lbl_Posti.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Posti.Location = new System.Drawing.Point(401, 345);
            this.lbl_Posti.Name = "lbl_Posti";
            this.lbl_Posti.Size = new System.Drawing.Size(78, 32);
            this.lbl_Posti.TabIndex = 6;
            this.lbl_Posti.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.lbl_info);
            this.panel1.Controls.Add(this.lbl_top);
            this.panel1.Controls.Add(this.lbl_Posti);
            this.panel1.Controls.Add(this.lbl_Partita);
            this.panel1.Controls.Add(this.lbl_Prezzo);
            this.panel1.Controls.Add(this.btn_acquista);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.lbl_settore);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 519);
            this.panel1.TabIndex = 7;
            // 
            // lbl_info
            // 
            this.lbl_info.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_info.Location = new System.Drawing.Point(304, 128);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(78, 32);
            this.lbl_info.TabIndex = 7;
            this.lbl_info.Text = "label1";
            // 
            // acquistaBiglietto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 519);
            this.Controls.Add(this.panel1);
            this.Name = "acquistaBiglietto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acquista Biglietto";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lbl_top;
        private Label lbl_Partita;
        private Button btn_acquista;
        private Label lbl_settore;
        private ComboBox comboBox1;
        private Label lbl_Prezzo;
        private Label lbl_Posti;
        private Panel panel1;
        private Label lbl_info;
    }
}