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
    public class PackageTemplate
    {
        [FindsBy(How = How.XPath, Using = "//iframe[@id='mainframe']")]
        public IWebElement Mainframe_iframe { get; set; }

        [FindsBy(How = How.XPath, Using = "//iframe[@id='gridframe']")]
        public IWebElement Gridframe_iframe { get; set; }

        //*[@id="RadWindowContentFramectl00_Cont_listControl1_ctl00_RadWindowManager1_WindowCloseBehaviour"]
        [FindsBy(How = How.XPath, Using = "//iframe[@name='WindowCloseBehaviour']")]
        public IWebElement WindowCloseBehaviour_iframe { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='content']/div[contains(.,'Edit')]")]
        public IWebElement PackageTemplate_Edit { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Save & Continue')]/parent::button")]
        public IWebElement EditPackageTemplate_SaveAndContinue { get; set; }
                      

        public IWebElement IFrame (string IFrameName)
        {
            string XPath_IFrame = $"//iframe[@name='{IFrameName}']";
            IWebElement IFrameElement = PropertiesCollection.driver.FindElement(By.XPath(XPath_IFrame));
            return IFrameElement;
        }

        [FindsBy(How = How.XPath, Using = "//iframe[@id='settingFrame']")]
        public IWebElement SettingFrame_IFrame { get; set; }

        public IWebElement SkeltaPackage(string SkeltaPackageName)
        {
            //tr/td[2]/nobr[text()='LPS2_Config_Report']/parent::*
            string ElementXpath = $"//tr/td[2]/nobr[text()='{SkeltaPackageName}']/parent::td/parent::tr";
            IWebElement ElementFound = PropertiesCollection.driver.FindElement(By.XPath(ElementXpath));

            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(ElementFound));
            return ElementFound;
        }

        public IWebElement PackageTemplateStatus(string SkeltaPackageName)
        {
            string XPath_PackageTemplateStatus = $"//tr/td[2]/nobr[contains(.,'{SkeltaPackageName}')]/following::td[2]/nobr";
            IWebElement ElementFound = PropertiesCollection.driver.FindElement(By.XPath(XPath_PackageTemplateStatus));
            return ElementFound;
        }

        public IWebElement PackageTemplateActionButton(string ActionButtonName)
        {
            string XPath_ActionButton = $"//div[@class='content']/div[contains(text(),'{ActionButtonName}')]/parent::div";
            IWebElement ElementFound = PropertiesCollection.driver.FindElement(By.XPath(XPath_ActionButton));
            return ElementFound;
        }

        public IWebElement EditPackageTemplate_Button(string ButtonName)
        {
            string XPath_ButtonName = $"//div[contains(text(),'{ButtonName}')]/parent::button";
            //SeleniumMethods.isElementPresent(PropertiesCollection.driver.FindElement(By.XPath(XPath_ButtonName)));
            IWebElement ElementFound = PropertiesCollection.driver.FindElement(By.XPath(XPath_ButtonName));
            return ElementFound;
        }

        public IWebElement ArtifactID_EditPackageTemplate(string ArtifactName)
        {
            //div/div/div/div/span[text()='Forms']/parent::div
            string XPath_ArtifactID = $"//div/div/div/div/span[text()='{ArtifactName}']/parent::div";
            IWebElement ArtifactIDElement = PropertiesCollection.driver.FindElement(By.XPath(XPath_ArtifactID));
            return ArtifactIDElement;
        }

        public IWebElement SubArtifactText_EditPackageTemplate(string ArtifactElementID, int SubArtifactIndex)
        {
            //div/div/div/div/span[text()='Forms']/parent::div
            //div[@id='GradPanelbar1_p0_p0_packageObjectsTreeView_t0_t4_t5']/div[6]/span
            string XPath_SubArtifactText = $"//div[@id='G{ArtifactElementID}']/div[{SubArtifactIndex}]/span";
            IWebElement SubArtifactText = PropertiesCollection.driver.FindElement(By.XPath(XPath_SubArtifactText));
            return SubArtifactText;
        }

        public string IsSubArtifactFolder_EditPackageTemplate(string ArtifactElementID, int SubArtifactIndex)
        {
            string XPath_IsSubArtifactFolder = $"//div[@id='G{ArtifactElementID}']/div[{SubArtifactIndex}]/img[5][(contains(@src,'folder.png'))]";
            string XPath_NonFolderSubArtifactText = $"//div[@id='G{ArtifactElementID}']/div[{SubArtifactIndex}]/span";
            string NonfolderSubArtifactText = "";
            bool IsFolderElementTag = true;
            try
            {
                //IWebElement IsSubArtifactFolder = PropertiesCollection.driver.FindElement(By.XPath(XPath_IsSubArtifactFolder));
                IsFolderElementTag = SeleniumMethods.isElementPresent(PropertiesCollection.driver.FindElement(By.XPath(XPath_IsSubArtifactFolder)));
                NonfolderSubArtifactText = "";
            }
            catch (Exception)
            {
                NonfolderSubArtifactText = PropertiesCollection.driver.FindElement(By.XPath(XPath_NonFolderSubArtifactText)).Text;
                //throw;
            }
            return NonfolderSubArtifactText;
        }

        public IList<IWebElement> SubArtifactElements_EditPackageTemplate(string ArtifactID)
        {
            //div[@id='GradPanelbar1_p0_p0_packageObjectsTreeView_t0_t4_t1']/div[*]
            string XPath_SubArtifactElements = $"//div[@id='G{ArtifactID}']/div[*]";
            IList<IWebElement> SubArtifactElements = PropertiesCollection.driver.FindElements(By.XPath(XPath_SubArtifactElements));
            return SubArtifactElements;
        }

        public void ExpandArtifactConfiguration_EditPackageTemplate(string ArtifactName)
        {
            string XPath_ExpandArtifactConfiguration = $"//div/span[text()='{ArtifactName}']/parent::*/img[3]";
            IWebElement ArtifactConfiguration = PropertiesCollection.driver.FindElement(By.XPath(XPath_ExpandArtifactConfiguration));

            string XPath_IsArtifactExpanded = XPath_ExpandArtifactConfiguration + $"/parent::*/img[3][contains(@src,'MiddleMinus')]";
            string XPath_IsArtifactNotExpanded = XPath_ExpandArtifactConfiguration + $"/parent::*/img[3][contains(@src,'MiddlePlus')]";
            bool IsArtifactExpanded = false;

            try
            {
                IsArtifactExpanded = SeleniumMethods.isElementPresent(PropertiesCollection.driver.FindElement(By.XPath(XPath_IsArtifactExpanded)));
            }
            catch (Exception)
            {
                //throw;
            }

            if (IsArtifactExpanded == false)
            {
                bool IsArtifactNotExpanded = SeleniumMethods.isElementPresent(PropertiesCollection.driver.FindElement(By.XPath(XPath_IsArtifactNotExpanded)));
                if (IsArtifactNotExpanded == true)
                {
                    IWebElement NotExpandedArtifact = PropertiesCollection.driver.FindElement(By.XPath(XPath_IsArtifactNotExpanded));
                    NotExpandedArtifact.Click();
                }
            }
            //return ArtifactConfiguration;
        }

        public IWebElement ArtifactConfiguration_EditPackageTemplate(string ArtifactName)
        {
            string XPath_ArtifactConfiguration = $"//div/span[text()='{ArtifactName}']";
            IWebElement ArtifactConfiguration = PropertiesCollection.driver.FindElement(By.XPath(XPath_ArtifactConfiguration));
            return ArtifactConfiguration;
        }

        public IWebElement NonFolderSubArtifact_EditPackageTemplate (string NonFolderSubArtifactText)
        {
            string XPath_NonFolderSubArtifactElement = $"//div/div/span[text()='{NonFolderSubArtifactText}']";
            IWebElement NonFolderSubArtifactElement = PropertiesCollection.driver.FindElement(By.XPath(XPath_NonFolderSubArtifactElement));
            return NonFolderSubArtifactElement;
        }

        public IWebElement NonFolderSubartifactSettings_EditPackageTemplate_Button(string Label, string YesOrNo)
        {
            string XPath_NonFolderSubArtifactSettings_Button = $"//div/div[contains(@data-bind,'visible: ') and contains(@class,'skctr skfdc') and contains(@data-sklp,'2')]/div/div/div[contains(text(),'{Label}')]/parent::*/parent::*/div[2]/div[2]/div/label/span[text()='{YesOrNo}']/parent::label";
            IWebElement NonFolderSubArtifactSettings_Button = PropertiesCollection.driver.FindElement(By.XPath(XPath_NonFolderSubArtifactSettings_Button));
            return NonFolderSubArtifactSettings_Button;
        }

        
        [FindsBy(How = How.XPath, Using = "//label[text()='Install']")]
        public IWebElement SubArtifactSettingsHeader_EditPackageTemplate { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Cancel')]/parent::button")]
        public IWebElement EditPackageTemplatePopup_Cancel_Button { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='btnCancel']")]
        public IWebElement EditPackageTemplate_Cancel_Button { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='btnSave']")]
        public IWebElement EditPackageTemplate_SaveTemplate_Button { get; set; }


    }
}
