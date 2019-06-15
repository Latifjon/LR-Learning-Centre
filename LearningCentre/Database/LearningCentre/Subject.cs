using System;
using System.Collections.Generic;

namespace LearningCentre.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Subject
    {
        /// <summary>
        /// 
        /// </summary>
        public Subject()
        {
            Teacher = new HashSet<Teacher>();
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Teacher> Teacher { get; set; }
    }
}
