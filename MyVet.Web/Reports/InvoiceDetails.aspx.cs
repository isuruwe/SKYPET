
//using Microsoft.Reporting.WebForms;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using Microsoft.Web.UI;
//using System.Web.UI.WebControls;

//namespace HMS.Reports
//{
//    public partial class InvoiceDetails : System.Web.UI.Page
//    {
//        SqlConnection oSqlConnection;
//        SqlCommand oSqlCommand;
//        SqlDataAdapter oSqlDataAdapter;
//        public string sqlQuery;
//        string resID;
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!Page.IsPostBack)
//            {
//                if (Request.QueryString["ResId"] != null)
//                {
//                    resID = Request.QueryString["ResId"].ToString();
//                }

//                DataTable odsvoltxndata6 = new DataTable();
//                oSqlCommand = new SqlCommand();
//                string selectQuery = "SELECT RD.ReservationId AS InvoiceNo,GETDATE() AS Date,RM.PersonName AS CustomerName,RR.ResReasonDesc AS Treatment,PD.PaidAmount AS Amount " +
//                                     "FROM  PaymentDetail PD  " +
//                                     "INNER JOIN ReservationReasons RR ON PD.TreatmentId = RR.ResReasonKeyId   " +
//                                     "INNER JOIN dbo.ReservationDetails RD ON PD.ReservationId =RD.ReservationId " +
//                                     "INNER JOIN dbo.ReservationMaster RM ON RD.CustomerId = Rm.CustomerId " +
//                                     "WHERE PD.ReservationId = '" + resID + "' AND PD.Status = 1";
//                DataTable dt = Select(selectQuery);
//                ReportDataSource rds = new("Invoice", dt);
//                ReportViewer1.LocalReport.DataSources.Add(rds);
//                ReportViewer1.LocalReport.Refresh();
//                ReportViewer1.DataBind();
//            }
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
//    }
//}