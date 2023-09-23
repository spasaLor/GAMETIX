namespace ClientCS.Forms
{
    partial class Ricarica
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
            this.tbx_importo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_carta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(302, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Importo";
            // 
            // tbx_importo
            // 
            this.tbx_importo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbx_importo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbx_importo.Location = new System.Drawing.Point(534, 94);
            this.tbx_importo.Name = "tbx_importo";
            this.tbx_importo.Size = new System.Drawing.Size(190, 32);
            this.tbx_importo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(268, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero Carta";
            // 
            // tbx_carta
            // 
            this.tbx_carta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbx_carta.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbx_carta.Location = new System.Drawing.Point(534, 172);
            this.tbx_carta.Name = "tbx_carta";
            this.tbx_carta.Size = new System.Drawing.Size(190, 32);
            this.tbx_carta.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(289, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 35);
            this.label3.TabIndex = 4;
            this.label3.Text = "Scadenza";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(534, 319);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 32);
            this.textBox1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(315, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 35);
            this.label4.TabIndex = 6;
            this.label4.Text = "CVV";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(533, 250);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(53, 28);
            this.comboBox1.TabIndex = 7;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(670, 250);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(53, 28);
            this.comboBox2.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(387, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 45);
            this.button1.TabIndex = 9;
            this.button1.Text = "Ricarica";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tbx_importo);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbx_carta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 515);
            this.panel1.TabIndex = 10;
            // 
            // Ricarica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(982, 513);
            this.Controls.Add(this.panel1);
            this.Name = "Ricarica";
            this.Text = "Ricarica";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox tbx_importo;
        private Label label2;
        private TextBox tbx_carta;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button1;
        private Panel panel1;
    }
}