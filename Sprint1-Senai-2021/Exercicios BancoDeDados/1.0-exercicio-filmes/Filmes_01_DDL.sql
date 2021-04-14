
--Cria um banco de dados com o nome "Filmes"
CREATE DATABASE Filmes;

--Define o banco de dados "Filmes" como o principal (utilizado)
USE Filmes;

CREATE TABLE Generos
(
	idGenero	INT PRIMARY KEY IDENTITY 
	,Nome		VARCHAR(200) NOT NULL --N�O NULO
	 
);
CREATE TABLE Filmes
(
	idFilme	INT PRIMARY KEY IDENTITY 
	,idGenero INT FOREIGN KEY REFERENCES Generos (idGenero)
	,Titulo VARCHAR(150) NOT NULL
)

 
SELECT * FROM Filmes;

SELECT * FROM Generos;
SELECT Titulo, idGenero FROM Filmes;

--			Tabela	Coluna
INSERT INTO Generos	(Nome)
VALUES              ('A��o')
					,('Aventura');

DELETE FROM Generos WHERE idGenero = 4;

INSERT INTO Filmes (Titulo, idGenero)
VALUES				('Rambo', 1)
					,('Vingadores', 1)
					,('Ghost', 2)
					,('Di�rio de uma paix�o', 2);

UPDATE Generos
SET Nome = 'Romance'
WHERE  idGenero = 2;




