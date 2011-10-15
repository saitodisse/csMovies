using Dominio.Entidades;
using Dominio.Repositorio;
using InfraNhibernate.NHibernateHelpers;

namespace InfraNhibernate.Repositorios
{
    public class UsuarioDAO : DAO<Usuario>, IUsuarioDAO
    {
        public UsuarioDAO(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}