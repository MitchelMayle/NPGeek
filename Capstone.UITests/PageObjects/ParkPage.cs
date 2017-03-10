using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.UITests.PageObjects
{
    public class ParkPage :BasePage 
    {
        public ParkPage(IWebDriver driver) : base (driver , "/Index")
        {
            PageFactory.InitElements(driver, this);
        }

        public ParkDetailPage SelectPark(string parkName)
        {
            IWebElement park = driver.FindElement(By.LinkText(parkName));
            park.Click();
            return new ParkDetailPage(driver);
        }

    }
}
