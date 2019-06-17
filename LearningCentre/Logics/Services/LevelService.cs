using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCentre.Database;
using LearningCentre.Logics.Helpers;
using LearningCentre.Logics.Repositories;
using LearningCentre.Logics.Services.Interfaces;
using StackExchange.Redis;

namespace LearningCentre.Logics.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class LevelService : BaseRepository, IBaseService<Level>
    {
        /// <summary>
        /// 
        /// </summary>
        private static LearningCentreContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public LevelService(LearningCentreContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public Level Create(Level level)
        {
            VerifyIfModelFieldsNull(level);

            _dbContext.Level.Add(level);
            _dbContext.SaveChanges();

            return level;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Level> GetAll()
        {
            return _dbContext.Level.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Level GetById(int id)
        {
            return _dbContext.Level.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="levelParam"></param>
        public void Update(int id, Level levelParam)
        {
            var level = GetById(id);

            if(level==null)
                throw new AppException("Current Level not found");

            level.Name = levelParam.Name;
            level.PlacementTest = levelParam.PlacementTest;

            _dbContext.Level.Update(level);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var level = GetById(id);

            if (level == null)
                throw new AppException("Level not found or already deleted");

            _dbContext.Level.Remove(level);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        public void VerifyIfModelFieldsNull(Level level)
        {
            if(string.IsNullOrWhiteSpace(level.Name))
                throw new AppException("Name column is required");
        }
    }
}
