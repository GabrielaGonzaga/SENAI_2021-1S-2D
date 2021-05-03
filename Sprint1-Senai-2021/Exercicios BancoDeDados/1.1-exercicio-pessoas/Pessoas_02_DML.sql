-----------		Exercicio 2 Pessoas		-----------

CREATE DATABASE Pessoas;

USE Pessoas;

CREATE TABLE Pessoas
(
	idPessoa	INT PRIMARY KEY IDENTITY 
	,Nome		VARCHAR(200) NOT NULL --NÃO NULO
	 
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

