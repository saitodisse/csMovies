using System.Collections.Generic;
using System.Transactions;
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
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var releaseDao = new ReleaseDAO(new SessionProvider(new SessionFactoryProvider()));
                var releases = releaseDao.GetAll();
                Assert.AreEqual(2, releases.Count);
            }
        }

        [Test]
        public void Todos_arquivos_do_release_2()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var arquivoDao = new ArquivoDAO(new SessionProvider(new SessionFactoryProvider()));
                int releaseId = 2;
                var arquivos = arquivoDao.PesquisarArquivosPorRelease(releaseId);
                Assert.AreEqual(2, arquivos.Count);
            }
        }

        [Test]
        public void Incluir_filme_novo_e_pesquisar_depois()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
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
        }      


        [Test]
        public void Incluir_releases_novo_e_pesquisar_depois()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
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
        }
        
        [Test]
        public void Inserir_filme_com_dois_releases_direto_da_sessao()
        {
            using (var transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                // Inicializa a session
                var provider = new SessionFactoryProvider();
                var sessionProvider = new SessionProvider(provider);
                var sessaoAtual = sessionProvider.GetCurrentSession();

                // Cria duas novas releases
                var release1 = new Release {Nome = "release 1"};
                sessaoAtual.Save(release1);
                int release1_id = release1.Id;
                var release2 = new Release {Nome = "release 2"};
                sessaoAtual.Save(release2);
                int release2_id = release2.Id;

                // Cria um filme o coloca as duas releases
                var filme = new Filme {Nome = "filme 1"};
                filme.AdicionarRelease(release1);
                filme.AdicionarRelease(release2);
                sessaoAtual.Save(filme);
                int filme_id = filme.Id;

                // Pesquisa os itens incluído por id
                Assert.AreEqual("filme 1", sessaoAtual.Get<Filme>(filme_id).Nome);
                Assert.AreEqual("release 1", sessaoAtual.Get<Release>(release1_id).Nome);
                Assert.AreEqual("release 2", sessaoAtual.Get<Release>(release2_id).Nome);

                // Pesquisa via lazyloading
                Assert.AreEqual(2, sessaoAtual.Get<Filme>(filme_id).Releases.Count);

                // ROWBACK
                transactionScope.Dispose();
            }
        }
    }
}
