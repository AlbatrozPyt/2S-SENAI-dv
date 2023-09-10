using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogoRepository
    {
        void Cadastrar(JogoDomain jogo);

        List<JogoDomain> listarJogos();
    }
}