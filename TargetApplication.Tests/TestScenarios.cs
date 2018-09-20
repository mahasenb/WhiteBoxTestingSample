using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TargetApplication.Tests.DSL;
using TargetLibrary;

namespace TargetApplication.Tests
{
    [TestClass]
    public class TestScenarios
    {
        private static RemoteWebDriver remoteWebDriver;
        private const string BaseUrl = "https://localhost:44353";

        private static InsuranceRiskFactorCalculation target;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            remoteWebDriver = new ChromeDriver(@"C:\Users\mahas\.nuget\packages\selenium.webdriver.chromedriver\2.42.0.1\driver\win32");
            target = new InsuranceRiskFactorCalculation(remoteWebDriver, BaseUrl);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            remoteWebDriver.Quit();
        }

        [TestMethod]
        public void Scenario_Male_UnderTwenty_Western()
        {
            float expected = 0.04f;
            float actual = target.CalculateWith(Gender.Male, AgeGroup.LessThanTwenty, Province.Western);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario_Male_UnderForty_Uva()
        {
            float expected = 0.06999999f;
            float actual = target.CalculateWith(Gender.Male, AgeGroup.TwentyOneToForty, Province.Uva);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario_Female_UnderSixty_Northern()
        {
            float expected = 0.09f;
            float actual = target.CalculateWith(Gender.Female, AgeGroup.FortyOneToSixty, Province.Northern);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario_Female_OverSixty_Central()
        {
            float expected = 0.09999999f;
            float actual = target.CalculateWith(Gender.Female, AgeGroup.AboveSixty, Province.Central);

            Assert.AreEqual(expected, actual);
        }

    }
}
