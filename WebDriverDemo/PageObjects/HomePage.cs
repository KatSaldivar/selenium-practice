using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WebDriverDemo.Extensions;

namespace WebDriverDemo.PageObjects
{
    public class HomePage
    {
        [FindsBy(How = How.Id, Using = "account")]
        [CacheLookup]
        private IWebElement MyAccount { get; set; }

        public void ClickOnMyAccount()
        {
            //Here we are just passing the WebElement Name, so that it can be used in the Logs
            MyAccount.ClickOnIt("MyAccount");
        }
    }

}

