using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.IO;
using SkeltaFormAutomation.Library_UI;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace SkeltaFormAutomation.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        //[BeforeScenario]
        //public void BeforeScenario()
        //{
        //    //TODO: implement logic that has to run before executing each scenario
        //}

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    //TODO: implement logic that has to run after executing each scenario
        //}

        /// Intialize the Driver and Browser
        //[BeforeScenario(Order = 1)]
        //[Scope(Tag = "UI")]
        //public static void IntializeDriverAndBrowser()
        //{
        //    InitializeDriverAndBrowser();
        //}

        // Quit Driver After Scenario
        [AfterScenario(Order = 1)]
        [Scope(Tag = "UI")]
        public static void TakeScreenShotAndQutiDriverAfterScenario()
        {
            quitDriver();
        }

        public static void InitializeDriverAndBrowser()
        {
            OpenBrowser("Chrome");
            setImplicitTimeout(PropertiesCollection.driver, 30);
            maximizeBrowser(PropertiesCollection.driver);

        }

        public static void OpenBrowser(string BrowserName)
        {
            try
            {
                switch (BrowserName)
                {
                    case "Internet Explorer":
                        PropertiesCollection.driver = new InternetExplorerDriver();
                        PropertiesCollection.Browser = new Browser(PropertiesCollection.driver);
                        break;
                    case "FireFox":
                        PropertiesCollection.driver = new FirefoxDriver();
                        PropertiesCollection.Browser = new Browser(PropertiesCollection.driver);
                        break;
                    case "Chrome":
                        //PropertiesCollection.driver = new ChromeDriver(GlobalSettings.chromeDriverLocation); 

                        //Get Chrome driver location
                        string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                        string baseFolder = Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName;
                        string chromeDriverLocation = baseFolder + "\\BrowserDrivers\\";

                        //Disables Pop window
                        var options = new ChromeOptions();
                        options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                        PropertiesCollection.driver = new ChromeDriver(chromeDriverLocation, options);

                        PropertiesCollection.Browser = new Browser(PropertiesCollection.driver);
                        break;
                }
            }
            catch (ArgumentNullException e1)
            {
                Console.WriteLine("Browser was not found. Check a browser has been chosen in the app.config file. " + e1.Message);
                throw;
            }

            catch (TargetInvocationException e2)
            {
                Console.WriteLine("Check Driver location. " + e2.Message);
                throw;
            }
            catch (Exception e3)
            {
                Console.WriteLine("Driver Invocation encountered an error. " + e3.Message);
                throw;
            }

        }

        public static void setImplicitTimeout(IWebDriver driver, int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void maximizeBrowser(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void quitDriver()
        {
            quitDriver(PropertiesCollection.driver);
        }

        public static void quitDriver(IWebDriver driver)
        {
            try
            {
                driver.Quit();
                Console.WriteLine("Browser Driver was quit sucessfully");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Null Driver Reference, no driver object to Quit", e.Message);
            }
        }
    }
}
