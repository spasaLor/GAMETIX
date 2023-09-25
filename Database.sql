DROP DATABASE IF EXISTS Gametix;
CREATE DATABASE Gametix;
Use Gametix;

CREATE TABLE Societa (
    id_societa INTEGER PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(30) UNIQUE NOT NULL,
    localita VARCHAR(30) NOT NULL,
    sport VARCHAR(30) NOT NULL
);

CREATE TABLE Stadio (
    id_stadio INTEGER PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(30) NOT NULL UNIQUE,
    localita VARCHAR(30) NOT NULL,
    capacita INTEGER NOT NULL,
    id_proprietario INTEGER NOT NULL,
    FOREIGN KEY (id_proprietario) REFERENCES Societa (id_societa)
);

CREATE TABLE Settore (
    id_settore INTEGER PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(30) NOT NULL,
    capacita INTEGER NOT NULL,
    id_stadio INTEGER NOT NULL,
    costo_abbonamento DECIMAL(5,2) NOT NULL,
    FOREIGN KEY (id_stadio) REFERENCES Stadio (id_stadio)
);

CREATE TABLE Partita (
    id_partita INTEGER PRIMARY KEY AUTO_INCREMENT,
    sport VARCHAR(30) NOT NULL,
    data DATE NOT NULL,
    ora VARCHAR(6) NOT NULL,
    squadra_casa INTEGER NOT NULL,
    squadra_trasferta VARCHAR(30) NOT NULL,
    tipologia VARCHAR (20) NOT NULL,
    luogo INTEGER NOT NULL,
    prezzo_settore_1 DECIMAL(5,2) NOT NULL,
    prezzo_settore_2 DECIMAL(5,2) NOT NULL,
    prezzo_settore_3 DECIMAL(5,2) NOT NULL,
    prezzo_settore_4 DECIMAL(5,2) NOT NULL,
    UNIQUE(squadra_casa,data),
    FOREIGN KEY (luogo) REFERENCES Stadio(id_stadio),
    FOREIGN KEY (squadra_casa) REFERENCES Societa(id_societa)
);

CREATE TABLE Cliente (
    id_cliente INTEGER PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(30) NOT NULL,
    cognome VARCHAR(30) NOT NULL,
    data_nascita VARCHAR(11) NOT NULL,
    email VARCHAR(30) NOT NULL UNIQUE,
    num_tel VARCHAR(30),
    password VARCHAR(64) NOT NULL,
    saldo DECIMAL(6,2) NOT NULL
);

CREATE TABLE Biglietto (
    id_biglietto INT PRIMARY KEY AUTO_INCREMENT,
    id_partita INT NOT NULL,
    squadra_casa VARCHAR(30) NOT NULL,
    squadra_trasferta VARCHAR(30) NOT NULL,
    id_cliente INTEGER NOT NULL,
    stadio INTEGER NOT NULL,
    settore INTEGER NOT NULL,
    prezzo DECIMAL(5,2) NOT NULL,
    UNIQUE(id_cliente,id_partita),
    FOREIGN KEY (id_partita) REFERENCES Partita(id_partita),
    FOREIGN KEY (stadio) REFERENCES Stadio(id_stadio),
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (settore) REFERENCES Settore(id_settore)
);

CREATE TABLE Abbonamento (
    id_abbonamento INT PRIMARY KEY AUTO_INCREMENT,
    id_cliente INTEGER NOT NULL,
    id_societa INTEGER NOT NULL,
    id_stadio INTEGER NOT NULL,
    id_settore INTEGER NOT NULL,
    prezzo DECIMAL(5,2) NOT NULL,
    UNIQUE(id_cliente,id_societa),
    FOREIGN KEY (id_societa) REFERENCES Societa(id_societa),
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (id_settore) REFERENCES Settore (id_settore),
    FOREIGN KEY (id_stadio) REFERENCES Stadio(id_stadio)
);

CREATE TABLE Impiegato (
    id_impiegato INTEGER PRIMARY KEY AUTO_INCREMENT,
    id_societa INTEGER NOT NULL,
    nome VARCHAR(20) NOT NULL,
    cognome VARCHAR(30) NOT NULL,
    email VARCHAR(30) NOT NULL UNIQUE,
    password VARCHAR(64) NOT NULL,
    FOREIGN KEY (id_societa) REFERENCES Societa (id_societa)
);

-- QUERY PER LA POPOLAZIONE DEL DB


-- società Calcio
insert into societa values (default,'ACR Messina','Messina','Calcio');
insert into societa values (default,'Catania Calcio','Catania','Calcio');
insert into societa values (default,'Palermo FC','Palermo','Calcio');

-- società volley
insert into societa values (default,'Akademia Messina','Messina','Volley');
insert into societa values (default,'Pallavolo Catania','Catania','Volley');
insert into societa values (default,'Palermo Volley','Palermo','Volley');

-- società basket
insert into societa values (default,'Basket Messina','Messina','Basket');
insert into societa values (default,'Alfa Basket Catania','Catania','Basket');
insert into societa values (default,'Green Basket Palermo','Palermo','Basket');

-- impiegati
insert into impiegato values(default,1,"Utente","Prova","prova@example.com","6258a5e0eb772911d4f92be5b5db0e14511edbe01d1d0ddd1d5a2cb9db9a56ba");

-- clienti registrati alla piattaforma
insert into cliente values (default,'Utente','Prova','12/09/1987','prova@example.com',null,'6258a5e0eb772911d4f92be5b5db0e14511edbe01d1d0ddd1d5a2cb9db9a56ba',0.0);

-- Stadi per le società
insert into stadio values (default,'San Filippo','Messina',40,1);
insert into stadio values (default,'Angelo Massimino','Catania',50,2);
insert into stadio values (default,'Renzo Barbera','Palermo',60,3);

insert into stadio values (default,'PalaRescifina','Messina',40,4);
insert into stadio values (default,'PalaCatania','Catania',50,5);
insert into stadio values (default,'PalaFondoPatti','Palermo',60,6);

insert into stadio values (default,'PalaSanFilippo','Messina',40,7);
insert into stadio values(default,'PalaDaVinci','Catania',50,8);
insert into stadio values (default,'PalaMangano','Palermo',60,9);

-- settori Massimino
insert into settore values(default,'Tribuna A',10,2,20);
insert into settore values(default,'Tribuna B',10,2,15);
insert into settore values(default,'Curva Nord',15,2,10);
insert into settore values(default,'Curva Sud',15,2,10);

-- settori San Filippo;
insert into settore values(default,'Tribuna A',10,1,10);
insert into settore values(default,'Tribuna B',10,1,15);
insert into settore values(default,'Tribuna C',10,1,20);
insert into settore values(default,'Curva Sud',10,1,25);

-- settori Barbera
insert into settore values(default,'Tribuna A',20,3,10);
insert into settore values(default,'Tribuna Laterale',20,3,15);
insert into settore values(default,'Curva Nord',10,3,20);
insert into settore values(default,'Curva Sud',10,3,25);

-- settori PalaRescifina
insert into settore values(default,'Settore A',10,4,10);
insert into settore values(default,'Settore B',10,4,15);
insert into settore values(default,'Settore C',15,4,20);
insert into settore values(default,'Settore D',15,4,25);

-- settori PalaCatania;
insert into settore values(default,'Settore A',10,5,10);
insert into settore values(default,'Settore B',10,5,15);
insert into settore values(default,'Settore C',15,5,20);
insert into settore values(default,'Settore D',15,5,25);

-- settori PalaFondoPatti
insert into settore values(default,'Settore A',20,6,10);
insert into settore values(default,'Settore B',20,6,15);
insert into settore values(default,'Settore C',10,6,20);
insert into settore values(default,'Settore D',10,6,25);

-- settori PalaSanFilippo
insert into settore values(default,'Settore A',10,7,10);
insert into settore values(default,'Settore B',10,7,15);
insert into settore values(default,'Settore C',15,7,20);
insert into settore values(default,'Settore D',15,7,25);

-- settori PalaDaVinci;
insert into settore values(default,'Settore A',10,8,10);
insert into settore values(default,'Settore B',10,8,15);
insert into settore values(default,'Settore C',15,8,20);
insert into settore values(default,'Settore D',15,8,25);

-- settori PalaMangano;
insert into settore values(default,'Settore A',20,9,10);
insert into settore values(default,'Settore B',20,9,15);
insert into settore values(default,'Settore C',10,9,20);
insert into settore values(default,'Settore D',10,9,25);

-- partite
insert into partita values(default,'Calcio','2023/09/20','15:00',1,'Monopoli Calcio','Campionato',1,10,20,30,40);
insert into partita values(default,'Calcio','2023/09/26','15:00',2,'Siracusa Calcio','Campionato',2,10,20,30,40);
insert into partita values(default,'Calcio','2023/10/02','20:45',3,'Bari','Campionato',3,10,20,30,40);
insert into partita values(default,'Volley','2023/09/30','18:00',4,'Gela Volley','Coppa',4,10,20,30,40);
insert into partita values(default,'Volley','2023/10/07','16:00',5,'Pallavolo Trapani','Campionato',5,10,20,30,40);
insert into partita values(default,'Volley','2023/10/06','17:00',6,'Milazzo Volley','Campionato',6,10,20,30,40);
insert into partita values(default,'Basket','2023/10/04','18:00',7,'Ragusa Basket','Campionato',7,10,20,30,40);
insert into partita values(default,'Basket','2023/09/30','18:00',8,'Pallacanestro Enna','Coppa',8,10,20,30,40);
insert into partita values(default,'Basket','2023/09/29','20:00',9,'Basket Agrigento','Amichevole',9,10,20,30,40);


