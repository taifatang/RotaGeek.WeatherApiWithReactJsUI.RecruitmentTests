using NUnit.Framework;
using RotaGeek.Providers;

namespace RotaGeek.UnitTests.Providers
{
    [TestFixture]
    public class FormSubmissionProviderShould
    {
        private FormSubmissionProvider _formSubmissionProvider;

        [SetUp]
        public void SetUp()
        {
            _formSubmissionProvider = new FormSubmissionProvider();
        }

        [TearDown]
        public void TearDown()
        {
            _formSubmissionProvider = null;
        }
    }
}