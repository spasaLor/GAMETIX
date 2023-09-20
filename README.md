# GameTix
A University project based on C#, Python and Golang.

La seguente applicazione è stata sviluppata in ambiente Windows, utilizzando come IDE Visual Studio, pertanto non si è a conoscenza di eventuali problemi legati all'esecuzione su altri IDE.
Il consiglio è di usare Visual Studio per l'esecuzione dell'applicazione, sfruttando la possibilità di creare terminali direttamente nell'ambiente di sviluppo.

## Istruzioni per l'esecuzione
### Creazione database MySQL
Per creare il database sarà necessario aprire un terminale MySQL ed eseguire il comando: ```source path_file_sql``` (es. source C:\Users..\Documenti..\GAMETIX\Database.sql) in questo modo sarà creato il database con tutte le tabelle ed alcune di queste saranno popolate per l'esecuzione di query di base.

In particolare la tabella 'Societa' conterrà 6 Societa sportive divise in 3 sport: ACR Messina,Catania Calcio ed FC Palermo per il calcio; Akademia Messina, Pallavolo Catania e Palermo Volley per il Volley; Basket Messina, Alfa Basket Catania e Green Basket Palermo per quanto riguarda il basket.
Queste società permetteranno di registrare impiegati che saranno autorizzati ad inserire le partite delle squadre. Le altre tabelle popolate sono: 'Stadio', 'Settore', 'Cliente', 'Impiegato' e 'Partita'.
### Avvio Server Golang
Prima di avviare il server, è fondamentale modificare la riga 81 che contiene il comando di connessione al database, al posto di *user* e *password* bisogna inserire le proprie credenziali per l'accesso a MySQL, altrimenti la connessione del server al database fallirà.

Una volta effettuata questa modifica si potranno compilare e linkare i file .go eseguendo da terminale il comando: ```go build main.go databaseManagement.go server.go``` a questo punto verrà creato l'eseguibile ```main.exe``` cha portà essere lanciato da terminale tramite il comando: ```./main```.

Dopo aver effettuato queste due oprerazioni sarà possibile eseguire i due client.
### Avvio Client C#
Prima dell'avvio del client lato acquirente è necessario verificare di avere installato il framework Newtonsoft.JSON. Per fare ciò, si osservino i seguenti passi:
- su Visual Studio 2022, andare in alto nella voce PROGETTO
- cliccare sulla voce GESTISCI PACCHETTI NUGET...
- cercare sulla barra di ricerca NETWONSOFT ed installare il pacchetto.

### Avvio Client Python
Prima dell'avvio del client lato venditore è necessario installare alcune dipendenze:
- pip install requests
- pip install tk
Una volta fatto ciò, sarà possibile eseguire il comando python ```app.py```  per avviare il client.

