﻿using AutoMapper;

namespace Core6WebApi.Profiles;
public class CoursesProfile : Profile
{
    public CoursesProfile()
    {
        CreateMap<Entities.Course, Models.CourseDto>();
        CreateMap<Models.CourseForUpdateDto, Entities.Course>().ReverseMap();
    }
}