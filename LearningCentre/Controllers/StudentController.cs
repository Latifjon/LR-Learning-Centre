using LearningCentre.Database;
using LearningCentre.Logics.Helpers;
using LearningCentre.Logics.Services.Interfaces;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningCentre.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBaseService<Student> _studentService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentService"></param>
        public StudentController(IBaseService<Student> studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentParam"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createStudent")]
        public IActionResult CreateStudent([FromBody] Student studentParam)
        {
            try
            {
                _studentService.Create(studentParam);
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
        [HttpGet("students")]
        public IActionResult GetStudents()
        {
            var students = _studentService.GetAll();
            return Ok(students);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("customStudent")]
        public IActionResult GetStudentsById(int id)
        {
            var student = _studentService.GetById(id);

            if (student == null)
                return BadRequest("Student not found");

            return Ok(student);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentParam"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Route("updateStudent")]
        public IActionResult UpdateStudent(int id,[FromBody]Student studentParam)
        {
            try
            {
                _studentService.Update(id, studentParam);
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
        [Route("deleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.Delete(id);
            return Ok();
        }

    }
}
