using Addon.ServiceManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Addon.ServiceManager.DAL
{
    public class ReportContext :DbContext, IReportAppContext
    {
        public ReportContext():base("ReportConnection")
        {

        }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void MarkAsModified(Report item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}