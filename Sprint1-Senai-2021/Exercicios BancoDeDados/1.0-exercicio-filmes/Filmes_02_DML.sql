 
USE Filmes;

--			Tabela	Coluna
INSERT INTO Generos	(Nome)
VALUES              ('Ação')
					,('Aventura');

DELETE FROM Generos WHERE idGenero = 4;

INSERT INTO Filmes (Titulo, idGenero)
VALUES				('Rambo', 1)
					,('Vingadores', 1)
					,('Ghost', 2)
					,('Diário de uma paixão', 2);

UPDATE Generos
SET Nome = 'Romance'
WHERE  idGenero = 2;