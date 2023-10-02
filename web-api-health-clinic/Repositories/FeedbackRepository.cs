using web_api_health_clinic.Contexts;
using web_api_health_clinic.Domains;
using web_api_health_clinic.Interfaces;

namespace web_api_health_clinic.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly EventContext ctx;

        public FeedbackRepository()
        {
            ctx = new EventContext();
        }

        public void Comentar(Feedback feedback)
        {
            ctx.Feedbacks!.Add(feedback);
            ctx.SaveChanges();
        }

        public List<Feedback> ListarComentarios(string nome)
        {
            List<Feedback> feedbacks = ctx.Feedbacks!.Where(x => x.Consulta.Paciente.NomePaciente == nome).ToList();

            return feedbacks;
        }
    }
}
