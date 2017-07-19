using System.Threading.Tasks;
using NUnit.Framework;
using RotaGeek.Providers;
using RotaGeek.Services;

namespace RotaGeek.UnitTests.Providers
{
    [TestFixture]
    public class FormValidationProviderShould
    {
        private FormValidationProvider _formValidationProvider;

        [SetUp]
        public void SetUp()
        {
            _formValidationProvider = new FormValidationProvider();
        }

        [TearDown]
        public void TearDown()
        {
            _formValidationProvider = null;
        }

        [Test]
        public async Task Validate_Form()
        {
            var validator = new FormValidationProvider();
            var form = new ContactForm();

            var result = await validator.ValidateAsync(form);

            //_validatorFactoryMock.Verify(x => x.Validate());
        }
    }
}
