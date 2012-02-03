using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;
using Dominio.Servicos;
using Moq;
using NUnit.Framework;

namespace DominioTest.Servicos
{
    [TestFixture]
    public class ConfiguracoesGeraisServicoTeste
    {
        [Test]
        public void pesquisa_se_nao_existir_cria_novo()
        {
            var configuracoesGeraisDAOMock = new Mock<IConfiguracoesGeraisDAO>();
            var listaConfiguracoes = new List<ConfiguracoesGerais>();
            configuracoesGeraisDAOMock.Setup(x => x.GetAll()).Returns(listaConfiguracoes);
            IConfiguracoesGeraisDAO configuracoesGeraisDAO = configuracoesGeraisDAOMock.Object;

            var configuracoesGeraisServico = new ConfiguracoesGeraisServico(configuracoesGeraisDAO);
            ConfiguracoesGerais configuracoesGerais = configuracoesGeraisServico.Pesquisar();

            Assert.IsNotNull(configuracoesGerais);
        }

        [Test]
        public void pesquisar_unico_configuracoesGerais_banco_dados()
        {
            var configuracoesGeraisDAOMock = new Mock<IConfiguracoesGeraisDAO>();
            var listaConfiguracoes = new List<ConfiguracoesGerais>();
            listaConfiguracoes.Add(new ConfiguracoesGerais());
            configuracoesGeraisDAOMock.Setup(x => x.GetAll()).Returns(listaConfiguracoes);
            IConfiguracoesGeraisDAO configuracoesGeraisDAO = configuracoesGeraisDAOMock.Object;

            var configuracoesGeraisServico = new ConfiguracoesGeraisServico(configuracoesGeraisDAO);
            ConfiguracoesGerais configuracoesGerais = configuracoesGeraisServico.Pesquisar();

            Assert.IsNotNull(configuracoesGerais);
        }

        [Test]
        public void salvar_configuracoesGerais_banco_dados()
        {
            var configuracoesGeraisDAOMock = new Mock<IConfiguracoesGeraisDAO>();

            var configuracoesGerais = new ConfiguracoesGerais();
            configuracoesGeraisDAOMock.Setup(x => x.Save(configuracoesGerais)).Callback(
                () => { configuracoesGerais.Id = 1; });
            IConfiguracoesGeraisDAO configuracoesGeraisDAO = configuracoesGeraisDAOMock.Object;

            var configuracoesGeraisServico = new ConfiguracoesGeraisServico(configuracoesGeraisDAO);
            configuracoesGeraisServico.Salvar(configuracoesGerais);

            Assert.AreNotEqual(0, configuracoesGerais.Id);
        }
    }
}