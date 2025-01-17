using AutoMapper;
using TestTask.Business.DTO;
using TestTask.Entities;

namespace CourseSelectionSystemFPM.Business.AutoMapper.Profiles;

public class CitizenProfile : Profile
{
    public CitizenProfile()
    {
        CreateMap<Citizen, CitizenDTO>().ReverseMap();
    }
}