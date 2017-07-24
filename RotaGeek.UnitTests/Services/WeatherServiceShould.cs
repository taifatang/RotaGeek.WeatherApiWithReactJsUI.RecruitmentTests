using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using RotaGeek.Providers;
using RotaGeek.Services;
using RotaGeek.Services.Models;

namespace RotaGeek.UnitTests.Services
{
    [TestFixture]
    public class WeatherServiceShould
    {
        private Mock<IHttpClientWrapper> _httpClientMock;
        private IWeatherService _weatherService;

        [SetUp]
        public void SetUp()
        {
            _httpClientMock = new Mock<IHttpClientWrapper>();
            _weatherService = new WeatherService(_httpClientMock.Object);

        }

        [TearDown]
        public void TearDown()
        {
            _httpClientMock = null;
            _weatherService = null;
        }

        [Test]
        public async Task Get_Weather_By_Location()
        {
            var location = "london";

             await _weatherService.GetWeatherAsync(location);

            _httpClientMock.Verify(x => x.GetAsync<Weather>(It.IsAny<Uri>()), Times.Once);
        }
        [Test]
        public  void Fail_When_Location_Is_Not_Set()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _weatherService.GetWeatherAsync(null));
        }
        [Test]
        public void Fail_When_Location_Is_Empty()
        {
            var location = "";
            Assert.ThrowsAsync<ArgumentNullException>(() => _weatherService.GetWeatherAsync(location));
        }
    }
}
