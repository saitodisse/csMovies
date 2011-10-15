using Dominio.Entidades;
using Dominio.Repositorio;
using InfraNhibernate.NHibernateHelpers;

namespace InfraNhibernate.Repositorios
{
    public class ImdbInfoDAO : DAO<ImdbInfo>, IImdbInfoDAO
    {
        public ImdbInfoDAO(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}