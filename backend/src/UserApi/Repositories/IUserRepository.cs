using UserApi.Entities;

namespace UserApi.Repositories;
public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<IEnumerable<Chatroom>> GetAllRoomsAsync();
    Task<IEnumerable<ChatHistory>> GetChatsAsync(string id);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<Chatroom?> GetRoomByRoomIdAsync(string id);
    Task<User?> GetUserByIdAsync(string id);
    Task<User?> CreateUserAsync(User user);
    Task<Chatroom?> CreateRoomAsync(Chatroom room, Guid userId);
    Task<ChatHistory?> CreateChatAsync(ChatHistory roomd);
}
