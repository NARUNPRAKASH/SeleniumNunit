using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SeleniumNUnit
{
    public class FinalPracticeProject
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void AllElementsTest()
        {
            // 1. Navigate
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            Thread.Sleep(5000); // Wait for page load

            // 2. Radio Button
            driver.FindElement(By.XPath("//input[@value='radio2']")).Click();

            // 3. Suggestion Box
            driver.FindElement(By.Id("autocomplete")).SendKeys("Ind");
            Thread.Sleep(2000);

            // 4. Dropdown
            driver.FindElement(By.Id("dropdown-class-example")).SendKeys("Option 2");

            // 5. Checkbox
            driver.FindElement(By.Id("checkBoxOption1")).Click();

            // 6. Alerts
            driver.FindElement(By.Id("name")).SendKeys("Student");
            driver.FindElement(By.Id("alertbtn")).Click();
            Thread.Sleep(2000);

            // 7. Alert Handling
            var simpleAlert = driver.SwitchTo().Alert();
            string alertText = simpleAlert.Text;
            simpleAlert.Accept(); // OK Click

            // 8. Validation
            Assert.That(alertText, Does.Contain("Student"));

            TestContext.Progress.WriteLine("Test Passed Successfully!");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}