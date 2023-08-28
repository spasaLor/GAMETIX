using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Globalization;

namespace ClientCS
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }
        private string controlloPwd(string password)
        {

            if (password.Length < 6)
            {
                return "lunghezza";
            }

            bool hasNumber = false;
            foreach (char c in password)
            {
                if (char.IsNumber(c))
                {
                    hasNumber = true;
                    break;
                }
            }
            if (!hasNumber)
            {
                return "numero";
            }

            bool hasSpecialChar = false;
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    hasSpecialChar = true;
                    break;
                }
            }
            if (!hasSpecialChar)
            {
                return"speciale";
            }

            return "ok";

        }
        private async void btn_reg_Click(object sender, EventArgs e)
        {
            string nome = tbx_nome.Text;
            string cognome = tbx_cogn.Text;
            string dataN = tbx_eta.Text;
            string numTel=tbx_tel.Text;
            string mail = tbx_mail.Text;
            string pwd = tbx_pwd.Text;
            string confPwd=tbx_conf.Text;
            string format = "dd/MM/yyyy";
            DateTime date;

            //controllo campi vuoti
            if (nome == String.Empty || cognome == String.Empty || dataN == String.Empty ||mail == String.Empty
                || pwd == String.Empty || confPwd == String.Empty)
            {
                MessageBox.Show("Attenzione: uno o più campi vuoti", "Errore", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            // controllo password e conferma password
            else if (pwd != confPwd)
            {
                MessageBox.Show("Le due Password non coincidono", "Errore", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else if (controlloPwd(pwd).Equals("ok") == false)
            {
                MessageBox.Show("La password deve essere lunga almeno 6 caratteri\nDi cui almeno uno speciale ed almeno un numero (0-9)", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //controllo data di nascita
            else if (DateTime.TryParseExact(dataN, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date)==false)
            {
                MessageBox.Show("Formato data di nascita errato", "Errore",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //controllo mail
            try
            {
                MailAddress address = new MailAddress(mail);
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato email errato\n- Formato corretto: mail@example.com", "Errore", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            try
            {

                var datiUtente = new Dictionary<string, string>
                {
                    {"nome", nome },
                    {"cognome", cognome },
                    {"dataNascita", dataN},
                    {"email", mail },
                    {"telefono", numTel},
                    {"password", pwd }
                };
                var data = new FormUrlEncodedContent(datiUtente);
                var url = "http://localhost:8080/registra_cliente";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                FormUrlEncodedContent content = data;

                HttpResponseMessage response = await client.PostAsync(url, content);

                string responseString = await response.Content.ReadAsStringAsync();

                // controllo utente esistente
                if (responseString.Equals("Email esistente") == true)
                {
                    MessageBox.Show("L'email inserita appartiene ad un account già registrato", "Account già esistente", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if (responseString.Equals("Errore generico") == true)
                {
                    MessageBox.Show("Non è stato possibile creare il tuo account", "Errore",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Il tuo account è stato creato correttamente!", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    new Login().Show();
                    this.Hide();

                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
                MessageBox.Show("Il server è offline in questo momento. Riprova più tardi.","Server error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
