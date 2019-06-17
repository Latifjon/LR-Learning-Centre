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
    public class LevelController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBaseService<Level> _levelService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="levelService"></param>
        public LevelController(IBaseService<Level> levelService)
        {
            _levelService = levelService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult CreateLevel([FromBody] Level level)
        {
            try
            {
                _levelService.Create(level);
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
        [HttpGet("Levels")]
        public IActionResult GetLevels()
        {
            var levels = _levelService.GetAll();
            return Ok(levels);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("customLevel")]
        public IActionResult GetLevelById(int id)
        {
            var level = _levelService.GetById(id);
            return Ok(level);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="levelParam"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Route("Update")]
        public IActionResult UpdateLevel(int id, [FromBody] Level levelParam)
        {
            try
            {
                _levelService.Update(id,levelParam);
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
        public IActionResult DeleteLevel(int id)
        {
            try
            {
                _levelService.Delete(id);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
