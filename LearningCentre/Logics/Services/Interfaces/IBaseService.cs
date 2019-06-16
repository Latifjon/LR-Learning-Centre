using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCentre.Logics.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IBaseService<TModel>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TModel Create(TModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<TModel> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TModel GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        void Update(int id, TModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void VerifyIfModelFieldsNull(TModel model);
    }
}
