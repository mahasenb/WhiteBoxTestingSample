using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace TargetApplication.Tests.PageWrappers
{
    public abstract class BasePageWrapper
    {
        private readonly string baseUrl;
        protected abstract string PageRoute { get; }

        protected RemoteWebDriver WebDriver;

        protected BasePageWrapper(RemoteWebDriver webDriver, string baseUrl)
        {
            WebDriver = webDriver;
            this.baseUrl = baseUrl;
        }

        protected void SelectDropDown(string dropDownId, int value)
        {
            var element = WebDriver.FindElementById(dropDownId);
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value.ToString(CultureInfo.InvariantCulture));
        }

        protected void ClickButton(string buttonIdentifier)
        {
            WebDriver.FindElement(By.Id(buttonIdentifier)).Click();
        }

        private string GetAbsoluteUrl()
        {
            return baseUrl + PageRoute;
        }

        public void NavigateToPage()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl());
        }
    }
}
