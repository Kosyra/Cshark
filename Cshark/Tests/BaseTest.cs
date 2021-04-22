using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cshark.Tests
{
    public class BaseTest
    {
        protected readonly IWebDriver Driver;

        protected BaseTest() { Driver = new ChromeDriver(); }

        [SetUp]
        public void SetUp() => Driver.Manage().Window.Maximize();

        [TearDown]
        public void TearDown()
        {
            if (Driver == null) return;
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Quit();

        }

    }
}