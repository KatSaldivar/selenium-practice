using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;



namespace WebDriverDemo.WrapperFactory
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        public static IWebDriver driver; //HAD TO MAKE THIS PUBLIC FOR TEST FILE. WHY???

        public static IWebDriver Driver
        {
            get
            { //THIS KEPT ERRORING OUT BEFORE RUNNING, IT WORKED AFTER COMMENTING OUT. WHY???
                //if (driver == null)
                    //throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox": //DOESN'T WORK!!!
                    if (Driver == null)
                    {
                        driver = new FirefoxDriver(@"C:\Users\Katie\Documents\selenium\selenium-practice");
                        Drivers.Add("Firefox", Driver);
                    }
                    break;

                case "IE": 
                    if (Driver == null)
                    {
                        driver = new InternetExplorerDriver(@"C:\Users\Katie\Documents\selenium\selenium-practice");
                        Drivers.Add("IE", Driver);
                    }
                    break;

                case "Chrome":
                    if (Driver == null)
                    {
                        driver = new ChromeDriver();
                        Drivers.Add("Chrome", Driver);
                    }
                    break;
            }
        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}
