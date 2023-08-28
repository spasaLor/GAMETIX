namespace ClientCS
{
    public class Biglietto : Titolo{
        public string partita {get;set;}
        public string data { get;set;}
        public string ora { get;set;}
        public int id_partita { get; set; }

        public Biglietto(int id_partita, string partita, string data, string ora,float prezzo,string stadio, string settore) : base(prezzo,stadio,settore)
        {
            this.id_partita = id_partita;
            this.partita=partita;
            this.data=data;
            this.ora=ora;
        }

    }
}