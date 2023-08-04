--DQL

USE Exercicio_1_2_TARDE;

insert into Cliente(CPF, NomeCliente)
values('2883958495', 'Junior')
--------------------------------------------------------------------------------
insert into Aluguel(IdVeiculo, IdCliente, Preco, DataInicio, DataFim)
values(3, 6, 111000, '20/08/2023', '10/09/2023')

select Aluguel.DataInicio as DataDeRetirada, Aluguel.DataFim as DataDeDevolução
from Aluguel 
inner join Cliente on Cliente.IdCliente = Aluguel.IdCliente

select Cliente.NomeCliente as Nome
from Aluguel 
inner join Cliente on Cliente.IdCliente = Aluguel.IdCliente

select Veiculo.Placa as Placa
from Aluguel 
inner join Veiculo on Veiculo.IdVeiculo = Aluguel.IdVeiculo

select Cliente.NomeCliente from Cliente
where Cliente.IdCliente = 4

select Aluguel.DataInicio, Aluguel.DataFim from Aluguel
where Aluguel.IdCliente = 4
------------------------------------------------------------------------------
select * from Aluguel
select * from Cliente
select * from Veiculo
select * from Modelo