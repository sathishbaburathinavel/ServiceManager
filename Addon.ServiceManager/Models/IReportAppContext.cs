using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addon.ServiceManager.Models
{
    public interface IReportAppContext : IDisposable
    {
        DbSet<Report> Reports { get; }
        int SaveChanges();
        void MarkAsModified(Report item);
    }
}
