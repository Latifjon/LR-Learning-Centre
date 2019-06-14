using Newtonsoft.Json.Converters;

namespace LearningCentre.Logics.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
