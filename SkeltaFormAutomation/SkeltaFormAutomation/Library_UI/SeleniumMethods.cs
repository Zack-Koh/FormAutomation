using AutoIt;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace SkeltaFormAutomation.Library_UI
{
    class SeleniumMethods
    {
        public static void SwitchToFrameWebElement(IWebElement element)
        {
            PropertiesCollection.driver.SwitchTo().Frame(element);
        }

        public static bool isElementPresent(IWebElement element)
        {
            bool foundElement = false;
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(15));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
                foundElement = true;
            }
            catch (WebDriverTimeoutException eTO)
            {
                foundElement = false;
            }
            return foundElement;
        }

        public static void SwitchToDefaultContent()
        {
            PropertiesCollection.driver.SwitchTo().DefaultContent();
        }
    }
    
}
