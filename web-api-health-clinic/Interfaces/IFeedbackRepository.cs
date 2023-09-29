using web_api_health_clinic.Domains;

namespace web_api_health_clinic.Interfaces
{
    public interface IFeedbackRepository
    {
        void Comentar(Feedback feedback);

        List<Feedback> ListarComentarios(string nome);
    }
}
