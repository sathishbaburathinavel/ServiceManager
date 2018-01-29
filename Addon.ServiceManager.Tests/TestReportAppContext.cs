using Addon.ServiceManager.Models;
using System.Data.Entity;

namespace Addon.ServiceManager.Tests
{
    public class TestReportAppContext : IReportAppContext
    {
        public TestReportAppContext()
        {
            this.Reports = new TestReportDbSet();
        }

        public DbSet<Report> Reports { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Report item) { }
        public void Dispose() { }
    }
}
