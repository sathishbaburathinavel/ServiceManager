﻿using System;

namespace Addon.ServiceManager.Models
{
    public class Report
    {

        public int Id { get; set; }

        public int RecordId { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalAmount { get; set; }

        public string BusinessId { get; set; }

        public string SystemId { get; set; }

    }
}