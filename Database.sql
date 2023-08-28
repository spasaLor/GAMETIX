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
    proprietario VARCHAR(30) NOT NULL,
    FOREIGN KEY (proprietario) REFERENCES Societa (nome)
);

CREATE TABLE Settore (
    id_settore INTEGER PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(30) NOT NULL,
    capacita INTEGER NOT NULL,
    stadio VARCHAR(30) NOT NULL,
    costo_abbonamento DECIMAL(5,2) NOT NULL,
    UNIQUE(nome,stadio),
    FOREIGN KEY (stadio) REFERENCES Stadio (nome)
);

CREATE TABLE Partita (
    id_partita INTEGER PRIMARY KEY AUTO_INCREMENT,
    sport VARCHAR(30) NOT NULL,
    data DATE NOT NULL,
    ora VARCHAR(6) NOT NULL,
    squadra_casa VARCHAR(30) NOT NULL,
    squadra_trasferta VARCHAR(30) NOT NULL,
    tipologia VARCHAR (20) NOT NULL,
    luogo VARCHAR(30) NOT NULL,
    prezzo_settore_1 DECIMAL(5,2) NOT NULL,
    prezzo_settore_2 DECIMAL(5,2) NOT NULL,
    prezzo_settore_3 DECIMAL(5,2) NOT NULL,
    prezzo_settore_4 DECIMAL(5,2) NOT NULL,
    UNIQUE(squadra_casa,data),
    FOREIGN KEY (luogo) REFERENCES Stadio(nome),
    FOREIGN KEY (squadra_casa) REFERENCES Societa(nome)
);

CREATE TABLE Cliente (
    id_cliente INTEGER PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(30) NOT NULL,
    cognome VARCHAR(30) NOT NULL,
    data_nascita VARCHAR(11) NOT NULL,
    email VARCHAR(30) NOT NULL UNIQUE,
    num_tel VARCHAR(30),
    password VARCHAR(100) NOT NULL
);

CREATE TABLE Biglietto (
    id_biglietto INT PRIMARY KEY AUTO_INCREMENT,
    id_partita INT NOT NULL,
    partita VARCHAR(50) NOT NULL,
    id_cliente INTEGER NOT NULL,
    stadio VARCHAR(50) NOT NULL,
    settore VARCHAR(30) NOT NULL,
    prezzo DECIMAL(5,2) NOT NULL,
    UNIQUE(id_cliente,partita),
    FOREIGN KEY (id_partita) REFERENCES Partita(id_partita),
    FOREIGN KEY (stadio) REFERENCES Stadio(nome),
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (settore) REFERENCES Settore(nome)
);

CREATE TABLE Abbonamento (
    id_abbonamento INT PRIMARY KEY AUTO_INCREMENT,
    id_cliente INTEGER NOT NULL,
    societa VARCHAR(30) NOT NULL,
    stadio VARCHAR(30) NOT NULL,
    settore VARCHAR(30) NOT NULL,
    prezzo DECIMAL(5,2) NOT NULL,
    UNIQUE(id_cliente,societa),
    FOREIGN KEY (societa) REFERENCES Societa(nome),
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (settore) REFERENCES Settore (nome)
);

CREATE TABLE Impiegato (
    id_impiegato INTEGER PRIMARY KEY AUTO_INCREMENT,
    societa VARCHAR(30) NOT NULL,
    nome VARCHAR(20) NOT NULL,
    cognome VARCHAR(30) NOT NULL,
    email VARCHAR(30) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    FOREIGN KEY (societa) REFERENCES Societa (nome)
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

-- impiegati per le società
insert into impiegato values (default,'ACR Messina','Marco','Rossi','rossim@gmail.com','265e6da75a33deaf9fbacd8386b6ccefd5c19f044c3b33a4b4c7a5b34d5eb203');
insert into impiegato values (default,'Akademia Messina','Luigi','Ferrara','ferraral@gmail.com','92bfa946a4a4c521d2112a6c8ff15a0b64dc7dc92cbd18e92ea65631db325c3d');
insert into impiegato values (default,'Basket Messina','Antonio','Verdi','verdia@gmail.com','4aebc2b073d401ef015c8617092d8b49fe8d32f552670a3eb4a7e368139e4ed2');

-- clienti registrati alla piattaforma
insert into cliente values (default,'Lorenzo','Merlino','12/09/1987','merlinol@gmail.com',null,'40bcb10892c5ba4f61889e5fb36751c61f5e93bdf8853a21447934a38ef4e63d');
insert into cliente values (default,'Silvano','Gialli','02/05/1997','giallis@gmail.com',null,'9657a46bac83f06497ea432d2e787a8a893e92d26829cee257210e6f885c441c');

-- Stadi per le società
insert into stadio values (default,'San Filippo','Messina',40,'ACR Messina');
insert into stadio values (default,'Angelo Massimino','Catania',50,'Catania Calcio');
insert into stadio values (default,'Renzo Barbera','Palermo',60,'Palermo FC');

insert into stadio values (default,'PalaRescifina','Messina',40,'Akademia Messina');
insert into stadio values (default,'PalaCatania','Catania',50,'Pallavolo Catania');
insert into stadio values (default,'PalaFondoPatti','Palermo',60,'Palermo Volley');

insert into stadio values (default,'PalaSanFilippo','Messina',40,'Basket Messina');
insert into stadio values(default,'PalaDaVinci','Catania',50,'Alfa Basket Catania');
insert into stadio values (default,'PalaMangano','Palermo',60,'Green Basket Palermo');

-- settori Massimino
insert into settore values(default,'Tribuna A',10,'Angelo Massimino',20);
insert into settore values(default,'Tribuna B',10,'Angelo Massimino',15);
insert into settore values(default,'Curva Nord',15,'Angelo Massimino',10);
insert into settore values(default,'Curva Sud',15,'Angelo Massimino',10);

-- settori San Filippo;
insert into settore values(default,'Tribuna A',10,'San Filippo',0);
insert into settore values(default,'Tribuna B',10,'San Filippo',0);
insert into settore values(default,'Tribuna C',10,'San Filippo',0);
insert into settore values(default,'Curva Sud',10,'San Filippo',0);

-- settori Barbera
insert into settore values(default,'Tribuna A',20,'Renzo Barbera',0);
insert into settore values(default,'Tribuna Laterale',20,'Renzo Barbera',0);
insert into settore values(default,'Curva Nord',10,'Renzo Barbera',0);
insert into settore values(default,'Curva Sud',10,'Renzo Barbera',0);

-- settori PalaRescifina
insert into settore values(default,'Settore A',10,'PalaRescifina',0);
insert into settore values(default,'Settore B',10,'PalaRescifina',0);
insert into settore values(default,'Settore C',15,'PalaRescifina',0);
insert into settore values(default,'Settore D',15,'PalaRescifina',0);

-- settori PalaCatania;
insert into settore values(default,'Settore A',10,'PalaCatania',0);
insert into settore values(default,'Settore B',10,'PalaCatania',0);
insert into settore values(default,'Settore C',15,'PalaCatania',0);
insert into settore values(default,'Settore D',15,'PalaCatania',0);

-- settori PalaFondoPatti
insert into settore values(default,'Settore A',20,'PalaFondoPatti',0);
insert into settore values(default,'Settore B',20,'PalaFondoPatti',0);
insert into settore values(default,'Settore C',10,'PalaFondoPatti',0);
insert into settore values(default,'Settore D',10,'PalaFondoPatti',0);

-- settori PalaSanFilippo
insert into settore values(default,'Settore A',10,'PalaSanFilippo',0);
insert into settore values(default,'Settore B',10,'PalaSanFilippo',0);
insert into settore values(default,'Settore C',15,'PalaSanFilippo',0);
insert into settore values(default,'Settore D',15,'PalaSanFilippo',0);

-- settori PalaDaVinci;
insert into settore values(default,'Settore A',10,'PalaDaVinci',0);
insert into settore values(default,'Settore B',10,'PalaDaVinci',0);
insert into settore values(default,'Settore C',15,'PalaDaVinci',0);
insert into settore values(default,'Settore D',15,'PalaDaVinci',0);

-- settori PalaMangano;
insert into settore values(default,'Settore A',20,'PalaMangano',0);
insert into settore values(default,'Settore B',20,'PalaMangano',0);
insert into settore values(default,'Settore C',10,'PalaMangano',0);
insert into settore values(default,'Settore D',10,'PalaMangano',0);

-- partite
insert into partita values(default,'Calcio','2023/09/20','15:00','ACR Messina','Monopoli Calcio','Campionato','San Filippo',30,20,10,10);
insert into partita values(default,'Basket','2023/09/24','18:00','Basket Messina','Ragusa Basket','Campionato','PalaSanFilippo',20.50,20.50,10,10);
insert into partita values(default,'Volley','2023/09/30','18:00','Akademia Messina','Gela Volley','Coppa','PalaRescifina',23.50,23.50,10,10);