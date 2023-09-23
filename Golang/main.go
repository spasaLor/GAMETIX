package main

import (
	"database/sql"
	"fmt"
	"log"
)

var sqlDB *sql.DB

func main() {

	sqlDB = startDB()
	startServer()
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
