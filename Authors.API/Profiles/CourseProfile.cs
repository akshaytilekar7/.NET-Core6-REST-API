using AutoMapper;

namespace Authors.API.Profiles;
public class CoursesProfile : Profile
{
    public CoursesProfile()
    {
        CreateMap<Entities.Course, Models.CourseDto>();
        CreateMap<Models.CourseForUpdateDto, Entities.Course>().ReverseMap();
    }
}