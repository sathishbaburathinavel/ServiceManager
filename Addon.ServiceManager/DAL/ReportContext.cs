using Addon.ServiceManager.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Addon.ServiceManager.DAL
{
    public class ReportContext :DbContext, IReportAppContext
    {
        public ReportContext():base("AzureConnection")
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