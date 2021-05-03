USE Ecommerce;


INSERT INTO Lojas(Nome)
VALUES			 ('Padaria.co')
				,('Style');


INSERT INTO Categorias(Nome, IdLoja)
VALUES				  ('Alimentos', 1)
					 ,('Roupas', 2);


INSERT INTO SubCategorias(Nome, IdCategoria)
VALUES					 ('Salgados', 1)
						,('Doces', 1)
						,('Calças', 2)
						,('Camisetas', 2);


INSERT INTO Produtos(Titulo, Valor, IdSubCategoria)
VALUES				('Pizza', 32, 1)
				   ,('Camiseta azul', 60, 4)
				   ,('Legging', 80, 3)
				   ,('Bolo de morango', 35, 2);


INSERT INTO Clientes(Nome)
VALUES				('Gabriela')
				   ,('Amanda');


INSERT INTO Pedidos( NPedido, IdCliente, DataPedido, [Status])
VALUES			   ( 001, 1, GETDATE(), 'Em andamento')
				  ,( 002, 2, GETDATE(), 'Entregue');


INSERT INTO PedidosProdutos(IdPedido, IdProduto)
VALUES					   (1,3)
						  ,(1,1);
						


 