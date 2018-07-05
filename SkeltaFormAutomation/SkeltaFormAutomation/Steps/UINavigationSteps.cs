using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SkeltaFormAutomation.Library_UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using AutoIt;
using System.Threading;
using SkeltaFormAutomation.PageObjects;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SkeltaFormAutomation.Steps
{
    [Binding]
    public sealed class UINavigationSteps
    {
        public List<string> SubArtifactNameList = new List<string>();
        public List<string> NonFolderSubArtifactNameList = new List<string>();

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I launch (.*)")]
        public void GivenILaunch(string BrowserType)
        {
            //ScenarioContext.Current.Pending();
            if (string.Compare("Chrome",BrowserType,true)==0)
            {
                //Get Chrome drive rlocation
                string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                string baseFolder = Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName;
                string chromeDriverLocation = baseFolder + "\\BrowserDrivers\\";

                var options = new ChromeOptions();
                options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                //options.AddArgument("no-sandbox");
                PropertiesCollection.driver = new ChromeDriver(chromeDriverLocation, options, TimeSpan.FromMinutes(3));
                PropertiesCollection.Browser = new Browser(PropertiesCollection.driver);

                //setImplicitTimeout(PropertiesCollection.driver, 30);
                maximizeBrowser(PropertiesCollection.driver);
            }
            else if (string.Compare("Firefox", BrowserType, true) == 0)
            {
                ScenarioContext.Current.Pending();
                //IWebDriver driver = new FirefoxDriver();
                //PropertiesCollection.Browser = new Browser(PropertiesCollection.driver);
            }
            else if (string.Compare("Internet Explorer", BrowserType, true) == 0)
            {
                ScenarioContext.Current.Pending();
                //IWebDriver driver = new InternetExplorerDriver();
                //PropertiesCollection.Browser = new Browser(PropertiesCollection.driver);
            }
            else
            {
                Console.WriteLine("Invalid Browser name provided. Use only 'Chrome, Firefox, or Internet Explorer'");
            }
        }
        
        [Given(@"I navigate to (.*)")]
        public void GivenINavigateTo(string URL)
        {
            //ScenarioContext.Current.Pending();
            Thread.Sleep(1000);
            PropertiesCollection.driver.Navigate().GoToUrl(URL);
        }

        [Given(@"I log in using username (.*) and password (.*)")]
        public void GivenILogInUsingUsernameAndPassword(string Username, string Password)
        {
            //Wait until element is visible
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(Pages.SkeltaLandingPage.LoginPassword_Input));

            //Login with credentials
            Pages.SkeltaLandingPage.LoginUserName_Input.SendKeys(Username);
            Pages.SkeltaLandingPage.LoginPassword_Input.SendKeys(Password);
            Pages.SkeltaLandingPage.Login_Button.Click();
        }

        [Given(@"I close the open Browser")]
        public void GivenICloseTheOpenBrowser()
        {
            //ScenarioContext.Current.Pending();
            quitDriver();
        }

        [Given(@"I select (.*) on Navigation side bar")]
        public void GivenISelectOnNavigationSideBar(string Navigation)
        {
            //ScenarioContext.Current.Pending();
            if (String.Compare(Navigation, "Package",true)==0)
            {
                //Wait until element is visible
                WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3));
                wait.Until(ExpectedConditions.ElementToBeClickable(Pages.SkeltaHomePage.Package_Navigation));

                Pages.SkeltaHomePage.Package_Navigation.Click();
            }
        }

        [Given(@"I select (.*) on Package tab")]
        public void GivenISelectOnPackageTab(string SubNavigation)
        {
            IWebElement ExpectedElement = Pages.SkeltaHomePage.Package_Navigation;
            //ScenarioContext.Current.Pending();
            if (String.Compare(SubNavigation, "Package Template",true) == 0)
            {
                //Wait until element is visible
                ExpectedElement = Pages.SkeltaHomePage.PackageTemplate_Navigation;
            }

            if (String.Compare(SubNavigation, "Manage Package",true) == 0)
            {
                //Wait until element is visible
                ExpectedElement = Pages.SkeltaHomePage.ManagePackage_Navigation;
            }

            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(ExpectedElement));
            ExpectedElement.Click();
        }

        [Given(@"I switch to Iframe (.*) in Package Template")]
        public void GivenISwitchToIframeInPackageTemplate(string IframeName)
        {
            //ScenarioContext.Current.Pending();
            
            if (string.Compare(IframeName, "Mainframe", true) == 0)
            {
                SeleniumMethods.isElementPresent(Pages.PackageTemplate.Mainframe_iframe);
                SeleniumMethods.SwitchToFrameWebElement(Pages.PackageTemplate.Mainframe_iframe);
            }
            else if (string.Compare(IframeName, "Gridframe", true) == 0)
            {
                SeleniumMethods.isElementPresent(Pages.PackageTemplate.Gridframe_iframe);
                SeleniumMethods.SwitchToFrameWebElement(Pages.PackageTemplate.Gridframe_iframe);
            }
            else if (string.Compare(IframeName, "WindowCloseBehaviour", true) == 0)
            {
                //SeleniumMethods.isElementPresent(Pages.PackageTemplate.EditPackageTemplatePopup_Cancel_Button);
                SeleniumMethods.isElementPresent(Pages.PackageTemplate.WindowCloseBehaviour_iframe);
                SeleniumMethods.SwitchToFrameWebElement(Pages.PackageTemplate.IFrame(IframeName));
            }
            else
            {
                SeleniumMethods.isElementPresent(Pages.PackageTemplate.IFrame(IframeName));
                SeleniumMethods.SwitchToFrameWebElement(Pages.PackageTemplate.IFrame(IframeName));
            }
        }

        [Given(@"Skelta Package (.*) status is (.*)")]
        public void GivenSkeltaPackageStatusIs(string SkeltaPackageName, string Status)
        {
            //ScenarioContext.Current.Pending();
            //string XPath_PackageTemplateStatus = $"//tr/td[2]/nobr[contains(.,'{SkeltaPackageName}')]/following::*/nobr[contains(.,'{Status}')]";
            //string XPath_PackageTemplateStatus = $"//tr/td[2]/nobr[contains(.,'{SkeltaPackageName}')]/following::td[2]/nobr";
            string PackageTemplateStatus = Pages.PackageTemplate.PackageTemplateStatus(SkeltaPackageName).Text;
            StringAssert.AreEqualIgnoringCase(Status, PackageTemplateStatus, $"Status of package is {PackageTemplateStatus} and not {Status}");

            //bool StatusMatch = SeleniumMethods.isElementPresent(PropertiesCollection.driver.FindElement(By.XPath(XPath_PackageTemplateStatus)));
            //if (StatusMatch == false)
            //{
            //    #throw Exception e;
            //}
            //tr/td[2]/nobr[contains(.,'For Automation')]/following::*/nobr[contains(.,'Draft')]
        }


        [Then(@"I select Skelta Package (.*)")]
        public void GivenISelectSkeltaPackage(string SkeltaPackageName)
        {
            Pages.PackageTemplate.SkeltaPackage(SkeltaPackageName).Click();
            //ScenarioContext.Current.Pending();

        }

        [Given(@"I switch to default Frame")]
        public void GivenISwitchToDefaultFrame()
        {
            SeleniumMethods.SwitchToDefaultContent();
        }


        [Given(@"I select the (.*) Package button")]
        public void GivenISelectThePackageButton(string ActionName)
        {
            //ScenarioContext.Current.Pending();
            SeleniumMethods.isElementPresent(Pages.PackageTemplate.PackageTemplateActionButton(ActionName));
            Pages.PackageTemplate.PackageTemplateActionButton(ActionName).Click();
        }

        [Given(@"I select (.*) button in Edit Package Template")]
        public void GivenISelectButtonInEditPackageTemplate(string EditPackageTemplateButton)
        {
            //ScenarioContext.Current.Pending();
            //SeleniumMethods.isElementPresent(Pages.PackageTemplate.EditPackageTemplate_Button(EditPackageTemplateButton));
            SeleniumMethods.isElementPresent(Pages.PackageTemplate.EditPackageTemplate_SaveAndContinue);
            Pages.PackageTemplate.EditPackageTemplate_Button(EditPackageTemplateButton).Click();
        }

        [Then(@"I close the Popup window")]
        public void ThenICloseThePopupWindow()
        {
            //ScenarioContext.Current.Pending();
            SeleniumMethods.isElementPresent(Pages.SkeltaHomePage.PopupNotification_Close_Button);
            Pages.SkeltaHomePage.PopupNotification_Close_Button.Click();
        }

        [Given(@"Edit Package Template page is open")]
        public void GivenEditPackageTemplatePageIsOpen()
        {
            //ScenarioContext.Current.Pending();

            SeleniumMethods.isElementPresent(Pages.PackageTemplate.EditPackageTemplate_Cancel_Button);
        }

        [Given(@"I Expand (.*) under Configuration tab in Edit Package Template")]
        public void GivenIExpandUnderConfigurationTabInEditPackageTemplate(string ArtifactName)
        {
            //ScenarioContext.Current.Pending();
            //div/span[text()='Workflows']/parent::*/img[3][contains(@src,'MiddlePlus')]
            Pages.PackageTemplate.ExpandArtifactConfiguration_EditPackageTemplate(ArtifactName);
        }

        [Then(@"I count the number for ChildArtifacts in (.*)")]
        public void ThenICountTheNumberForChildArtifactsInForms(string ArtifactName)
        {
            //ScenarioContext.Current.Pending();

            //Get ID of ArtifactName <div> like this //div/div/div/div/span[text()='Forms']/parent::div
            string ArtifactElementID = Pages.PackageTemplate.ArtifactID_EditPackageTemplate(ArtifactName).GetAttribute("id");

            //Count number of SubArtifacts using ArtifactID
            IList<IWebElement> SubArtifacts = Pages.PackageTemplate.SubArtifactElements_EditPackageTemplate(ArtifactElementID);
            int NumSubArtifacts = SubArtifacts.Count;
            for (int i = 1; i < NumSubArtifacts+1; i++)
            {
                string SubArtifactName = Pages.PackageTemplate.SubArtifactText_EditPackageTemplate(ArtifactElementID, i).Text;
                //Add name of SubArtiface names to list
                SubArtifactNameList.Add(SubArtifactName);
            }
        }

        [Then(@"I identify the Non-folder ChildArtifacts in (.*)")]
        public void ThenICountTheNumberOfNon_FolderChildArtifactsInForms(string ArtifactName)
        {
            //ScenarioContext.Current.Pending();

            //Get ID of ArtifactName <div> like this //div/div/div/div/span[text()='Forms']/parent::div
            string ArtifactElementID = Pages.PackageTemplate.ArtifactID_EditPackageTemplate(ArtifactName).GetAttribute("id");

            //Identify Non-folder elements from folder elements
            for (int i = 1; i < SubArtifactNameList.Count+1; i++)
            {
                string NonFolderElementName = "";
                NonFolderElementName = Pages.PackageTemplate.IsSubArtifactFolder_EditPackageTemplate(ArtifactElementID, i);
                if (NonFolderElementName != "")
                {
                    NonFolderSubArtifactNameList.Add(NonFolderElementName);
                }
            }
        }

        [Then(@"I select (.*) for '(.*)' in Sub Artifact settings")]
        public void ThenISelectInSubArtifactSettings(string YesOrNo, string Label)
        {
            for (int i = 0; i < NonFolderSubArtifactNameList.Count; i++)
            {
                string NonFolderSubArtifactText = NonFolderSubArtifactNameList[i];

                //Switch to default iframe, then to window close behaviour for each iteration of non folder sub artifacts
                SeleniumMethods.SwitchToDefaultContent();
                SeleniumMethods.isElementPresent(Pages.PackageTemplate.WindowCloseBehaviour_iframe);
                SeleniumMethods.SwitchToFrameWebElement(Pages.PackageTemplate.IFrame("WindowCloseBehaviour"));

                //Open named subartifact
                Pages.PackageTemplate.NonFolderSubArtifact_EditPackageTemplate(NonFolderSubArtifactText).Click();

                //Change form settings
                SeleniumMethods.isElementPresent(Pages.PackageTemplate.SubArtifactSettingsHeader_EditPackageTemplate);
                SeleniumMethods.SwitchToFrameWebElement(Pages.PackageTemplate.SettingFrame_IFrame);
                Pages.PackageTemplate.NonFolderSubartifactSettings_EditPackageTemplate_Button(Label, YesOrNo).Click();

                //StringComparison StringContainIgnoreCase = StringComparison.OrdinalIgnoreCase;
                
                if ((Label.ToLower()).Contains("workflow"))
                {
                    try
                    {
                        Pages.PackageTemplate.SQLSCript_EditPackageTemplate_TextArea.Clear();
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }

            }
            //ScenarioContext.Current.Pending();
        }

        [Then(@"I select '(.*)' button in Edit Package Template window")]
        public void ThenISelectButtonInEditPackageTemplateWindow(string EPT_button)
        {
            //ScenarioContext.Current.Pending();

            //Switch to default iframe, then to window close behaviour for each iteration of non folder sub artifacts
            SeleniumMethods.SwitchToDefaultContent();
            SeleniumMethods.isElementPresent(Pages.PackageTemplate.WindowCloseBehaviour_iframe);
            SeleniumMethods.SwitchToFrameWebElement(Pages.PackageTemplate.IFrame("WindowCloseBehaviour"));

            //Select Save Template button
            SeleniumMethods.isElementPresent(Pages.PackageTemplate.EditPackageTemplate_SaveTemplate_Button);
            Pages.PackageTemplate.EditPackageTemplate_SaveTemplate_Button.Click();
        }



        [Given(@"I click on (.*) for Repository (.*)")]
        public void GivenIClickOnForRepository(string AutheticationProvider, string RepositoryName)
        {
            //ScenarioContext.Current.Pending();
            string ElementXpath = $"//div/div/div[text()='{RepositoryName}']//following::span[contains(.,'{AutheticationProvider}')]";
            IWebElement element = PropertiesCollection.driver.FindElement(By.XPath(ElementXpath));
            element.Click();
            Thread.Sleep(5000);
        }





        public static void setImplicitTimeout(IWebDriver driver, int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void maximizeBrowser(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
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

        public static void quitDriver()
        {
            quitDriver(PropertiesCollection.driver);
        }


    }
}
