﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;

namespace webapi.inlock.tarde.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(Guid id, Estudio novoEstudio)
        {
            Estudio antigoEstudio = ctx.Estudios.Find(id)!;
           
            if (antigoEstudio != null)
            {
                antigoEstudio.Nome = novoEstudio.Nome;
            }

            ctx.Estudios.Update(antigoEstudio);

            ctx.SaveChanges();
            
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id)!;
        }

        public void Cadastrar(Estudio estudio)
        {
            ctx.Estudios.Add(estudio);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id)!;

            if (estudioBuscado != null)
            {
                ctx.Estudios.Remove(estudioBuscado);
            }

            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
