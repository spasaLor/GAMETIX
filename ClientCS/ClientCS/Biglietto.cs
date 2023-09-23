namespace ClientCS
{
    public class Biglietto : Titolo{
        public string data { get;set;}
        public string casa { get; set; }
        public string trasferta { get; set; }
        public string ora { get;set;}
        public int id_partita { get; set; }

        public Biglietto(int id_partita, string casa,string trasferta,string data, string ora,float prezzo,string stadio, string settore) : base(prezzo,stadio,settore)
        {
            this.id_partita = id_partita;
            this.casa = casa;
            this.trasferta= trasferta;
            this.data=data;
            this.ora=ora;
        }

    }
}