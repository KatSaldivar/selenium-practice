using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebDriverDemo.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;

namespace WebDriverDemo.PageObjects
{
    class LoginTestUsingPageObjects
    {
  
            [Test]
            public void PageObjectLoginTest()
            {

                IWebDriver driver = new ChromeDriver();
                driver.Url = ConfigurationManager.AppSettings["URL"];

                var homePage = new HomePage(driver);
                homePage.ClickOnMyAccount();

                var loginPage = new LoginPage(driver);
                loginPage.LoginToApplication();

                driver.Close();
        }

        
    }

}

