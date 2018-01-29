using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Addon.ServiceManager.Models
{
    public class Report
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalAmount { get; set; }

        public int BusinessId { get; set; }

        public int SystemId { get; set; }

    }
}