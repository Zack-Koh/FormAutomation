using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using SkeltaFormAutomation.Library_UI;
using System.Collections;

namespace SkeltaFormAutomation.PageObjects
{
    public static class Pages
    {
        public static void Initilise()
        {
            ArrayList pages = new ArrayList();

            foreach (var page in pages)
            {

            }
        }

        public static SkeltaLandingPage SkeltaLandingPage
        {
            get
            {
                var SkeltaLandingPage = new SkeltaLandingPage();
                PageFactory.InitElements(PropertiesCollection.driver, SkeltaLandingPage);
                return SkeltaLandingPage;
            }
        }

        public static SkeltaHomePage SkeltaHomePage
        {
            get
            {
                var SkeltaHomePage = new SkeltaHomePage();
                PageFactory.InitElements(PropertiesCollection.driver, SkeltaHomePage);
                return SkeltaHomePage;
            }
        }

        public static PackageTemplate PackageTemplate
        {
            get
            {
                var PackageTemplate = new PackageTemplate();
                PageFactory.InitElements(PropertiesCollection.driver, PackageTemplate);
                return PackageTemplate;
            }
        }
    }
}
