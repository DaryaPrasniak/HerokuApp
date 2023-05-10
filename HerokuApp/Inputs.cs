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
    internal class Inputs
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
        public void InputsTest()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/inputs");
            var inputsNumber = ChromeDriver.FindElement(By.TagName("input"));


            inputsNumber.SendKeys("test text");
            inputsNumber.SendKeys(Keys.ArrowUp + Keys.ArrowDown);
            var inputText1 = inputsNumber.GetAttribute("value");
            Assert.That(inputText1, Is.EqualTo("0"));

            inputsNumber.Clear();
            inputsNumber.Click();
            inputsNumber.SendKeys("123456");
            inputsNumber.SendKeys(Keys.ArrowDown);
            var inputText2 = inputsNumber.GetAttribute("value");
            Assert.That(inputText2, Is.EqualTo("123455"));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
