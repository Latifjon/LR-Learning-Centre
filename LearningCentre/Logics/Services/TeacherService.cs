using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCentre.Database;
using LearningCentre.Logics.Helpers;
using LearningCentre.Logics.Services.Interfaces;
using Microsoft.CodeAnalysis.Text;

namespace LearningCentre.Logics.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TeacherService : IBaseService<Teacher>
    {
        /// <summary>
        /// 
        /// </summary>
        private static LearningCentreContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public TeacherService(LearningCentreContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public Teacher Create(Teacher teacher)
        {
            VerifyIfModelFieldsNull(teacher);

            _dbContext.Teacher.Add(teacher);
            _dbContext.SaveChanges();

            return teacher;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Teacher> GetAll()
        {
            return _dbContext.Teacher.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Teacher GetById(int id)
        {
            return _dbContext.Teacher.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacherParam"></param>
        public void Update(int id, Teacher teacherParam)
        {
            var teacher = GetById(id);

            if(teacher==null)
                throw new AppException("Teacher not found");

            teacher.FirstName = teacherParam.FirstName;
            teacher.LastName = teacherParam.LastName;
            teacher.SubjectId = teacherParam.SubjectId;

            _dbContext.Teacher.Update(teacher);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var teacher = GetById(id);

            if(teacher==null)
                throw new AppException("Teacher not found or already deleted");

            _dbContext.Teacher.Remove(teacher);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacher"></param>
        public void VerifyIfModelFieldsNull(Teacher teacher)
        {
            if(string.IsNullOrWhiteSpace(teacher.FirstName))
                throw new AppException("FirstName is required");
            if(string.IsNullOrWhiteSpace(teacher.LastName))
                throw new AppException("LastName is required");
        }
    }
}
