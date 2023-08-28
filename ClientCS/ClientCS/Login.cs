using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientCS
{
    public partial class Login : Form
    {
        public static Utente utenteLoggato;
        public Login()
        {
            InitializeComponent();
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Login");

            string email = tbx_mail.Text;
            string pass = tbx_pwd.Text;

            if (email == String.Empty || pass == String.Empty)
            {
                MessageBox.Show("Attenzione: uno o più campi vuoti", "Avviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var datiUtente = new Dictionary<string, string>
                {
                    {"email", email },
                    {"password", pass }
                };

                var data = new FormUrlEncodedContent(datiUtente);
                var url = "http://localhost:8080/login_cliente";

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                HttpResponseMessage response = await client.PostAsync(url, data);
                string dataString = await response.Content.ReadAsStringAsync();
                string[] infoUtente = (string[])JsonConvert.DeserializeObject(dataString, typeof(string[]));
            
               
                if (infoUtente[0].Equals("Credenziali"))
                {
                    MessageBox.Show("Credenziali errate","Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (infoUtente[0].Equals("Errore generico"))
                {
                    MessageBox.Show("Qualcosa è andato storto", "Errore",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                else
                {
                    utenteLoggato = new Utente(infoUtente[1], infoUtente[2], infoUtente[0]);
                    new Mainpage().Show();
                    this.Hide();
                }

            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
                MessageBox.Show("Errore di connessione al server.","Server error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void btn_reg_Click(object sender, EventArgs e)
        {
            new Reg().Show();
            this.Hide();
        }

        private void cbx_mostraPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_mostraPwd.Checked)
            {
                tbx_pwd.PasswordChar = '\0';
            }
            else
            {
                tbx_pwd.PasswordChar = '•';
            }
        }
    }
}
