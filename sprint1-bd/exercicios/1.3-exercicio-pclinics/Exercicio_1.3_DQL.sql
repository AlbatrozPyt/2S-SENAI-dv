select Veterinario.NomeVeterinario as Veterinario from Veterinario
inner join Clinica on Clinica.IdClinica = Veterinario.IdClinica

select Raca.Raca as Raça  from Raca
where Raca.Raca like 'S%'

select Raca.Raca as Raça from Raca
where Raca.Raca like '%O'

select Dono.NomeDono as Dono, Pets.Nome as Nome_do_Pet from Dono, Pets

select 
	Veterinario.NomeVeterinario as Veterinario, 
	Pets.Nome as Pet,
	Raca.Raca as Raça,
	TiposPets.Tipo  as Tipo_do_Pet,
	Dono.NomeDono as Dono
from Pets
inner join Veterinario on Veterinario.IdVeterinario = Pets.IdVeterinario
inner join Raca on Raca.IdRaca = Pets.IdRaca
inner join TiposPets on TiposPets.IdTiposPets = Pets.IdTiposPets
inner join Dono on Dono.IdDono = Pets.IdDono

SELECT * FROM Clinica
SELECT * FROM Dono
SELECT * FROM TiposPets
SELECT * FROM Raca
SELECT * FROM Veterinario
SELECT * FROM Pets
SELECT * FROM Atendimento