namespace MasterNet.Domain;


public static class Constant
{
    // Custom Roles
    public const string ADMIN = nameof(ADMIN);
    public const string CLIENT = nameof(CLIENT);

    // Custom Claims
    public const string POLICIES = nameof(POLICIES);

    // Course Policies
    public const string COURSE_CREATE = nameof(COURSE_CREATE);
    public const string COURSE_READ = nameof(COURSE_READ);
    public const string COURSE_UPDATE = nameof(COURSE_UPDATE);
    public const string COURSE_DELETE = nameof(COURSE_DELETE);

    // Instructor Polices 
    public const string INSTRUCTOR_CREATE = nameof(INSTRUCTOR_CREATE);
    public const string INSTRUCTOR_READ = nameof(INSTRUCTOR_READ);
    public const string INSTRUCTOR_UPDATE = nameof(INSTRUCTOR_UPDATE);
    public const string INSTRUCTOR_DELETE = nameof(INSTRUCTOR_DELETE);

    // Comment Polices 
    public const string COMMENT_CREATE = nameof(COMMENT_CREATE);
    public const string COMMENT_READ = nameof(COMMENT_READ);
    public const string COMMENT_UPDATE = nameof(COMMENT_UPDATE);
    public const string COMMENT_DELETE = nameof(COMMENT_DELETE);

}