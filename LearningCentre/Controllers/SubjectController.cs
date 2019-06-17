using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    public class SubjectController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBaseService<Subject> _subjectService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjectService"></param>
        public SubjectController(IBaseService<Subject> subjectService)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult CreateSubject([FromBody]Subject subject)
        {
            try
            {
                _subjectService.Create(subject);
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
        [HttpGet("Subjects")]
        public IActionResult GetSubjects()
        {
            var subjects = _subjectService.GetAll();
            return Ok(subjects);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("customSubject")]
        public IActionResult GetSubjectById(int id)
        {
            try
            {
                _subjectService.GetById(id);
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
        /// <param name="subjectParam"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Route("Update")]
        public IActionResult UpdateSubject(int id, [FromBody] Subject subjectParam)
        {
            try
            {
                _subjectService.Update(id,subjectParam);
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
        public IActionResult DeleteSubject(int id)
        {
            try
            {
                _subjectService.Delete(id);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}
