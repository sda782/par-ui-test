using System;
using System.Threading;
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
        private static WebDriverWait wait;
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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            IWebElement record_table = wait.Until(d => d.FindElement(By.Id("record_table")));
            Assert.IsTrue(record_table.Text.Contains("shit label"));
            Console.WriteLine(record_table.Text);

            //filter
            IWebElement search = driver.FindElement(By.Id("searchinput")); //input field
            search.SendKeys("record 2"); //search word
            IWebElement searchbutton = driver.FindElement(By.Id("searchbutton")); //button
            searchbutton.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            record_table = wait.Until(d => d.FindElement(By.Id("record_table")));
            Console.WriteLine(record_table.Text);
            Assert.IsTrue(record_table.Text.Contains("record 2"));
            Assert.IsFalse(record_table.Text.Contains("record 1"));

            //add record
            string record_name = "testrecord2";
            IWebElement addname = driver.FindElement(By.Id("name_input")); //input field
            addname.SendKeys(record_name); //search word
            IWebElement addlabel = driver.FindElement(By.Id("label_input")); //input field
            addlabel.SendKeys("notgoodlabel"); //search word
            IWebElement addruntime = driver.FindElement(By.Id("run_time_input")); //input field
            addruntime.SendKeys("160"); //search word
            IWebElement adddate = driver.FindElement(By.Id("date_input")); //input field
            adddate.SendKeys("12122021");
            adddate.SendKeys(Keys.Tab);
            adddate.SendKeys("1625");
            //search word
            IWebElement addtrack = driver.FindElement(By.Id("track_input")); //input field
            addtrack.SendKeys("20"); //search word
            IWebElement addbutton = driver.FindElement(By.Id("add_button")); //button
            addbutton.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            record_table = wait.Until(d => d.FindElement(By.Id("record_table")));
            Assert.IsTrue(record_table.Text.Contains(record_name));
        }

        [ClassCleanup]
        public static void clean_up()
        {
            driver.Dispose();
            driver.Quit();
        }
    }
}
