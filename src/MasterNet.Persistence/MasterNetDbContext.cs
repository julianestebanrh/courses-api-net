using Bogus;
using MasterNet.Domain;
using MasterNet.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Persistence;

public class MasterNetDbContext : IdentityDbContext<User>
{
    public MasterNetDbContext(DbContextOptions<MasterNetDbContext> options) : base(options)
    {
    }

    public DbSet<Course>? Courses { get; set; }
    public DbSet<Instructor>? Instructors { get; set; }
    public DbSet<Price>? Prices { get; set; }
    public DbSet<Rating>? Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Tables
        modelBuilder.Entity<Course>().ToTable("courses");
        modelBuilder.Entity<Instructor>().ToTable("instructors");
        modelBuilder.Entity<CourseInstructor>().ToTable("course_instructor");
        modelBuilder.Entity<Price>().ToTable("prices");
        modelBuilder.Entity<CoursePrice>().ToTable("courses_prices");
        modelBuilder.Entity<Rating>().ToTable("ratings");
        modelBuilder.Entity<Photography>().ToTable("photographies");

        // Configure Properties
        modelBuilder.Entity<Price>().Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(250);
        modelBuilder.Entity<Price>().Property(x => x.Amount).HasPrecision(10, 2);
        modelBuilder.Entity<Price>().Property(x => x.Promotion).HasPrecision(10, 2);


        // Relations
        modelBuilder.Entity<Course>()
            .HasMany(x => x.Photographies)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Course>()
            .HasMany(x => x.Ratings)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Course>()
            .HasMany(x => x.Prices)
            .WithMany(x => x.Courses)
            .UsingEntity<CoursePrice>(
                x => x.HasOne(x => x.Price).WithMany(x => x.CoursePrices).HasForeignKey(x => x.PriceId),
                x => x.HasOne(x => x.Course).WithMany(x => x.CoursePrices).HasForeignKey(x => x.CourseId),
                x => { x.HasKey(x => new { x.PriceId, x.CourseId }); }
            );

        modelBuilder.Entity<Course>()
            .HasMany(x => x.Instructors)
            .WithMany(x => x.Courses)
            .UsingEntity<CourseInstructor>(
                x => x.HasOne(x => x.Instructor).WithMany(x => x.CoursesInstructors).HasForeignKey(x => x.InstructorId),
                x => x.HasOne(x => x.Course).WithMany(x => x.CourseInstructors).HasForeignKey(x => x.CourseId),
                x => { x.HasKey(x => new { x.InstructorId, x.CourseId }); }
            );

        // Generate Fake Data  
        modelBuilder.Entity<Course>().HasData(ConfigureDataFake().Item1);
        modelBuilder.Entity<Price>().HasData(ConfigureDataFake().Item2);
        modelBuilder.Entity<Instructor>().HasData(ConfigureDataFake().Item3);

        ConfigureSecurityData(modelBuilder);

    }

    private void ConfigureSecurityData(ModelBuilder modelBuilder)
    {
        var adminId = Guid.NewGuid().ToString();
        var clientId = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = adminId,
                Name = Constant.ADMIN,
                NormalizedName = Constant.ADMIN,
            }
        );

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = clientId,
                Name = Constant.CLIENT,
                NormalizedName = Constant.CLIENT,
            }
        );

        modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(
            // Admin Permission
            new IdentityRoleClaim<string>
            {
                Id = 1,
                RoleId = adminId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.COURSE_READ,
            },
            new IdentityRoleClaim<string>
            {
                Id = 2,
                RoleId = adminId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.COURSE_UPDATE,
            },
            new IdentityRoleClaim<string>
            {
                Id = 3,
                RoleId = adminId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.COURSE_CREATE,
            },
            new IdentityRoleClaim<string>
            {
                Id = 4,
                RoleId = adminId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.COURSE_DELETE,
            },
            new IdentityRoleClaim<string>
            {
                Id = 5,
                RoleId = adminId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.INSTRUCTOR_CREATE,
            },
            new IdentityRoleClaim<string>
            {
                Id = 6,
                RoleId = adminId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.INSTRUCTOR_READ,
            },
            new IdentityRoleClaim<string>
            {
                Id = 7,
                RoleId = adminId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.INSTRUCTOR_UPDATE,
            },
            new IdentityRoleClaim<string>
            {
                Id = 8,
                RoleId = adminId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.COMMENT_READ,
            },
            new IdentityRoleClaim<string>
            {
                Id = 9,
                RoleId = adminId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.COMMENT_DELETE,
            },
            new IdentityRoleClaim<string>
            {
                Id = 10,
                RoleId = adminId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.COMMENT_CREATE,
            },
            // Client Permission
            new IdentityRoleClaim<string>
            {
                Id = 11,
                RoleId = clientId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.COURSE_READ,
            },
            new IdentityRoleClaim<string>
            {
                Id = 12,
                RoleId = clientId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.INSTRUCTOR_READ,
            },
            new IdentityRoleClaim<string>
            {
                Id = 13,
                RoleId = clientId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.COMMENT_READ,
            },
            new IdentityRoleClaim<string>
            {
                Id = 14,
                RoleId = clientId,
                ClaimType = Constant.POLICIES,
                ClaimValue = Constant.COMMENT_CREATE,
            }
        );

    }

    private Tuple<Course[], Price[], Instructor[]> ConfigureDataFake()
    {
        var faker = new Faker();
        var courses = new List<Course>();
        var prices = new List<Price>();
        var instrcutors = new List<Instructor>();

        for (int i = 1; i < 10; i++)
        {
            courses.Add(new Course { Id = Guid.NewGuid(), Title = faker.Commerce.ProductName(), Description = faker.Commerce.ProductDescription(), PublicationDate = DateTime.Now });
        }

        prices.Add(new Price { Id = Guid.NewGuid(), Name = "Regular Price", Amount = 10.0m, Promotion = 8.0m });

        var fakerInstructor = new Faker<Instructor>()
            .RuleFor(x => x.Id, _ => Guid.NewGuid()).RuleFor(x => x.Names, f => f.Name.FirstName()).RuleFor(x => x.Surnames, f => f.Name.LastName()).RuleFor(x => x.Degree, f => f.Name.JobTitle());

        instrcutors = fakerInstructor.Generate(10);

        return Tuple.Create(courses.ToArray(), prices.ToArray(), instrcutors.ToArray());
    }
}