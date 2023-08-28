namespace ClientCS
{
    public class Utente{
        public string nome {get;set;}
        public string cognome {get;set;}
        public string id { get;set;}


        public Utente(string nome, string cognome, string id)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.id = id;
        }
    }
}