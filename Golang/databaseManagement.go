package main

import (
	"crypto/sha256"
	"database/sql"
	"fmt"
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
	Societa  int
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
	Codice    string
	Casa      string
	Trasferta string
	Data      string
	Ora       string
	Prezzo    float32
	Stadio    string
	Settore   string
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
	Tot_Incasso   float64
}

func queryRegImpiegato(db *sql.DB, societa, nome, cognome, email, pwd string) string {
	fmt.Println("Query Registrazione Impiegato")
	res, err := db.Query("SELECT * FROM impiegato WHERE email=" + "'" + email + "'")
	if err != nil {
		fmt.Println(err)
		return "Errore generico"
	}
	if res.Next() == true {
		return "Email esistente"
	}
	defer res.Close()

	var id_societa int
	query1 := fmt.Sprintf("SELECT id_societa FROM societa where nome ='%s'", societa)
	res1, err1 := db.Query(query1)
	if err1 != nil {
		fmt.Println(err)
		return "Errore generico"
	}
	if res1.Next() == true {
		res1.Scan(&id_societa)
	}
	defer res1.Close()

	password := []byte(pwd)
	hashedPassword := sha256.Sum256(password)
	query2 := fmt.Sprintf("INSERT INTO impiegato VALUES (default, '%d', '%s', '%s', '%s', '%x')", id_societa, nome, cognome, email, hashedPassword)
	res2, err2 := db.Query(query2)

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
	query2 := fmt.Sprintf("SELECT nome FROM societa WHERE id_societa = %d", imp.Societa)

	var soci string
	err2 := db.QueryRow(query2).Scan(&soci)
	if err2 != nil {
		return "Errore Generico"
	}

	return soci
}

func querySettoriStadio(db *sql.DB, societa string) []string {
	fmt.Println("Query Caricamento settori")
	var settori []string
	var idStadio int

	query := "SELECT id_stadio FROM stadio WHERE id_proprietario = (SELECT id_societa FROM societa WHERE nome = ?)"
	err := db.QueryRow(query, societa).Scan(&idStadio)
	if err != nil {
		fmt.Println(err)
		return append(settori, "Errore Generico")
	}

	query2 := fmt.Sprintf("SELECT nome FROM settore WHERE id_stadio = '%d'", idStadio)
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
	var idCasa int

	old_layout := "02/01/2006"
	parsed_date, err := time.Parse(old_layout, data)
	if err != nil {
		return "errore"
	}
	new_data := parsed_date.Format("2006-01-02")

	query1 := fmt.Sprintf("SELECT id_societa FROM societa WHERE nome ='%s'", casa)
	err1 := db.QueryRow(query1).Scan(&idCasa)
	if err1 != nil {
		fmt.Print(err1)
	}
	fmt.Println("Query inserimento partita")

	query2 := fmt.Sprintf("SELECT id_stadio FROM stadio where id_proprietario =%d", idCasa)
	res2, err2 := db.Query(query2)
	if err2 != nil {
		fmt.Println(err2)
	}

	defer res2.Close()

	var idStadio int
	if res2.Next() == true {
		res2.Scan(&idStadio)
	}

	query3 := fmt.Sprintf("SELECT sport FROM societa where id_societa =%d", idCasa)
	res3, err3 := db.Query(query3)
	if err3 != nil {
		fmt.Println(err3)
	}

	defer res3.Close()

	var sport string
	if res3.Next() == true {
		res3.Scan(&sport)
	}

	query4 := fmt.Sprintf("SELECT * FROM partita where squadra_casa = '%d' AND data = '%s'", idCasa, new_data)
	res4, err4 := db.Query(query4)
	if err4 != nil {
		fmt.Print(err4)
	}
	if res4.Next() == true {
		return "Squadra in casa gioca lo stesso giorno"
	}
	defer res4.Close()

	query5 := fmt.Sprintf("INSERT INTO partita VALUES (default,'%s','%s','%s','%d','%s','%s','%d',%.2f,%.2f,%.2f,%.2f)",
		sport, new_data, ora, idCasa, ospite, tipo, idStadio, prezzo_s1, prezzo_s2, prezzo_s3, prezzo_s4)

	res5, err5 := db.Query(query5)
	if err5 != nil {
		return "Partita presente"
	}

	defer res5.Close()
	return "Partita inserita"
}

func queryRegCliente(db *sql.DB, nome, cognome, dataN, email, tel, pwd string) string {
	fmt.Println("Query Registrazione cliente")

	password := []byte(pwd)
	hashedPassword := sha256.Sum256(password)
	query2 := fmt.Sprintf("INSERT INTO cliente VALUES (default,'%s', '%s', '%s', '%s', '%s', '%x',0.0 )", nome, cognome, dataN, email, tel, hashedPassword)
	res2, err2 := db.Query(query2)

	if err2 != nil {
		return "Email esistente"
	}
	defer res2.Close()
	return "Account creato"
}

func queryLogCliente(db *sql.DB, email, pwd string) []string {
	fmt.Println("Query Login cliente")
	var info_cliente []string
	password := []byte(pwd)
	hashedPassword := sha256.Sum256(password)

	query := fmt.Sprintf("SELECT id_cliente,nome,cognome,saldo FROM cliente WHERE email = '%s' AND password = '%x'", email, hashedPassword)
	res, err := db.Query(query)

	if err != nil {
		fmt.Println(err)
	}

	var id_cliente, nome, cognome, saldo string
	//AGGIUNTO SALDO NELLO SCAN E NELL APPEND
	if res.Next() == true {
		res.Scan(&id_cliente, &nome, &cognome, &saldo)
		info_cliente = append(info_cliente, id_cliente)
		info_cliente = append(info_cliente, nome)
		info_cliente = append(info_cliente, cognome)
		info_cliente = append(info_cliente, saldo)

		return info_cliente
	}
	return append(info_cliente, "Credenziali")

}

func queryGetPartite(db *sql.DB) []Partita {
	currentTime := time.Now()
	const layout = "2006-01-02"
	data := currentTime.Format(layout)
	var idCasa, idStadio int

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
		err2 := res.Scan(&pa.Id, &pa.Sport, &pa.Data, &pa.Ora, &idCasa, &pa.Squadra_trasferta, &pa.Tipologia, &idStadio, &pa.Prezzo_settore_1, &pa.Prezzo_settore_2, &pa.Prezzo_settore_3, &pa.Prezzo_settore_4)
		if err2 != nil {
			fmt.Println(err2)
		}
		query1 := fmt.Sprintf("SELECT nome FROM societa WHERE id_societa = %d", idCasa)
		err := db.QueryRow(query1).Scan(&pa.Squadra_casa)
		if err != nil {
			fmt.Println(err)
		}
		query2 := fmt.Sprintf("SELECT nome FROM stadio WHERE id_stadio = %d", idStadio)
		err = db.QueryRow(query2).Scan(&pa.Luogo)
		if err != nil {
			fmt.Println(err)
		}

		listaPartite = append(listaPartite, pa)

	}
	return listaPartite
}

func queryInserisciBiglietto(db *sql.DB, id_partita, id_cliente int, casa, trasferta, stadio, settore string, prezzo float64) string {
	var idStadio, idSettore int
	var saldo, nuovo_saldo float64

	query1 := fmt.Sprintf("SELECT id_stadio FROM stadio WHERE nome = '%s'", stadio)
	err := db.QueryRow(query1).Scan(&idStadio)
	if err != nil {
		fmt.Println(err)
		return "Errore"
	}

	query2 := fmt.Sprintf("SELECT id_settore FROM settore WHERE nome = '%s' AND id_stadio = %d", settore, idStadio)
	err2 := db.QueryRow(query2).Scan(&idSettore)
	if err2 != nil {
		fmt.Println(err2)
		return "Errore"
	}

	query := fmt.Sprintf("SELECT * FROM abbonamento WHERE id_cliente= '%d' AND id_stadio = %d AND id_settore= %d", id_cliente, idStadio, idSettore)
	res, err := db.Query(query)
	if err != nil {
		fmt.Println(err)
		return "Errore"
	}
	if res.Next() == true {
		return "Abbonato"
	}
	defer res.Close()

	query3 := fmt.Sprintf("INSERT INTO biglietto VALUES (default,%d,'%s','%s','%d',%d,'%d',%.2f)", id_partita, casa, trasferta, id_cliente, idStadio, idSettore, prezzo)
	res3, err3 := db.Query(query3)
	if err3 != nil {
		fmt.Println(err3)
		return "Duplicato"
	}
	defer res3.Close()

	query4 := fmt.Sprintf("SELECT saldo FROM cliente where id_cliente= %d", id_cliente)
	err4 := db.QueryRow(query4).Scan(&saldo)
	if err4 != nil {
		fmt.Println(err4)
		return "Errore"
	}

	nuovo_saldo = saldo - prezzo

	query5 := fmt.Sprintf("UPDATE cliente SET saldo=%.2f where id_cliente= %d", nuovo_saldo, id_cliente)
	res5, err5 := db.Query(query5)
	if err5 != nil {
		fmt.Println(err5)
		return "errore aggiornamento"
	}
	defer res5.Close()

	return "ok"
}

func queryGetBiglietti(db *sql.DB, id_utente string) []Biglietto {
	fmt.Println("Query biglietti")
	var listaBiglietti []Biglietto
	var idPartita, idStadio, idCliente, idSettore int

	query := fmt.Sprintf("SELECT * FROM biglietto WHERE id_cliente = '%s'", id_utente)
	res, err := db.Query(query)
	if err != nil {
		fmt.Println(err)

	}
	defer res.Close()

	for res.Next() {
		var bi Biglietto
		err2 := res.Scan(&bi.Codice, &idPartita, &bi.Casa, &bi.Trasferta, &idCliente, &idStadio, &idSettore, &bi.Prezzo)
		if err2 != nil {
			fmt.Println(err2)
		}
		query2 := fmt.Sprintf("SELECT data,ora FROM partita WHERE id_partita =%d", idPartita)
		err = db.QueryRow(query2).Scan(&bi.Data, &bi.Ora)
		query3 := fmt.Sprintf("SELECT stadio.nome,settore.nome FROM stadio JOIN settore on stadio.id_stadio = settore.id_stadio where id_settore=%d", idSettore)
		err = db.QueryRow(query3).Scan(&bi.Stadio, &bi.Settore)

		old_layout := "2006-01-02"
		parsed_date, err := time.Parse(old_layout, bi.Data)
		if err != nil {
			fmt.Println(err)
		}
		bi.Data = parsed_date.Format("02/01/2006")

		listaBiglietti = append(listaBiglietti, bi)

	}
	return listaBiglietti
}

func queryGetAbbonamenti(db *sql.DB, id_utente string) []Abbonamento {
	fmt.Println("Query abbonamenti")
	var listaAbbonamenti []Abbonamento
	var idSocieta, idStadio, idSettore int

	query := fmt.Sprintf("SELECT id_abbonamento,id_societa,id_stadio,id_settore,prezzo FROM abbonamento WHERE id_cliente = '%s'", id_utente)
	res, err := db.Query(query)
	if err != nil {
		fmt.Println(err)
	}
	defer res.Close()

	for res.Next() {
		var abb Abbonamento
		err2 := res.Scan(&abb.Codice, &idSocieta, &idStadio, &idSettore, &abb.Prezzo)
		if err2 != nil {
			fmt.Println(err2)
		}
		query2 := fmt.Sprintf("SELECT stadio.nome,settore.nome FROM stadio JOIN settore on stadio.id_stadio = settore.id_stadio where id_settore=%d", idSettore)
		err = db.QueryRow(query2).Scan(&abb.Stadio, &abb.Settore)
		query3 := fmt.Sprintf("SELECT nome FROM societa WHERE id_societa=%d", idSocieta)
		err = db.QueryRow(query3).Scan(&abb.Societa)

		listaAbbonamenti = append(listaAbbonamenti, abb)
	}
	return listaAbbonamenti
}

func queryGetPostiSettore(db *sql.DB, stadio, settore, tipo string) int {
	fmt.Println("Query posti settore")
	var sommaBiglietti, sommaAbb, capacita int
	var idStadio, idSettore int

	query1 := fmt.Sprintf("SELECT id_stadio FROM stadio WHERE nome = '%s'", stadio)
	err := db.QueryRow(query1).Scan(&idStadio)
	if err != nil {
		fmt.Println(err)
	}

	query2 := fmt.Sprintf("SELECT id_settore FROM settore WHERE nome = '%s' AND id_stadio = %d", settore, idStadio)
	err2 := db.QueryRow(query2).Scan(&idSettore)
	if err2 != nil {
		fmt.Println(err2)
	}

	query3 := fmt.Sprintf("SELECT count(id_biglietto) FROM biglietto WHERE stadio = %d AND settore = %d", idStadio, idSettore)
	res3, err3 := db.Query(query3)
	if err3 != nil {
		fmt.Println(err3)
	}
	defer res3.Close()

	if res3.Next() == true {
		err := res3.Scan(&sommaBiglietti)
		if err != nil {
			fmt.Println(err)
		}
	}

	query4 := fmt.Sprintf("SELECT count(id_abbonamento) FROM abbonamento WHERE id_stadio = %d AND id_settore = %d", idStadio, idSettore)
	res4, err4 := db.Query(query4)
	if err != nil {
		fmt.Println(err)
	}
	defer res4.Close()

	if res4.Next() == true {
		err := res4.Scan(&sommaAbb)
		if err != nil {
			fmt.Println(err4)
		}
	}

	query5 := fmt.Sprintf("SELECT capacita FROM settore WHERE id_stadio = %d AND id_settore = %d", idStadio, idSettore)
	res5, err5 := db.Query(query5)
	if err5 != nil {
		fmt.Println(err5)
	}
	defer res5.Close()

	if res5.Next() == true {
		err := res5.Scan(&capacita)
		if err != nil {
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
	var idSocieta int

	query := fmt.Sprintf("SELECT id_societa from societa WHERE nome LIKE ?")
	soc := "%" + societa + "%"
	res, err := db.Query(query, soc)
	if err != nil {
		fmt.Println(err)
	}
	defer res.Close()

	for res.Next() {
		err2 := res.Scan(&idSocieta)
		if err2 != nil {
			fmt.Println(err2)
		}

		query2 := fmt.Sprintf("SELECT settore.nome,stadio.nome,settore.capacita,settore.costo_abbonamento FROM settore join stadio on settore.id_stadio = stadio.id_stadio WHERE stadio.id_proprietario =%d", idSocieta)
		res2, err2 := db.Query(query2)
		if err2 != nil {
			fmt.Println(err2)
		}
		defer res2.Close()

		for res2.Next() {
			var abbD AbbDisponibile

			queryR := fmt.Sprintf("SELECT nome from societa WHERE id_societa='%d'", idSocieta)
			err := db.QueryRow(queryR).Scan(&abbD.Societa)
			if err != nil {
				fmt.Println(err)
			}

			res2.Scan(&abbD.Settore, &abbD.Stadio, &abbD.TotPosti, &abbD.Costo)
			abbDisponibili = append(abbDisponibili, abbD)
		}
	}
	defer res.Close()

	return abbDisponibili
}

func queryInserisciAbbonamento(db *sql.DB, societa, stadio, settore string, costo float64, id_cliente int) string {
	fmt.Println("Query inserimento abbonamento")
	var idSocieta, idStadio, idSettore int
	var saldo, nuovo_saldo float64

	query := fmt.Sprintf("SELECT id_societa FROM societa WHERE nome='%s'", societa)
	err := db.QueryRow(query).Scan(&idSocieta)

	query2 := fmt.Sprintf("SELECT settore.id_settore,stadio.id_stadio FROM settore JOIN stadio on settore.id_stadio = stadio.id_stadio WHERE settore.nome = '%s' AND stadio.nome = '%s'", settore, stadio)
	err = db.QueryRow(query2).Scan(&idSettore, &idStadio)
	if err != nil {
		fmt.Println(err)
		return "Duplicato"
	}
	query3 := fmt.Sprintf("INSERT INTO abbonamento VALUES (default,%d,'%d','%d','%d',%.2f)", id_cliente, idSocieta, idStadio, idSettore, costo)
	res3, err3 := db.Query(query3)
	if err3 != nil {
		fmt.Println(err3)
		return "Duplicato"
	}
	defer res3.Close()

	query4 := fmt.Sprintf("SELECT saldo FROM cliente where id_cliente= %d", id_cliente)
	err4 := db.QueryRow(query4).Scan(&saldo)
	if err4 != nil {
		fmt.Println(err4)
		return "Errore"
	}

	nuovo_saldo = saldo - costo

	query5 := fmt.Sprintf("UPDATE cliente SET saldo=%.2f where id_cliente= %d", nuovo_saldo, id_cliente)
	res5, err5 := db.Query(query5)
	if err5 != nil {
		fmt.Println(err5)
		return "errore aggiornamento"
	}
	defer res5.Close()

	return "ok"
}

func queryGetPartiteSocieta(db *sql.DB, societa string) []Partita {
	fmt.Println("Query Visualizzazione partite inserite da " + societa)
	var idCasa, idStadio int
	var listaPartite []Partita

	query := fmt.Sprintf("SELECT * FROM partita WHERE squadra_casa = (SELECT id_societa FROM societa WHERE nome = '%s')", societa)
	res, err := db.Query(query)

	if err != nil {
		fmt.Println(err)
	}

	defer res.Close()
	for res.Next() {
		var pa Partita

		err2 := res.Scan(&pa.Id, &pa.Sport, &pa.Data, &pa.Ora, &idCasa, &pa.Squadra_trasferta, &pa.Tipologia, &idStadio, &pa.Prezzo_settore_1, &pa.Prezzo_settore_2, &pa.Prezzo_settore_3, &pa.Prezzo_settore_4)
		if err2 != nil {
			fmt.Println(err2)
		}
		query := fmt.Sprintf("SELECT nome FROM societa WHERE id_societa = %d", idCasa)
		err := db.QueryRow(query).Scan(&pa.Squadra_casa)
		if err != nil {
			fmt.Println(err)
		}
		query2 := fmt.Sprintf("SELECT nome FROM stadio WHERE id_stadio = %d", idStadio)
		err2 = db.QueryRow(query2).Scan(&pa.Luogo)
		if err2 != nil {
			fmt.Println(err2)
		}

		old_layout := "2006-01-02"
		parsed_date, err := time.Parse(old_layout, pa.Data)
		if err != nil {
			fmt.Println(err)
		}
		pa.Data = parsed_date.Format("02/01/2006")
		listaPartite = append(listaPartite, pa)
	}
	return listaPartite
}

func queryAggiornaPrezzoAbb(db *sql.DB, societa, settore1, settore2, settore3, settore4 string) string {
	fmt.Println("Query aggiornamento prezzo abbonamenti")
	var idStadio int
	var settori []int

	settore1 = strings.Replace(settore1, ",", ".", -1)
	se1Float, err := strconv.ParseFloat(settore1, 64)
	settore2 = strings.Replace(settore2, ",", ".", -1)
	se2Float, err := strconv.ParseFloat(settore2, 64)
	settore3 = strings.Replace(settore3, ",", ".", -1)
	se3Float, err := strconv.ParseFloat(settore3, 64)
	settore4 = strings.Replace(settore4, ",", ".", -1)
	se4Float, err := strconv.ParseFloat(settore4, 64)

	prezzi := []float64{se1Float, se2Float, se3Float, se4Float}

	query := fmt.Sprintf("SELECT id_stadio FROM stadio WHERE id_proprietario = (SELECT id_societa FROM societa WHERE nome='%s')", societa)
	err = db.QueryRow(query).Scan(&idStadio)
	if err != nil {
		fmt.Println(err)
	}

	query2 := fmt.Sprintf("SELECT id_settore FROM settore WHERE id_stadio= %d", idStadio)
	res2, err2 := db.Query(query2)

	if err2 != nil {
		fmt.Println(err2)
	}
	defer res2.Close()

	for res2.Next() {
		var se int
		res2.Scan(&se)
		settori = append(settori, se)
	}

	for i := 0; i < len(settori); i++ {
		query3 := fmt.Sprintf("UPDATE settore SET costo_abbonamento=%f WHERE id_stadio= %d AND id_settore= %d", prezzi[i], idStadio, settori[i])
		res3, err3 := db.Query(query3)
		if err3 != nil {
			fmt.Println(err3)
			return "errore aggiornamento"
		}
		defer res3.Close()
	}

	return "ok"
}
func queryGetBigliettiPartita(db *sql.DB, societa, avversario, tipologia string) InfoBigliettiVenduti {
	fmt.Println("Query biglietti Partita")
	var idSocieta, idPartita, biglietti int
	var incasso float64

	queryR := fmt.Sprintf("SELECT id_societa FROM societa WHERE nome = '%s'", societa)
	err := db.QueryRow(queryR).Scan(&idSocieta)

	query := fmt.Sprintf("SELECT id_partita FROM partita WHERE squadra_casa = '%d' AND squadra_trasferta = '%s' and tipologia = '%s'",
		idSocieta, avversario, tipologia)

	res, err := db.Query(query)
	if err != nil {
		fmt.Println(err)
	}
	if res.Next() == true {
		res.Scan(&idPartita)
	}
	defer res.Close()

	query2 := fmt.Sprintf("SELECT count(prezzo) as biglietti_venduti, sum(prezzo) as incasso_tot FROM biglietto WHERE id_partita = '%d'",
		idPartita)
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
func queryRicarica(db *sql.DB, id, importo float64) string {
	fmt.Println("Query Ricarica")
	var saldo, nuovo_saldo float64
	id_cliente := int(id)

	queryR := fmt.Sprintf("SELECT saldo FROM cliente WHERE id_cliente = %d", id_cliente)
	err := db.QueryRow(queryR).Scan(&saldo)
	if err != nil {
		fmt.Println(err)
	}

	nuovo_saldo = saldo + importo

	query2 := fmt.Sprintf("UPDATE cliente SET saldo=%.2f WHERE id_cliente = %d", nuovo_saldo, id_cliente)
	res2, err2 := db.Query(query2)
	if err2 != nil {
		fmt.Println(err2)
		return "errore aggiornamento"
	}
	defer res2.Close()

	return "ok"

}

func querySaldo(db *sql.DB, id int) float64 {
	var saldo float64
	query := fmt.Sprintf("SELECT saldo FROM cliente WHERE id_cliente = %d", id)
	err := db.QueryRow(query).Scan(&saldo)
	if err != nil {
		fmt.Println(err)
	}
	return saldo

}
