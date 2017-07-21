using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using RotaGeek.Providers;
using RotaGeek.Repository;
using RotaGeek.Services;
using RotaGeek.Services.Models;

namespace RotaGeek.UnitTests.Services
{
    [TestFixture]
    public class FormServiceShould
    {
        private Mock<IFormValidationProvider> _formValidatorMock;
        private Mock<IDocumentDbRepository<ContactForm>> _documentDbMock;
        private FormService _formService;

        [SetUp]
        public void SetUp()
        {
            _formValidatorMock = new Mock<IFormValidationProvider>();
            _documentDbMock = new Mock<IDocumentDbRepository<ContactForm>>();
            _formService = new FormService(_formValidatorMock.Object, _documentDbMock.Object);

            _formValidatorMock.Setup(x => x.ValidateAsync(It.IsAny<ContactForm>()))
                .Returns(Task.FromResult(new OperationResult()));
        }

        [TearDown]
        public void TearDown()
        {
            _formValidatorMock = null;
            _formService = null;
        }

        [Test]
        public async Task Submit_Form()
        {
            await _formService.SubmitAsync(new ContactForm());

            _documentDbMock.Verify(x => x.CreateOrUpdateItemAsync(It.IsAny<ContactForm>()), Times.Once);
        }

        [Test]
        public async Task Submit_Form_SuccessFully()
        {
            var actionResult = await _formService.SubmitAsync(new ContactForm());

            _documentDbMock.Verify(x => x.CreateOrUpdateItemAsync(It.IsAny<ContactForm>()), Times.Once);
            Assert.That(actionResult.Success);
            Assert.That(actionResult.Errors.Any() == false);
        }

        [Test]
        public async Task Validate_Form_Fields()
        {
            await _formService.SubmitAsync(new ContactForm());

            _formValidatorMock.Verify(x => x.ValidateAsync(It.IsAny<ContactForm>()), Times.Once);
        }

        [Test]
        public async Task Return_Errors_From_Validation()
        {
            var validationResult = new OperationResult()
            {
                Errors = new List<string>()
                {
                    "Wrong name",
                    "Wrong email"
                }
            };
            _formValidatorMock.Setup(x => x.ValidateAsync(It.IsAny<ContactForm>())).Returns(Task.FromResult(validationResult));

            var submissionResult = await _formService.SubmitAsync(new ContactForm());

            Assert.That(submissionResult.Errors.Count == validationResult.Errors.Count);
        }

        [Test]
        public async Task Not_Submit_When_Validation_Failed()
        {
            var validationResult = new OperationResult()
            {
                Errors = new List<string>()
                {
                    "Wrong name",
                    "Wrong email"
                },
                Success = false
            };
            _formValidatorMock.Setup(x => x.ValidateAsync(It.IsAny<ContactForm>())).Returns(Task.FromResult(validationResult));

            await _formService.SubmitAsync(new ContactForm());

            _documentDbMock.Verify(x => x.CreateOrUpdateItemAsync(It.IsAny<ContactForm>()), Times.Never);
        }
        [Test]
        public async Task Get_All_Contact_Form()
        {
            _documentDbMock.Setup(x => x.GetAllAsync()).ReturnsAsync(() => null);

            var forms = await _formService.RetrieveAllContactForms();

            _documentDbMock.Verify(x => x.GetAllAsync(), Times.Once);
        }
    }
}