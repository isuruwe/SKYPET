using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data
{
    public interface IReportService
    {
        byte[] GenerateReportAsync(string reportName);
    }
}
