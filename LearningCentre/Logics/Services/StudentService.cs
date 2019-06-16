using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCentre.Database;
using LearningCentre.Logics.Helpers;
using LearningCentre.Logics.Repositories;
using LearningCentre.Logics.Services.Interfaces;

namespace LearningCentre.Logics.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class StudentService : BaseRepository, IBaseService<Student>
    {
        /// <summary>
        /// 
        /// </summary>
        private static LearningCentreContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public StudentService(LearningCentreContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Create(Student student)
        {
            VerifyIfModelFieldsNull(student);

            _dbContext.Student.Add(student);
            _dbContext.SaveChanges();

            return student;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetAll()
        {
           return _dbContext.Student.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetById(int id)
        {
            return _dbContext.Student.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentParam"></param>
        public void Update(int id,Student studentParam)
        {
            var student = _dbContext.Student.Find(id);

            if (student == null)
                throw new AppException("Student not found");

            student.FirstName = studentParam.FirstName;
            student.LastName = studentParam.LastName;
            student.Gender = studentParam.Gender;
            student.Citizenship = studentParam.Citizenship;
            student.DateOfBirth = studentParam.DateOfBirth;
            student.NativeLanguage = studentParam.NativeLanguage;
            student.PassportNumber = studentParam.PassportNumber;
            student.PlaceOfStudy = studentParam.PlaceOfStudy;
            student.WorkPlace = student.WorkPlace;
            student.DateOfRegistration = studentParam.DateOfRegistration;
            student.CountryId = studentParam.CountryId;
            student.UserProfileId = studentParam.UserProfileId;

            _dbContext.Student.Update(student);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var student = GetById(id);
            if (student == null) return;

            _dbContext.Student.Remove(student);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        public void VerifyIfModelFieldsNull(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.FirstName))
                throw new AppException("First name is required");
            if (string.IsNullOrWhiteSpace(student.LastName))
                throw new AppException("Last name is required");
            if (string.IsNullOrWhiteSpace(student.Gender))
                throw new AppException("Gender is required");
        }
    }
}
