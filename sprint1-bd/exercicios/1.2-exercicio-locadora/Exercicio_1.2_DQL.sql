--DQL

USE Exercicio_1_2_TARDE;

insert into Cliente(CPF, NomeCliente)
values('2883958495', 'Junior')
--------------------------------------------------------------------------------
insert into Aluguel(IdVeiculo, IdCliente, Preco, DataInicio, DataFim)
values(5, 4, 103000, '07/08/2023', '25/08/2023')

select Aluguel.DataInicio, Aluguel.DataFim
from Cliente 
inner join Aluguel on Cliente.IdCliente = Aluguel.IdCliente

select Cliente.IdCliente
from Aluguel 
inner join Cliente on Cliente.IdCliente = Aluguel.IdCliente

select Veiculo.IdVeiculo
from Aluguel 
inner join Veiculo on Veiculo.IdVeiculo = Aluguel.IdVeiculo
--------------------------------------------------------------------------------
select * from Aluguel
select * from Cliente
select * from Veiculo
select * from Modelo