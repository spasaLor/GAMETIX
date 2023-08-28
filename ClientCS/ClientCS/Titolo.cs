namespace ClientCS
{
    public class Titolo{
        public float codice { get; set; }
        public float prezzo {get;set;}
        public string stadio { get;set;}
        public string settore {get;set;}

        public Titolo (float prezzo,string stadio, string settore){
            this.prezzo=prezzo;
            this.stadio=stadio;
            this.settore=settore;
        }
    
    }
}