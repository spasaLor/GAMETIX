namespace ClientCS
{
    public class Abbonamento : Titolo{

        public string societa {get;set;}

        public Abbonamento(string societa, string stadio,string settore, float prezzo) : base(prezzo,stadio,settore)
        {
            this.societa= societa;
        }

    }
}