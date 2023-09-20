package main

import (
	"crypto/sha256"
	"database/sql"
	"fmt"
	"log"
	"strconv"
	"strings"
	"time"

	_ "github.com/go-sql-driver/mysql"
)

type Societa struct {
	Id       int
	Nome     string
	Localita string
	Sport    string
}

type Impiegato struct {
	Id       int
	Societa  string
	Nome     string
	Cognome  string
	Email    string
	Password string
}

type Partita struct {
	Id                int
	Sport             string
	Data              string
	Ora               string
	Squadra_casa      string
	Squadra_trasferta string
	Tipologia         string
	Luogo             string
	Prezzo_settore_1  float32
	Prezzo_settore_2  float32
	Prezzo_settore_3  float32
	Prezzo_settore_4  float32
}

type Biglietto struct {
	Codice  string
	Partita string
	Data    string
	Ora     string
	Prezzo  float32
	Stadio  string
	Settore string
}

type Abbonamento struct {
	Codice  string
	Societa string
	Stadio  string
	Settore string
	Prezzo  float32
}

type AbbDisponibile struct {
	Societa  string
	Settore  string
	Stadio   string
	TotPosti int
	Costo    float32
}

type InfoBigliettiVenduti struct {
	Tot_Biglietti int
	Tot_Incasso   float32
}

func startDB() *sql.DB {

	db, err := sql.Open("mysql", "root:Lorenzo99@tcp(localhost:3306)/gametix")

	if err != nil {
		fmt.Println("Controllare la funzione startDB del file databaseManagement per essere sicuri" +
			" di aver inserito il correttamente id,password,hostname e numero di porta")
		log.Fatal(err)
	}

	fmt.Println("Database avviato con successo")
	return db
}

func queryRegImpiegato(db *sql.DB, societa, nome, cognome, email, pwd string) string {
	fmt.Println("Query Registrazione Impiegato")
	res1, err1 := db.Query("SELECT * FROM impiegato WHERE email=" + "'" + email + "'")
	if err1 != nil {
		fmt.Println(err1)
		return "Errore generico"
	}
	if res1.Next() == true {
		return "Email esistente"
	}
	defer res1.Close()

	password := []byte(pwd)
	hashedPassword := sha256.Sum256(password)

	query1 := fmt.Sprintf("INSERT INTO impiegato VALUES (default, '%s', '%s', '%s', '%s', '%x')", societa, nome, cognome, email, hashedPassword)
	res2, err2 := db.Query(query1)

	if err2 != nil {
		fmt.Println(err2)
		return "Errore societa"
	}
	defer res2.Close()

	return "successo"
}

func queryLogImpiegato(db *sql.DB, email, pwd string) string {
	fmt.Println("Query Login Impiegato")
	password := []byte(pwd)
	hashedPassword := sha256.Sum256(password)

	query := fmt.Sprintf("SELECT * FROM impiegato WHERE email = '%s' AND password = '%x'", email, hashedPassword)
	res, err := db.Query(query)

	if err != nil {
		return "Errore Generico"
	}
	var imp Impiegato

	if res.Next() == true {
		res.Scan(&imp.Id, &imp.Societa, &imp.Nome, &imp.Cognome, &imp.Email, &imp.Password)
	}

	if imp.Id == 0 {
		return "Credenziali errate"
	}

	return imp.Societa
}

func querySettoriStadio(db *sql.DB, societa string) []string {
	fmt.Println("Query Caricamento settori")
	var settori []string

	query := "SELECT nome FROM stadio where proprietario LIKE ?"
	soc := societa + "%"
	res, err := db.Query(query, soc)

	if err != nil {
		fmt.Println(err)
		return append(settori, "Errore Generico")
	}
	defer res.Close()

	var nomeStadio string
	if res.Next() == true {
		res.Scan(&nomeStadio)
	}

	query2 := fmt.Sprintf("SELECT nome FROM settore WHERE stadio = '%s'", nomeStadio)
	res2, err2 := db.Query(query2)
	if err2 != nil {
		fmt.Println(err2)
		return append(settori, "Errore Generico")
	}
	defer res2.Close()

	var se string
	for res2.Next() {
		res2.Scan(&se)
		settori = append(settori, se)
	}
	return settori
}

func queryCaricaPartita(db *sql.DB, casa, ospite, data, ora, tipo string, prezzo_s1, prezzo_s2, prezzo_s3, prezzo_s4 float64) string {
	fmt.Println("Query inserimento partita")
	query := fmt.Sprintf("SELECT id_partita FROM partita where squadra_casa = '%s' AND squadra_trasferta = '%s' AND tipologia = '%s'", casa, ospite, tipo)

	res, err := db.Query(query)
	if err != nil {
		fmt.Print(err)
	}

	defer res.Close()
	if res.Next() == true {
		return "Partita presente"
	}

	query2 := fmt.Sprintf("SELECT nome FROM stadio where proprietario ='%s'", casa)
	res2, err2 := db.Query(query2)
	if err2 != nil {
		fmt.Println(err2)
	}

	defer res2.Close()

	var nomeStadio string
	if res2.Next() == true {
		res2.Scan(&nomeStadio)
	}

	query3 := fmt.Sprintf("SELECT sport FROM societa where nome ='%s'", casa)
	res3, err3 := db.Query(query3)
	if err3 != nil {
		fmt.Println(err3)
	}

	defer res3.Close()

	var sport string
	if res3.Next() == true {
		res3.Scan(&sport)
	}

	query4 := fmt.Sprintf("INSERT INTO partita VALUES (default,'%s','%s','%s','%s','%s','%s','%s',%.2f,%.2f,%.2f,%.2f)",
		sport, data, ora, casa, ospite, tipo, nomeStadio, prezzo_s1, prezzo_s2, prezzo_s3, prezzo_s4)

	res4, err4 := db.Query(query4)
	if err4 != nil {
		fmt.Print(err4)
	}

	if res2.Next() == true {
		return "Squadra in casa gioca lo stesso giorno"
	}

	defer res4.Close()
	return "Partita inserita"
}

func queryRegCliente(db *sql.DB, nome, cognome, dataN, email, tel, pwd string) string {
	fmt.Println("Query Registrazione cliente")
	query1 := fmt.Sprintf("SELECT * FROM cliente WHERE email='%s'", email)
	res1, err1 := db.Query(query1)
	if err1 != nil {
		fmt.Println(err1)
		return "Errore generico"
	}
	if res1.Next() == true {
		return "Email esistente"
	}
	defer res1.Close()

	password := []byte(pwd)
	hashedPassword := sha256.Sum256(password)

	query2 := fmt.Sprintf("INSERT INTO cliente VALUES (default,'%s', '%s', '%s', '%s', '%s', '%x' )", nome, cognome, dataN, email, tel, hashedPassword)
	res2, err2 := db.Query(query2)

	if err2 != nil {
		fmt.Println(err2)
		return "Errore generico"
	}
	defer res2.Close()
	return "Account creato"
}

func queryLogCliente(db *sql.DB, email, pwd string) []string {
	fmt.Println("Query Login cliente")
	var info_cliente []string
	password := []byte(pwd)
	hashedPassword := sha256.Sum256(password)

	query := fmt.Sprintf("SELECT id_cliente,nome,cognome FROM cliente WHERE email = '%s' AND password = '%x'", email, hashedPassword)
	res, err := db.Query(query)

	if err != nil {
		fmt.Println(err)
	}

	var id_cliente, nome, cognome string

	if res.Next() == true {
		res.Scan(&id_cliente, &nome, &cognome)
		info_cliente = append(info_cliente, id_cliente)
		info_cliente = append(info_cliente, nome)
		info_cliente = append(info_cliente, cognome)
		return info_cliente
	}
	return append(info_cliente, "Credenziali")
}

func queryGetPartite(db *sql.DB) []Partita {
	currentTime := time.Now()
	const layout = "2006-01-02"
	data := currentTime.Format(layout)

	fmt.Println("Query Visualizzazione partite")
	var listaPartite []Partita
	query := fmt.Sprintf("SELECT * FROM partita WHERE data >= '%s' ORDER BY data", data)
	res, err := db.Query(query)

	if err != nil {
		fmt.Println(err)
	}
	defer res.Close()
	for res.Next() {
		var pa Partita
		err2 := res.Scan(&pa.Id, &pa.Sport, &pa.Data, &pa.Ora, &pa.Squadra_casa, &pa.Squadra_trasferta, &pa.Tipologia, &pa.Luogo, &pa.Prezzo_settore_1, &pa.Prezzo_settore_2, &pa.Prezzo_settore_3, &pa.Prezzo_settore_4)
		if err2 != nil {
			fmt.Println(err2)
		}
		listaPartite = append(listaPartite, pa)

	}
	return listaPartite
}

func queryInserisciBiglietto(db *sql.DB, id_partita, id_cliente int, partita, stadio, settore string, prezzo float64) string {

	query := fmt.Sprintf("SELECT * FROM abbonamento WHERE id_cliente= '%d' AND settore= '%s'", id_cliente, settore)
	res, err := db.Query(query)
	if err != nil {
		fmt.Println(err)
		return "Errore"
	}
	if res.Next() == true {
		return "Abbonato"
	}
	defer res.Close()
	query2 := fmt.Sprintf("INSERT INTO biglietto VALUES (default,%d,'%s',%d,'%s','%s',%.2f)", id_partita, partita, id_cliente, stadio, settore, prezzo)
	res2, err2 := db.Query(query2)
	if err2 != nil {
		fmt.Println(err2)
		return "Duplicato"
	}
	defer res2.Close()
	return "ok"
}

func queryGetBiglietti(db *sql.DB, id_utente string) []Biglietto {
	fmt.Println("Query biglietti")
	var listaBiglietti []Biglietto

	query := fmt.Sprintf("SELECT id_biglietto,partita,data,ora,stadio,settore,prezzo FROM biglietto join partita ON biglietto.id_partita = partita.id_partita WHERE id_cliente = '%s'", id_utente)
	res, err := db.Query(query)
	if err != nil {
		fmt.Println(err)

	}
	defer res.Close()

	for res.Next() {
		var bi Biglietto
		err2 := res.Scan(&bi.Codice, &bi.Partita, &bi.Data, &bi.Ora, &bi.Stadio, &bi.Settore, &bi.Prezzo)
		if err2 != nil {
			fmt.Println(err2)
		}
		listaBiglietti = append(listaBiglietti, bi)

	}
	return listaBiglietti
}

func queryGetAbbonamenti(db *sql.DB, id_utente string) []Abbonamento {
	fmt.Println("Query abbonamenti")
	var listaAbbonamenti []Abbonamento

	query := fmt.Sprintf("SELECT id_abbonamento,societa,stadio,settore,prezzo FROM abbonamento WHERE id_cliente = '%s'", id_utente)
	res, err := db.Query(query)
	if err != nil {
		fmt.Println(err)

	}
	defer res.Close()

	for res.Next() {
		var abb Abbonamento
		err2 := res.Scan(&abb.Codice, &abb.Societa, &abb.Stadio, &abb.Settore, &abb.Prezzo)
		if err2 != nil {
			fmt.Println(err2)
		}
		listaAbbonamenti = append(listaAbbonamenti, abb)
	}
	return listaAbbonamenti
}

func queryGetPostiSettore(db *sql.DB, stadio, settore, tipo string) int {
	fmt.Println("Query posti settore")
	var sommaBiglietti, sommaAbb, capacita int

	query := fmt.Sprintf("SELECT count(id_biglietto) FROM biglietto WHERE stadio = '%s' AND settore = '%s'", stadio, settore)
	res, err := db.Query(query)
	if err != nil {
		fmt.Println(err)
	}
	defer res.Close()

	if res.Next() == true {
		err2 := res.Scan(&sommaBiglietti)
		if err2 != nil {
			fmt.Println(err2)
		}
	}

	query2 := fmt.Sprintf("SELECT count(id_abbonamento) FROM abbonamento WHERE stadio = '%s' AND settore = '%s'", stadio, settore)
	res2, err3 := db.Query(query2)
	if err3 != nil {
		fmt.Println(err3)
	}
	defer res2.Close()

	if res2.Next() == true {
		err3 := res2.Scan(&sommaAbb)
		if err3 != nil {
			fmt.Println(err3)
		}
	}

	query3 := fmt.Sprintf("SELECT capacita FROM settore WHERE stadio = '%s' AND nome = '%s'", stadio, settore)
	res3, err4 := db.Query(query3)
	if err4 != nil {
		fmt.Println(err4)
	}
	defer res3.Close()

	if res3.Next() == true {
		err5 := res3.Scan(&capacita)
		if err5 != nil {
			fmt.Println(err5)
		}
	}
	if tipo == "Campionato" {
		return capacita - sommaBiglietti - sommaAbb
	}
	return capacita - sommaBiglietti
}

func queryGetAbbDisponibili(db *sql.DB, societa string) []AbbDisponibile {
	fmt.Println("Query abbonamenti disponibili")
	var abbDisponibili []AbbDisponibile

	query := "SELECT stadio.proprietario,settore.nome,stadio.nome,settore.capacita,settore.costo_abbonamento FROM settore join stadio on settore.stadio = stadio.nome WHERE stadio.proprietario LIKE ?"
	soc := "%" + societa + "%"
	res, err := db.Query(query, soc)
	if err != nil {
		fmt.Println(err)

	}
	defer res.Close()

	for res.Next() {
		var abbD AbbDisponibile
		err2 := res.Scan(&abbD.Societa, &abbD.Settore, &abbD.Stadio, &abbD.TotPosti, &abbD.Costo)
		if err2 != nil {
			fmt.Println(err2)
		}
		abbDisponibili = append(abbDisponibili, abbD)
	}
	return abbDisponibili
}

func queryInserisciAbbonamento(db *sql.DB, societa, stadio, settore string, costo float64, id_cliente int) string {
	fmt.Println("Query inserimento abbonamento")

	query := fmt.Sprintf("INSERT INTO abbonamento VALUES (default,%d,'%s','%s','%s',%.2f)", id_cliente, societa, stadio, settore, costo)
	res, err := db.Query(query)
	if err != nil {
		fmt.Println(err)
		return "Duplicato"
	}
	defer res.Close()
	return "ok"
}

func queryGetPartiteSocieta(db *sql.DB, societa string) []Partita {
	fmt.Println("Query Visualizzazione partite inserite da " + societa)

	var listaPartite []Partita
	query := fmt.Sprintf("SELECT * FROM partita WHERE squadra_casa = '%s'", societa)
	res, err := db.Query(query)

	if err != nil {
		fmt.Println(err)
	}

	defer res.Close()

	for res.Next() {
		var pa Partita
		err2 := res.Scan(&pa.Id, &pa.Sport, &pa.Data, &pa.Ora, &pa.Squadra_casa, &pa.Squadra_trasferta, &pa.Tipologia, &pa.Luogo, &pa.Prezzo_settore_1, &pa.Prezzo_settore_2, &pa.Prezzo_settore_3, &pa.Prezzo_settore_4)
		if err2 != nil {
			fmt.Println(err2)
		}
		listaPartite = append(listaPartite, pa)

	}
	return listaPartite
}

func queryAggiornaPrezzoAbb(db *sql.DB, societa, settore1, settore2, settore3, settore4 string) string {
	fmt.Println("Query aggiornamento prezzo abbonamenti")

	settore1 = strings.Replace(settore1, ",", ".", -1)
	se1Float, err := strconv.ParseFloat(settore1, 64)
	settore2 = strings.Replace(settore2, ",", ".", -1)
	se2Float, err := strconv.ParseFloat(settore2, 64)
	settore3 = strings.Replace(settore3, ",", ".", -1)
	se3Float, err := strconv.ParseFloat(settore3, 64)
	settore4 = strings.Replace(settore4, ",", ".", -1)
	se4Float, err := strconv.ParseFloat(settore4, 64)

	query := fmt.Sprintf("SELECT nome FROM stadio WHERE proprietario= '%s'", societa)
	res, err := db.Query(query)

	if err != nil {
		fmt.Println(err)
	}
	defer res.Close()

	var stadio string
	if res.Next() == true {
		res.Scan(&stadio)
	}
	query2 := fmt.Sprintf("SELECT nome FROM settore WHERE stadio= '%s'", stadio)
	res2, err2 := db.Query(query2)

	if err2 != nil {
		fmt.Println(err2)
	}
	defer res2.Close()

	var settori []string
	for res2.Next() {
		var se string
		res2.Scan(&se)
		settori = append(settori, se)
	}

	query3 := fmt.Sprintf("UPDATE settore SET costo_abbonamento=%f WHERE stadio= '%s' AND nome= '%s'", se1Float, stadio, settori[0])
	res3, err3 := db.Query(query3)
	if err3 != nil {
		fmt.Println(err3)
		return "errore aggiornamento"
	}
	defer res3.Close()

	query4 := fmt.Sprintf("UPDATE settore SET costo_abbonamento=%f WHERE stadio= '%s' AND nome= '%s'", se2Float, stadio, settori[1])
	res4, err4 := db.Query(query4)
	if err4 != nil {
		fmt.Println(err4)
		return "errore aggiornamento"
	}
	defer res4.Close()

	query5 := fmt.Sprintf("UPDATE settore SET costo_abbonamento=%f WHERE stadio= '%s' AND nome= '%s'", se3Float, stadio, settori[2])
	res5, err5 := db.Query(query5)

	if err5 != nil {
		fmt.Println(err5)
		return "errore aggiornamento"
	}
	defer res5.Close()

	query6 := fmt.Sprintf("UPDATE settore SET costo_abbonamento=%f WHERE stadio= '%s' AND nome= '%s'", se4Float, stadio, settori[3])
	res6, err6 := db.Query(query6)

	if err6 != nil {
		fmt.Println(err6)
		return "errore aggiornamento"
	}
	defer res6.Close()

	return "ok"
}
func queryGetBigliettiPartita(db *sql.DB, societa, avversario, tipologia string) InfoBigliettiVenduti {
	fmt.Println("Query biglietti Partita")
	var id_partita, biglietti int
	var incasso float32

	query := fmt.Sprintf("SELECT id_partita FROM partita WHERE squadra_casa = '%s' AND squadra_trasferta = '%s' and tipologia = '%s'",
		societa, avversario, tipologia)

	res, err := db.Query(query)
	if err != nil {
		fmt.Println(err)
	}
	if res.Next() == true {
		res.Scan(&id_partita)
	}
	defer res.Close()

	query2 := fmt.Sprintf("SELECT count(prezzo) as biglietti_venduti, sum(prezzo) as incasso_tot FROM biglietto WHERE id_partita = '%d'",
		id_partita)
	res2, err2 := db.Query(query2)
	if err2 != nil {
		fmt.Println(err2)
	}
	if res2.Next() == true {
		res2.Scan(&biglietti, &incasso)
	}

	defer res2.Close()

	vendite := InfoBigliettiVenduti{
		Tot_Biglietti: biglietti,
		Tot_Incasso:   incasso,
	}

	return vendite
}
