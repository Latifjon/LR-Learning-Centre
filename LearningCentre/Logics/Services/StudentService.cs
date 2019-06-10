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
    public class StudentService : BaseRepository, IStudentService
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
        /// <returns></returns>
        public IEnumerable<Student> GetStudents()
        {
            return _dbContext.Student.ToList();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Student GetStudentById(int id)
        {
            return _dbContext.Student.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student CreateStudent(Student student)
        {
            VerifyIfStudentFieldsNull(student);

            _dbContext.Student.Add(student);
            _dbContext.SaveChanges();

            return student;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <param name="studentParam"></param>
        public void UpdateStudent(Student studentParam)
        {
            var student = _dbContext.Student.Find(studentParam.Id);

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
            student.UserProfileId = studentParam.UserProfileId;
            student.UserProfile = student.UserProfile;

            _dbContext.Student.Add(student);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var student = _dbContext.Student.Find(id);
            if (student == null) return;

            _dbContext.Student.Remove(student);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        private void VerifyIfStudentFieldsNull(Student student)
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
