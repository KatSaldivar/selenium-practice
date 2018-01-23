using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WebDriverDemo.TestDataAccess;
using WebDriverDemo.Extensions;

namespace WebDriverDemo.PageObjects
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "log")]
        [CacheLookup]
        private IWebElement UserName { get; set; }
        //private IWebElement screenLogin = Browser.Driver.FindElement(By.Id("log"));

        [FindsBy(How = How.Id, Using = "pwd")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        [CacheLookup]
        private IWebElement Submit { get; set; }

        public void LoginToApplication(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            UserName.EnterText(userData.Username, "UserName");
            Password.EnterText(userData.Password, "Password");
            Submit.ClickOnIt("Submit Button");
        }
    }

}

