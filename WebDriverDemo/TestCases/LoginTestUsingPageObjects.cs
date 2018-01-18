﻿using System;
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
using WebDriverDemo.WrapperFactory;

namespace WebDriverDemo.TestCases
{
    class LoginTestUsingPageObjects
    {
        //http://toolsqa.com/selenium-c-sharp/?lipi=urn%3Ali%3Apage%3Ad_flagship3_messaging%3BJxOADBYURbyJrpH5uuKTtQ%3D%3D

        [Test]
            public void PageObjectLoginTest()
            {
            
                BrowserFactory.InitBrowser("Chrome");
                BrowserFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

                var homePage = new HomePage(WrapperFactory.BrowserFactory.driver);
                homePage.ClickOnMyAccount();

                var loginPage = new LoginPage(WrapperFactory.BrowserFactory.driver);
                loginPage.LoginToApplication("LogInTest");
            
                BrowserFactory.CloseAllDrivers();
        }

        
    }

}

