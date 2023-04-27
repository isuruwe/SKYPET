using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyVet.Web.Data;
using MyVet.Web.Data.Entities;
using MyVet.Web.Helpers;
using MyVet.Web.Models;
using MyVet.Web.Reports;

namespace MyVet.Web.Controllers
{
    public class HistoriesController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        public HistoriesController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        // GET: Histories
        public async Task<IActionResult> Index()
        {
            var model = new HistoryViewModel
            {
                Id = 0,
                ServiceTypes = _combosHelper.GetComboServiceTypes(),
                Owners = _combosHelper.GetComboOwners(),
                Pets = _combosHelper.GetComboPets(0)
            };
            var sd = await _context.Histories.Include(p => p.ServiceType)
                .Include(p => p.Pet).ThenInclude(o => o.Owner).ThenInclude(o => o.User).OrderBy(p => p.Date).ToListAsync();
            ViewBag.sd = sd;
                return View(model);
        }

        // GET: Histories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // GET: Histories/Create
        public IActionResult Create()
        {
            var model = new HistoryViewModel
            {
                Id = 0,
                ServiceTypes = _combosHelper.GetComboServiceTypes(),
                Owners = _combosHelper.GetComboOwners(),
                Pets = _combosHelper.GetComboPets(0)
            };
            return View(model);
        }
        public async Task<JsonResult> getpet(int? id)
        {
            var pets = await _context.Pets
               .Where(p => p.Owner.Id == id)
               .OrderBy(p => p.Name)
               .ToListAsync();
            return Json(pets);
        }
        // POST: Histories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Date,Remarks,ServiceTypeId,PetId")] HistoryViewModel history)
        {
            if (ModelState.IsValid)
            {
                History agenda = new History();
                if (agenda != null)
                {
                    agenda.Date = DateTime.Now;
                    agenda.Description = history.Description;
                    agenda.Pet = await _context.Pets.FindAsync(history.PetId);
                    agenda.ServiceType = await  _context.ServiceTypes.FindAsync(history.ServiceTypeId);
                    agenda.Remarks = history.Remarks;
                    _context.Histories.Add(agenda);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }


                //_context.Add(history);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(history);
        }
        public async Task<JsonResult> savep(string pid, string cons, string medi, 
            string surg, string dis, string dio, string oth, string dgn, string uss,
string consp, string medip, string surgp, string disp, string diop, string othp,
string dgnp, string ussp)
        {
            char[] MyChar = { '\n', '/', '"', ' ' };
            pid = pid.Trim(MyChar);
            cons = cons.Trim(MyChar);
            medi = medi.Trim(MyChar);
            surg = surg.Trim(MyChar);
            dis = dis.Trim(MyChar);
            dio = dio.Trim(MyChar);
            oth = oth.Trim(MyChar);
            dgn = dgn.Trim(MyChar);
            uss = uss.Trim(MyChar);
            consp = consp.Trim(MyChar);
            medip = medip.Trim(MyChar);
            surgp = surgp.Trim(MyChar);
            disp = disp.Trim(MyChar);
            diop = diop.Trim(MyChar);
            othp = othp.Trim(MyChar);
            dgnp = dgnp.Trim(MyChar);
            ussp = ussp.Trim(MyChar);


            try
            {
               string hid= Guid.NewGuid().ToString();
                string selectQuery = "";
                 selectQuery = "INSERT INTO [dbo].[Histories] ([Description],[Date],[Remarks],[ServiceTypeId],[PetId],[price],[Hid]) "+
    " VALUES ('"+ consp + "','"+DateTime.Now+"','"+ cons + "',2,'"+ pid + "',0,'"+ hid + "')";
                 Select(selectQuery);
                 selectQuery = "INSERT INTO [dbo].[Histories] ([Description],[Date],[Remarks],[ServiceTypeId],[PetId],[price],[Hid]) " +
   " VALUES ('" + medip + "','" + DateTime.Now + "','" + medi + "',8," + pid + ",0,'" + hid + "')";
                Select(selectQuery);
                selectQuery = "INSERT INTO [dbo].[Histories] ([Description],[Date],[Remarks],[ServiceTypeId],[PetId],[price],[Hid]) " +
  " VALUES ('" + surgp + "','" + DateTime.Now + "','" + surg + "',9," + pid + ",0,'" + hid + "')";
                Select(selectQuery);
                selectQuery = "INSERT INTO [dbo].[Histories] ([Description],[Date],[Remarks],[ServiceTypeId],[PetId],[price],[Hid]) " +
 " VALUES ('" + disp + "','" + DateTime.Now + "','" + dis + "',10," + pid + ",0,'" + hid + "')";
                Select(selectQuery);
                selectQuery = "INSERT INTO [dbo].[Histories] ([Description],[Date],[Remarks],[ServiceTypeId],[PetId],[price],[Hid]) " +
 " VALUES ('" + diop + "','" + DateTime.Now + "','" + dio + "',11," + pid + ",0,'" + hid + "')";
                Select(selectQuery);
                selectQuery = "INSERT INTO [dbo].[Histories] ([Description],[Date],[Remarks],[ServiceTypeId],[PetId],[price],[Hid]) " +
" VALUES ('" + othp + "','" + DateTime.Now + "','" + oth + "',12," + pid + ",0,'" + hid + "')";
                Select(selectQuery);
                selectQuery = "INSERT INTO [dbo].[Histories] ([Description],[Date],[Remarks],[ServiceTypeId],[PetId],[price],[Hid]) " +
" VALUES ('" + dgnp + "','" + DateTime.Now + "','" + dgn + "',13," + pid + ",0,'" + hid + "')";
                Select(selectQuery);
                selectQuery = "INSERT INTO [dbo].[Histories] ([Description],[Date],[Remarks],[ServiceTypeId],[PetId],[price],[Hid]) " +
" VALUES ('" + ussp + "','" + DateTime.Now + "','" + uss + "',14," + pid + ",0,'" + hid + "')";
                Select(selectQuery);

                return Json(0);
            }
            catch (Exception ex)
            {
                return Json(0);
            }

        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlConnection conn = ConnectionManager.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter adp = new SqlDataAdapter(command);
                adp.Fill(dt);
                conn.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }

        // GET: Histories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }
            return View(history);
        }

        // POST: Histories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Date,Remarks")] History history)
        {
            if (id != history.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoryExists(history.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(history);
        }

        // GET: Histories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // POST: Histories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var history = await _context.Histories.FindAsync(id);
            _context.Histories.Remove(history);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoryExists(int id)
        {
            return _context.Histories.Any(e => e.Id == id);
        }
    }
}
