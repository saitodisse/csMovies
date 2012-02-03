using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;
using Dominio.Servicos;
using Moq;
using NUnit.Framework;

namespace DominioTest.Servicos
{
    [TestFixture]
    public class FilmeServicoTeste
    {
        [Test]
        public void pesquisar_filmes_banco_dados()
        {
            var filmeDAOMock = new Mock<IFilmeDAO>();
            filmeDAOMock.Setup(x => x.GetAll()).Returns(new List<Filme>());
            var filmeDAO = filmeDAOMock.Object;

            var filmeServico = new FilmeServico(filmeDAO);
            IList<Filme> filmes = filmeServico.PesquisarTodos();

            Assert.IsNotNull(filmes);
        }

        [Test]
        public void pesquisar_unico_filme_banco_dados()
        {
            var filmeDAOMock = new Mock<IFilmeDAO>();
            filmeDAOMock.Setup(x => x.Get(It.IsAny<int>())).Returns(new Filme());
            var filmeDAO = filmeDAOMock.Object;

            var filmeServico = new FilmeServico(filmeDAO);
            Filme filme = filmeServico.Pesquisar(123);

            Assert.IsNotNull(filme);
        }
    }
}
