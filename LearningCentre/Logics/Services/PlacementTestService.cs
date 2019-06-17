using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCentre.Database;
using LearningCentre.Logics.Helpers;
using LearningCentre.Logics.Repositories;
using LearningCentre.Logics.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LearningCentre.Logics.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class PlacementTestService: BaseRepository, IBaseService<PlacementTest>
    {
        /// <summary>
        /// 
        /// </summary>
        private static LearningCentreContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public PlacementTestService(LearningCentreContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="placementTest"></param>
        /// <returns></returns>
        public PlacementTest Create(PlacementTest placementTest)
        {
            VerifyIfModelFieldsNull(placementTest);

            _dbContext.PlacementTest.Add(placementTest);
            _dbContext.SaveChanges();

            return placementTest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PlacementTest> GetAll()
        {
            return _dbContext.PlacementTest.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlacementTest GetById(int id)
        {
            return _dbContext.PlacementTest.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="placementTestParam"></param>
        public void Update(int id, PlacementTest placementTestParam)
        {
            var placementTest = GetById(id);

            if(placementTest==null)
                throw new AppException("Placement test not found");

            placementTest.LevelId = placementTestParam.LevelId;
            placementTest.TeacherId = placementTestParam.TeacherId;
            placementTest.PlacementTestDate = placementTestParam.PlacementTestDate;

            _dbContext.PlacementTest.Update(placementTest);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var placementTest = GetById(id);

            if(placementTest==null)
                throw new AppException("Placement test not found or already deleted");

            _dbContext.PlacementTest.Remove(placementTest);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="placementTest"></param>
        public void VerifyIfModelFieldsNull(PlacementTest placementTest)
        {
            if(placementTest.TeacherId==null)
                throw  new AppException("TeacherId is required");
            if (placementTest.LevelId == null)
                throw new AppException("LevelId is required");
            if(placementTest.PlacementTestDate==null)
                throw new AppException("Date is required");
        }
    }
}
