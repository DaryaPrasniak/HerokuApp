using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace HerokuApp
{
    [TestFixture]
    internal class Tests
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
        public void AddRemoveElementsTest()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
            IWebElement addElement = ChromeDriver.FindElement(By.XPath("//button[text()='Add Element']"));
            addElement.Click();
            addElement.Click();

            IWebElement removeElement =ChromeDriver.FindElement(By.XPath("//button[text()='Delete']"));
            removeElement.Click();

            var deleteButton = ChromeDriver.FindElements(By.XPath("//button[text()='Delete']"));
            Assert.That(deleteButton.Count, Is.EqualTo(1));          
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}