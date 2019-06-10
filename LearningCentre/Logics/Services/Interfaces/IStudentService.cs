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
    public interface IStudentService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetStudents();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student GetStudentById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student CreateStudent(Student student);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentParam"></param>
        void UpdateStudent(Student studentParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

    }
}
