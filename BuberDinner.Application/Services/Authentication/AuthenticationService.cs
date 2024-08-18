using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        //1. user does exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            // throw new Exception("User with given email does not exists");
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. validate password is correct
        if (user.Password != password)
        {
            // throw new Exception("Invalid password");
            return Errors.Authentication.InvalidCredentials;
        }

        // 3. create jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }

    // public OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName, string lastName, string email, string password)
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        //check if user doesnot exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            // return new DuplicateEmailError();
            // throw new Exception("User with given email already exists");
            return Errors.User.DuplicateEmail;
        }

        // create user (generate unique ID)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}