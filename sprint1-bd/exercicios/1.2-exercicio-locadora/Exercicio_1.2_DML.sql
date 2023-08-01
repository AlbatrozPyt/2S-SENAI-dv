--DML

USE Exercicio_1_2_TARDE;

INSERT INTO Empresa(NomeEmpresa)
VALUES('Chevrolet'), ('Volkswagen')

INSERT INTO Marca(NomeMarca)
VALUES('Camaro'), ('Fusca')

INSERT INTO Modelo(NumeroChassi)
VALUES('1234567'), ('7654321')

INSERT INTO Cliente(CPF)
VALUES('12345678900'), ('98765432100')

INSERT INTO Veiculo(IdEmpresa, IdMarca, IdModelo, Placa)
VALUES(4, 1, 1, '122FJKD'), (5, 2, 2, '995EFHB')

INSERT INTO Aluguel(IdVeiculo, IdCliente, Preco)
VALUES(3, 1, 490000.00), (4, 2, 25000.00)

SELECT * FROM Empresa
SELECT * FROM Marca
SELECT * FROM Modelo
SELECT * FROM Cliente
SELECT * FROM Veiculo
SELECT * FROM Aluguel