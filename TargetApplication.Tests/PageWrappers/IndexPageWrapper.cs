using OpenQA.Selenium.Remote;
using TargetLibrary;

namespace TargetApplication.Tests.PageWrappers
{
    public class IndexPageWrapper : BasePageWrapper
    {
        public IndexPageWrapper(RemoteWebDriver webDriver, string baseUrl) : base(webDriver, baseUrl)
        {
        }

        private const string GenderDropDownIdentifier = "GenderDropDown";
        private const string AgeGroupDropDownIdentifier = "AgeGroupDropDown";
        private const string ProvinceDropDownIdentifier = "ProvinceDropDown";
        private const string CalculateButtonIdentifier = "SubmitButton";

        protected override string PageRoute => "/Home/Index";

        public void SelectGender(Gender gender)
        {
            SelectDropDown(GenderDropDownIdentifier, (int) gender);
        }

        public void SelectAgeGroup(AgeGroup ageGroup)
        {
            SelectDropDown(AgeGroupDropDownIdentifier, (int) ageGroup);
        }

        public void SelectProvince(Province province)
        {
            SelectDropDown(ProvinceDropDownIdentifier, (int) province);
        }

        public void ClickCalculate()
        {
            ClickButton(CalculateButtonIdentifier);
        }
    }
}
