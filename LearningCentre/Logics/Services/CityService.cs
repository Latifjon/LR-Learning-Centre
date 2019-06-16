using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCentre.Database;
using LearningCentre.Logics.Helpers;
using LearningCentre.Logics.Services.Interfaces;

namespace LearningCentre.Logics.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class CityService : IBaseService<City>
    {
        /// <summary>
        /// 
        /// </summary>
        private static LearningCentreContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public CityService(LearningCentreContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public City Create(City city)
        {
            VerifyIfModelFieldsNull(city);

            _dbContext.City.Add(city);
            _dbContext.SaveChanges();

            return city;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<City> GetAll()
        {
            return _dbContext.City.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public City GetById(int id)
        {
            return _dbContext.City.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cityParam"></param>
        public void Update(int id, City cityParam)
        {
            var city = GetById(id);

            if(city==null)
                throw new AppException("City not found");

            city.Name = cityParam.Name;
            city.Code = cityParam.Code;
            city.CountryId = cityParam.CountryId;

            _dbContext.City.Update(city);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var city = GetById(id);

            _dbContext.City.Remove(city);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        public void VerifyIfModelFieldsNull(City city)
        {
            if (string.IsNullOrWhiteSpace(city.Name))
                throw new AppException("Name column is required");
            if (city.CountryId == null)
                throw new AppException("CountryId column is required");
        }
    }
}
