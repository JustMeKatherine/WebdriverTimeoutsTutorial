using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace WebdriverTimeoutsTutorial
{
    public static class WebDriverCreator
    {
        public static IWebDriver BasicInitialize()
        {
            return new ChromeDriver(@"C:\Users\Kat\Documents\Visual Studio 2015\Projects\4_Selenium_own\WebdriverTimeoutsTutorial\Drivers");
            //return new FirefoxDriver(@"C:\Users\Kat\Documents\Visual Studio 2015\Projects\3_frameworki\WebdriverTimeoutsTutorial\Drivers\chromedriver.exe");
        }

        public static IWebDriver RemoteInitialize()
        {
            var capability = new DesiredCapabilities();
            //capability.SetCapability("browserstack.user", Environment.GetEnvironmentVariable("BROWSERSTACK_USER", EnvironmentVariableTarget.User));
            //capability.SetCapability("browserstack.key", Environment.GetEnvironmentVariable("BROWSERSTACK_KEY", EnvironmentVariableTarget.User));
            capability.SetCapability("browserstack.user", "katarzynakarp1");
            capability.SetCapability("browserstack.key", "ChKGEd5vbZsnkmXHgWHN");

            capability.SetCapability("browser", "Edge");
            capability.SetCapability("browser_version", "14.0");
            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "10");
            capability.SetCapability("resolution", "1024x768");

            capability.SetCapability("browserstack.debug", "true");

            var driver = new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capability);
            return driver;
        }
    }
}