using Bogus;
using MasterNet.Domain;
using MasterNet.Persistence;
using MasterNet.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.WebApi.Extensions;

public static class SeedData
{

    public static async Task ConfigureAuthenticationData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var service = scope.ServiceProvider;
        var loggerFactory = service.GetRequiredService<ILoggerFactory>();

        try
        {
            var context = service.GetRequiredService<MasterNetDbContext>();
            await context.Database.MigrateAsync();

            var userManager = service.GetRequiredService<UserManager<User>>();
            if (!userManager.Users.Any())
            {
                var userAdmin = new User
                {
                    FullName = "Administrador",
                    UserName = "admin",
                    Email = "admin@masternet.com"
                };

                await userManager.CreateAsync(userAdmin, "Password123$");
                await userManager.AddToRoleAsync(userAdmin, Constant.ADMIN);

                var userClient = new User
                {
                    FullName = "Client",
                    UserName = "client",
                    Email = "client@masternet.com"
                };

                await userManager.CreateAsync(userClient, "Password123$");
                await userManager.AddToRoleAsync(userClient, Constant.CLIENT);
            }

            var courses = await context.Courses!.Take(10).Skip(0).ToListAsync();
            if (!context.Set<CourseInstructor>().Any())
            {
                var instructors = await context.Instructors!.Take(10).Skip(0).ToListAsync();
                foreach (var course in courses)
                {
                    course.Instructors = instructors;
                }
            }

            if (!context.Set<CoursePrice>().Any())
            {
                var prices = await context.Prices!.ToListAsync();
                foreach (var course in courses)
                {
                    course.Prices = prices;
                }
            }

            if (!context.Set<Rating>().Any())
            {
                var random = new Random();
                foreach (var course in courses)
                {
                    var fakeRating = new Faker<Rating>()
                        .RuleFor(x => x.Id, _ => Guid.NewGuid())
                        .RuleFor(x => x.Student, x => x.Name.FullName())
                        .RuleFor(x => x.Commentary, x => x.Commerce.ProductDescription())
                        .RuleFor(x => x.Score, random.Next(1, 6))
                        .RuleFor(x => x.CourseId, course.Id);

                    var ratings = fakeRating.Generate(10);
                    context.AddRange(ratings);
                }
            }

            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<MasterNetDbContext>();
            logger.LogError(ex.Message);
        }
    }
}