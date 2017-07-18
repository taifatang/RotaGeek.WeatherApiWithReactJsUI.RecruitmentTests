using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RotaGeek.UnitTests
{
    [TestFixture]
    public class ContactUsControllerShould
    {
        [Test]
        public void Return_Razor_View()
        {
            var controller = new ContactUsController();

            var result = controller.Index();

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void SubmitFormPost()
        {
        }
    }
}
