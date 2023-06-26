using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCPracticals;
using MVCPracticals.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVCPracticals.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Hello World", result.ViewBag.Message);
        }
    }
}
