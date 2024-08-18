using BuberDinner.Application.Common.Errors;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    // OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName, string lastName, string email, string password);

    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

    ErrorOr<AuthenticationResult> Login(string email, string password);
}