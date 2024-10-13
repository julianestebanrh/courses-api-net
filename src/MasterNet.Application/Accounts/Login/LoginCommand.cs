using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Application.Interfaces;
using MasterNet.Persistence.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Accounts.Login;

public class LoginCommand
{
    public record LoginCommandRequest(LoginRequest loginRequest) : IRequest<Result<Profile>>, ICommandBase;

    internal class LoginCommandHandler : IRequestHandler<LoginCommandRequest, Result<Profile>>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<Result<Profile>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == request.loginRequest.Email);

            if (user is null)
            {
                return Result<Profile>.Failure("User  not found");
            }

            var response = await _userManager.CheckPasswordAsync(user, request.loginRequest.Password!);

            if (!response)
            {
                return Result<Profile>.Failure("The credentials are incorrect");
            }

            var profile = new Profile
            {
                Email = user.Email,
                FullName = user.FullName,
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };

            return Result<Profile>.Success(profile);

        }
    }

    public class LoginCommandRequestValidator : AbstractValidator<LoginCommandRequest>
    {

        public LoginCommandRequestValidator()
        {
            RuleFor(x => x.loginRequest).SetValidator(new LoginValidator());
        }
    }
}

