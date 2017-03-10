using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.UITests
{
    public class TestContext
    {
        public IWebDriver Driver { get; set; }

        public TestContext()
        {
            if(Driver == null)
            {
                Driver = new ChromeDriver();
                Driver.Navigate().GoToUrl("http://localhost:55601/");
            }
        }
    }

}
