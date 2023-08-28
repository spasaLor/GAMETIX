namespace ClientCS.Forms
{
    partial class acquistaAbbonamento
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
            this.btn_cerca = new System.Windows.Forms.Button();
            this.tbx_societa = new System.Windows.Forms.TextBox();
            this.pnl_child = new System.Windows.Forms.Panel();
            this.pnl_child.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(381, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ricerca per società:";
            // 
            // btn_cerca
            // 
            this.btn_cerca.BackColor = System.Drawing.Color.DimGray;
            this.btn_cerca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_cerca.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_cerca.Location = new System.Drawing.Point(368, 267);
            this.btn_cerca.Name = "btn_cerca";
            this.btn_cerca.Size = new System.Drawing.Size(230, 55);
            this.btn_cerca.TabIndex = 1;
            this.btn_cerca.Text = "Cerca";
            this.btn_cerca.UseVisualStyleBackColor = false;
            this.btn_cerca.Click += new System.EventHandler(this.btn_cerca_Click);
            // 
            // tbx_societa
            // 
            this.tbx_societa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbx_societa.Location = new System.Drawing.Point(368, 200);
            this.tbx_societa.Name = "tbx_societa";
            this.tbx_societa.Size = new System.Drawing.Size(230, 34);
            this.tbx_societa.TabIndex = 2;
            // 
            // pnl_child
            // 
            this.pnl_child.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnl_child.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnl_child.Controls.Add(this.label1);
            this.pnl_child.Controls.Add(this.btn_cerca);
            this.pnl_child.Controls.Add(this.tbx_societa);
            this.pnl_child.Location = new System.Drawing.Point(0, 0);
            this.pnl_child.Name = "pnl_child";
            this.pnl_child.Size = new System.Drawing.Size(982, 513);
            this.pnl_child.TabIndex = 3;
            // 
            // acquistaAbbonamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(982, 513);
            this.Controls.Add(this.pnl_child);
            this.Name = "acquistaAbbonamento";
            this.Text = "Acquista Abbonamento";
            this.pnl_child.ResumeLayout(false);
            this.pnl_child.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Button btn_cerca;
        private TextBox tbx_societa;
        private Panel pnl_child;
    }
}