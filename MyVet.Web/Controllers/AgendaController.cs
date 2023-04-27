using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVet.Web.Data;
using MyVet.Web.Helpers;
using MyVet.Web.Models;
using System.Security.Cryptography.X509Certificates;


using System.Data;

using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using MyVet.Web.Data.Entities;

namespace MyVet.Web.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class AgendaController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly DataContext _dataContext;
        private readonly IAgendaHelper _agendaHelper;
        private readonly ICombosHelper _combosHelper;

        public AgendaController(
            DataContext dataContext, 
            IAgendaHelper agendaHelper,
            ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _agendaHelper = agendaHelper;
            _combosHelper = combosHelper;
        }

        public IActionResult Index()
        {
            //_dataContext.Agendas
            //    .Include(a => a.Owner)
            //    .ThenInclude(o => o.User)
            //    .Include(a => a.Pet)
            //    .Where(a => a.Date.Month >= DateTime.Today.Month && a.Date.Day >= DateTime.Today.Day && a.Date.Year >= DateTime.Today.Year)
            return View();
        }

        public async Task<IActionResult> AddDays()
        {
            await _agendaHelper.AddDaysAsync(7);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Assing()
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var agenda = await _dataContext.Agendas
            //    .FirstOrDefaultAsync(o => o.Id == id.Value);
            //if (agenda == null)
            //{
            //    return NotFound();
            //}

            var model = new AgendaViewModel
            {
                Id = 0,
                Owners = _combosHelper.GetComboOwners(),
                Pets = _combosHelper.GetComboPets(0)
            };

            return View(model);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
        public async Task<IActionResult> Assing(AgendaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Agenda agenda = new Agenda();
                if (agenda != null)
                {
                    agenda.IsAvailable = false;
                    agenda.Owner = await _dataContext.Owners.FindAsync(model.OwnerId);
                    agenda.Pet = await _dataContext.Pets.FindAsync(model.PetId);
                    agenda.Remarks = model.Remarks;
                    agenda.Date = model.Date;
                    _dataContext.Agendas.Add(agenda);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            model.Owners = _combosHelper.GetComboOwners();
            model.Pets = _combosHelper.GetComboPets(model.OwnerId);

            return View(model);
        }
        private static String ACTIVITY_ID = "z12gtjhq3qn2xxl2o224exwiqruvtda0i";

        public  void call()
        {
            //Console.WriteLine("Plus API - Service Account");
            //Console.WriteLine("==========================");

            //String serviceAccountEmail = "skypet@slaf-315317.iam.gserviceaccount.com";

            //var certificate = new X509Certificate2(@"key.p12", "notasecret", X509KeyStorageFlags.Exportable);

            //ServiceAccountCredential credential = new ServiceAccountCredential(
            //   new ServiceAccountCredential.Initializer(serviceAccountEmail)
            //   {
            //       Scopes = new[] { PlusService.Scope.PlusMe }
            //   }.FromCertificate(certificate));

            //// Create the service.
            //var service = new PlusService(new BaseClientService.Initializer()
            //{
            //    HttpClientInitializer = credential,
            //    ApplicationName = "Plus API Sample",
            //});

            //Activity activity = service.Activities.Get(ACTIVITY_ID).Execute();
            ////Console.WriteLine("  Activity: " + activity.Object.Content);
            //Console.WriteLine("  Video: " + activity.Object.Attachments[0].Url);

            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();
        }
        public class ReservationInfo
        {
            public string OrganizerId { get; set; }
            public string CustomerId { get; set; }
            public string OrganizerName { get; set; }
            public string OrganizerAddress { get; set; }
            public string OrganizerTel { get; set; }
            public string OrganizerMobile { get; set; }
            public string OrganizerEmail { get; set; }
            public string NIC { get; set; }
            public string ResReasonDesc { get; set; }
            public string ReservationId { get; set; }
            public bool IsTentative { get; set; }
            public long ReserveDate { get; set; }
            public DateTime CreateDate { get; set; }
            public string CreateBy { get; set; }
            public int ReservationTypeKeyId { get; set; }
            public string ReservationType { get; set; }
            public string TentativeType { get; set; }
            public float paymentAmount { get; set; }
            public DateTime ModifyDate { get; set; }
            public string ModifyBy { get; set; }
            public string CancelReason { get; set; }
            public int ResReasonKeyId { get; set; }
            public string status { get; set; }
            public int StatusCode { get; set; }
            public string StatusDesc { get; set; }
            public string PackageId { get; set; }
            public string PackageName { get; set; }
            public int NoOfPax { get; set; }
            public decimal totalAmount { get; set; }
            public decimal patailAmount { get; set; }
            public int paymentMasterKeyId { get; set; }
            public DateTime AdvancePayDate { get; set; }
            public DateTime patailAmountpayDate { get; set; }
            public string resTime { get; set; }
            public decimal rate { get; set; }
            public string remarks { get; set; }
            public string eventNo { get; set; }
            public int locationId { get; set; }
            public int rankId { get; set; }
            public string rankDesc { get; set; }
            public string personTypeId { get; set; }
            public int treatmentId { get; set; }
            public string mobileNo { get; set; }
            public int MedicalStatusId { get; set; }
            public string MedicalStatus { get; set; }
            public string BeauticianName { get; set; }
            public string BeauticianId { get; set; }
            public DateTime date { get; set; }
            public int ParadeStateId { get; set; }
            public string time { get; set; }
            public decimal price { get; set; }
            public string tratmentSubCat { get; set; }
            public int catid { get; set; }
            public string Endtime { get; set; }
        }
        public JsonResult getEvents()
        {
          var qw=  _dataContext.Agendas
                  .Include(a => a.Owner)
                  .ThenInclude(o => o.User)
                  .Include(a => a.Pet);
                  //.Where(a => a.Date.Month >= DateTime.Today.Month && a.Date.Day >= DateTime.Today.Day && a.Date.Year >= DateTime.Today.Year);
           // DataTable eventDetails = new DALReservationInfo().getReservationCalendeDetails();
            List<ReservationInfo> eventDetailsList = new List<ReservationInfo>();
            foreach (var dr in qw)
            {
                ReservationInfo info = new ReservationInfo();
                info.ReservationId = dr.Id.ToString();
                info.remarks = dr.Remarks.ToString();
                info.OrganizerName = dr.Owner.User.FullName.ToString();
                info.ReserveDate =  new DateTimeOffset(dr.Date).ToUnixTimeMilliseconds();
                eventDetailsList.Add(info);
            }
            return Json(eventDetailsList);
        }
        public async Task<IActionResult>GetPetsAsync(int? ownerId)
        {
            var pets =  await _dataContext.Pets
                .Where(p => p.Owner.Id == ownerId)
                .OrderBy(p => p.Name)
                .ToListAsync();
            return Json(pets);
        }
        public async Task<JsonResult> getpet(int? id)
        {
            var pets = await _dataContext.Pets
               .Where(p => p.Owner.Id == id)
               .OrderBy(p => p.Name)
               .ToListAsync();
            return Json(pets);
        }
        public async Task<JsonResult> getow(string id)
        {
            char[] MyChar = { '\n', '/', '"', ' ' };
            id = id.Trim(MyChar);
            try
            {
                var pets = await _dataContext.Owners.Include(p=>p.User)
                   .Where(p => p.User.Document.Contains(id))
                   .OrderBy(p => p.User.FirstName)
                   .ToListAsync();
                return Json(pets);
            }
            catch (Exception ex)
            {
                return Json(0);
            }
           
        }
        public async Task<IActionResult> Unassign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _dataContext.Agendas
                .Include(a => a.Owner)
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (agenda == null)
            {
                return NotFound();
            }

            agenda.IsAvailable = true;
            agenda.Pet = null;
            agenda.Owner = null;
            agenda.Remarks = null;

            _dataContext.Agendas.Update(agenda);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
