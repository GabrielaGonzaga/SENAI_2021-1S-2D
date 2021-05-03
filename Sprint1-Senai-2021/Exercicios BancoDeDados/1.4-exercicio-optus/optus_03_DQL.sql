USE Optus;


SELECT * FROM TipoDeUsuarios

SELECT * FROM Usuarios

SELECT * FROM AlbunsEstilos

SELECT * FROM Albuns

SELECT * FROM Artistas

SELECT * FROM Estilos


-- listar todos os usu�rios administradores, sem exibir suas senhas
SELECT Nome, Email, idTipoUsuario FROM Usuarios
WHERE Usuarios.idTipoUsuario LIKE 1

-- listar todos os �lbuns lan�ados ap�s o um determinado ano de lan�amento
SELECT Titulo AS Album, YEAR(DataLancamento) AS Lancamento, Localizacao, QtdMinutos AS Dura��o,  Artistas.Nome AS Artista 
FROM Albuns
INNER JOIN Artistas
ON Albuns.IdArtista = Artistas.IdArtista
WHERE Albuns.DataLancamento > '1980'

-- listar os dados de um usu�rio atrav�s do e-mail e senha
SELECT Nome, Email, idTipoUsuario FROM Usuarios
WHERE Email LIKE 'comum@comum.com' AND Senha LIKE 'C123'

