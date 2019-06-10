using AutoMapper;
using LearningCentre.Database;
using LearningCentre.Database.LearningCentre.Data_Transfer_Objects;

namespace LearningCentre.Logics.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserProfileAutoMapper : Profile
    {
        public UserProfileAutoMapper()
        {
            CreateMap<UserProfile, UserProfileTransfer>().ReverseMap();
        }
    }
}
