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
    internal class Checkboxes
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
        public void CheckboxesTest()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");

            var checkbox1 = ChromeDriver.FindElement(By.CssSelector("[type = checkbox]"));
            var checkboxAttribute = checkbox1.GetAttribute("checked");
            Assert.IsNull(checkboxAttribute);
            Assert.IsFalse(checkbox1.Selected);
        }

        [Test]
        public void CheckboxesTest2()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");

            var checkbox1 = ChromeDriver.FindElement(By.CssSelector("[type = checkbox]"));
            checkbox1.Click();
            var checkboxAttribute = checkbox1.GetAttribute("checked");
            Assert.IsNotNull(checkboxAttribute);
            //Assert.IsTrue(checkbox1.Selected);
        }

        [Test]
        public void CheckboxesTest3()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");

            var checkbox2 = ChromeDriver.FindElement(By.XPath("//input[2]"));
            var checkboxAttribute = checkbox2.GetAttribute("checked");
            Assert.IsNotNull(checkboxAttribute);
        }

        [Test]
        public void CheckboxesTest4()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");

            var checkbox2 = ChromeDriver.FindElement(By.XPath("//input[2]"));
            checkbox2.Click();
            var checkboxAttribute = checkbox2.GetAttribute("checked");
            Assert.IsNull(checkboxAttribute);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
