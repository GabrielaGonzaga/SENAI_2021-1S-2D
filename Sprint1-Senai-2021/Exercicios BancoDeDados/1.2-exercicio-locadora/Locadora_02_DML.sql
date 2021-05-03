-- Inserções --

-- Nomes --
INSERT INTO Pessoas(Nome)
VALUES              ('Gabriela')
					,('Camila');

-- Telefones --
INSERT INTO Telefones(Descricao, idPessoa)
VALUES              ('11999999999', 1)
					,('11888888888', 2);

DELETE FROM Telefones WHERE idTelefone = 2;

-- Emails --
INSERT INTO	Emails(Descricao, idPessoa)
VALUES              ('gabriela@modelo.com', 1)
					,('gabriela@modelo.com', 2);

-- CNHs --
INSERT INTO	CNHs(Descricao, idPessoa)
VALUES              ('12345678', 1)
					,('22233344', 2);