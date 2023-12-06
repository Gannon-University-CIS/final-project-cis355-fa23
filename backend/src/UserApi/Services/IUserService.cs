using UserApi.Entities;
using UserApi.Models;

namespace UserApi.Services;

public interface IUserService
{
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
    Task<ChatGetResponse?> AuthenticateRoom(ChatGetRequest model);
    Task<IEnumerable<UserResponse>> GetAllAsync();
    Task<IEnumerable<RoomResponse>> GetAllChatroomsAsync();
    Task<UserResponse?> GetByIdAsync(string id);
    Task<CreateUserResponse?> CreateUserAsync(CreateUserRequest user);
    Task<CreateRoomResponse?> CreateRoomAsync(CreateRoomRequest room);
}