using System.Transactions;
using Dominio.Entidades;
using InfraNhibernate.NHibernateHelpers;
using InfraNhibernate.Repositorios;
using NUnit.Framework;
using Dominio.Repositorio;

namespace NhibernateConsultasTeste
{
    
    [TestFixture]

    public class RepositorioTeste
    {
        [Test]
        public void Incluir_filme()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                // Cria um novo filme
                var filme = new Filme();
                filme.Nome = "Titanic";

                // O ID é zero!
                Assert.AreEqual(0, filme.Id);

                // Inicializa a sessão do NHibernate
                var sessionProvider = new SessionProvider(new SessionFactoryProvider());
                // Inicializa o repositório do Filme
                IFilmeDAO filmeDAO = new FilmeDAO(sessionProvider);
                // Grava o filme no banco
                filmeDAO.Save(filme);

                // ID deixa de ser zero
                Assert.AreNotEqual(0, filme.Id);
            }
        }      

        [Test]
        public void Incluir_filme_e_pesquisar()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                // Cria um novo filme
                var filme = new Filme();
                filme.Nome = "Titanic";

                // O ID é zero!
                Assert.AreEqual(0, filme.Id);

                // Inicializa a sessão do NHibernate
                var sessionProvider = new SessionProvider(new SessionFactoryProvider());
                // Inicializa o repositório do Filme
                IFilmeDAO filmeDAO = new FilmeDAO(sessionProvider);
                // Grava o filme no banco
                filmeDAO.Save(filme);

                // ID deixa de ser zero
                Assert.AreNotEqual(0, filme.Id);

                
                /////////////////////////////////////////////
                // LIMPA A SESSÃO - FORÇA A PESQUISA NO BANCO
                sessionProvider.GetCurrentSession().Clear();

                // Pega todos os filmes
                var filmes = filmeDAO.GetAll();
                Assert.AreNotEqual(0, filmes.Count);


                /////////////////////////////////////////////
                // LIMPA A SESSÃO - FORÇA A PESQUISA NO BANCO
                // Pega filme especifico
                var filmeEspecifico = filmeDAO.Get(filme.Id);
                Assert.AreEqual("Titanic", filmeEspecifico.Nome);
            }
        }
        
    }
}
