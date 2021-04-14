


ALTER TABLE Funcionarios
ADD DataNascimento DATE

SELECT idfuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios

SELECT * FROM Funcionarios

SELECT idFuncionario, Nome, Sobrenome FROM Funcionarios

SELECT idFuncionario, Nome , Sobrenome FROM Funcionarios
WHERE nome = 'Catarina';

SELECT CONCAT (nome, ' ', sobrenome) AS nomeCompleto
FROM Funcionarios

SELECT nome, sobrenome FROM Funcionarios
ORDER BY nome ASC;