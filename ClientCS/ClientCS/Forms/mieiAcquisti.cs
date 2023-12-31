﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientCS.Forms
{
    public partial class mieiAcquisti : Form
    {
        List<Biglietto> listaBiglietti;
        List<Abbonamento> listaAbbonamenti;
        Utente utenteLoggato;
        HttpClient client;

        public mieiAcquisti(Utente user)
        {
            InitializeComponent();
            utenteLoggato = user;
            client=new HttpClient();
            listaBiglietti = new List<Biglietto>();
            listaAbbonamenti = new List<Abbonamento>();
            riempiBiglietti();
            riempiAbbonamenti();
        }

        //Popola la listview dei biglietti
        public async void riempiBiglietti()
        {
            var url = "http://localhost:8080/get_biglietti";
            var dati = new Dictionary<string, string>
                        {
                            {"id_cliente",utenteLoggato.Id}
                        };

            var datiPost = new FormUrlEncodedContent(dati);
            var response = await client.PostAsync(url, datiPost);
            string res = await response.Content.ReadAsStringAsync();
            listaBiglietti = JsonConvert.DeserializeObject<List<Biglietto>>(res);

            if (listaBiglietti != null)
            {
                listView_acquisti.View = View.Details;
                listView_acquisti.FullRowSelect = true;

                listView_acquisti.Columns.Add("Codice", 90, HorizontalAlignment.Left);
                listView_acquisti.Columns.Add("Partita", 250, HorizontalAlignment.Left);
                listView_acquisti.Columns.Add("Data", 100, HorizontalAlignment.Left);
                listView_acquisti.Columns.Add("Ora", 70, HorizontalAlignment.Left);
                listView_acquisti.Columns.Add("Stadio", 150, HorizontalAlignment.Left);
                listView_acquisti.Columns.Add("Settore", 110, HorizontalAlignment.Left);
                listView_acquisti.Columns.Add("Prezzo", 70, HorizontalAlignment.Left);

                foreach (Biglietto bi in listaBiglietti)
                {
                    ListViewItem item = new ListViewItem(bi.codice.ToString());
                    item.SubItems.Add(bi.casa + " vs. " + bi.trasferta);
                    item.SubItems.Add(bi.data);
                    item.SubItems.Add(bi.ora);
                    item.SubItems.Add(bi.stadio);
                    item.SubItems.Add(bi.settore);
                    item.SubItems.Add("€ " + bi.prezzo.ToString("0.00"));

                    listView_acquisti.Items.Add(item);

                    this.groupBox1.Controls.Add(listView_acquisti);
                }
            }
        }
        //Popola la listview degli abbonamenti
        public async void riempiAbbonamenti()
        {
            var url = "http://localhost:8080/get_abbonamenti";
            var dati = new Dictionary<string, string>
                        {
                            {"id_cliente",utenteLoggato.Id}
                        };

            var datiPost = new FormUrlEncodedContent(dati);
            var responseAbb = await client.PostAsync(url, datiPost);
            var resAbb = await responseAbb.Content.ReadAsStringAsync();
            listaAbbonamenti = JsonConvert.DeserializeObject<List<Abbonamento>>(resAbb);

            if (listaAbbonamenti != null)
            {
                listView_abbonamenti.View = View.Details;
                listView_abbonamenti.FullRowSelect = true;

                listView_abbonamenti.Columns.Add("Codice", 90, HorizontalAlignment.Left);
                listView_abbonamenti.Columns.Add("Societa", 150, HorizontalAlignment.Left);
                listView_abbonamenti.Columns.Add("Stadio", 200, HorizontalAlignment.Left);
                listView_abbonamenti.Columns.Add("Settore", 170, HorizontalAlignment.Left);
                listView_abbonamenti.Columns.Add("Prezzo", 70, HorizontalAlignment.Left);

                foreach (Abbonamento abb in listaAbbonamenti)
                {
                    ListViewItem item = new ListViewItem(abb.codice.ToString());
                    item.SubItems.Add(abb.societa);
                    item.SubItems.Add(abb.stadio);
                    item.SubItems.Add(abb.settore);
                    item.SubItems.Add("€ " + abb.prezzo.ToString("0.00"));

                    listView_abbonamenti.Items.Add(item);

                    this.groupBox2.Controls.Add(listView_abbonamenti);
                }
            }
        }
    }
}
