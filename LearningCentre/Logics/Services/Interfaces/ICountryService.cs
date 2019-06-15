using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCentre.Database;

namespace LearningCentre.Logics.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        Country CreateCountry(Country country);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Country> GetCountries();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Country GetCountryById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        void UpdateCountry(Country country);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void DeleteCountry(int id);
    }
}
