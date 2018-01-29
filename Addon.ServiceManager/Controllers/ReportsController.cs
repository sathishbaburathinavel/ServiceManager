using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Addon.ServiceManager.DAL;
using Addon.ServiceManager.Models;

namespace Addon.ServiceManager.Controllers
{
    public class ReportsController : ApiController
    {
        private IReportAppContext db = new ReportContext();

        public ReportsController()
        {

        }
        public ReportsController(IReportAppContext context)
        {
            db = context;
        }

        // GET: api/Reports
        public IQueryable<Report> GetReports()
        {
            return db.Reports;
        }

        // GET: api/Reports/5
        [ResponseType(typeof(Report))]
        public IHttpActionResult GetReport(int id)
        {
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        // PUT: api/Reports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReport(int id, Report report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != report.Id)
            {
                return BadRequest();
            }

            db.MarkAsModified(report);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Reports
        [ResponseType(typeof(Report))]
        public IHttpActionResult PostReport(Report report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reports.Add(report);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = report.Id }, report);
        }

        // DELETE: api/Reports/5
        [ResponseType(typeof(Report))]
        public IHttpActionResult DeleteReport(int id)
        {
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return NotFound();
            }

            db.Reports.Remove(report);
            db.SaveChanges();

            return Ok(report);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReportExists(int id)
        {
            return db.Reports.Count(e => e.Id == id) > 0;
        }
    }
}