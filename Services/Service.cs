using CityWeatherReports.DBModels;
using CityWeatherReports.IServices;
using CityWeatherReports.Models;
using Microsoft.EntityFrameworkCore;

namespace CityWeatherReports
{
    public class Service : IService
    {
        public async Task<List<CityModel>> GetCity()
        {
            List<CityModel> returndata;
            try
            {
                using (var dbContext = new cityweatherContext())
                {
                    returndata = await dbContext.Cities.Select(s => new CityModel
                    {
                        CityId = s.CityId,
                        CityName = s.CityName,
                        Country = s.Country,
                        TouristRating = s.TouristRating,
                        TwoDigitCountryCode = s.TwoDigitCountryCode,
                        ThreeDigitCountryCode = s.ThreeDigitCountryCode,
                        CityWeather = s.CityWeather,
                        EstimatedPopulation = s.EstimatedPopulation,
                        DateEstablisted = s.DateEstablisted,
                        State = s.State
                    }).AsQueryable().ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return returndata;
        }

        public async Task<int> SaveCity(CityModel cityModel)
        {
            int cityId = 0;
            try
            {
                using (var dbContext = new cityweatherContext())
                {
                    var city = new City();
                    city.State = cityModel.State;
                    city.CityName = cityModel.CityName;
                    city.Country = cityModel.Country;
                    city.TouristRating = cityModel.TouristRating;
                    city.TwoDigitCountryCode = cityModel.TwoDigitCountryCode;
                    city.ThreeDigitCountryCode = cityModel.ThreeDigitCountryCode;
                    city.CityWeather = cityModel.CityWeather;
                    city.EstimatedPopulation = cityModel.EstimatedPopulation;
                    city.DateEstablisted = cityModel.DateEstablisted;
                    city.State = cityModel.State;
                    city.CreatedDate = DateTime.Now;
                    dbContext.Cities.Add(city);
                    await dbContext.SaveChangesAsync();
                    cityId = city.CityId;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return cityId;
        }

        public async Task<CityModel> GetCityById(int cityId)
        {
            CityModel returndata = new CityModel();
            try
            {
                using (var dbContext = new cityweatherContext())
                {
                    var dbcity = await dbContext.Cities.FirstOrDefaultAsync(f => f.CityId == cityId);
                    if (dbcity != null)
                    {
                        returndata.CityId = dbcity.CityId;
                        returndata.CityName = dbcity.CityName;
                        returndata.Country = dbcity.Country;
                        returndata.TouristRating = dbcity.TouristRating;
                        returndata.TwoDigitCountryCode = dbcity.TwoDigitCountryCode;
                        returndata.ThreeDigitCountryCode = dbcity.ThreeDigitCountryCode;
                        returndata.CityWeather = dbcity.CityWeather;
                        returndata.EstimatedPopulation = dbcity.EstimatedPopulation;
                        returndata.DateEstablisted = dbcity.DateEstablisted;
                        returndata.State = dbcity.State;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return returndata;
        }

        public async Task<int> EditCity(CityModel cityModel)
        {
            int cityId = 0;
            try
            {
                using (var dbContext = new cityweatherContext())
                {
                    var dbcity = await dbContext.Cities.FirstOrDefaultAsync(f => f.CityId == cityModel.CityId);
                    if (dbcity != null)
                    {
                        dbcity.State = cityModel.State;
                        dbcity.CityName = cityModel.CityName;
                        dbcity.Country = cityModel.Country;
                        dbcity.TouristRating = cityModel.TouristRating;
                        dbcity.TwoDigitCountryCode = cityModel.TwoDigitCountryCode;
                        dbcity.ThreeDigitCountryCode = cityModel.ThreeDigitCountryCode;
                        dbcity.CityWeather = cityModel.CityWeather;
                        dbcity.EstimatedPopulation = cityModel.EstimatedPopulation;
                        dbcity.DateEstablisted = cityModel.DateEstablisted;
                        dbcity.State = cityModel.State;
                        dbcity.UpdatedDate = DateTime.Now;
                        await dbContext.SaveChangesAsync();
                        cityId = dbcity.CityId;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return cityId;
        }

        public async Task<bool> DeleteCity(int cityId)
        {
            bool isDeleted = false;
            try
            {
                using (var dbContext = new cityweatherContext())
                {
                    var dbcity = await dbContext.Cities.FirstOrDefaultAsync(f => f.CityId == cityId);
                    if (dbcity != null)
                    {
                        dbContext.Remove(dbcity);
                        await dbContext.SaveChangesAsync();
                        isDeleted = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isDeleted;
        }
    }
}
