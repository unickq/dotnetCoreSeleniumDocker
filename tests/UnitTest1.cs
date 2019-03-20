using System;
using System.Threading;
using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Tests
{
    [AllureNUnit]
    [Parallelizable(ParallelScope.Children)]
    public class Tests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [Test]
        
        public void Test1([Range(0, 2)] int x)
        {
            var capabilities = new DesiredCapabilities("chrome", "73.0", new Platform(PlatformType.Any));
            var driver = new RemoteWebDriver(new Uri("http://selenoid:4444/wd/hub"), capabilities);
            driver.Navigate().GoToUrl($"https://google.com/search?q={x}");
            Console.WriteLine(driver.Title);
            driver.Quit();
        }


        [Test]
        public void A()
        {
            Assert.IsNull(AllureLifecycle.Instance.ResultsDirectory);
        }
    }
}