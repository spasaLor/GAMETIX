namespace ClientCS
{
    public class Utente{
        public string Nome {get;set;}
        public string Cognome {get;set;}
        public string Id { get;set;}
        public decimal Saldo{get;set;}
        public Utente(string nome, string cognome, string id,decimal saldo)
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.Id = id;
            this.Saldo = saldo;
        }
    }
}