using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;
using InfraNhibernate.NHibernateHelpers;

namespace InfraNhibernate.Repositorios
{
    public class ArquivoDAO : DAO<Arquivo>, IArquivoDAO
    {
        public ArquivoDAO(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }

        public IList<Arquivo> PesquisarArquivosPorFilme(int filmeId)
        {
            return Session.QueryOver<Arquivo>()
                .JoinQueryOver(x => x.Release)
                .Where(x => x.Filme.Id == filmeId).List();
        }
    }
}