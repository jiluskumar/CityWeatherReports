using CityWeatherReports.Models;

namespace CityWeatherReports.IServices
{
    public interface IService
    {
        public Task<List<CityModel>> GetCity();
        public Task<int> SaveCity(CityModel cityModel);
        public Task<CityModel> GetCityById(int cityId);
        public Task<int> EditCity(CityModel cityModel);
        public Task<bool> DeleteCity(int cityId);
    }
}
