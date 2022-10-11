using CityWeatherReports.Controllers;
using CityWeatherReports.IServices;
using CityWeatherReports.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestCityWeatherReport
{
    public class Tests
    {
        private Mock<IService> _service;
        private WeatherForecastController _weatherForecastController;
        public Tests()
        {
            _service = new Mock<IService>();
            _weatherForecastController = new WeatherForecastController(_service.Object);
        }
        
        [Fact]
        public void TestGet()
        {

            var testCityList = GetCityList();
            _service.Setup(x => x.GetCity()).Returns(Task.FromResult(testCityList));
            var result = _weatherForecastController.Get();
            Assert.True(result.Result.Count > 0);
        }

        [Fact]
        public void TestAdd()
        {
            var testCity = GetCity();
            _service.Setup(x => x.SaveCity(testCity)).Returns(Task.FromResult(1));

            var result = _weatherForecastController.SaveCity(testCity);
            Assert.True(result.Result == 1);
        }

        [Fact]
        public void TestUpdate()
        {
            var testCity = GetCity();
            _service.Setup(x => x.SaveCity(testCity)).Returns(Task.FromResult(1));

            var result = _weatherForecastController.EditCity(testCity);
            Assert.True(result.Result == 1);
        }


        [Fact]
        public void TestDelete()
        {
            var testCityList = GetCityList();
            _service.Setup(x => x.GetCity()).Returns(Task.FromResult(testCityList));
            var result = _weatherForecastController.DeleteCity(1);
            
            Assert.True(result.Result);
        }

        public List<CityModel> GetCityList()
        {
            var cityList = new List<CityModel>();
            cityList.Add( new CityModel
            {
                CityId = 1,
                CityName = "Northampton",
                CityWeather = 12,
                Country = "England",
                DateEstablisted = System.DateTime.Now,
                State = "Wootton",
                EstimatedPopulation = 1200,
                TouristRating = 4,
                TwoDigitCountryCode = "NR",
                ThreeDigitCountryCode = "NRA",
                CreatedDate = System.DateTime.Now,
                UpdatedDate = System.DateTime.Now
            });
            return cityList;
        }

        public CityModel GetCity()
        {
            return new CityModel
            {
                CityId = 1,
                CityName = "Northampton",
                CityWeather = 12,
                Country = "England",
                DateEstablisted = System.DateTime.Now,
                State = "Wootton",
                EstimatedPopulation = 1200,
                TouristRating = 4,
                TwoDigitCountryCode = "NR",
                ThreeDigitCountryCode = "NRA",
                CreatedDate = System.DateTime.Now,
                UpdatedDate = System.DateTime.Now
            };
        }
    }
}