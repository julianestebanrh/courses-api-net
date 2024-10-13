// using MasterNet.Domain;
// using MasterNet.Persistence;
// using Microsoft.EntityFrameworkCore;

// using var context = new MasterNetDbContext();
// var courses = await context.Courses!.ToListAsync();


// var newCourse = new Course
// {
//     Id = Guid.NewGuid(),
//     Title = "Programtion with C#",
//     Description = "The base a programation",
//     PublicationDate = DateTime.Now
// };

// context.Add(newCourse);
// await context.SaveChangesAsync();

// foreach (var course in courses)
// {
//     Console.WriteLine($"{course.Id} {course.Title}");
// }