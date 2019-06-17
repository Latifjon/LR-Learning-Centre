using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCentre.Database;
using LearningCentre.Logics.Helpers;
using LearningCentre.Logics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LearningCentre.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    public class PlacementTestController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBaseService<PlacementTest> _testService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testService"></param>
        public PlacementTestController(IBaseService<PlacementTest> testService)
        {
            _testService = testService;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="placementTest"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult CreatePlacementTest([FromBody] PlacementTest placementTest)
        {
            try
            {
                _testService.Create(placementTest);
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
        [HttpGet("PlacementTests")]
        public IActionResult GetTests()
        {
            var tests = _testService.GetAll();
            return Ok(tests);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("customTest")]
        public IActionResult GetCustomTest(int id)
        {
            var placementTest = _testService.GetById(id);
            return Ok(placementTest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="placementTest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Route("Update")]
        public IActionResult UpdatePlacementTest(int id, [FromBody] PlacementTest placementTest)
        {
            try
            {
                _testService.Update(id, placementTest);
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
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Route("Delete")]
        public IActionResult DeletePlacementTest(int id)
        {
            try
            {
                _testService.Delete(id);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}
