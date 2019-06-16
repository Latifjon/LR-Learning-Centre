using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCentre.Database;
using LearningCentre.Logics.Helpers;
using LearningCentre.Logics.Services;
using LearningCentre.Logics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningCentre.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBaseService<Teacher> _teacherService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherService"></param>
        public TeacherController(IBaseService<Teacher> teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult CreateTeacher([FromBody] Teacher teacherParam)
        {
            try
            {
                var teacher = _teacherService.Create(teacherParam);
                return Ok(teacher);
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
        [HttpGet("Teachers")]
        public IActionResult GetTeachers()
        {
            var teachers = _teacherService.GetAll();
            return Ok(teachers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("customTeacher")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = _teacherService.GetById(id);
            return Ok(teacher);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacherParam"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Route("Update")]
        public IActionResult UpdateTeacher(int id, [FromBody] Teacher teacherParam)
        {
            try
            {
                _teacherService.Update(id, teacherParam);
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
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Route("Delete")]
        public IActionResult DeleteTeacher(int id)
        {
            try
            {
                _teacherService.Delete(id);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}
