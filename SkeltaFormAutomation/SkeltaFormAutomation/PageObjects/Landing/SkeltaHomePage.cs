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
    public class SkeltaHomePage
    {
        [FindsBy(How = How.XPath, Using = "//md-toolbar[@title='Package']")]
        public IWebElement Package_Navigation { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-toolbar[@title='Package Template']")]
        public IWebElement PackageTemplate_Navigation { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-toolbar[@title='Manage Package']")]
        public IWebElement ManagePackage_Navigation { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value ='Close']")]
        public IWebElement PopupNotification_Close_Button { get; set; }
    }
}
