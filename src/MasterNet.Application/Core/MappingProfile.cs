using AutoMapper;
using MasterNet.Application.Courses.GetCourse;
using MasterNet.Application.Instructors.GetInstructors;
using MasterNet.Application.Photographs.GetPhotography;
using MasterNet.Application.Prices.GetPrices;
using MasterNet.Application.Ratings.GetRatings;
using MasterNet.Domain;

namespace MasterNet.Application.Core;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Course, CourseResponse>();
        CreateMap<Photography, PhotographyResponse>();
        CreateMap<Price, PriceResponse>();
        CreateMap<Instructor, InstructorResponse>();
        CreateMap<Rating, RatingResponse>()
            .ForMember(destination => destination.Course, source => source.MapFrom(x => x.Course!.Title));


    }
}