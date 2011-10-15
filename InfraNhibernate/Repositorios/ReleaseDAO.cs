using Dominio.Entidades;
using Dominio.Repositorio;
using InfraNhibernate.NHibernateHelpers;

namespace InfraNhibernate.Repositorios
{
    public class ReleaseDAO : DAO<Release>, IReleaseDAO
    {
        public ReleaseDAO(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}