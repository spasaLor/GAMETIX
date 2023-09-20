package main

import (
	"database/sql"
)

var sqlDB *sql.DB

func main() {

	sqlDB = startDB()
	startServer()
}
