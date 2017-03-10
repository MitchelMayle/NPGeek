using Capstone.UITests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Capstone.UITests.StepDefinitions
{
    [Binding]
    public class ParkSteps
    {
        private readonly TestContext context;

        public ParkSteps(TestContext context)
        {
            this.context = context;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            context.Driver.Quit();
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            context.Driver.Navigate().GoToUrl("http://localhost:55601/");
        }

        [When(@"I click on ""(.*)""")]
        public void WhenIClickOn(string parkName)
        {
            ParkPage parkPage = new ParkPage(context.Driver);
            ParkDetailPage parkDetailPage = parkPage.SelectPark(parkName);

            ScenarioContext.Current.Set(parkDetailPage, "Current_Page");
        }

        [Then(@"I should See Details of ""(.*)""")]
        public void ThenIShouldSeeDetailsOf(string parkName)
        {
            ParkDetailPage parkDetailPage = ScenarioContext.Current.Get<ParkDetailPage>("Current_Page");

            Assert.AreEqual(parkName, parkDetailPage.ParkTitle.Text);
        }
    }
}
