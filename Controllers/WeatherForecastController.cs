using CityWeatherReports.IServices;
using Microsoft.AspNetCore.Mvc;
using CityWeatherReports.Models;

namespace CityWeatherReports.Controllers
{
    [ApiController]
    [Route("WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IService _service;
        public WeatherForecastController(IService service)
        {
            _service = service;
        }

        /// <summary>
        /// Fetch all cities from local database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public async Task<List<CityModel>> Get()
        {
            List<CityModel> results;
            try
            {
                results = await _service.GetCity();
            }
            catch (Exception)
            {
                return new List<CityModel>();
            }
            return results;
        }

        /// <summary>
        /// Save Single City to local db.
        /// </summary>
        /// <param name="cityModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("saveCity")]
        public async Task<int> SaveCity(CityModel cityModel)
        {
            int cityId = 0;
            try
            {
                cityId = await _service.SaveCity(cityModel);
            }
            catch (Exception)
            {
                return 0;
            }
            return cityId;
        }

        /// <summary>
        /// Fetch Single city by city id.
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getCityById")]
        public async Task<CityModel> GetCityById(int cityId)
        {
            CityModel cityDetails;
            try
            {
                cityDetails = await _service.GetCityById(cityId);
            }
            catch (Exception)
            {
                return new CityModel();
            }
            return cityDetails;
        }

        /// <summary>
        /// Update existing City details.
        /// </summary>
        /// <param name="cityModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("editCity")]
        public async Task<int> EditCity(CityModel cityModel)
        {
            int cityId = 0;
            try
            {
                cityId = await _service.EditCity(cityModel);
            }
            catch (Exception)
            {
                return 0;
            }
            return cityId;
        }

        /// <summary>
        /// Delete existing City by city id.
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteCity")]
        public async Task<bool> DeleteCity(int cityId)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = await _service.DeleteCity(cityId);
            }
            catch (Exception)
            {
                return false;
            }
            return isDeleted;
        }
    }
}
