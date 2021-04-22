CREATE DATABASE M_Peoples;

USE M_Peoples

CREATE TABLE Funcionarios(
	idFuncionario INT PRIMARY KEY IDENTITY
	,nome VARCHAR(200) NOT NULL
	,sobrenome VARCHAR(255) NOT NULL
)

ALTER TABLE Funcionarios
ADD DataNascimento DATE

