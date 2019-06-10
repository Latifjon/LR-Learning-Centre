using System;
using System.Data;
using System.Data.SqlClient;

namespace LearningCentre.Logics.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseRepository: IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public IDbConnection Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected BaseRepository()
        {
            Connection = new SqlConnection("Server=User\\SQLEXPRESS;Database=LearningCentre;Trusted_Connection=True;ConnectRetryCount=0");
            Connection.Open();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if(IsDisposed)
                return;

            Connection?.Close();
            IsDisposed = true;
        }
    }
}
