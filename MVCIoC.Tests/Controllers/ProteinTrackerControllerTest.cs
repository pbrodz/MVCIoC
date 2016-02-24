using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCIoC.Controllers;
using System.Web.Mvc;

namespace MVCIoC.Tests.Controllers
{
    [TestClass]
    public class ProteinTrackerControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProteinTrackerController controller = new ProteinTrackerController();
            var result = controller.Index() as ViewResult;

            Assert.AreEqual(0, result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);
        }
    }
}
