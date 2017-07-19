using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RotaGeek.Controllers;

namespace RotaGeek.UnitTests.Controllers
{
    [TestFixture]
    public class RotaGeekControllerShould
    {
        [Test]
        public void Return_Home_Page()
        {
            var controller = new RotaGeekController();

            var result = controller.Index();

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
