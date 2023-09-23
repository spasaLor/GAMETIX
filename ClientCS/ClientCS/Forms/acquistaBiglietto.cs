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
    public partial class acquistaBiglietto : Form
    {
        Dictionary<string, float> prezziSettori;
        Partita infoPartita;
        Utente utenteLoggato;
        struct infoBiglietto
        {
            public string id_cliente { get; set; }
            public Biglietto big { get; set; }
        }

        public acquistaBiglietto(Utente user,Partita infoPartita,Dictionary<string,float> prezziSettori)
        {
            InitializeComponent();
            this.prezziSettori = prezziSettori;
            this.infoPartita = infoPartita;
            utenteLoggato= user;
            riempiLabels(infoPartita.squadra_casa, infoPartita.squadra_trasferta, infoPartita.data.ToString(),infoPartita.ora,
                infoPartita.tipologia, prezziSettori.Keys.ToList());
        }
        
        private void riempiLabels(string casa, string trasferta, string data, string ora, string tipo, List<string> listaSettori)
        {
            lbl_Partita.Text = casa + " vs. " + trasferta;
            lbl_info.Text = "Data: " + data + " Orario: " + ora;
            comboBox1.DataSource = listaSettori;
        }

        private async void postiSettore(string nomeSettore,string nomeStadio,string tipologia)
        {
            HttpClient client = new HttpClient();
            var url = "http://localhost:8080/get_posti_settore";
            var dati = new Dictionary<string, string>
                        {
                            {"settore",nomeSettore},
                            {"stadio",nomeStadio},
                            {"tipo",tipologia }
                        };

            var datiPost = new FormUrlEncodedContent(dati);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            var response = await client.PostAsync(url, datiPost);
            var dataResp = await response.Content.ReadAsStringAsync();
            lbl_Posti.Text= "Posti liberi: " + Int32.Parse(dataResp);
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string se = comboBox1.SelectedItem.ToString();
            lbl_Prezzo.Text = "Prezzo: € " + prezziSettori[se];
            postiSettore(se, infoPartita.luogo, infoPartita.tipologia);
        }

        private async void btn_acquista_Click(object sender, EventArgs e)
        {
           if(prezziSettori[comboBox1.SelectedItem.ToString()] > (float)utenteLoggato.Saldo)
            {
                MessageBox.Show("Saldo insufficiente. Effettua una ricarica per procedere", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           if (lbl_Posti.Text.Equals("Posti disponibili: 0")){
                MessageBox.Show("Non ci sono più posti disponibili in questo settore. Prova a cambiare settore", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HttpClient client = new HttpClient();
            var url = "http://localhost:8080/conferma_biglietto";
            var biglietto = new Biglietto(infoPartita.id,infoPartita.squadra_casa,infoPartita.squadra_trasferta,infoPartita.data.ToString(), infoPartita.ora,
                            prezziSettori[comboBox1.SelectedItem.ToString()], infoPartita.luogo, comboBox1.SelectedItem.ToString());

            var info = new infoBiglietto
            {
                id_cliente = utenteLoggato.Id,
                big = biglietto
            };

            var json = JsonSerializer.Serialize(info);
            var datiPost = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, datiPost);
            var dataResp = await response.Content.ReadAsStringAsync();

            if(dataResp.ToString().Equals("Duplicato")){
                MessageBox.Show("Hai già acquistato un biglietto per questo evento\n Lo puoi trovare nella sezione 'I miei Acquisti'",
                    "Errore", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (dataResp.ToString().Equals("Abbonato"))
            {
                MessageBox.Show("Sei abbonato a questo settore, non puoi acquistare un biglietto",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("L'acquisto è andato a buon fine\nTroverai il biglietto nella sezione 'I miei acquisti'", "Successo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

    }
}
