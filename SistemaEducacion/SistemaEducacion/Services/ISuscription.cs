using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Services
{
    public interface ISuscription
    {
        Answer? AddSuscription(Suscription entity);
        Answer? UpdateSuscription(Suscription entity);
    }
}
