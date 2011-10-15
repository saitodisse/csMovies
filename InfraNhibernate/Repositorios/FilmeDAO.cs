using Dominio.Entidades;
using Dominio.Repositorio;
using InfraNhibernate.NHibernateHelpers;

namespace InfraNhibernate.Repositorios
{
    public class FilmeDAO : DAO<Filme>, IFilmeDAO
    {
        public FilmeDAO(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}