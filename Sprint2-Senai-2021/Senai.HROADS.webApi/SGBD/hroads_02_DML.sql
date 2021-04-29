--------------------------------------------------------
------ Inserções ------

-- Classes --
INSERT INTO Classes(Nome )
VALUES              ('Bárbaro')
					,('Cruzado')
					,('Caçadora')
					,('Monge')
					,('Necromante')
					,('Feiticeiro')
					,('Arcanista');

-- Tipo Hbalidade --
INSERT INTO TipoHabilidade(Nome)
VALUES				('Ataque')
					,('Defesa')
					,('Cura')
					,('Magia')
					,('Nenhuma');

-- Habilidades  --
INSERT INTO Habilidades(idTipoHabilidade, Nome)
VALUES				(1,'Lança Mortal')
					,(2,'Escudo Supremo')
					,(3,'Recuperar Vida')
					,(5,'Sem Hablidade');

-- Relação  --
INSERT INTO Relacao(idClasse, idHabilidade)
VALUES				(1, 1)
					,(1, 2)
					,(2, 2)
					,(3, 1)
					,(4, 3)
					,(4, 2)
					,(5, 4)
					,(6, 3)
					,(7, 4);


-- Personagens --
INSERT INTO Personagens(idClasse, Nome, CapacidadedeMaximaDeVida, CapacidadeMaximaDeMana, DataDeAtualização, DataDeCriacao)
VALUES				(1,'DeuBug', '100', '80', GETDATE(), 18/01/2019)
					,(2,'BitBug', '70', '100', GETDATE(), 17/03/2016)
					,(3,'Fer8', '75', '60', GETDATE(), 17/03/2016);



INSERT INTO TiposDeUsuarios (tipoUsuario)
VALUES			('Administrador')			
				,('Jogador')


INSERT INTO Usuarios (email, senha, idTipoUsuario)
VALUES			('admin@admin.com', 'admin', 1)			
				,('jogador@jogador.com', 'jogador', 2)


UPDATE Personagens SET idUsuario = 1




