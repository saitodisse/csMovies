using Dominio.Entidades;
using Dominio.Enums;
using Dominio.Repositorio;
using InfraNhibernate.NHibernateHelpers;

namespace InfraNhibernate.Repositorios
{
    public class NotaDAO : DAO<Nota>, INotaDAO
    {
        public NotaDAO(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}