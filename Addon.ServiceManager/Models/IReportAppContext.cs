using System;
using System.Data.Entity;

namespace Addon.ServiceManager.Models
{
    public interface IReportAppContext : IDisposable
    {
        DbSet<Report> Reports { get; }
        int SaveChanges();
        void MarkAsModified(Report item);
    }
}
