using Dominio.Entidades;
using Dominio.Repositorio;
using InfraNhibernate.NHibernateHelpers;

namespace InfraNhibernate.Repositorios
{
    public class ConfiguracoesGeraisDAO : DAO<ConfiguracoesGerais>, IConfiguracoesGeraisDAO
    {
        public ConfiguracoesGeraisDAO(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}