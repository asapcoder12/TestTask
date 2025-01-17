using AutoMapper;
using TestTask.Business.DTO;
using TestTask.Web.Models;

namespace CourseSelectionSystemFPM.Business.AutoMapper.Profiles;

public class CitizenProfile : Profile
{
    public CitizenProfile()
    {
        CreateMap<CitizenViewModel, CitizenDTO>().ReverseMap();
        CreateMap<EditCitizenViewModel, CitizenDTO>().ReverseMap();
        CreateMap<CsvRecordViewModel, CitizenDTO>()
            .ForMember(dest => dest.IsMarried, opt => opt.MapFrom(src => src.Married)).ReverseMap();
    }
}