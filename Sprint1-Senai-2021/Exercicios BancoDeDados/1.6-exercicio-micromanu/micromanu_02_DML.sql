USE Micromanu;


INSERT INTO Clientes(Nome)
VALUES			 ('Cliente A')
				,('Cliente B');
				


INSERT INTO Colaboradores(Nome)
VALUES			('Erick')
				,('Claudio')
				,('Daniel');	  


INSERT INTO Itens(Nome)
VALUES			 ('Computador')
				,('Televisão')
				,('Video game')
				,('Notebook')
				,('Celular');


INSERT INTO TiposConsertos(Descricao)
VALUES				('Manutenção')
				   ,('Limpeza');


INSERT INTO Pedidos(IdCliente, IdItem, IdTipoConserto, NEquipamento, Entrada, Saida)
VALUES			   (1, 1, 1, '455', '20/08/2021', '22/07/2020')
				  ,(2, 2, 2, '456', '24/08/2021', GETDATE());
				  

INSERT INTO PedidosColaboradores(IdPedido, IdColaborador)
VALUES							(1,1)
							   ,(1,2)
							   ,(2,3);
							   
