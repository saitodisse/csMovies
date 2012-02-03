using Dominio.Entidades;
using Dominio.Repositorio;
using InfraNhibernate.NHibernateHelpers;

namespace InfraNhibernate.Repositorios
{
    public class PastaArquivosDAO : DAO<PastaArquivos>, IPastaArquivosDAO
    {
        public PastaArquivosDAO(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}