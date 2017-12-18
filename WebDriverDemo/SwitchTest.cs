using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebDriverDemo
{
    public class SwitchTest
    {
        private ChromeDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Url = "http://toolsqa.wpengine.com/automation-practice-switch-windows/";
        }

        [Test]
        public void OpenJavaScriptAlert()
        {
            var alertButton = _driver.FindElement(By.Id("alert"));
            alertButton.Click();
            var alert = _driver.SwitchTo().Alert();
            var expectedAlertText = "Knowledge increases by sharing but not by saving. Please share " +
                "this website with your friends and in your organization.";
            Assert.AreEqual(expectedAlertText, alert.Text);
        }
        
        [Test]
        public void OpenNewBrowserWindow()
        {
            //Step 1
            var newBrowserWindowButton = _driver.FindElement(By.Id("button1"));
            Assert.AreEqual(1, _driver.WindowHandles.Count);

            string originalWindowTitle = "Demo Windows for practicing Selenium Automation";
            Assert.AreEqual(originalWindowTitle, _driver.Title);

            //Step 2
            newBrowserWindowButton.Click();
            Assert.AreEqual(2, _driver.WindowHandles.Count);

            //Step 3
            string newWindowHandle = _driver.WindowHandles.Last();
            var newWindow = _driver.SwitchTo().Window(newWindowHandle);

            string expectedNewWindowTitle = "QA Automation Tools Tutorial";
            Assert.AreEqual(expectedNewWindowTitle, newWindow.Title);
        }

        [Test]
        public void OpenBrowserTab()
        {
            //Step 1
            var alertButton = _driver.FindElement(By.XPath("/html/body/div[1]/div[5]/div[2]/div/div/p[4]/button"));
            alertButton.Click();

            string originalTabTitle = "Demo Windows for practicing Selenium Automation";
            Assert.AreEqual(originalTabTitle, _driver.Title);

            //Step 2
            string newTabHandle = _driver.WindowHandles.Last();
            var newTab = _driver.SwitchTo().Window(newTabHandle);

            var expectedNewTabTitle = "QA Automation Tools Tutorial";
            Assert.AreEqual(expectedNewTabTitle, newTab.Title);

            //Step 3
            var originalTab = _driver.SwitchTo().Window(_driver.WindowHandles.First());
            Assert.AreEqual(originalTabTitle, originalTab.Title);
        }

        
    }
}
