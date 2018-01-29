using Addon.ServiceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
