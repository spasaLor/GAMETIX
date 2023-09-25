using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClientCS.Forms
{
    public partial class acquistaAbbonamento : Form
    {
        System.Windows.Forms.ListView listViewAbbonati;
        private Utente utenteLoggato;
        struct AbbDisponibili
        {
            public string societa;
            public string settore;
            public string stadio;
            public int totPosti;
            public float costo;
        }

        public acquistaAbbonamento(Utente user)
        {
            InitializeComponent();
            utenteLoggato = user;
            listViewAbbonati = new System.Windows.Forms.ListView();
            listViewAbbonati.ItemActivate+= listViewAbbonati_ItemActivate;
        }

        //Popola la listview
        private async void riempiLista(string societa, System.Windows.Forms.ListView listView_abb)
        {
            var url = "http://localhost:8080/get_abbonamenti_disponibili";
            var client = new HttpClient();

            var dati = new Dictionary<string, string>
                        {
                            {"societa",societa}
                        };
            var datiPost = new FormUrlEncodedContent(dati);
            var response = await client.PostAsync(url, datiPost);

            string res = await response.Content.ReadAsStringAsync();
            List<AbbDisponibili> listaAbb = JsonConvert.DeserializeObject<List<AbbDisponibili>>(res);

            if (listaAbb != null)
            {
                listView_abb.View = View.Details;
                listView_abb.Scrollable = true;
                listView_abb.FullRowSelect = true;

                listView_abb.Columns.Add("Societa", 200, HorizontalAlignment.Left);
                listView_abb.Columns.Add("Settore", 150, HorizontalAlignment.Left);
                listView_abb.Columns.Add("Stadio", 200, HorizontalAlignment.Left);
                listView_abb.Columns.Add("Posti Disponibili", 150, HorizontalAlignment.Left);
                listView_abb.Columns.Add("Costo", 150, HorizontalAlignment.Left);

                foreach (AbbDisponibili abb in listaAbb)
                {
                    ListViewItem item = new ListViewItem(abb.societa);
                    item.SubItems.Add(abb.settore);
                    item.SubItems.Add(abb.stadio);
                    item.SubItems.Add(abb.totPosti.ToString());
                    item.SubItems.Add(abb.costo.ToString());

                    listView_abb.Items.Add(item);

                    this.Controls.Add(listView_abb);
                }
            }
            else
            {
                MessageBox.Show("Nessuna società corrisponde alla ricerca, Riprova", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Event listener
        private void btn_cerca_Click(object sender, EventArgs e)
        {
            listViewAbbonati.Items.Clear();
            listViewAbbonati.BackColor= SystemColors.ControlLight;
            listViewAbbonati.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            riempiLista(tbx_societa.Text,listViewAbbonati);
            listViewAbbonati.Dock= DockStyle.Fill;
            this.Controls.Add(listViewAbbonati);

            foreach (Control control in this.Controls)
            {
                if (control != listViewAbbonati)
                {
                    control.Visible = false;
                }
            }
        }

        private void listViewAbbonati_ItemActivate(object sender, EventArgs e)
        {
            var abbSelezionato = listViewAbbonati.SelectedItems[0];
            var infoAbb = new Abbonamento(abbSelezionato.Text, abbSelezionato.SubItems[2].Text, abbSelezionato.SubItems[1].Text,
                          float.Parse(abbSelezionato.SubItems[4].Text));

            confermaAbbonamento formConferma = new confermaAbbonamento(infoAbb, utenteLoggato);
            formConferma.Show();

        }
    }
}
