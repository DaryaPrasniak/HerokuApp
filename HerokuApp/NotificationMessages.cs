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
    internal class NotificationMessages
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
        public void NotificationMessagesTest()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/notification_message_rendered");
            IWebElement clickButton = ChromeDriver.FindElement(By.LinkText("Click here"));
            clickButton.Click();
            ChromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);

            var messageText = ChromeDriver.FindElement(By.Id("flash"));
            Assert.That(messageText.Text, Is.EqualTo("Action successful\r\n×"));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
