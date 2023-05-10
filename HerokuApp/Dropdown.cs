using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuApp
{
    internal class Dropdown
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
        public void DropdownTest()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");

            var dropdown = ChromeDriver.FindElement(By.Id("dropdown"));
            dropdown.Click();

            var dropdownElements = ChromeDriver.FindElements(By.XPath("//option"));
            Assert.That(dropdownElements.Count().Equals(3));

            SelectElement selectElement1 = new SelectElement(ChromeDriver.FindElement(By.Id("dropdown")));
            selectElement1.SelectByText("Option 1");
            IWebElement selectedElement1 = ChromeDriver.FindElement(By.XPath("//option[@value='1']"));
            var selectedElementOne = selectedElement1.GetAttribute("selected");
            Assert.IsNotNull(selectedElementOne);
        }

        [Test]
        public void DropdownTest2()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");

            var dropdownElement2 = ChromeDriver.FindElement(By.XPath("//option[3]"));
            dropdownElement2.Click();
            Assert.IsTrue(dropdownElement2.Selected);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
