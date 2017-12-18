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
    class WindowTest
    {
        class MultipleWindow
        {
            [Test]
            public void MultipleWindowTest()
            {
                IWebDriver driver = new ChromeDriver();

                driver.Url = "http://toolsqa.com/automation-practice-switch-windows/";

                // Store the parent window of teh driver
                String parentWindowHandle = driver.CurrentWindowHandle;
                Console.WriteLine("Parent window's handle -> " + parentWindowHandle);

                IWebElement clickElement = driver.FindElement(By.Id("button1"));

                // Multiple click to open multiple window
                for (var i = 0; i < 3; i++)
                {
                    clickElement.Click();
                    Thread.Sleep(3000);
                }
            }
        }


        class PrintOutWindowHandles
        {
            [Test]
            public void PrintOutWindowHandlesTest()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Url = "http://toolsqa.com/automation-practice-switch-windows/";

                // Store the parent window of the driver
                String parentWindowHandle = driver.CurrentWindowHandle;
                Console.WriteLine("Parent window's handle -> " + parentWindowHandle);

                IWebElement clickElement = driver.FindElement(By.Id("button1"));

                // Multiple click to open multiple window
                for (var i = 0; i < 3; i++)
                {
                    clickElement.Click();
                    Thread.Sleep(3000);
                }

                // Store all the opened window into the list 
                // Print each and every items of the list
                List<string> lstWindow = driver.WindowHandles.ToList();
                foreach (var handle in lstWindow)
                {
                    Console.WriteLine(handle);
                }

            }
        }

        class HandleMultipleWindows
        {
            [Test]
            public void HandleMultipleWindowsTest()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Url = "http://toolsqa.com/automation-practice-switch-windows/";

                // Store the parent window of the driver
                String parentWindowHandle = driver.CurrentWindowHandle;
                Console.WriteLine("Parent window's handle -> " + parentWindowHandle);

                IWebElement clickElement = driver.FindElement(By.Id("button1"));

                // Multiple click to open multiple window
                for (var i = 0; i < 3; i++)
                {
                    clickElement.Click();
                    Thread.Sleep(3000);
                }

                // Store all the opened window into the 'list' 
                List<string> lstWindow = driver.WindowHandles.ToList();

                // Traverse each and every window 
                foreach (var handle in lstWindow)
                {
                    Console.WriteLine("Switching to window - > " + handle);
                    Console.WriteLine("Navigating to google.com");

                    //Switch to the desired window first and then execute commands using driver
                    driver.SwitchTo().Window(handle);
                    driver.Navigate().GoToUrl("http://google.com");
                }

            }
        }

        class ClosingAllWindows
        {
            [Test]
            public void ClosingAllWindowsTest()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Url = "http://toolsqa.com/automation-practice-switch-windows/";

                // Store the parent window into a variable for further use 
                String parentWindowHandle = driver.CurrentWindowHandle;
                Console.WriteLine("Parent window's handle -> " + parentWindowHandle);

                IWebElement clickElement = driver.FindElement(By.Id("button1"));
                //I am using 'for' loop to get multiple windows by clicking the element
                for (var i = 0; i < 3; i++)
                {
                    clickElement.Click();
                    Thread.Sleep(3000);
                }

                /*
                * driver.WindowHandles is a ReadOnlycollection So i am using '.ToList()' and store into the 'List<string>'
                * Again using 'for loop' to traverse all window which are opened by the above loop 
                * then i use '.SwitchTo().Window'. Basically this is use to switch your control from parent window to current window
                **/

                List<string> lstWindow = driver.WindowHandles.ToList();
                String lastWindowHandle = "";
                foreach (var handle in lstWindow)
                {
                    Console.WriteLine("Switching to window - > " + handle);
                    Console.WriteLine("Navigating to google.com");

                    //Switch to the desired window first and then execute commands using driver
                    driver.SwitchTo().Window(handle);

                    driver.Navigate().GoToUrl("http://google.com");
                    lastWindowHandle = handle;
                }

                //Switch to the parent window
                driver.SwitchTo().Window(parentWindowHandle);

                //close the parent window
                driver.Close();

                //at this point there is no focused window, we have to explicitly switch back to some window.
                driver.SwitchTo().Window(lastWindowHandle);

                driver.Url = "http://toolsqa.com";

            }
        }

    }


        }

