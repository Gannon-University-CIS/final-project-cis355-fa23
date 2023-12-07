using UserApi.Entities;
using UserApi.Models;

namespace UserApi.Services;

public interface IUserService
{
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
    Task<ChatGetResponse?> AuthenticateRoom(string password, string roomId);
    Task<IEnumerable<UserResponse>> GetAllAsync();
    Task<IEnumerable<RoomResponse>> GetAllChatroomsAsync();
    Task<IEnumerable<ChatResponse>> GetChatsAsync(string id);
    Task<UserResponse?> GetByIdAsync(string id);
    Task<CreateUserResponse?> CreateUserAsync(CreateUserRequest user);
    Task<CreateRoomResponse?> CreateRoomAsync(CreateRoomRequest room, Guid userId);
    Task<CreateChatResponse?> CreateMessageAsync(ChatGetRequest room, Guid userId, Guid roomId);
}