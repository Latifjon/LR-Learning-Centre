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
    public class CityController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBaseService<City> _cityService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityService"></param>
        public CityController(IBaseService<City> cityService)
        {
            _cityService = cityService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityParam"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult CreateCity([FromBody]City cityParam)
        {
            try
            {
                _cityService.Create(cityParam);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Cities")]
        public IActionResult GetCities()
        {
            var cities = _cityService.GetAll();
            return Ok(cities);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("customCity")]
        public IActionResult GetCityById(int id)
        {
            var city = _cityService.GetById(id);

            if (city == null)
                return BadRequest("City not found");

            return Ok(city);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Route("Update")]
        public IActionResult UpdateCity(int id, [FromBody]City city)
        {
            try
            {
                _cityService.Update(id, city);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Route("Delete")]
        public IActionResult DeleteCity(int id)
        {
            _cityService.Delete(id);
            return Ok();
        }
    }
}
