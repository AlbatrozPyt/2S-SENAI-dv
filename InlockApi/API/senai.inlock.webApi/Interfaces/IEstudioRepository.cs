using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IEstudioRepository
    {
        void Cadastrar(EstudioDomain estudio);

        List<EstudioDomain> ListarEstudios();
    }
}
