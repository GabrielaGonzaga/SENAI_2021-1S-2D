
CREATE DATABASE inlock_games_manha

USE inlock_games_manha


CREATE TABLE Estudios(
	idEstudio		INT PRIMARY KEY IDENTITY
	,nomeEstudio	VARCHAR (150) NOT NULL
)


CREATE TABLE Jogos(
	idJogo			INT PRIMARY KEY IDENTITY
	,nomeJogo		VARCHAR (150) NOT NULL
	,descricao		VARCHAR (300) NOT NULL
	,dataLancamento DATE NOT NULL
	,valor			VARCHAR (100)
	,idEstudio		INT FOREIGN KEY REFERENCES Estudios (idEstudio) 
)

sp_RENAME 'Jogos.dataNascimento', 'dataLancamento', 'COLUMN'

CREATE TABLE TiposDeUsuarios(
	idTipoUsuario	INT PRIMARY KEY IDENTITY
	,titulo			VARCHAR (150) NOT NULL
)

CREATE TABLE Usuarios(
	idUsuario		INT PRIMARY KEY IDENTITY
	,email			VARCHAR (200) UNIQUE NOT NULL
	,senha			VARCHAR (200) NOT NULL
	,idTipoUsuario  INT FOREIGN KEY REFERENCES TiposDeUsuarios (idTipoUsuario)
)


