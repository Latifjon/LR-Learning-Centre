using System;
using System.Collections.Generic;
using LearningCentre.Logics.Helpers;
using Newtonsoft.Json;

namespace LearningCentre.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PlacementTest
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TeacherId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? LevelId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime? PlacementTestDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Level Level { get; set; }
    }
}
