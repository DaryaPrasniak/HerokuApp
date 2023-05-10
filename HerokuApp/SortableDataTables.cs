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
    internal class SortableDataTables
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
        public void SortableDataTablesTest()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tables");

            var cell1 = ChromeDriver.FindElement(By.XPath("//table//tr[1]//td[1]"));
            Assert.That(cell1.Text, Is.EqualTo("Smith"));

            var cell2 = ChromeDriver.FindElement(By.XPath("//table//tr[3]//td[4]"));
            Assert.That(cell2.Text, Is.EqualTo("$100.00"));

            var cell3 = ChromeDriver.FindElement(By.XPath("//table[2]//tr[4]//td[2]"));
            Assert.That(cell3.Text, Is.EqualTo("Tim"));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
