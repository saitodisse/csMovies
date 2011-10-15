using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebSeleniumTests
{
    [TestFixture]
    public class Configuracoes
    {
        [Test]
        public void CriarDadosTeste()
        {
            //IWebDriver driver = new FirefoxDriver();

            ////Notice navigation is slightly different than the Java version
            ////This is because 'get' is a keyword in C#

            //driver.Navigate().GoToUrl("http://localhost/OurMoviesMvc/configuracoes");
            //driver.FindElement(By.LinkText("Inserir Dados para teste")).Click();
            //driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            
            //// TODO add wait
            //driver.Quit(); 
        }
    }
}
