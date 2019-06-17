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
    public class SubjectService : BaseRepository, IBaseService<Subject>
    {
        /// <summary>
        /// 
        /// </summary>
        private static LearningCentreContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public SubjectService(LearningCentreContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public Subject Create(Subject subject)
        {
            VerifyIfModelFieldsNull(subject);

            _dbContext.Subject.Add(subject);
            _dbContext.SaveChanges();

            return subject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Subject> GetAll()
        {
            return _dbContext.Subject.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Subject GetById(int id)
        {
            var subject = _dbContext.Subject.Find(id);

            if(subject==null)
                throw new AppException("Subject not found");

            return subject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectModel"></param>
        public void Update(int id, Subject subjectModel)
        {
            var subject = GetById(id);

            if(subject==null)
                throw new AppException("Subject not found");

            subject.Name = subjectModel.Name;

            _dbContext.Subject.Update(subject);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var subject = GetById(id);

            if(subject==null)
                throw new AppException("Subject not found or already deleted");

            _dbContext.Subject.Remove(subject);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        public void VerifyIfModelFieldsNull(Subject subject)
        {
            if(string.IsNullOrWhiteSpace(subject.Name))
                throw new AppException("Name is required");
        }
    }
}
