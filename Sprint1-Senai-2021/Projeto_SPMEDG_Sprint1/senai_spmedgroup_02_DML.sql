
---- INSERTS ----

-- Tipos de Perfis --
INSERT INTO TipoPerfil (tituloTipoPerfil)
VALUES					('Administrador')
						,('Médico')
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
					,(3, 'João',			  'joao@hotmail.com',	 'senha@131')
					,(3, 'Bruno',			  'bruno@gmail.com',	 'senha@132')
					,(3, 'Mariana',			  'mariana@outlook.com', 'senha@133');



-- Paciente Teste --
INSERT INTO Pacientes (idTipoPerfil, nome, email, dataNascimento, telefone, RG, CPF, endereço)
VALUES					(3,	'Ligia',	  'ligia@gmail.com',	'13/10/1983', '11 3456-7654',   '43522543-5',  '948.398.590-00',	'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000')							
						,(3, 'Alexandre', 'alexandre@gmail.com','23/07/2001', '11 98765-6543',	'32654345-7',  '735.569.440-57',	'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200')
						,(3, 'Fernando',  'fernando@gmail.com', '10/10/1978', '11 97208-4453',	'54636525-3',  '168.393.380-02',	'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200' )
						,(3, 'Henrique',  'henrique@gmail.com', '13/10/1985', '11 3456-6543',	'54366362-5',  '143.326.547-65',	'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030')
						,(3, 'João',	  'joao@hotmail.com',	'27/08/1975', '11 7656-6377',	'53254444-1',  '913.053.480-10',	'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380')
						,(3, 'Bruno',	  'bruno@gmail.com',	'21/03/1972', '11 95436-8769',	'54566266-7',  '797.992.990-04',	'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001')
						,(3, 'Mariana',	  'mariana@outlook.com','05/03/2018', '             ',	'54566266-8',  '137.719.130-39',	'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');


-- Especialidades --
INSERT INTO Especialidades (nomeEspecialidade)
VALUES						('Acupuntura')
							,('Anestesiologia')
							,('Angiologia')
							,('Cardiologia')
							,('Cirurgia Cardiovascular')
							,('Cirurgia da Mão')
							,('Cirurgia do Aparelho Digestivo')
							,('Cirurgia Geral')
							,('Cirurgia Pediátrica')
							,('Cirurgia Plástica')
							,('Cirurgia Torácica')
							,('Cirurgia Vascular')
							,('Dermatologia')
							,('Radioterapia')
							,('Urologia')
							,('Pediatria')
							,('Psiquiatria');


-- Clínicas --
INSERT INTO Clinicas(clinica, razaoSocial, endereço)
VALUES				('Clinica Possarle', 'SP Medical Group', 'Av. Barão Limeira, 532, São Paulo, SP' );


-- Médico --
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


INSERT INTO Consultas (idPaciente, idMedico, dataConsulta, horaConsulta, situacao)
VALUES				   (7, 3, '20/01/2020', '15:00', 'Realizada' )
					   ,(2, 2, '06/01/2020', '10:00', 'Cancelada' )
					   ,(3, 2, '07/02/2020', '11:00', 'Realizada' )
					   ,(2, 2, '06/02/2018', '10:00', 'Realizada' )
					   ,(4, 1, '07/02/2019', '11:00', 'Cancelada' )
					   ,(7, 3, '08/03/2020', '15:00', 'Agendada' )
					   ,(4, 1, '09/03/2020', '11:00', 'Agendada' );

---- FIM INSERTS ----