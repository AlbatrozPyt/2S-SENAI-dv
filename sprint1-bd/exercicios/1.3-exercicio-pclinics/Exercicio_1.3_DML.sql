--DML

USE Exercicio_1_3;

INSERT INTO Clinica(Endereco)
VALUES('Rua dos Animais, nº7')

INSERT INTO Dono(NomeDono)
VALUES('Carlos'), ('Eduardo')

INSERT INTO TiposPets(Tipo)
VALUES('Roedor'), ('Pombo')

INSERT INTO Raca
VALUES('Ratazana'), ('Calopsita')

INSERT INTO Veterinario(IdClinica, NomeVeterinario)
VALUES(1, 'Matheus'), (1, 'Murillo')

INSERT INTO Pets(IdTiposPets, IdDono, IdRaca, Nome, DataNascimento)
VALUES(1, 1, 1, 'Ratão', '19/10/1979'), (2, 2, 2, 'Frango', '500 a.C')

INSERT INTO Atendimento(IdVeterinario, IdPets, DataAtendimento)
VALUES(1, 1, '07/08/2023'), (2, 2, '15/08/2023')

SELECT * FROM Clinica
SELECT * FROM Dono
SELECT * FROM TiposPets
SELECT * FROM Raca
SELECT * FROM Veterinario
SELECT * FROM Pets
SELECT * FROM Atendimento