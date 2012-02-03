using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;
using Dominio.Servicos;
using Moq;
using NUnit.Framework;

namespace DominioTest.Servicos
{
    [TestFixture]
    public class ReleaseServicoTeste
    {
        [Test]
        public void pesquisar_releases_banco_dados()
        {
            var releaseDAOMock = new Mock<IReleaseDAO>();
            releaseDAOMock.Setup(x => x.GetAll()).Returns(new List<Release>());
            var releaseDAO = releaseDAOMock.Object;

            var releaseServico = new ReleaseServico(releaseDAO);
            IList<Release> releases = releaseServico.PesquisarTodos();

            Assert.IsNotNull(releases);
        }

        [Test]
        public void pesquisar_unico_release_banco_dados()
        {
            var releaseDAOMock = new Mock<IReleaseDAO>();
            releaseDAOMock.Setup(x => x.Get(It.IsAny<int>())).Returns(new Release());
            var releaseDAO = releaseDAOMock.Object;

            var releaseServico = new ReleaseServico(releaseDAO);
            Release release = releaseServico.Pesquisar(123);

            Assert.IsNotNull(release);
        }
    }
}
