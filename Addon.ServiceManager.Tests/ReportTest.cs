using Addon.ServiceManager.Controllers;
using Addon.ServiceManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Web.Http.Results;

namespace Addon.ServiceManager.Tests
{
    [TestClass]
    public class TestProductController
    {
        [TestMethod]
        public void PostReport_ShouldReturnSameReport()
        {
            var controller = new ReportsController(new TestReportAppContext());

            var item = GetDemoReport();

            var result =
                controller.PostReport(item) as CreatedAtRouteNegotiatedContentResult<Report>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.TotalAmount, item.TotalAmount);
        }

        [TestMethod]
        public void PutProduct_ShouldReturnStatusCode()
        {
            var controller = new ReportsController(new TestReportAppContext());

            var item = GetDemoReport();

            var result = controller.PutReport(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            var controller = new ReportsController(new TestReportAppContext());

            var badresult = controller.PutReport(5, GetDemoReport());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetProduct_ShouldReturnProductWithSameID()
        {
            var context = new TestReportAppContext();
            context.Reports.Add(GetDemoReport());

            var controller = new ReportsController(context);
            var result = controller.GetReport(999) as OkNegotiatedContentResult<Report>;

            Assert.IsNotNull(result);
            Assert.AreEqual(999, result.Content.Id);
        }

        [TestMethod]
        public void GetProducts_ShouldReturnAllProducts()
        {
            var context = new TestReportAppContext();
            context.Reports.Add(new Report
            {
                Id = 599,
                Date = new DateTime(2005, 4, 1),
                TotalAmount = 234,
                BusinessId = 1,
                SystemId = "1"
            });
            context.Reports.Add(new Report
            {
                Id = 699,
                Date = new DateTime(2005, 3, 1),
                TotalAmount = 567,
                BusinessId = 2,
                SystemId = "1"
            });
            context.Reports.Add(new Report
            {
                Id = 799,
                Date = new DateTime(2005, 2, 1),
                TotalAmount = 890,
                BusinessId = 1,
                SystemId = "2"
            });

            var controller = new ReportsController(context);
            var result = controller.GetReports() as TestReportDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteProduct_ShouldReturnOK()
        {
            var context = new TestReportAppContext();
            var item = GetDemoReport();
            context.Reports.Add(item);

            var controller = new ReportsController(context);
            var result = controller.DeleteReport(999) as OkNegotiatedContentResult<Report>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        Report GetDemoReport()
        {
            return new Report()
            {
                Id = 999,
                Date = new DateTime(2005, 1, 1),
                TotalAmount = 5553,
                BusinessId = 1,
                SystemId = "1"
            };
        }
    }
}

