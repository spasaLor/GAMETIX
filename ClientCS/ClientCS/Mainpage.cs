using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientCS
{
    public partial class Mainpage : Form
    {
        public Form formCorrente;
        public Mainpage()
        {
            InitializeComponent();
            this.Text = string.Empty;
            lbl_utente.Text = Login.utenteLoggato.nome;
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (formCorrente != null)
                formCorrente.Close();
            formCorrente = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnl_children.Controls.Add(childForm);
            this.pnl_children.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbl_home.Text = childForm.Text;
        }
        
        private void Reset()
        {
            lbl_home.Text = "HOME";
            pnl_Title.BackColor = Color.DarkGray;
            pnl_Logo.BackColor = Color.Gray;
            pnl_side.Height = btn_Home.Height;
            pnl_side.Top = btn_Home.Top;

        }

        private void btn_closeChild_Click(object sender, EventArgs e)
        {
            if (formCorrente != null)
                formCorrente.Close();
            
            Reset();
        }


        private void btn_Abbonamento_Click(object sender, EventArgs e)
        {
            pnl_side.Height = btn_Abbonamento.Height;
            pnl_side.Top = btn_Abbonamento.Top;
            OpenChildForm(new Forms.acquistaAbbonamento(), sender);
        }

        private void btn_proxEvent_Click(object sender, EventArgs e)
        {
            pnl_side.Height = btn_proxEvent.Height;
            pnl_side.Top = btn_proxEvent.Top;
            OpenChildForm(new Forms.prossimiEventi(), sender);
        }

        private void btn_acquisti_Click(object sender, EventArgs e)
        {
            pnl_side.Height = btn_acquisti.Height;
            pnl_side.Top = btn_acquisti.Top;
            OpenChildForm(new Forms.mieiAcquisti(), sender);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            if (formCorrente != null)
                formCorrente.Close();
            Reset();
            
        }

    }
}
