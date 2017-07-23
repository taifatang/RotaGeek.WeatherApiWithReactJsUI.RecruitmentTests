using Moq;
using NUnit.Framework;
using RotaGeek.Controllers;
using RotaGeek.Services;
using RotaGeek.Services.Models;

namespace RotaGeek.UnitTests.Controllers
{
    //TODO: add more tests

    [TestFixture]
    public class WeatherControllerShould
    {
        private Mock<IWeatherService> _weatherServiceMock;
        private WeatherController _weatherController;

        [SetUp]
        public void SetUp()
        {
            _weatherServiceMock = new Mock<IWeatherService>();
            _weatherController = new WeatherController(_weatherServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _weatherServiceMock = null;
            _weatherController = null;
        }

        [Test]
        public void Return_Weather()
        {
            var response = _weatherController.GetWeather(new WeatherRequest());

            //Assert.That(response.StatusCode == (int)HttpStatusCode.OK);
        }
    }
}
