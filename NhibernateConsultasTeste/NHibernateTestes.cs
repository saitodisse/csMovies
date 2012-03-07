using System.Transactions;
using Dominio.Entidades;
using InfraNhibernate.NHibernateHelpers;
using NUnit.Framework;

namespace NhibernateConsultasTeste
{
    [TestFixture]
    public class NhibernateDicasTeste
    {
        [Test]
        public void Inserir_sem_cascade()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                // Inicializa a session
                var provider = new SessionFactoryProvider();
                var sessionProvider = new SessionProvider(provider);
                var sessaoAtual = sessionProvider.GetCurrentSession();

                // Cria um filme
                var filme = new Filme { Nome = "filme 1" };
                // Grava o filme
                sessaoAtual.Save(filme);

                // Cria os releases
                var release1 = new Release { Nome = "release 1" };
                var release2 = new Release { Nome = "release 2" };
                // Adiciona os releases no filme (faz a volta pro pai)
                filme.AdicionarRelease(release1);
                filme.AdicionarRelease(release2);
                // Grava os Releases
                sessaoAtual.Save(release1);
                sessaoAtual.Save(release2);


                /////////////////////////////////////////////
                // LIMPA A SESSÃO - FORÇA A PESQUISA NO BANCO
                sessaoAtual.Clear();


                // Pesquisa os itens incluído por id
                Assert.AreEqual("filme 1", sessaoAtual.Get<Filme>(filme.Id).Nome);
                Assert.AreEqual("release 1", sessaoAtual.Get<Release>(release1.Id).Nome);
                Assert.AreEqual("release 2", sessaoAtual.Get<Release>(release2.Id).Nome);


                /////////////////////////////////////////////
                // LIMPA A SESSÃO - FORÇA A PESQUISA NO BANCO
                sessaoAtual.Clear();


                // Pesquisa as releases do filme via lazyloading
                var filmePesquisado = sessaoAtual.Get<Filme>(filme.Id);
                Assert.AreEqual(2, filmePesquisado.Releases.Count);
            }
        }

        [Test]
        public void Inserir_com_cascade()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                // Inicializa a session
                var provider = new SessionFactoryProvider();
                var sessionProvider = new SessionProvider(provider);
                var sessaoAtual = sessionProvider.GetCurrentSession();

                // Cria um release
                var release = new Release { Nome = "release 1" };
                // Cria as legendas
                var legenda1 = new Legenda { Linguagem = "pt-BR" };
                var legenda2 = new Legenda { Linguagem = "pt-BR" };
                // Adiciona as legendas no release
                release.AdicionarLegenda(legenda1);
                release.AdicionarLegenda(legenda2);
                // Grava o release que já grava automaticamente os filhos
                sessaoAtual.Save(release);

                /////////////////////////////////////////////
                // LIMPA A SESSÃO - FORÇA A PESQUISA NO BANCO
                sessaoAtual.Clear();

                // Pesquisa as releases do filme via lazyloading
                var releasePesquisado = sessaoAtual.Get<Release>(release.Id);
                Assert.AreEqual(2, releasePesquisado.Legendas.Count);
            }
        }
    }
}
