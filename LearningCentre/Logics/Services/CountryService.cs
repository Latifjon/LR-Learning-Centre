using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCentre.Database;
using LearningCentre.Logics.Helpers;
using LearningCentre.Logics.Repositories;
using LearningCentre.Logics.Services.Interfaces;

namespace LearningCentre.Logics.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class CountryService : BaseRepository, IBaseService<Country>
    {
        /// <summary>
        /// 
        /// </summary>
        private static LearningCentreContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public CountryService(LearningCentreContext context)
        {
            _dbContext = context;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public Country Create(Country country)
        {
            VerifyIfCountryFieldsNull(country);

            _dbContext.Country.Add(country);
            _dbContext.SaveChanges();

            return country;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Country> GetAll()
        {
            return _dbContext.Country.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country GetById(int id)
        {
            return _dbContext.Country.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryParam"></param>
        public void Update(Country countryParam)
        {
            var country = _dbContext.Country.Find(countryParam.Id);

            if (country == null)
                throw new AppException("Country not found");

            country.Code = countryParam.Code;
            country.Name = countryParam.Name;

            _dbContext.Country.Update(country);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var student = GetById(id);

            _dbContext.Country.Remove(student);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        private void VerifyIfCountryFieldsNull(Country country)
        {
            if (string.IsNullOrWhiteSpace(country.Name))
                throw new AppException("Name column is required");
        }
    }
}
