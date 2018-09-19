using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TargetApplication.Models;
using TargetLibrary;

namespace TargetApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(InsuranceRiskInformation riskInformation)
        {
            float riskFactor = CalculateInsuranceRiskFactor.GetRiskFactor(riskInformation);
            ViewBag.RiskFactor = riskFactor.ToString(CultureInfo.InvariantCulture);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
