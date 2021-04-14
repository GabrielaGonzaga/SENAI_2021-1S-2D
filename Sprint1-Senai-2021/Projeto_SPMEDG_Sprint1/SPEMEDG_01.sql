---- In�cio CREATES ----
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
	,endere�o			VARCHAR(200)		NOT NULL
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
	,endere�o		VARCHAR(200) NOT NULL
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


--Criar fun��o (Escalar)

CREATE FUNCTION  QuantidadeDeMedicos (@Especialidades VARCHAR(200))
--Tipo de dados do retorno
RETURNS INT 
--Como
AS 
	--In�cio da fun��o
	BEGIN
	--Declarar vari�vel		--Nome		   --Tipo vari�vel
	DECLARE					 @Number		INT
	--Contagem de n�meros de ids	 --Da tabelas M�dicos
	SELECT  @Number = COUNT(IdMedico) FROM Medicos m
	-- Add Especialidades
	INNER JOIN Especialidades e
	--Rela��o dos ids										--Nome da especialidade contada
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


---- INSERTS ----

-- Tipos de Perfis --
INSERT INTO TipoPerfil (tituloTipoPerfil)
VALUES					('Administrador')
						,('M�dico')
						,('Paciente');

-- PerfiS --
INSERT INTO Perfis (idTipoPerfil, nomeUsuario, email, senha)
VALUES				(1, 'Fernando Strada',   'fernando.strada@spmedicalgroup.com.br', 'senha@123')
					,(2, 'Ricardo Lemos',    'ricardo.lemos@spmedicalgroup.com.br',   'senha@124')
					,(2, 'Roberto Possarle', 'roberto.possarle@spmedicalgroup.com.br','senha@125')
					,(2, 'Helena Strada',    'helena.souza@spmedicalgroup.com.br ',   'senha@126')
					,(3, 'Ligia',	          'ligia@gmail.com',	 'senha@127')
					,(3, 'Alexandre',	      'alexandre@gmail.com', 'senha@128')
					,(3, 'Fernando',		  'fernando@gmail.com',  'senha@129')
					,(3, 'Henrique',		  'henrique@gmail.com',  'senha@130')
					,(3, 'Jo�o',			  'joao@hotmail.com',	 'senha@131')
					,(3, 'Bruno',			  'bruno@gmail.com',	 'senha@132')
					,(3, 'Mariana',			  'mariana@outlook.com', 'senha@133');



-- Paciente Teste --
INSERT INTO Pacientes (idTipoPerfil, nome, email, dataNascimento, telefone, RG, CPF, endere�o)
VALUES					(3,	'Ligia',	  'ligia@gmail.com',	'13/10/1983', '11 3456-7654',   '43522543-5',  '948.398.590-00',	'Rua Estado de Israel 240,�S�o Paulo, Estado de S�o Paulo, 04022-000')							
						,(3, 'Alexandre', 'alexandre@gmail.com','23/07/2001', '11 98765-6543',	'32654345-7',  '735.569.440-57',	'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200')
						,(3, 'Fernando',  'fernando@gmail.com', '10/10/1978', '11 97208-4453',	'54636525-3',  '168.393.380-02',	'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200' )
						,(3, 'Henrique',  'henrique@gmail.com', '13/10/1985', '11 3456-6543',	'54366362-5',  '143.326.547-65',	'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030')
						,(3, 'Jo�o',	  'joao@hotmail.com',	'27/08/1975', '11 7656-6377',	'53254444-1',  '913.053.480-10',	'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380')
						,(3, 'Bruno',	  'bruno@gmail.com',	'21/03/1972', '11 95436-8769',	'54566266-7',  '797.992.990-04',	'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001')
						,(3, 'Mariana',	  'mariana@outlook.com','05/03/2018', '             ',	'54566266-8',  '137.719.130-39',	'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');


-- Especialidades --
INSERT INTO Especialidades (nomeEspecialidade)
VALUES						('Acupuntura')
							,('Anestesiologia')
							,('Angiologia')
							,('Cardiologia')
							,('Cirurgia Cardiovascular')
							,('Cirurgia da M�o')
							,('Cirurgia do Aparelho Digestivo')
							,('Cirurgia Geral')
							,('Cirurgia Pedi�trica')
							,('Cirurgia Pl�stica')
							,('Cirurgia Tor�cica')
							,('Cirurgia Vascular')
							,('Dermatologia')
							,('Radioterapia')
							,('Urologia')
							,('Pediatria')
							,('Psiquiatria');


-- Cl�nicas --
INSERT INTO Clinicas(clinica, razaoSocial, endere�o)
VALUES				('Clinica Possarle', 'SP Medical Group', 'Av. Bar�o Limeira, 532, S�o Paulo, SP' );


-- M�dico --
INSERT INTO Medicos (idTipoPerfil, idEspecialidade, CRM, nome, email, CNPJ, idClinica)
VALUES				(2, 2,   '54356-SP', 'Ricardo Lemos',    'ricardo.lemos@spmedicalgroup.com.br',    '86.400.902/0001-30', 1)
					,(2, 17, '53452-SP', 'Roberto Possarle', 'roberto.possarle@spmedicalgroup.com.br', '86.400.903/0001-30', 1)
					,(2, 16, '65463-SP', 'Helena Strada',    'helena.souza@spmedicalgroup.com.br ',    '86.400.904/0001-30', 1);


--Consulta Teste --
INSERT INTO Consultas (idPaciente, idMedico, dataConsulta, situacao)
VALUES				   (7, 3, '20/01/2020 15:00', 'Realizada' )
					   ,(2, 2, '06/01/2020 10:00', 'Cancelada' )
					   ,(3, 2, '07/02/2020 11:00', 'Realizada' )
					   ,(2, 2, '06/02/2018 10:00', 'Realizada' )
					   ,(4, 1, '07/02/2019 11:00', 'Cancelada' )
					   ,(7, 3, '08/03/2020 15:00', 'Agendada' )
					   ,(4, 1, '09/03/2020 11:00', 'Agendada' );

---- FIM INSERTS ----




---- SELECTS ----

-- Medicos e suas especialidades --
SELECT Medicos.nome AS Medicos, Especialidades.nomeEspecialidade AS Especialidade FROM Medicos
INNER JOIN Especialidades
ON Medicos.idEspecialidade = Especialidades.idEspecialidade;



-- Paciente e sua data de consulta --
SELECT Pacientes.nome AS Paciente, Consultas.dataConsulta FROM Consultas
INNER JOIN Pacientes
ON Pacientes.idPaciente = Consultas.idPaciente;



-- Paciente, sua data de consulta, especialidade e medico --
SELECT Pacientes.nome AS Paciente, Medicos.nome AS Medico, Consultas.dataConsulta, Especialidades.nomeEspecialidade AS Especialidade FROM Pacientes
INNER JOIN Consultas 
ON Pacientes.idPaciente = Consultas.idPaciente
INNER JOIN Medicos
ON Consultas.idMedico = Medicos.idMedico
INNER JOIN Especialidades
ON Medicos.idEspecialidade = Especialidades.idEspecialidade;



-- Quantidade de usu�rios ap�s realizar a importa��o do banco de dados --
SELECT COUNT(idPerfil) AS QntHabilidades FROM Perfis


-- Idade do usu�rio a partir da data de nascimento --
SELECT Pacientes.nome, DATEDIFF(hour, Pacientes.dataNascimento, getdate()) / 8766 AS Idade 
FROM Pacientes


-- Evento para que a idade do usu�rio seja calculada todos os dias--
-

-- Quantidade de m�dicos de uma determinada especialidade --

SELECT dbo.QuantidadeDeMedicos('Psiquiatria') AS [Qntd Medicos];


-- Idade do usu�rio a partir de uma determinada stored procedure --

EXEC idadeUsuario @Pacientes = 'Bruno', @idadeUsuario = idadeUsuario 

---- FIM SELECTS ----