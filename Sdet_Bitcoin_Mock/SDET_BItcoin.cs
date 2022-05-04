using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdet_Bitcoin_Mock
{
    [TestClass]
    public class SDET_BItcoin
    {
        public IWebDriver Driver { get; private set; }
        public string HomeUrl = "http://cgross.github.io/angular-busy/demo/";
        private readonly By Template = By.Id("template");
        private readonly By DemoButton = By.XPath("/html/body/div[1]/div[2]/div[2]/div[1]/form/div[6]/button");
        private readonly By PleaseWait = By.XPath("/html/body/div/div[2]/div[2]/div[2]/div/div/div[2]/div/div[2]");

        [TestCleanup]
        public void TestCleanup()
        {
            Driver.Close();
        }
        [TestInitialize]
        public void TestIntitialize()
        {
            var ChromeOptions = new ChromeOptions();
            ChromeOptions.AddArguments();
            Driver = new ChromeDriver("C:\\Users\\rohan_reddy\\Downloads\\chromedriver_win32", ChromeOptions);
        }

        [TestMethod]
        public void VerifyMockPage()
        {
            Driver.Navigate().GoToUrl(HomeUrl);
            webdriverwaitforelementvisible(Template);
        }

        [TestMethod]
        public void VerifyDemoButtonOnMockPageWithPleaseWait()
        {
            Driver.Navigate().GoToUrl(HomeUrl);
            webdriverwaitforelementvisible(Template);
            Driver.FindElement(DemoButton).Click();
            webdriverwaitforelementvisible(PleaseWait);
        }

        private void webdriverwaitforelementvisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(15));
            wait.Until(Driver => Driver.FindElement(by));
        }
    }
}
