using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.UITests.PageObjects
{
    public class ParkDetailPage : BasePage
    {

        public ParkDetailPage(IWebDriver driver) : base(driver, "/Home/ParkDetail")
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName,Using="parkTitle")]
        public IWebElement ParkTitle { get; set; }


    }
}
