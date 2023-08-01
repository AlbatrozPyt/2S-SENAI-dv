--DML - INSERIR DADOS NA TABELA

--USAR O BANCO CRIADO
USE Exercicio_1_1;

--INSERIR DADOS NA TABELA
INSERT INTO Pessoa(NomePessoa, Idade, Cnh)
VALUES('Carlos', 30, '123456789'), ('Eduardo', 30, '129300940')

--INSERT INTO Pessoa VALUES('Matheus', '123456778')

INSERT INTO Email(IdPessoa, Endereco)
VALUES(1, 'carlos@email.com')

INSERT INTO Telefone(IdPessoa, Numero)
VALUES(2, '999999339')

SELECT*FROM Pessoa
SELECT*FROM Email
SELECT*FROM Telefone