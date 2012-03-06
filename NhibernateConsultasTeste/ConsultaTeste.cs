using System.Collections.Generic;
using Dominio.Entidades;
using InfraNhibernate.NHibernateHelpers;
using InfraNhibernate.Repositorios;
using NUnit.Framework;
using Dominio.Repositorio;

namespace NhibernateConsultasTeste
{
    
    [TestFixture]

    public class ConsultaTeste
    {
        [Test]
        public void Pesquisar_todos_releases()
        {
            var releaseDao = new ReleaseDAO(new SessionProvider(new SessionFactoryProvider()));
            var releases = releaseDao.GetAll();
            Assert.AreEqual(2, releases.Count);
        }

        [Test]
        public void Todos_arquivos_do_release_2()
        {
            var arquivoDao = new ArquivoDAO(new SessionProvider(new SessionFactoryProvider()));
            int releaseId = 2;
            var arquivos = arquivoDao.PesquisarArquivosPorRelease(releaseId);
            Assert.AreEqual(2, arquivos.Count);
        }

        [Test]
        public void Incluir_filme_novo_e_pesquisar_depois()
        {
            IFilmeDAO filmeDAO = new FilmeDAO(new SessionProvider(new SessionFactoryProvider()));
            var filme = new Filme();
            filme.Nome = "Titanic";
            filme.ImdbInfo = null;
            filme.Releases = null;
            Assert.AreEqual(0, filme.Id);
            //gravar o filme no banco
            filmeDAO.Save(filme);
            //deixa de ser zero
            Assert.AreNotEqual(0, filme.Id);
        }      


        [Test]
        public void Incluir_releases_novo_e_pesquisar_depois()
        {
            IReleaseDAO releaseDAO = new ReleaseDAO(new SessionProvider(new SessionFactoryProvider()));
            var release = new Release();
            release.Nome = "Titanic-2012-XVid-1080p.Corpse";
            Assert.AreEqual(0, release.Id);
            //gravar o filme no banco
            releaseDAO.Save(release);
            //deixa de ser zero
            Assert.AreNotEqual(0, release.Id);
        }
        
        [Test]
        public void inserir_filme_no_release()
        {
            var Session = new SessionProvider(new SessionFactoryProvider());
            IReleaseDAO releaseDAO = new ReleaseDAO(Session);
            IFilmeDAO filmeDAO = new FilmeDAO(Session);

            var release = releaseDAO.Get(3);
            var filme = filmeDAO.Get(2);
            release.Filme = filme;
            //Assert.AreEqual(0, release.Id);
            //gravar o filme no banco
            releaseDAO.Save(release);
            //deixa de ser zero
            Assert.AreNotEqual(0, release.Id);
        }
    }
}
