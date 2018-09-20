using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace TargetApplication.Tests.Helpers
{
    static class WaitForElement
    {
        public static bool WaitUntilElementIsPresent(this IWebDriver driver, By by, int timeout = 10)
        {
            for (var i = 0; i < timeout; i++)
            {
                if (driver.IsElementPresent(by)) return true;
                Thread.Sleep(1000);
            }
            return false;
        }

        public static bool IsElementPresent(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
