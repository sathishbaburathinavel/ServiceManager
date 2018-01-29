using Addon.ServiceManager.Models;
using System.Linq;

namespace Addon.ServiceManager.Tests
{
    class TestReportDbSet:TestDbSet<Report>
    {
        public override Report Find(params object[] keyValues)
        {
            return this.SingleOrDefault(report => report.Id == (int)keyValues.Single());
        }
    }
}
