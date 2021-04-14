-----------		Exercicio 2 Pessoas		-----------

CREATE DATABASE Pessoas;

USE Pessoas;

CREATE TABLE Pessoas
(
	idPessoa	INT PRIMARY KEY IDENTITY 
	,Nome		VARCHAR(200) NOT NULL --N�O NULO
	 
);

CREATE TABLE Telefones
(
	idTelefone	INT PRIMARY KEY IDENTITY 
	,Descricao VARCHAR(150) NOT NULL
	,idPessoa INT FOREIGN KEY REFERENCES Pessoas (idPessoa)
)

CREATE TABLE Emails
(
	idEmail	INT PRIMARY KEY IDENTITY 
	,Descricao VARCHAR(150) NOT NULL
	,idPessoa INT FOREIGN KEY REFERENCES Pessoas (idPessoa)
)

CREATE TABLE CNHs
(
	idCNH	INT PRIMARY KEY IDENTITY 
	,Descricao VARCHAR(150) NOT NULL
	,idPessoa INT FOREIGN KEY REFERENCES Pessoas (idPessoa)
)


-- Inser��es --

-- Nomes --
INSERT INTO Pessoas(Nome)
VALUES              ('Gabriela')
					,('Camila');

-- Telefones --
INSERT INTO Telefones(Descricao, idPessoa)
VALUES              ('11999999999', 1)
					,('11888888888', 2);

DELETE FROM Telefones WHERE idTelefone = 2;

-- Emails --
INSERT INTO	Emails(Descricao, idPessoa)
VALUES              ('gabriela@modelo.com', 1)
					,('gabriela@modelo.com', 2);

-- CNHs --
INSERT INTO	CNHs(Descricao, idPessoa)
VALUES              ('12345678', 1)
					,('22233344', 2);

------ Fim -------

SELECT * FROM Pessoas;
SELECT * FROM Telefones;
SELECT * FROM Emails;
SELECT * FROM CNHs;
