using Dominio.Entidades;
using Dominio.Repositorio;
using InfraNhibernate.NHibernateHelpers;

namespace InfraNhibernate.Repositorios
{
    public class DownloadLinkDAO : DAO<DownloadLink>, IDownloadLinkDAO
    {
        public DownloadLinkDAO(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}