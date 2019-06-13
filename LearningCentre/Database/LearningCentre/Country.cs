using System;
using System.Collections.Generic;

namespace LearningCentre.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Country
    {
        /// <summary>
        /// 
        /// </summary>
        public Country()
        {
            Student=new HashSet<Student>();
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Student> Student { get; set; }
    }
}
