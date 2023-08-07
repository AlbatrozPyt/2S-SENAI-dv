--DDL

--- listar todos os pedidos de um cliente (nome), mostrando quais produtos foram solicitados 
--- (titulo) neste pedido e de qual subcategoria (nome) e categoria (nome) pertencem

CREATE DATABASE Exercicio_1_5;
use Exercicio_1_5;

create table Loja
(
	IdLoja int primary key identity,
	NomeLoja varchar(20) not null 
);

create table Cliente
(
 IdCliente int primary key identity,
 NomeCliente varchar(20) not null
);

create table Categoria
(
	IdCategoria int primary key identity,
	IdLoja int foreign key references Loja(IdLoja),
	NomeCategoria varchar(20) not null
);

create table SubCategoria
(
	IdSubCategoria int primary key identity,
	IdCategoria int foreign key references Categoria(IdCategoria),
	NomeSubCategoria varchar(20) not null
);

create table Produto
(
	IdProduto int primary key identity,
	IdSubCategoria int foreign key references SubCategoria(IdSubCategoria),
	NomeProduto varchar not null
);

create table Pedido
(
	IdPedido int primary key identity,
	IdCliente int foreign key references Cliente(IdCliente),
	NumeroPedido int unique not null
);

create table ProdutoPedido
(
	IdProdutoPedido int primary key identity,
	IdProduto int foreign key references Produto(IdProduto),
	IdPedido int foreign key references Pedido(IdPedido)
);

select * from Loja
select * from Cliente
select * from Categoria
select * from SubCategoria
select * from Produto
select * from Pedido
select * from ProdutoPedido