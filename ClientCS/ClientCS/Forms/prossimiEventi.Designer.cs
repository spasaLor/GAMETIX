﻿namespace ClientCS.Forms
{
    partial class prossimiEventi
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
            this.listViewPartite = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewPartite
            // 
            this.listViewPartite.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listViewPartite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPartite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewPartite.Location = new System.Drawing.Point(0, 0);
            this.listViewPartite.Name = "listViewPartite";
            this.listViewPartite.Size = new System.Drawing.Size(1012, 522);
            this.listViewPartite.TabIndex = 0;
            this.listViewPartite.UseCompatibleStateImageBehavior = false;
            this.listViewPartite.ItemActivate += new System.EventHandler(this.listViewPartite_ItemActivate);
            // 
            // prossimiEventi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 522);
            this.Controls.Add(this.listViewPartite);
            this.Name = "prossimiEventi";
            this.Text = "Prossimi Eventi";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listViewPartite;
    }
}