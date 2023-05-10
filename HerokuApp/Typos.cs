using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuApp
{
    internal class Typos
    {
        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void SetUp()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void TyposTest()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/typos");
            IWebElement typoText = ChromeDriver.FindElement(By.XPath("//p[2]"));
            Assert.That(typoText.Text, Is.EqualTo("Sometimes you'll see a typo, other times you won't."));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
