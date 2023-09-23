using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ClientCS.Forms
{
    public partial class Ricarica : Form
    {
        private Utente utenteLoggato;
        public Ricarica(Utente user)
        {
            InitializeComponent();
            this.utenteLoggato = user;
            riempiComboBox();
        }

        public void riempiComboBox() {
            for(int i = 0; i <= 12; i++)
            {
                comboBox1.Items.Add(i.ToString("D2"));
            }

            for (int i =2022; i<=2032; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }
        
        }

        private string controlloCampi()
        {
            

            if (string.IsNullOrEmpty(tbx_importo.Text) || string.IsNullOrEmpty(tbx_carta.Text) || string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) 
                || string.IsNullOrEmpty(comboBox2.SelectedItem.ToString()) || string.IsNullOrEmpty(textBox1.Text))
            {
                return "Attenzione uno o più campi vuoti";
            }
            if(textBox1.Text.Length != 3)
            {
                return "Formato CVV errato";
            }
            return "ok";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string check = controlloCampi();
            if (check.Equals("ok"))
            {
                HttpClient client = new HttpClient();
                var url = "http://localhost:8080/ricarica";

                var info = new
                {
                    id = float.Parse(utenteLoggato.Id),
                    importo = float.Parse(tbx_importo.Text)
                };

                string jsonData = JsonSerializer.Serialize(info);
                var datiPost = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, datiPost);
                var dataResp = await response.Content.ReadAsStringAsync();
                if (dataResp.ToString().Equals("ok"))
                {
                    MessageBox.Show("La ricarica è avvenuta con successo", "Successo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(check, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }
        
    }
}
