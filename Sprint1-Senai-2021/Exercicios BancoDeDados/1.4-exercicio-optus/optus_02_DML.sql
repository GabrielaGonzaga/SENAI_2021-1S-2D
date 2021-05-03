USE Optus;
GO

INSERT INTO Artistas(Nome)
VALUES				('Exemplo');
				  


INSERT INTO Estilos(Nome)
VALUES				 ('Rock')
					,('Pop')
					,('Jazz');


INSERT INTO Albuns(Titulo, DataLancamento, Localizacao, QtdMinutos, IdArtista)
VALUES			  ('Exemplo', '2002', 'Brasil', 45, 1)
		


INSERT INTO AlbunsEstilos(IdAlbum, IdEstilo)
VALUES			 (1,1)
				


INSERT INTO TipoDeUsuarios(nome)
VALUES				('Administrador') 
					,('Comum')


INSERT INTO Usuarios(Nome, Email, Senha, idTipoUsuario)
VALUES				('Administrador', 'administrador@administrador.com', 'A123', 1)
				   ,('Comum', 'comum@comum.com', 'C123', 2);


