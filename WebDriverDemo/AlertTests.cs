using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace WebDriverDemo
{
    class AlertTests
    {
        class Alerts
        {
            [Test]
            public void UnhandledAlertExceptionTest()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";

                //This step produce an alert on screen
                driver.FindElement(By.XPath("//*[@id='content']/p[4]/button")).Click();

                //Once alert is present try to click on any button on the page
                driver.FindElement(By.XPath("//*[@id='content']/p[16]/button")).Click();
            }
        }
        

        class SimpleAlerts
        {
            [Test]
            public void AlertTest()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
                driver.Manage().Window.Maximize();

                //This step produce an alert on screen
                driver.FindElement(By.XPath("//*[@id='content']/p[4]/button")).Click();

                // Switch the control of 'driver' to the Alert from main Window
                IAlert simpleAlert = driver.SwitchTo().Alert();

                // '.Text' is used to get the text from the Alert
                String alertText = simpleAlert.Text;
                Console.WriteLine("Alert text is " + alertText);

                // '.Accept()' is used to accept the alert '(click on the Ok button)'
                simpleAlert.Accept();
            }
        }

        class ConfirmationAlerts
        {
            [Test]
            public void Test()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
                driver.Manage().Window.Maximize();

                //This step produce an alert on screen
                IWebElement element = driver.FindElement(By.XPath("//*[@id='content']/p[8]/button"));

                // 'IJavaScriptExecutor' is an interface which is used to run the 'JavaScript code' into the webdriver (Browser)
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

                // Switch the control of 'driver' to the Alert from main window
                IAlert confirmationAlert = driver.SwitchTo().Alert();

                // Get the Text of Alert
                String alertText = confirmationAlert.Text;

                Console.WriteLine("Alert text is " + alertText);

                //'.Dismiss()' is used to cancel the alert '(click on the Cancel button)'
                confirmationAlert.Dismiss();
            }
        }

        class PromptAlerts
        {
            [Test]
            public void PromptTest()
            {
                IWebDriver driver = new ChromeDriver();

                driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
                driver.Manage().Window.Maximize();

                //This step produce an alert on screen
                IWebElement element = driver.FindElement(By.XPath("//*[@id='content']/p[11]/button"));

                // 'IJavaScriptExecutor' is an 'interface' which is used to run the 'JavaScript code' into the webdriver (Browser)        
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

                // Switch the control of 'driver' to the Alert from main window
                IAlert promptAlert = driver.SwitchTo().Alert();

                // Get the Text of Alert
                String alertText = promptAlert.Text;
                Console.WriteLine("Alert text is " + alertText);

                //'.SendKeys()' to enter the text in to the textbox of alert 
                promptAlert.SendKeys("Accepting the alert");

                Thread.Sleep(4000); //This sleep is not necessary, just for demonstration

                // '.Accept()' is used to accept the alert '(click on the Ok button)'
                promptAlert.Accept();
            }
        }








    }

}

