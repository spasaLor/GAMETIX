using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ClientCS.Forms
{
    public partial class prossimiEventi : Form
    {
        List<Partita> listaPartite;
        public prossimiEventi()
        {
            InitializeComponent();
            getPartite();
        }
        public async void  getPartite()
        {
                       
            var url = "http://localhost:8080/get_partite";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            string res =await response.Content.ReadAsStringAsync();
            listaPartite= JsonConvert.DeserializeObject<List<Partita>>(res);

            if (listaPartite != null)
            {
                listViewPartite.View = View.Details;
                listViewPartite.FullRowSelect = true;
                listViewPartite.Columns.Add("Sport", 70, HorizontalAlignment.Left);
                listViewPartite.Columns.Add("Squadra Casa", 160, HorizontalAlignment.Left);
                listViewPartite.Columns.Add("Squadra Ospite", 160, HorizontalAlignment.Left);
                listViewPartite.Columns.Add("Data", 150, HorizontalAlignment.Left);
                listViewPartite.Columns.Add("Ora", 100, HorizontalAlignment.Left);
                listViewPartite.Columns.Add("Tipologia", 150, HorizontalAlignment.Left);
                listViewPartite.Columns.Add("Stadio", 200, HorizontalAlignment.Left);

                foreach (Partita pa in listaPartite)
                {
                    ListViewItem item = new ListViewItem(pa.sport);
                    item.SubItems.Add(pa.squadra_casa);
                    item.SubItems.Add(pa.squadra_trasferta);
                    item.SubItems.Add(pa.data.ToString());
                    item.SubItems.Add(pa.ora);
                    item.SubItems.Add(pa.tipologia);
                    item.SubItems.Add(pa.luogo);
              
                    listViewPartite.Items.Add(item);
                    item.SubItems.Add(pa.prezzo_settore_1.ToString());
                    item.SubItems.Add(pa.prezzo_settore_2.ToString());
                    item.SubItems.Add(pa.prezzo_settore_3.ToString());
                    item.SubItems.Add(pa.prezzo_settore_4.ToString());
                    item.SubItems.Add(pa.id.ToString());
                    this.Controls.Add(listViewPartite);
                }
            }
        }

        private async void listViewPartite_ItemActivate(object sender, EventArgs e)
        {
            List<string> listaSettori;

            var scelta = listViewPartite.SelectedItems[0];
            var partitaSelezionata = new Partita(int.Parse(scelta.SubItems[11].Text), DateOnly.Parse(scelta.SubItems[3].Text), scelta.SubItems[4].Text,
                        scelta.SubItems[1].Text, scelta.SubItems[2].Text, scelta.SubItems[5].Text, scelta.SubItems[6].Text,
                        float.Parse(scelta.SubItems[7].Text), float.Parse(scelta.SubItems[8].Text), float.Parse(scelta.SubItems[9].Text),
                        float.Parse(scelta.SubItems[10].Text));
 
            HttpClient client = new HttpClient();
            var url = "http://localhost:8080/settori_stadio";
            var dati = new Dictionary<string, string>
                        {
                            {"societa",partitaSelezionata.squadra_casa}
                        };

            var datiPost = new FormUrlEncodedContent(dati);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            var response = await client.PostAsync(url, datiPost);
            var dataResp = await response.Content.ReadAsStringAsync();

            listaSettori = JsonConvert.DeserializeObject<List<string>>(dataResp);

            var prezziSettori = new Dictionary<string, float>
            {
                {listaSettori[0],partitaSelezionata.prezzo_settore_1 },
                {listaSettori[1],partitaSelezionata.prezzo_settore_2 },
                {listaSettori[2],partitaSelezionata.prezzo_settore_3 },
                {listaSettori[3],partitaSelezionata.prezzo_settore_4 },
            };
    
            acquistaBiglietto formBiglietto=new acquistaBiglietto(partitaSelezionata,prezziSettori);
            formBiglietto.Show();

        }
    }
}
