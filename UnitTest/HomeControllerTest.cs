using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Controllers;

namespace UnitTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void RegistrationView()
        {
            var controller = new HomeControllerTest();
            var result = controller.Registration as ViewResult;
            Assert.AreEqual("Registration", result.ViewName);
        }
    }
}
