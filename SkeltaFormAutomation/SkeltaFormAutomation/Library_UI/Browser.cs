using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeltaFormAutomation.Library_UI
{
    public class Browser
    {
        private readonly IWebDriver newWebDriver;

        public Browser(IWebDriver driver)
        {
            newWebDriver = driver;
        }


        public void GoToUrl(string url)
        {
            PropertiesCollection.driver.Url = url;
        }

    }
}
