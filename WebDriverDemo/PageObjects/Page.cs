using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverDemo.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverDemo.PageObjects
{
    namespace OnlineStore.PageObjects
    {
        public static class Page
        {
            private static T GetPage<T>() where T : new()
            {
                var page = new T();
                PageFactory.InitElements(BrowserFactory.Driver, page);
                return page;
            }

            public static HomePage Home
            {
                get { return GetPage<HomePage>(); }
            }

            public static LoginPage Login
            {
                get { return GetPage<LoginPage>(); }
            }
        }
    }
}
