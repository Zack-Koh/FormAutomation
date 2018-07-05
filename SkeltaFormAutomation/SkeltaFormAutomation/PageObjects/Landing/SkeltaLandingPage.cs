using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SkeltaFormAutomation.Library_UI;

namespace SkeltaFormAutomation.PageObjects
{
    public class SkeltaLandingPage
    {
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'Login1_UserName')]")]
        public IWebElement LoginUserName_Input { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'Login1_Password')]")]
        public IWebElement LoginPassword_Input { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@type,'submit')]")]
        public IWebElement Login_Button { get; set; }
    }
}
