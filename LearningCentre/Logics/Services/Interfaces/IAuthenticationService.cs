using System.Collections.Generic;
using LearningCentre.Database;

namespace LearningCentre.Logics.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// 
        /// </summary>
        UserProfile Authenticate(string userName, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserProfile> GetUsers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "id" ></ param >
        /// < returns ></ returns >
        UserProfile GetUserById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "user" ></ param >
        /// < param name="password"></param>
        /// <returns></returns>
        UserProfile CreateUser(UserProfile user, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "userParam" ></ param >
        /// < param name="password"></param>
        /// <returns></returns>
        void UpdateUser(UserProfile userParam, string password = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "id" ></ param >
        void Delete(int id);

    }
}
