using Dominio.Entidades;
using Dominio.Repositorio;
using InfraNhibernate.NHibernateHelpers;

namespace InfraNhibernate.Repositorios
{
    public class LegendaDAO : DAO<Legenda>, ILegendaDAO
    {
        public LegendaDAO(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}