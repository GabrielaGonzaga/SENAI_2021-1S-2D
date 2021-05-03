CREATE DATABASE Micromanu;


USE Micromanu;


CREATE TABLE Clientes 
(
    IdCliente	INT PRIMARY KEY IDENTITY
    ,Nome		VARCHAR(200) UNIQUE NOT NULL
);


CREATE TABLE Colaboradores
(
    IdColaborador	INT PRIMARY KEY IDENTITY
    ,Nome			VARCHAR(200) UNIQUE NOT NULL
);


CREATE TABLE Itens
(
	IdItem		INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR(200) UNIQUE NOT NULL
);


CREATE TABLE TiposConsertos
(
    IdTipoConserto		INT PRIMARY KEY IDENTITY
    ,Descricao			VARCHAR(200) UNIQUE NOT NULL
);


CREATE TABLE Pedidos
(
	IdPedido			INT PRIMARY KEY IDENTITY
	,IdCliente			INT FOREIGN KEY REFERENCES Clientes(IdCliente)
	,IdItem				INT FOREIGN KEY REFERENCES Itens(IdItem)
	,IdTipoConserto		INT FOREIGN KEY REFERENCES TiposConsertos(IdTipoConserto)
	,NEquipamento		VARCHAR(200) UNIQUE NOT NULL
	,Entrada			DATE NOT NULL
	,Saida				DATE NOT NULL
);


CREATE TABLE PedidosColaboradores
(
	IdPedido		INT FOREIGN KEY REFERENCES Pedidos(IdPedido)
	,IdColaborador	INT FOREIGN KEY REFERENCES Colaboradores(IdColaborador)
);
