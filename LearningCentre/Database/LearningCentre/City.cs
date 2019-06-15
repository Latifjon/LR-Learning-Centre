using System;
using System.Collections.Generic;

namespace LearningCentre.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class City
    {
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
        public int? CountryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Country Country { get; set; }
    }
}
