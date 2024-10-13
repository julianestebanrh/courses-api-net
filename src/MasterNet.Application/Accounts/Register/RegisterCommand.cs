using FluentValidation;
using FluentValidation.Validators;
using MasterNet.Application.Core;
using MasterNet.Application.Interfaces;
using MasterNet.Persistence.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Accounts.Register;

public class RegisterCommand
{

    public record RegisterCommandRequest(RegisterRequest registerRequest) : IRequest<Result<Profile>>, ICommandBase;

    internal class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Result<Profile>>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterCommandHandler(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<Result<Profile>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {

            if (await _userManager.Users.AnyAsync(x => x.Email == request.registerRequest.Email))
            {
                return Result<Profile>.Failure("The user has already been registered");
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == request.registerRequest.UserName))
            {
                return Result<Profile>.Failure("The username has already been registered");
            }

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                FullName = request.registerRequest.FullName,
                Career = request.registerRequest.Career,
                Email = request.registerRequest.Email,
                UserName = request.registerRequest.UserName,
            };

            var response = await _userManager.CreateAsync(user, request.registerRequest.Password!);

            if (response.Succeeded)
            {

                await _userManager.AddToRoleAsync(user, "Client");

                var profile = new Profile
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    Token = await _tokenService.CreateToken(user),
                    UserName = user.UserName
                };

                return Result<Profile>.Success(profile);

            }

            return Result<Profile>.Failure("Error registering user");


        }
    }

    public class RegisterCommandRequestValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandRequestValidator()
        {
            RuleFor(x => x.registerRequest).SetValidator(new RegisterValidator());
        }
    }

}