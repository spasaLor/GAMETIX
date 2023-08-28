using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCS
{
    public class Partita
    {
        public int id { get; set; }
        public string sport { get; set; }
        public DateOnly data { get; set; }
        public string ora { get; set; }
         
        public string squadra_casa { get; set; }
        public string squadra_trasferta { get; set; }
        public string tipologia { get; set; }
         
        public string luogo { get; set; }
        public float prezzo_settore_1 {get;set;}
        public float prezzo_settore_2 {get;set;}
        public float prezzo_settore_3 {get;set;}
        public float prezzo_settore_4 { get; set;}

        public Partita(int id, DateOnly data, string ora, string squadra_casa, string squadra_trasferta, string tipologia, string luogo, float prezzo_settore_1, float prezzo_settore_2, float prezzo_settore_3, float prezzo_settore_4)
        {
            this.id = id;
            this.data = data;
            this.ora = ora;
            this.squadra_casa = squadra_casa;
            this.squadra_trasferta = squadra_trasferta;
            this.tipologia = tipologia;
            this.luogo = luogo;
            this.prezzo_settore_1 = prezzo_settore_1;
            this.prezzo_settore_2 = prezzo_settore_2;
            this.prezzo_settore_3 = prezzo_settore_3;
            this.prezzo_settore_4 = prezzo_settore_4;
        }
    }
}
