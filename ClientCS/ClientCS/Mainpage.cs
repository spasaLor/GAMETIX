using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace ClientCS
{
    public partial class Mainpage : Form
    {
        private Form formCorrente;
        private Utente utenteLoggato;
        public Mainpage(Utente user)
        {
            InitializeComponent();
            this.Text = string.Empty;
            utenteLoggato = user;
            lbl_utente.Text = utenteLoggato.Nome;
            aggiornaSaldo(utenteLoggato.Id);
        }

        public async void aggiornaSaldo(string id)
        {
            HttpClient client = new HttpClient();
            var url = "http://localhost:8080/get_saldo";

            var info = new
            {
                id = int.Parse(utenteLoggato.Id),
            };

            string jsonData = JsonSerializer.Serialize(info);
            var datiPost = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, datiPost);
            var json = await response.Content.ReadAsStringAsync();

            RespSaldo saldoResponse = JsonSerializer.Deserialize<RespSaldo>(json);

            double saldo = saldoResponse.saldo;
            string formatSaldo = saldo.ToString("0.00");
            utenteLoggato.Saldo = (decimal)saldo;
            lbl_saldo.Text ="SALDO: €"+formatSaldo;
        }

        //Gestore apertura form
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

        private void btn_Home_Click(object sender, EventArgs e)
        {
            if (formCorrente != null)
                formCorrente.Close();
            Reset();
            aggiornaSaldo(utenteLoggato.Id);
        }

        private void btn_Abbonamento_Click(object sender, EventArgs e)
        {
            pnl_side.Height = btn_Abbonamento.Height;
            pnl_side.Top = btn_Abbonamento.Top;
            OpenChildForm(new Forms.acquistaAbbonamento(utenteLoggato), sender);
        }

        private void btn_proxEvent_Click(object sender, EventArgs e)
        {
            pnl_side.Height = btn_proxEvent.Height;
            pnl_side.Top = btn_proxEvent.Top;
            OpenChildForm(new Forms.prossimiEventi(utenteLoggato), sender);
        }

        private void btn_acquisti_Click(object sender, EventArgs e)
        {
            pnl_side.Height = btn_acquisti.Height;
            pnl_side.Top = btn_acquisti.Top;
            OpenChildForm(new Forms.mieiAcquisti(utenteLoggato), sender);
        }

        private void btn_ricarica_click(object sender, EventArgs e)
        {
            pnl_side.Height = btn_ricarica.Height;
            pnl_side.Top = btn_ricarica.Top;
            OpenChildForm(new Forms.Ricarica(utenteLoggato), sender);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
