using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace SAP.TimePicker
{
    public class SampleTimePickerPage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://openui5.hana.ondemand.com/explored.html?sap-ui-rtl=true#sample/sap.m.sample.TimePicker/preview";
        private WebDriverWait wait;

        public SampleTimePickerPage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();
            PageFactory.InitElements(this.driver, this);
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }

        [FindsBy(How = How.Id, Using = "__xmlview3--TP1-icon")]
        public IWebElement SimpleMinutesTimePickerOpenButton { get; set; }

        [FindsBy(How = How.Id, Using = "__xmlview3--TP1-inner")]
        public IWebElement SimpleMintuesTimePickerInput { get; set; }

        [FindsBy(How = How.Id, Using = "__button1-content")]
        public IWebElement SimpleMinutesTimePickerOKButton { get; set; }

        [FindsBy(How = How.Id, Using = "__xmlview3--TP1-sliders-listHours")]
        public IWebElement SimpleTimePickerHours { get; set; }

        [FindsBy(How = How.Id, Using = "__xmlview3--TP1-sliders-listMins")]
        public IWebElement SimpleTimePickerMinutes { get; set; }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void SelectTime(int hours,int minutes)
        {
            this.SimpleMinutesTimePickerOpenButton.Click();
            SimpleTimePickerHours.SendKeys(hours.ToString());
            SimpleTimePickerMinutes.SendKeys(minutes.ToString());
            this.SimpleMinutesTimePickerOKButton.Click();
        }

        public void AssertTime(int hours,int minutes)
        {
            Assert.AreEqual(string.Format("{0}:{1}", hours, minutes), this.SimpleMintuesTimePickerInput.GetAttribute("value"));
        }
    }
}
