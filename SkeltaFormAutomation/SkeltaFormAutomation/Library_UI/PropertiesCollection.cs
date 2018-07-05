using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SkeltaFormAutomation.Library_UI
{
    public static class PropertiesCollection
    {
        private static IWebDriver newWebDriver;
        public static IWebDriver driver
        {
            get
            {
                return newWebDriver;
            }
            set
            {
                newWebDriver = value;
            }
        }

        public static Browser Browser { get; set; }
    }

}
