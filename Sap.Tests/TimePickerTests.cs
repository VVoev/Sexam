using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SAP.TimePicker;
using OpenQA.Selenium.Chrome;

namespace Sap.Tests
{
    [TestClass]
    public class TimePickerTests
    {
        private IWebDriver driver;
        private SampleTimePickerPage page;
        
        [TestInitialize]
        public void TestInit()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            this.page = new SampleTimePickerPage(this.driver);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.driver.Quit();
        }

        [TestMethod]
        public void OpenSimpleTimePickerWithLowerBoundaryValue()
        {
            this.page.Navigate();
            this.page.SelectTime(22, 16);
            this.page.AssertTime(22, 16);
        }
    }
}
