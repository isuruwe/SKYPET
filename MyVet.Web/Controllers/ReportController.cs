using Microsoft.AspNetCore.Mvc;
using MyVet.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{reportName}")]
        public ActionResult Get(string reportName)
        {
            var returnString = _reportService.GenerateReportAsync(reportName);
            return new FileContentResult(returnString, "application/pdf");
        }
    }
}
