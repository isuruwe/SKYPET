
using MyVet.Web.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Web.Data
{
   
   
    public class ReportService : IReportService
    {
        SqlConnection oSqlConnection;
        SqlCommand oSqlCommand;
        SqlDataAdapter oSqlDataAdapter;
        public string sqlQuery;
//        public byte[] GenerateReportAsync(string reportName)
//        {
//            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("MyVet.Web.dll", string.Empty);
//            string rdlcFilePath = string.Format("{0}Reports\\{1}.rdlc", fileDirPath, "Invoice");
//            Dictionary<string, string> parameters = new Dictionary<string, string>();
//            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
//            Encoding.GetEncoding("windows-1252");
//            LocalReport report = new LocalReport(rdlcFilePath);

//            //List<UserDto> userList = new List<UserDto>();
//            //userList.Add(new UserDto
//            //{
//            //    FirstName = "Alex",
//            //    LastName = "Smith",
//            //    Email = "alex.smith@gmail.com",
//            //    Phone = "2345334432"
//            //});

//            //userList.Add(new UserDto
//            //{
//            //    FirstName = "John",
//            //    LastName = "Legend",
//            //    Email = "john.legend@gmail.com",
//            //    Phone = "5633435334"
//            //});

//            //userList.Add(new UserDto
//            //{
//            //    FirstName = "Stuart",
//            //    LastName = "Jones",
//            //    Email = "stuart.jones@gmail.com",
//            //    Phone = "3575328535"
//            //});
          
//        DataTable odsvoltxndata6 = new DataTable();
//            oSqlCommand = new SqlCommand();
//            string selectQuery = "SELECT a.[Id]as InvoiceNo,[Description] as Amount,[Date],b.Name as CustomerName,c.Name as Treatment" +
//"  FROM[SKYPET].[dbo].[Histories] as a left join[dbo].[Pets] as b on a.PetId = b.Id left join[dbo].[ServiceTypes] " +
//" as c on c.Id = a.ServiceTypeId where a.id="+reportName+"";
//            DataTable dt = Select(selectQuery);
           
//            report.AddDataSource("DataSet1", dt);
//            var result = report.Execute(GetRenderType("pdf"), 1, parameters);
//            return result.MainStream;
//        }
//        public DataTable Select(string sql)
//        {
//            DataTable dt = new DataTable();

//            try
//            {
//                SqlConnection conn = ConnectionManager.Open();
//                SqlCommand command = new SqlCommand(sql, conn);
//                SqlDataAdapter adp = new SqlDataAdapter(command);
//                adp.Fill(dt);
//                conn.Close();

//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//            return dt;
//        }
//        private RenderType GetRenderType(string reportType)
//        {
//            var renderType = RenderType.Pdf;
//            switch (reportType.ToLower())
//            {
//                default:
//                case "pdf":
//                    renderType = RenderType.Pdf;
//                    break;
//                case "word":
//                    renderType = RenderType.Word;
//                    break;
//                case "excel":
//                    renderType = RenderType.Excel;
//                    break;
//            }

//            return renderType;
//        }
    }
}
