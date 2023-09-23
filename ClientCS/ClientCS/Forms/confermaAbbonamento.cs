using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientCS.Forms
{
    public partial class confermaAbbonamento : Form
    {
        private Utente utenteLoggato;

        struct infoAbbonamento
        {
            public string id_cliente { get; set; }
            public Abbonamento abb { get; set; }
        }
        infoAbbonamento dati; 
        public confermaAbbonamento(Abbonamento abb, Utente user)
        {
            InitializeComponent();
            utenteLoggato = user;
            this.dati = new infoAbbonamento
            {
                id_cliente = utenteLoggato.Id,
                abb = abb
            };
            riempiLabels(abb);
        }

        private void riempiLabels(Abbonamento abb)
        {
            lbl_data.Text = abb.societa;
            label3.Text = "Impianto: " + abb.stadio + ", Settore: " + abb.settore;
            lbl_costo.Text="Prezzo: €" + abb.prezzo;
        }

        private async void btn_conferma_Click(object sender, EventArgs e)
        {

            if ((float)utenteLoggato.Saldo < dati.abb.prezzo)
            {
                MessageBox.Show("Saldo insufficiente. Effettua una ricarica per procedere", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HttpClient client = new HttpClient();
            var url = "http://localhost:8080/inserisci_abbonamento";
            var json = JsonSerializer.Serialize(dati);
            var datiPost = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, datiPost);
            var dataResp = await response.Content.ReadAsStringAsync();

            if (dataResp.Equals("Duplicato"))
            {
                MessageBox.Show("Hai già un abbonamento per questa società", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("L'acquisto è andato a buon fine\nTroverai l'abbonamento nella sezione 'I miei Acquisti'", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
