---- Início CREATES ----
CREATE DATABASE SPMEDG;

USE SPMEDG;


CREATE TABLE  TipoPerfil
(
	idTipoPerfil		INT PRIMARY KEY IDENTITY
	,tituloTipoPerfil	VARCHAR(200) UNIQUE NOT NULL
);


CREATE TABLE Perfis
(
	idPerfil			INT PRIMARY KEY IDENTITY
	,idTipoPerfil		INT FOREIGN KEY REFERENCES TipoPerfil (idTipoPerfil)
	,nomeUsuario		VARCHAR(200) NOT NULL
	,email				VARCHAR(200) UNIQUE NOT NULL
	,senha				VARCHAR(200) NOT NULL
);


CREATE TABLE  Pacientes
(
	idPaciente			INT PRIMARY KEY IDENTITY
	,idTipoPerfil		INT FOREIGN KEY REFERENCES TipoPerfil (idTipoPerfil)
	,nome				VARCHAR(200)		NOT NULL
	,email				VARCHAR(200) UNIQUE NOT NULL
	,dataNascimento		SMALLDATETIME		NOT NULL
	,telefone			VARCHAR(18)	 UNIQUE NULL
	,RG					VARCHAR(12)	 UNIQUE	NOT NULL
	,CPF				VARCHAR(14)  UNIQUE	NOT NULL
	,endereço			VARCHAR(200)		NOT NULL
);


CREATE TABLE  Especialidades
(
	idEspecialidade		INT PRIMARY KEY IDENTITY
	,nomeEspecialidade	VARCHAR(200) NOT NULL
);


CREATE TABLE  Clinicas
(
	idClinica		INT PRIMARY KEY IDENTITY
	,clinica		VARCHAR(200) NOT NULL
	,razaoSocial	VARCHAR(200) NOT NULL
	,endereço		VARCHAR(200) NOT NULL
)


CREATE TABLE  Medicos
(
	idMedico			INT PRIMARY KEY IDENTITY
	,idTipoPerfil		INT FOREIGN KEY REFERENCES TipoPerfil (idTipoPerfil)
	,idEspecialidade	INT FOREIGN KEY REFERENCES Especialidades (idEspecialidade)
	,CRM				VARCHAR(10)	 UNIQUE	NOT NULL
	,nome				VARCHAR(200)		NOT NULL
	,email				VARCHAR(200) UNIQUE NOT NULL
	,CNPJ				VARCHAR(18)	 UNIQUE	NOT NULL
	,idClinica			INT FOREIGN KEY REFERENCES Clinicas (idClinica)
);



CREATE TABLE  Consultas
(
	idConsulta			INT PRIMARY KEY IDENTITY
	,idPaciente			INT FOREIGN KEY REFERENCES Pacientes  (idPaciente)
	,idMedico			INT FOREIGN KEY REFERENCES Medicos    (idMedico)
	,dataConsulta		SMALLDATETIME NOT NULL
	,situacao			VARCHAR(200)  NOT NULL
);


--Criar função (Escalar)

CREATE FUNCTION  QuantidadeDeMedicos (@Especialidades VARCHAR(200))
--Tipo de dados do retorno
RETURNS INT 
--Como
AS 
	--Início da função
	BEGIN
	--Declarar variável		--Nome		   --Tipo variável
	DECLARE					 @Number		INT
	--Contagem de números de ids	 --Da tabelas Médicos
	SELECT  @Number = COUNT(IdMedico) FROM Medicos m
	-- Add Especialidades
	INNER JOIN Especialidades e
	--Relação dos ids										--Nome da especialidade contada
	ON m.IdEspecialidade = e.IdEspecialidade WHERE e.nomeEspecialidade = @Especialidades
	--Retornar contagem 
	RETURN @Number
--Fim 
END;



CREATE PROCEDURE idadeUsuario @Pacientes varchar(30), @idadeUsuario VARCHAR
AS
SELECT  p.nome, DATEDIFF(hour,  p.dataNascimento, getdate()) / 8766 AS Idade FROM Pacientes p
WHERE  p.nome = @Pacientes AND @idadeUsuario = @idadeUsuario;
GO

---- Fim CREATES ----







