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
            // 0.01 + 0.01 + 0.01
            decimal expected = 0.03m;
            decimal actual = target.CalculateWith(Gender.Male, AgeGroup.LessThanTwenty, Province.Western);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario_Male_UnderForty_Uva()
        {
            // 0.01 + 0.03 + 0.02
            decimal expected = 0.06m;
            decimal actual = target.CalculateWith(Gender.Male, AgeGroup.TwentyOneToForty, Province.Uva);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario_Female_UnderSixty_Northern()
        {
            // 0.02 + 0.05 + 0.03
            decimal expected = 0.1m;
            decimal actual = target.CalculateWith(Gender.Female, AgeGroup.FortyOneToSixty, Province.Northern);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario_Female_OverSixty_Central()
        {
            // 0.02 + 0.08 + 0.01
            decimal expected = 0.11m;
            decimal actual = target.CalculateWith(Gender.Female, AgeGroup.AboveSixty, Province.Central);

            Assert.AreEqual(expected, actual);
        }

    }
}
