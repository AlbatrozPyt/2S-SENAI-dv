--CRIA BANCO DE DADOS == DDL: DATA DEFINITION LANGUAGE
CREATE DATABASE BancoTarde;

--USA O BANCO DE DADOS
USE BancoTarde;

--CRIA A TABELA
CREATE TABLE Funcionarios
(
	IdFuncionario INT PRIMARY KEY IDENTITY,
	--Colchetes ignoram palavras reservadas
	Nome VARCHAR(10)
);

CREATE TABLE Empresas
(
	IdEmpresas INT PRIMARY KEY IDENTITY,
	IdFuncionario INT FOREIGN KEY REFERENCES Funcionarios(IdFuncionario),
	Nome VARCHAR(20)
);


--ALTER TABLE

ALTER TABLE Funcionarios
ADD Cpf VARCHAR(11)

ALTER TABLE Funcionarios
DROP COLUMN Cpf

DROP TABLE Empresas;

DROP DATABASE BancoTarde;