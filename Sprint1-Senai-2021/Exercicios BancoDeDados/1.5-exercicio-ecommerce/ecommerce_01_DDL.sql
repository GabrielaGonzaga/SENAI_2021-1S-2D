CREATE DATABASE Ecommerce;

USE Ecommerce;

CREATE TABLE Lojas 
(
    IdLoja		INT PRIMARY KEY IDENTITY
    ,Nome		VARCHAR(200) UNIQUE NOT NULL
);


CREATE TABLE Categorias
(
    IdCategoria		INT PRIMARY KEY IDENTITY
    ,Nome			VARCHAR(200) UNIQUE NOT NULL
	,IdLoja			INT FOREIGN KEY REFERENCES Lojas(IdLoja)
);


CREATE TABLE SubCategorias
(
	IdSubCategoria		INT PRIMARY KEY IDENTITY
	,Nome				VARCHAR(200) NOT NULL
	,IdCategoria		INT FOREIGN KEY REFERENCES Categorias(IdCategoria)
);


CREATE TABLE Produtos
(
    IdProduto			INT PRIMARY KEY IDENTITY
    ,Titulo				VARCHAR(200) UNIQUE NOT NULL
	,Valor				DECIMAL(18,2) NOT NULL
	,IdSubCategoria		INT FOREIGN KEY REFERENCES SubCategorias (IdSubCategoria)
);


CREATE TABLE Clientes
(
	IdCliente	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR (200) UNIQUE NOT NULL
);


CREATE TABLE Pedidos
(
	IdPedido		INT PRIMARY KEY IDENTITY
	,NPedido		INT UNIQUE NOT NULL
	,IdCliente		INT FOREIGN KEY REFERENCES Clientes(IdCliente)
	,DataPedido		DATE NOT NULL
	,[Status]		VARCHAR(200) NOT NULL
);


CREATE TABLE PedidosProdutos
(
	IdPedido		INT FOREIGN KEY REFERENCES Pedidos(IdPedido)
	,IdProduto		INT FOREIGN KEY REFERENCES Produtos(IdProduto)
);


