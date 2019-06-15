using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCentre.Database;
using LearningCentre.Logics.Helpers;
using LearningCentre.Logics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningCentre.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBaseService<Country> _countryService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryService"></param>
        public CountryController(IBaseService<Country> countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createCountry")]
        public IActionResult CreateCountry(Country country)
        {
            try
            {
                _countryService.Create(country);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Countries")]
        public IActionResult GetCountries()
        {
            var countries = _countryService.GetAll();
            return Ok(countries);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("customCountry")]
        public IActionResult GetCountryById(int id)
        {
            var country = _countryService.GetById(id);

            if (country == null)
                return BadRequest("Country not found");

            return Ok(country);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="country"></param>
        [HttpPut("{id}")]
        [Route("updateCountry")]
        public IActionResult UpdateCountry([FromBody]Country countryParam)
        {
            try
            {
                _countryService.Update(countryParam);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Route("deleteCountry")]
        public IActionResult DeleteCountry(int id)
        {
            _countryService.Delete(id);
            return Ok();
        }
    }
}
