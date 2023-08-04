--DML

USE Exercicio_1_3_Tarde;

INSERT INTO Clinica(Endereco)
VALUES('Rua dos Animais, nº7')

INSERT INTO Dono(NomeDono)
VALUES('Matheus')

INSERT INTO TiposPets(Tipo)
VALUES('Cachorro')

INSERT INTO Raca
VALUES('Cachorro')

INSERT INTO Veterinario(IdClinica, NomeVeterinario)
VALUES(1, 'Matheus')

INSERT INTO Pets(IdTiposPets, IdDono, IdRaca, Nome, DataNascimento, IdVeterinario)
VALUES(2, 2, 2, 'Pombo-2', 'Alguns minutos', 2)

INSERT INTO Atendimento(IdVeterinario, IdPets, DataAtendimento)
VALUES(1, 7, '13/09')

SELECT * FROM Clinica
SELECT * FROM Dono
SELECT * FROM TiposPets
SELECT * FROM Raca
SELECT * FROM Veterinario
SELECT * FROM Pets
SELECT * FROM Atendimento