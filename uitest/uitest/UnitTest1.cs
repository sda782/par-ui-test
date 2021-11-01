using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace uitest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string driver_path = @"C:\Users\Andreas\Documents\GitHub\Programming\_Webdrivers";
        private static IWebDriver driver;

        [ClassInitialize]
        public static void init_setup(TestContext testContext)
        {
            //driver = new ChromeDriver(driver_path);
            driver = new FirefoxDriver(driver_path);
        }

        [TestMethod]
        public void TestMethod1()
        {
            string url = "https://sda782.github.io/par-web";
            driver.Navigate().GoToUrl(url);
            Assert.AreEqual(driver.Title, "Document");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            IWebElement record_table = wait.Until(d => d.FindElement(By.Id("record_table")));
            Assert.IsTrue(record_table.Text.Contains("shit label"));

        }
        [TestMethod]
        public void TestMethod2()
        {
            string filter_name = "record 1";
            string url = "https://sda782.github.io/par-web?name=" + filter_name;
            driver.Navigate().GoToUrl(url);
            Assert.AreEqual(driver.Title, "Document");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            IWebElement record_table = wait.Until(d => d.FindElement(By.Id("record_table")));
            Assert.IsTrue(record_table.Text.Contains(filter_name));

        }
        [ClassCleanup]
        public static void clean_up()
        {
            driver.Dispose();
            driver.Quit();
        }
    }
}
