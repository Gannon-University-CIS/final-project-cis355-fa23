using UserApi.Entities;
using UserApi.Models;

namespace UserApi.Services;

public interface IUserService
{
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
    Task<IEnumerable<UserResponse>> GetAllAsync();
    Task<UserResponse?> GetByIdAsync(string id);
    Task<CreateUserResponse?> CreateUserAsync(CreateUserRequest user);

// for 2FA service
    Task<twoFAresponse?> twoFAService(twoFArequest model);
}