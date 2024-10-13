using FluentValidation;
using FluentValidation.AspNetCore;
using MasterNet.Application.Core;
using MasterNet.Application.Courses.CreateCourse;
using Microsoft.Extensions.DependencyInjection;

namespace MasterNet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            configuration.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CreateCourseCommand>();

        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }
}
