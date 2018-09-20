using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TargetApplication.Tests.Helpers;
using TargetApplication.Tests.PageWrappers;
using TargetLibrary;

namespace TargetApplication.Tests.DSL
{
    internal class InsuranceRiskFactorCalculation
    {
        private RemoteWebDriver remoteWebDriver;
        private string baseUrl;

        private const string ResultTextIdentifier = "ResultText";

        public InsuranceRiskFactorCalculation(RemoteWebDriver remoteWebDriver, string baseUrl)
        {
            this.remoteWebDriver = remoteWebDriver;
            this.baseUrl = baseUrl;
        }

        private IndexPageWrapper indexPage;

        internal decimal CalculateWith(Gender gender, AgeGroup ageGroup, Province province)
        {
            SubmitValuesInIndexPage(gender, ageGroup, province);
            remoteWebDriver.WaitUntilElementIsPresent(By.Id(ResultTextIdentifier));

            return decimal.Parse(remoteWebDriver.FindElementById(ResultTextIdentifier).Text);
        }

        private void SubmitValuesInIndexPage(Gender gender, AgeGroup ageGroup, Province province)
        {
            indexPage = new IndexPageWrapper(remoteWebDriver, baseUrl);
            indexPage.NavigateToPage();

            indexPage.SelectGender(gender);
            indexPage.SelectAgeGroup(ageGroup);
            indexPage.SelectProvince(province);

            indexPage.ClickCalculate();
        }
    }
}
