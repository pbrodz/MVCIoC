using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCIoC.Controllers;
using System.Web.Mvc;
using MVCIoC.Models;

namespace MVCIoC.Tests.Controllers
{
    [TestClass]
    public class ProteinTrackerControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProteinTrackerController controller = new ProteinTrackerController(new StubTrackingService());
            var result = controller.Index() as ViewResult;

            Assert.AreEqual(0, result.ViewBag.Total);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var service = new StubTrackingService {Total = 10};

            ProteinTrackerController controller = new ProteinTrackerController(service);
            var result = controller.AddProtein(15) as ViewResult;

            if (result != null)
            {
                Assert.AreEqual(25, result.ViewBag.Total);
                Assert.AreEqual(0, result.ViewBag.Goal);
            }
        }

        public class StubTrackingService : IProteinTrackingService
        {
            public int Total { get; set; }
            public void AddProtein(int proteinGrams)
            {
                Total += proteinGrams;
            }
        }
    }
}
