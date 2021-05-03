USE Micromanu;
GO

SELECT * FROM Clientes;

SELECT * FROM Colaboradores;

SELECT * FROM Itens;

SELECT * FROM TiposConsertos;

SELECT * FROM Pedidos;

SELECT * FROM PedidosColaboradores;


-- listar todos os pedidos dos clientes
SELECT CL.Nome Cliente, NEquipamento, Entrada, Saida, IT.Nome Item, TC.Descricao TipoConserto,
CO.Nome Colaborador
FROM Clientes CL
INNER JOIN Pedidos PE
ON CL.IdCliente = PE.IdCliente
INNER JOIN Itens IT
ON PE.IdItem = IT.IdItem
INNER JOIN TiposConsertos TC
ON PE.IdTipoConserto = TC.IdTipoConserto
INNER JOIN PedidosColaboradores PC
ON PE.IdPedido = PC.IdPedido
INNER JOIN Colaboradores CO
ON PC.IdColaborador = CO.IdColaborador;

-- listar todos os pedidos de um determinado cliente, 
-- mostrando quais foram os colaboradores que executaram o serviço, 
-- qual foi o tipo de conserto, qual item foi consertado e o nome deste cliente
SELECT CL.Nome Cliente, NEquipamento, Entrada, Saida, IT.Nome Item, TC.Descricao TipoConserto,
CO.Nome Colaborador
FROM Clientes CL
INNER JOIN Pedidos PE
ON CL.IdCliente = PE.IdCliente
INNER JOIN Itens IT
ON PE.IdItem = IT.IdItem
INNER JOIN TiposConsertos TC
ON PE.IdTipoConserto = TC.IdTipoConserto
INNER JOIN PedidosColaboradores PC
ON PE.IdPedido = PC.IdPedido
INNER JOIN Colaboradores CO
ON PC.IdColaborador = CO.IdColaborador
WHERE CL.Nome LIKE 'Cliente A';