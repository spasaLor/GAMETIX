namespace ClientCS.Forms
{
    partial class mieiAcquisti
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
            this.listView_acquisti = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView_abbonamenti = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_acquisti
            // 
            this.listView_acquisti.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listView_acquisti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_acquisti.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView_acquisti.Location = new System.Drawing.Point(3, 23);
            this.listView_acquisti.Name = "listView_acquisti";
            this.listView_acquisti.Size = new System.Drawing.Size(1024, 237);
            this.listView_acquisti.TabIndex = 0;
            this.listView_acquisti.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView_acquisti);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1030, 263);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Biglietti";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView_abbonamenti);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1030, 313);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Abbonamenti";
            // 
            // listView_abbonamenti
            // 
            this.listView_abbonamenti.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listView_abbonamenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_abbonamenti.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView_abbonamenti.Location = new System.Drawing.Point(3, 23);
            this.listView_abbonamenti.Name = "listView_abbonamenti";
            this.listView_abbonamenti.Size = new System.Drawing.Size(1024, 287);
            this.listView_abbonamenti.TabIndex = 0;
            this.listView_abbonamenti.UseCompatibleStateImageBehavior = false;
            // 
            // mieiAcquisti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1030, 547);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "mieiAcquisti";
            this.Text = "I miei Acquisti";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView_acquisti;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListView listView_abbonamenti;
    }
}