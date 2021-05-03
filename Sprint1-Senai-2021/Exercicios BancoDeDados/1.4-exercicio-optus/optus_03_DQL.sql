USE Optus;


SELECT * FROM TipoDeUsuarios

SELECT * FROM Usuarios

SELECT * FROM AlbunsEstilos

SELECT * FROM Albuns

SELECT * FROM Artistas

SELECT * FROM Estilos


-- listar todos os usuários administradores, sem exibir suas senhas
SELECT Nome, Email, idTipoUsuario FROM Usuarios
WHERE Usuarios.idTipoUsuario LIKE 1

-- listar todos os álbuns lançados após o um determinado ano de lançamento
SELECT Titulo AS Album, YEAR(DataLancamento) AS Lancamento, Localizacao, QtdMinutos AS Duração,  Artistas.Nome AS Artista 
FROM Albuns
INNER JOIN Artistas
ON Albuns.IdArtista = Artistas.IdArtista
WHERE Albuns.DataLancamento > '1980'

-- listar os dados de um usuário através do e-mail e senha
SELECT Nome, Email, idTipoUsuario FROM Usuarios
WHERE Email LIKE 'comum@comum.com' AND Senha LIKE 'C123'

