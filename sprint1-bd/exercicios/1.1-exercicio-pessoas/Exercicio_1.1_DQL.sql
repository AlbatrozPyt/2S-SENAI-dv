--DQL

USE Exercicio_1_1;

SELECT 
	Pess.NomePessoa AS SER_HUMANO , 
	Telefone.Numero AS Fone, 
	E.Endereco AS Mail, 
	Pess.Cnh AS CNH
FROM 
	Pessoa AS Pess, 
	Email AS E, 
	Telefone
WHERE 
	Pess.IdPessoa = E.IdPessoa
	AND Pess.IdPessoa = Telefone.IdPessoa
ORDER BY 
	SER_HUMANO DESC

insert into Pessoa
values
	('Gabriel', 25, '1920930'),
	('Vinicius', 16, '374849'),
	('Vitoria', 18, '949590'),
	('Gustavo', 17, '374845');

	SELECT * FROM Pessoa