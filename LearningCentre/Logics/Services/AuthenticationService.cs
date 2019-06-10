using System;
using System.Collections.Generic;
using System.Linq;
using LearningCentre.Database;
using LearningCentre.Logics.Helpers;
using LearningCentre.Logics.Repositories;
using LearningCentre.Logics.Services.Interfaces;

namespace LearningCentre.Logics.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationService : BaseRepository, IAuthenticationService
    {
        /// <summary>
        /// 
        /// </summary>
        private static LearningCentreContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        public AuthenticationService(LearningCentreContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        public UserProfile Authenticate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return null;

            var userProfile = _dbContext.UserProfile.SingleOrDefault(u => u.Username == userName);

            if (userProfile == null)
                return null;

            return !VerifyPasswordHash(password, userProfile.PasswordHash, userProfile.PasswordSalt) ? null : userProfile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserProfile> GetUsers()
        {
            return _dbContext.UserProfile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "id" ></ param >
        /// < returns ></ returns >
        public UserProfile GetUserById(int id)
        {
            return _dbContext.UserProfile.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "user" ></ param >
        /// < param name="password"></param>
        /// <returns></returns>
        public UserProfile CreateUser(UserProfile user, string password)
        {
            if(string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if(_dbContext.UserProfile.Any(u=>u.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password,out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _dbContext.UserProfile.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userParam"></param>
        /// <param name="password"></param>
        public void UpdateUser(UserProfile userParam, string password = null)
        {
            var user = _dbContext.UserProfile.Find(userParam.Id);

            if(user==null)
                throw new AppException("User not found");

            if (userParam.Username != user.Username)
            {
                if(_dbContext.UserProfile.Any(u=>u.Username==userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");
            }

            user.Username = userParam.Username;

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _dbContext.UserProfile.Update(user);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var user = _dbContext.UserProfile.Find(id);
            if (user == null) return;

            _dbContext.UserProfile.Remove(user);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="storedHash"></param>
        /// <param name="storedSalt"></param>
        /// <returns></returns>
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            VerifyIfPasswordNull(password, storedHash, storedSalt);

            using (var security = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = security.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (var index = 0; index < computedHash.Length; index++)
                {
                    if (computedHash[index] != storedHash[index])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="storedHash"></param>
        /// <param name="storedSalt"></param>
        /// <returns></returns>
        private static void VerifyIfPasswordNull(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");

            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
        }
    }
}
