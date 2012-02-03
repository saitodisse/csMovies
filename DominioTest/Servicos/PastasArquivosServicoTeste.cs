using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;
using Dominio.Servicos;
using Moq;
using NUnit.Framework;

namespace DominioTest.Servicos
{
    [TestFixture]
    public class PastaArquivosServicoTeste
    {
        [Test]
        public void pesquisar_pastaArquivoss_banco_dados()
        {
            var pastaArquivosDAOMock = new Mock<IPastaArquivosDAO>();
            pastaArquivosDAOMock.Setup(x => x.GetAll()).Returns(new List<PastaArquivos>());
            var pastaArquivosDAO = pastaArquivosDAOMock.Object;

            var pastaArquivosServico = new PastaArquivosServico(pastaArquivosDAO);
            IList<PastaArquivos> pastaArquivoss = pastaArquivosServico.PesquisarTodos();

            Assert.IsNotNull(pastaArquivoss);
        }

        [Test]
        public void pesquisar_unico_pastaArquivos_banco_dados()
        {
            var pastaArquivosDAOMock = new Mock<IPastaArquivosDAO>();
            pastaArquivosDAOMock.Setup(x => x.Get(It.IsAny<int>())).Returns(new PastaArquivos());
            var pastaArquivosDAO = pastaArquivosDAOMock.Object;

            var pastaArquivosServico = new PastaArquivosServico(pastaArquivosDAO);
            PastaArquivos pastaArquivos = pastaArquivosServico.Pesquisar(123);

            Assert.IsNotNull(pastaArquivos);
        }
    }
}
