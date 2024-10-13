using MasterNet.Domain;

namespace MasterNet.WebApi.Extensions;

public static class PoliciesExtensions
{
    public static IServiceCollection AddPoliciesServices(this IServiceCollection services)
    {

        services.AddAuthorization(options =>
        {
            // Couse policy
            options.AddPolicy(Constant.COURSE_READ, policy =>
                policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.COURSE_READ)));

            options.AddPolicy(Constant.COURSE_CREATE, policy =>
                policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.COURSE_CREATE)));

            options.AddPolicy(Constant.COURSE_UPDATE, policy =>
               policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.COURSE_UPDATE)));

            options.AddPolicy(Constant.COURSE_DELETE, policy =>
                policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.COURSE_DELETE)));

            // Instructor policy
            options.AddPolicy(Constant.INSTRUCTOR_READ, policy =>
                policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.INSTRUCTOR_READ)));

            options.AddPolicy(Constant.INSTRUCTOR_CREATE, policy =>
                policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.INSTRUCTOR_CREATE)));

            options.AddPolicy(Constant.INSTRUCTOR_UPDATE, policy =>
               policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.INSTRUCTOR_UPDATE)));

            options.AddPolicy(Constant.INSTRUCTOR_DELETE, policy =>
                policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.INSTRUCTOR_DELETE)));

            // Comment policy
            options.AddPolicy(Constant.COMMENT_READ, policy =>
                policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.COMMENT_READ)));

            options.AddPolicy(Constant.COMMENT_CREATE, policy =>
                policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.COMMENT_CREATE)));

            options.AddPolicy(Constant.COMMENT_UPDATE, policy =>
               policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.COMMENT_UPDATE)));

            options.AddPolicy(Constant.COMMENT_DELETE, policy =>
                policy.RequireAssertion(context => context.User.HasClaim(x => x.Type == Constant.POLICIES && x.Value == Constant.COMMENT_DELETE)));

        });

        return services;
    }
}