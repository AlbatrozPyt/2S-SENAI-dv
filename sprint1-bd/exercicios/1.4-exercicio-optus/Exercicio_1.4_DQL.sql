--DQL

USE Exercicio_1_4_Tarde;

--- listar todos os usu�rios administradores, sem exibir suas senhas
select Usuario.Nome as Nome_do_Usuario from Usuario
where Usuario.NivelPermissao = 1

--- listar todos os �lbuns lan�ados ap�s o um determinado ano de lan�amento
select * from Album
where Album.Lancamento like '%2000'

--- listar os dados de um usu�rio atrav�s do e-mail e senha
select * from Usuario
where Usuario.Email like 'matheus@email.com' and Usuario.Senha like '1234'

--- listar todos os �lbuns ativos, mostrando o nome do artista e os estilos do �lbum 
select * from Album
where Album.ATIVO = 1

SELECT*FROM Artista
SELECT*FROM Album
SELECT*FROM Musica
SELECT*FROM Estilo
SELECT*FROM Usuario