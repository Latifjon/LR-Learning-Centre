using System;
using System.Collections.Generic;

namespace LearningCentre.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Teacher
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? SubjectId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Subject Subject { get; set; }
    }
}
