using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RotaGeek.Controllers;
using RotaGeek.Services;
using RotaGeek.Services.Models;

namespace RotaGeek.UnitTests.Controllers
{
    [TestFixture]
    public class ContactUsControllerShould
    {
        private Mock<IFormService> _formServiceMock;
        private ContactUsController _contactUsController;
        private ContactForm _form;
        [SetUp]
        public void SetUp()
        {
            _form = new ContactForm()
            {
                Message = "message",
                Email = "ddd@gmail.com",
                Name = "hello world"
            };

            _formServiceMock = new Mock<IFormService>();
            _contactUsController = new ContactUsController(_formServiceMock.Object);

            _formServiceMock.Setup(x => x.SubmitAsync(It.IsAny<ContactForm>())).Returns(Task.FromResult(new OperationResult()));
        }

        [TearDown]
        public void TearDown()
        {
            _formServiceMock = null;
            _contactUsController = null;
        }

        [Test]
        public async Task Submit_Form_Via_Form_Service()
        {
            await _contactUsController.SubmitForm(_form);

            _formServiceMock.Verify(x => x.SubmitAsync(It.IsAny<ContactForm>()), Times.Once);
        }
        [Test]
        public async Task Return_Accepted_Status_Code_If_Succeed()
        {
            var result = (StatusCodeResult)await _contactUsController.SubmitForm(_form);

            Assert.That(result.StatusCode == (int)HttpStatusCode.Created);
        }
        [Test]
        public async Task Return_Errors_If_Failed()
        {
            var submissionResult = new OperationResult()
            {
                Errors = new List<string>()
                {
                    "Wrong name",
                    "Wrong email"
                },
                Success = false
            };
            _formServiceMock.Setup(x => x.SubmitAsync(It.IsAny<ContactForm>()))
                .Returns(Task.FromResult(submissionResult));

            var result = (JsonResult)await _contactUsController.SubmitForm(_form);

            var operationResult = (OperationResult)result.Value;
            Assert.That(result.StatusCode == (int)HttpStatusCode.BadRequest);
            Assert.That(operationResult.Errors.Count == 2);
            Assert.That(operationResult.Success == false);
        }

        [Test]
        public async Task Return_All_Forms()
        {
            var forms = new List<ContactForm>()
            {
                new ContactForm()
            };
            _formServiceMock.Setup(x => x.RetrieveAllContactForms()).ReturnsAsync(() => forms);

            var response = (JsonResult)await _contactUsController.Forms();

            var returnedForms = (IEnumerable<ContactForm>)response.Value;
            Assert.That(returnedForms.Count() == 1);
        }

        [Test]
        public async Task Return_Internal_Server_Error_When_Error_Occured()
        {
            _formServiceMock.Setup(x => x.RetrieveAllContactForms()).Throws<Exception>();

            var response = (StatusCodeResult)await _contactUsController.Forms();

            Assert.That(response.StatusCode == 500);
        }
    }
}
