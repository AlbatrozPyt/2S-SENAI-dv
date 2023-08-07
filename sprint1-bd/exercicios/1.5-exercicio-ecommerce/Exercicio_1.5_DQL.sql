use Exercicio_1_5

--- listar todos os pedidos de um cliente (nome), mostrando quais produtos foram solicitados 
--- (titulo) neste pedido e de qual subcategoria (nome) e categoria (nome) pertencem

select 
	Cliente.NomeCliente as Nome_do_Cliente, 
	Produto.NomeProduto as Nome_do_Produto, 
	Pedido.NumeroPedido as nº_Pedido, 
	SubCategoria.NomeSubCategoria as SubCategoria, 
	Categoria.NomeCategoria as Categoria
from 
	Cliente, Produto, Pedido, SubCategoria, Categoria
inner join ProdutoPedido on ProdutoPedido.IdPedido = Pedido.IdPedido
--where Cliente.IdCliente = 1
