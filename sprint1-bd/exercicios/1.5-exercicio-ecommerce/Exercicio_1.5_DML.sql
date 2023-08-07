--DML

use Exercicio_1_5

insert into Loja
values('Carrefour')

insert into Cliente
values('Matheus'), ('Murillo')

insert into Categoria
values(1, 'Limpeza'), (1, 'Alimentos'), (1, 'Roupas'), (1, 'Eletrodomesticos'), (1, 'Esporte')

insert into SubCategoria
values(1, 'Limpa-Moveis'), (2, 'Carnes'), (3, 'Camisetas'), (4, 'Maquinas de lavar'), (5, 'Bolas')

insert into Produto
values(1, 'LimpaTudo'), (2, 'Filé Mignon'), (3, 'Camisa Esportiva'), (4, 'Eletrolux-2000'), (5, 'Bola de futebol-Nike')

insert into Pedido
values(1, 1), (2, 2)

insert into ProdutoPedido
values(5, 1), (6, 2)

select * from Loja
select * from Cliente
select * from Categoria
select * from SubCategoria
select * from Produto
select * from Pedido
select * from ProdutoPedido