--DQL

USE Exercicio_1_4_Tarde;

--- listar todos os usuários administradores, sem exibir suas senhas
select Usuario.Nome as Nome_do_Usuario from Usuario
where Usuario.NivelPermissao = 1

--- listar todos os álbuns lançados após o um determinado ano de lançamento
select * from Album
where Album.Lancamento like '%2000'

--- listar os dados de um usuário através do e-mail e senha
select * from Usuario
where Usuario.Email like 'matheus@email.com' and Usuario.Senha like '1234'

--- listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum 
select * from Album
where Album.ATIVO = 1

SELECT*FROM Artista
SELECT*FROM Album
SELECT*FROM Musica
SELECT*FROM Estilo
SELECT*FROM Usuario