using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

[assembly: Parallelize(Workers = 5, Scope = ExecutionScope.MethodLevel)]
namespace Sdet_Bitcoin_Mock
{
    [TestClass]
    public class SDET_BItcoin
    {
        public IWebDriver Driver { get; private set; }

        public string HomeUrl = "http://cgross.github.io/angular-busy/demo/";

        private readonly By DemoButton = By.XPath("/html/body/div[1]/div[2]/div[2]/div[1]/form/div[6]/button");
        private readonly By PleaseWait = By.XPath("/html/body/div/div[2]/div[2]/div[2]/div/div/div[2]/div/div[2]");
        private readonly By MessageTextId = By.Id("message");
        private readonly By Template = By.Id("template");
        private readonly By MinDuration = By.Id("durationInput");
        private readonly By TemplateUrlDropDown = By.Id("template");
        private readonly By Waiting = By.XPath("/html/body/div/div[2]/div[2]/div[2]/div/div/div[2]/div/div[2]");
        private readonly By DancingIcon = By.XPath("/html/body/div[1]/div[2]/div[2]/div[2]/div/div/div[2]");

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

        //Scenario 1 - Validate loading of the mock page and wait for the "Template" element to load.
        [TestMethod]
        public void VerifyMockPage()
        {
            Driver.Navigate().GoToUrl(HomeUrl);
            WaitForElementVisible(Template);
        }

        //Scenario 2 - Validate loading of the mock page, click on the "Demo" button and validate that the "Busy Indicator" is seen.
        [TestMethod]
        public void VerifyDemoButtonOnMockPageWithPleaseWait()
        {
            Driver.Navigate().GoToUrl(HomeUrl);
            WaitForElementVisible(Template);
            Driver.FindElement(DemoButton).Click();
            WaitForElementVisible(PleaseWait);
        }

        //Scenario 3 - Send the MinDuration value, clear the text, type "Waiting" and click "Demo", validate that the "Busy Indicator" with the given message is seen.
        [TestMethod]
        public void VerifyMockPageWithWaitingDelay()
        {
            Driver.Navigate().GoToUrl(HomeUrl);
            WaitForElementVisible(Template);
            Driver.FindElement(MinDuration).Clear();
            Driver.FindElement(MinDuration).SendKeys("1000");
            Driver.FindElement(MessageTextId).Clear();
            Driver.FindElement(MessageTextId).SendKeys("waiting");
            Driver.FindElement(DemoButton).Click();
            WaitForElementVisible(Waiting);
        }

        //Scenario 4 - Select "Custom-template.html" from the "TemplateURLDropDown" and validate that the "DancingIcon" element is visible.
        [TestMethod]
        public void VerifyMockPageWithCustomTemplate()
        {
            Driver.Navigate().GoToUrl(HomeUrl);
            WaitForElementVisible(Template);
            Driver.FindElement(TemplateUrlDropDown).SendKeys("custom-template.html");
            Driver.FindElement(DemoButton).Click();
            WaitForElementVisible(DancingIcon);
        }

        private void WaitForElementVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(15));
            wait.Until(Driver => Driver.FindElement(by));
        }
    }
}
