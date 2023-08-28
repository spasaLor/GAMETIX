namespace ClientCS.Forms
{
    partial class confermaAbbonamento
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_data = new System.Windows.Forms.Label();
            this.lbl_costo = new System.Windows.Forms.Label();
            this.btn_conferma = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(250, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Abbonamento selezionato:";
            // 
            // lbl_data
            // 
            this.lbl_data.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_data.AutoSize = true;
            this.lbl_data.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_data.Location = new System.Drawing.Point(312, 90);
            this.lbl_data.Name = "lbl_data";
            this.lbl_data.Size = new System.Drawing.Size(78, 32);
            this.lbl_data.TabIndex = 1;
            this.lbl_data.Text = "label2";
            // 
            // lbl_costo
            // 
            this.lbl_costo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_costo.AutoSize = true;
            this.lbl_costo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_costo.Location = new System.Drawing.Point(341, 215);
            this.lbl_costo.Name = "lbl_costo";
            this.lbl_costo.Size = new System.Drawing.Size(65, 28);
            this.lbl_costo.TabIndex = 2;
            this.lbl_costo.Text = "label2";
            // 
            // btn_conferma
            // 
            this.btn_conferma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_conferma.BackColor = System.Drawing.Color.DimGray;
            this.btn_conferma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_conferma.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_conferma.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_conferma.Location = new System.Drawing.Point(287, 273);
            this.btn_conferma.Name = "btn_conferma";
            this.btn_conferma.Size = new System.Drawing.Size(196, 50);
            this.btn_conferma.TabIndex = 3;
            this.btn_conferma.Text = "Conferma";
            this.btn_conferma.UseVisualStyleBackColor = false;
            this.btn_conferma.Click += new System.EventHandler(this.btn_conferma_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "* valido esclusivamente per le partite di Campionato";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(227, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "label2";
            // 
            // confermaAbbonamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_conferma);
            this.Controls.Add(this.lbl_costo);
            this.Controls.Add(this.lbl_data);
            this.Controls.Add(this.label1);
            this.Name = "confermaAbbonamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "confermaAbbonamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label lbl_data;
        private Label lbl_costo;
        private Button btn_conferma;
        private Label label2;
        private Label label3;
    }
}