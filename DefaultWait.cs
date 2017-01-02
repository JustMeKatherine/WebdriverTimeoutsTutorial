using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace WebdriverTimeoutsTutorial
{
    [TestClass]
    public class DefaultWait
    {
        private IWebDriver _driver;
        private const string URI = "https://the-internet.herokuapp.com/dynamic_loading/2";
        private By elementId = By.Id("finish");
        private By elementXPath = By.XPath(".//*[@id='finish']");
        Stopwatch _stopwatch = new Stopwatch();

        [TestInitialize]
        public void Setup()
        {
            _driver = WebDriverCreator.RemoteInitialize();
            //_driver = WebDriverCreator.BasicInitialize();
            //go to a url that contains a dynamically loading page element
            _driver.Navigate().GoToUrl(URI);
            //click the start button
            _driver.FindElement(By.TagName("button")).Click();
        }

        [TestCleanup]
        public void Teardown()
        {
            _driver.Close();
            _driver.Quit();
        }

        [TestMethod]
        public void DefaultWaitTest()
        {
            //var wait = new DefaultWait<IWebDriver>(_driver)
            //{
            //    Timeout = TimeSpan.FromSeconds(10),
            //    PollingInterval = TimeSpan.FromSeconds(1)
            //};

            IClock clock = new SystemClock();
            var wait2 = new WebDriverWait(clock, _driver, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(1));
            //_stopwatch.Start();
            wait2.Until(ElementIsVisible(elementId));
            //wait.Until(ElementIsVisible(elementXPath));
            //_stopwatch.Stop();
            Trace.WriteLine($"Time elapsed for element identification: {_stopwatch.Elapsed.TotalSeconds}s");
        }
    }
}
