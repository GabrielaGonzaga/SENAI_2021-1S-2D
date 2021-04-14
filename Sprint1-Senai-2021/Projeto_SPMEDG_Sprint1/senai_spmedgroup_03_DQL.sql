
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



-- Quantidade de usuários após realizar a importação do banco de dados --
SELECT COUNT(idPerfil) AS QntHabilidades FROM Perfis


-- Idade do usuário a partir da data de nascimento --
SELECT Pacientes.nome, DATEDIFF(hour, Pacientes.dataNascimento, getdate()) / 8766 AS Idade 
FROM Pacientes


-- Evento para que a idade do usuário seja calculada todos os dias--


-- Quantidade de médicos de uma determinada especialidade --

SELECT dbo.QuantidadeDeMedicos('Psiquiatria') AS [Qntd Medicos];


-- Idade do usuário a partir de uma determinada stored procedure --

EXEC idadeUsuario @Pacientes = 'Bruno', @idadeUsuario = idadeUsuario 


---- FIM SELECTS ----