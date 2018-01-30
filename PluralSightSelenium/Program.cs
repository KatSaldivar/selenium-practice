using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;


namespace PluralSightSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://github.com/SeleniumHQ/selenium/wiki/Grid2
            //DesiredCapabilities capability = new DesiredCapabilities(); http://10.3.1.185:4444
            //ChromeOptions options = new ChromeOptions();
            //DesiredCapabilities dc = DesiredCapabilities.Chrome();
            //dc.SetCapability(ChromeOptions.Capability, options);
            IWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), DesiredCapabilities.Chrome());

            //IWebDriver driver = new ChromeDriver();
            //IWebDriver driver = new InternetExplorerDriver(@"C:\Users\katie.saldivar\Documents\");
            //IWebDriver driver = new FirefoxDriver(@"C:\Users\katie.saldivar\Documents\");

            /*
            driver.Url = @"file://10.1.2.245/Users/katie.Saldivar/My%20Documents/SeleniumTestCases/WebDriverDemo/WebDriverDemo/TestPage1.html";
            
            //      XPATH
            var xrow = driver.FindElement(By.XPath("/html/body/table/tbody/tr/td[2]/table/tbody/tr[2]/td"));
            Console.WriteLine(xrow.Text);

            //       TABLES
            var outerTable = driver.FindElement(By.TagName("table"));
            var innerTable = outerTable.FindElement(By.TagName("table"));
            var row = innerTable.FindElements(By.TagName("td"))[1];
            Console.WriteLine(row.Text);

            //      SELECT ITEMS
            var select = driver.FindElement(By.Id("Select1"));
            var tomOption = select.FindElements(By.TagName("option"))[2];
            tomOption.Click();
            var selectElement = new SelectElement(select);
            selectElement.SelectByText("Frank");
            
            //      CHECKBOXES
            var checkbox = driver.FindElement(By.Id("Checkbox1"));
            checkbox.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(500);
            checkbox.Click();
            
            //      RADIO BUTTONS
            var redRadioButton = driver.FindElements(By.Name("color"))[0];
            redRadioButton.Click();
            var radioButtons = driver.FindElements(By.Name("color"));
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.Selected)
                    Console.WriteLine(radioButton.GetAttribute("value"));
            }
            */

            //     GOOGLE IMAGE SEARCH TEST
            /*driver.Url = "http://www.google.com";      //or driver.Navigate().GoToUrl("http://www.google.com");
            var searchBox = driver.FindElement(By.Id("lst-ib"));
            searchBox.SendKeys("selenium");
            searchBox.SendKeys(Keys.Enter);
            var imagesLink = driver.FindElement(By.LinkText("Images"));
            imagesLink.Click();
            var firstImageLink = driver.FindElement(By.CssSelector("div[data-ri='0']")); 
            //driver.PageSource.Contains() //checks that something is on the page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(500);
            firstImageLink.Click();*/
            //driver.Close();

            //     EXPLICIT WAIT 
            driver.Navigate().GoToUrl("http://www.google.com"); //driver.Url = "http://www.google.com";      
            var searchBox = driver.FindElement(By.Id("lst-ib"));
            searchBox.SendKeys("selenium");
            searchBox.SendKeys(Keys.Enter);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var imagesLink = wait.Until(d =>
            {
                return driver.FindElement(By.LinkText("Images"));
                //if using elements (plural) you will need to modify to avoid getting an exception
                //var elements = driver.FindElements(By.ClassName("k1"));
                //if elements.Count > 0
                //return elements[0];
                //return null;
            });
            imagesLink.Click();
            var firstImageLink = driver.FindElement(By.CssSelector("div[data-ri='0']"));
            //driver.PageSource.Contains() //checks that something is on the page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(500);
            firstImageLink.Click();
            //driver.Close();
        }
    }
}
