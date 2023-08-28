package main

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"net/http"
	"strconv"
)

func startServer() {
	http.HandleFunc("/registra_impiegato", registraImpiegato)
	http.HandleFunc("/login_impiegato", loginImpiegato)
	http.HandleFunc("/settori_stadio", settoriStadio)
	http.HandleFunc("/carica_partita", caricaPartita)
	http.HandleFunc("/registra_cliente", registraCliente)
	http.HandleFunc("/login_cliente", loginCliente)
	http.HandleFunc("/get_partite", getPartite)
	http.HandleFunc("/conferma_biglietto", confermaBiglietto)
	http.HandleFunc("/get_biglietti", getBiglietti)
	http.HandleFunc("/get_abbonamenti", getAbbonamenti)
	http.HandleFunc("/get_posti_settore", getPostiSettore)
	http.HandleFunc("/get_abbonamenti_disponibili", getAbbDisponibili)
	http.HandleFunc("/inserisci_abbonamento", inserisciAbbonamento)
	http.HandleFunc("/get_partite_societa", getPartiteSocieta)
	http.HandleFunc("/aggiorna_costo_abbonamenti", aggiornaCostoAbb)
	http.HandleFunc("/get_biglietti_partita", getBigliettiPartita)

	http.ListenAndServe(":8080", nil)
}
func registraImpiegato(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	societa := req.Form.Get("societa")
	nome := req.Form.Get("nome")
	cognome := req.Form.Get("cognome")
	email := req.Form.Get("email")
	passw := req.Form.Get("password")
	resp := queryRegImpiegato(sqlDB, societa, nome, cognome, email, passw)
	fmt.Fprintf(w, resp)
}
func loginImpiegato(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	email := req.Form.Get("email")
	passw := req.Form.Get("password")
	resp := queryLogImpiegato(sqlDB, email, passw)
	fmt.Fprintf(w, resp)
}
func settoriStadio(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	societa := req.Form.Get("societa")
	resp := querySettoriStadio(sqlDB, societa)
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(resp)
}
func caricaPartita(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	casa := req.Form.Get("casa")
	ospite := req.Form.Get("ospite")
	data := req.Form.Get("data")
	ora := req.Form.Get("ora")
	tipo := req.Form.Get("tipo")
	prezzo_s1, _ := strconv.ParseFloat(req.Form.Get("prezzo_s1"), 64)
	prezzo_s2, _ := strconv.ParseFloat(req.Form.Get("prezzo_s2"), 64)
	prezzo_s3, _ := strconv.ParseFloat(req.Form.Get("prezzo_s3"), 64)
	prezzo_s4, _ := strconv.ParseFloat(req.Form.Get("prezzo_s4"), 64)

	resp := queryCaricaPartita(sqlDB, casa, ospite, data, ora, tipo, prezzo_s1, prezzo_s2, prezzo_s3, prezzo_s4)
	fmt.Fprintf(w, resp)
}
func registraCliente(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	nome := req.Form.Get("nome")
	cognome := req.Form.Get("cognome")
	tel := req.Form.Get("telefono")
	dataN := req.Form.Get("dataNascita")
	email := req.Form.Get("email")
	passw := req.Form.Get("password")
	resp := queryRegCliente(sqlDB, nome, cognome, dataN, email, tel, passw)
	fmt.Fprintf(w, resp)
}
func loginCliente(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	email := req.Form.Get("email")
	passw := req.Form.Get("password")
	resp := queryLogCliente(sqlDB, email, passw)
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(resp)
}
func getPartite(w http.ResponseWriter, req *http.Request) {
	resp := queryGetPartite(sqlDB)
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(resp)
}
func confermaBiglietto(w http.ResponseWriter, req *http.Request) {
	body, _ := ioutil.ReadAll(req.Body)
	type Biglietto struct {
		Partita    string
		Prezzo     float64
		Stadio     string
		Settore    string
		Id_Partita int
	}

	type Data struct {
		Id_Cliente string
		Big        Biglietto
	}

	var data Data

	err := json.Unmarshal([]byte(body), &data)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}
	id_cliente, _ := strconv.Atoi(data.Id_Cliente)

	resp := queryInserisciBiglietto(sqlDB, data.Big.Id_Partita, id_cliente, data.Big.Partita, data.Big.Stadio, data.Big.Settore, data.Big.Prezzo)
	fmt.Fprintf(w, resp)
}
func getBiglietti(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	id_utente := req.Form.Get("id_cliente")
	resp := queryGetBiglietti(sqlDB, id_utente)
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(resp)
}
func getAbbonamenti(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	id_utente := req.Form.Get("id_cliente")
	resp := queryGetAbbonamenti(sqlDB, id_utente)
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(resp)
}
func getPostiSettore(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	settore := req.Form.Get("settore")
	stadio := req.Form.Get("stadio")
	tipo := req.Form.Get("tipo")
	resp := queryGetPostiSettore(sqlDB, stadio, settore, tipo)
	fmt.Fprintf(w, strconv.Itoa(resp))
}
func getAbbDisponibili(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	societa := req.Form.Get("societa")
	resp := queryGetAbbDisponibili(sqlDB, societa)
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(resp)
}
func inserisciAbbonamento(w http.ResponseWriter, req *http.Request) {
	body, _ := ioutil.ReadAll(req.Body)
	type Abb struct {
		Societa string
		Prezzo  float64
		Stadio  string
		Settore string
	}

	type Data struct {
		Id_Cliente string
		Abb        Abb
	}

	var data Data

	err := json.Unmarshal([]byte(body), &data)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}

	id_cliente, _ := strconv.Atoi(data.Id_Cliente)
	resp := queryInserisciAbbonamento(sqlDB, data.Abb.Societa, data.Abb.Stadio, data.Abb.Settore, data.Abb.Prezzo, id_cliente)
	fmt.Fprintf(w, resp)
}
func getPartiteSocieta(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	societa := req.Form.Get("societa")
	resp := queryGetPartiteSocieta(sqlDB, societa)
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(resp)
}
func aggiornaCostoAbb(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	societa := req.Form.Get("societa")
	settore1 := req.Form.Get("settore1")
	settore2 := req.Form.Get("settore2")
	settore3 := req.Form.Get("settore3")
	settore4 := req.Form.Get("settore4")
	resp := queryAggiornaPrezzoAbb(sqlDB, societa, settore1, settore2, settore3, settore4)
	fmt.Fprintf(w, resp)
}
func getBigliettiPartita(w http.ResponseWriter, req *http.Request) {
	req.ParseForm()
	societa := req.Form.Get("societa")
	avv := req.Form.Get("avversario")
	tipo := req.Form.Get("tipologia")
	resp := queryGetBigliettiPartita(sqlDB, societa, avv, tipo)
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(resp)
}
