using Microsoft.EntityFrameworkCore;
using UserApi.Entities;
using UserApi.Exceptions;

namespace UserApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(UserDbContext context, ILogger<UserRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }


    public async Task<IEnumerable<Chatroom>> GetAllRoomsAsync()
    {
        return await _context.Chatrooms.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(string id)
    {
        // convert string to Guid
        if (!Guid.TryParse(id, out var guidId))
        {
            _logger.LogError("Invalid GUID received. Id: {Id}", id);
            return null;
        }
        return await _context.Users.FindAsync(guidId);
    }

    public async Task<User?> CreateUserAsync(User user)
    {
        try
        {
            // Add user to database
            var createdUser = (await _context.Users.AddAsync(user)).Entity;
            // Save changes to database
            await _context.SaveChangesAsync();

            if (createdUser == null)
            {
                _logger.LogError("An error occurred while creating user. User data: {User}", user);
                return null;
            }

            return createdUser;
        }
        catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException pgEx && pgEx.SqlState == "23505")
        {
            _logger.LogWarning("Attempted to create a user with a duplicate email. Email: {Email}", user.Email);
            throw new DuplicateEmailException("This email is already in use.", ex);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "An error occurred while saving the entity changes.");
            throw new UserCreationFailedException("An unexpected error occurred while creating the room.", ex);
        }
    }

    public async Task<Chatroom?> CreateRoomAsync(Chatroom room)
    {
        try
        {
            // Add room to database
            var createdRoom = (await _context.Chatrooms.AddAsync(room)).Entity;
            // Save changes to database
            await _context.SaveChangesAsync();

            if (createdRoom == null)
            {
                _logger.LogError("An error occurred while creating the room. Room data: {Room}", room);
                return null;
            }

            return createdRoom;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "An error occurred while saving the entity changes.");
            throw new RoomCreationFailedException("An unexpected error occurred while creating the room.", ex);
        }
    }

    public async Task<ChatHistory?> CreateChatAsync(ChatHistory message)
    {
        try
        {
            // Add room to database
            var createdMessage = (await _context.ChatHistory.AddAsync(message)).Entity;
            // Save changes to database
            await _context.SaveChangesAsync();

            if (createdMessage == null)
            {
                _logger.LogError("An error occurred while creating the message. Message data: {Message}", message);
                return null;
            }

            return createdMessage;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "An error occurred while saving the entity changes.");
            throw new RoomCreationFailedException("An unexpected error occurred while creating the message.", ex);
        }
    }

    public Task<User?> GetUserByUsernameAsync(string username)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }


    public Task<Chatroom?> GetRoomByRoomIdAsync(string id)
    {
        return _context.Chatrooms.FirstOrDefaultAsync(u => u.Id.ToString() == id);
    }

    // ... Add other methods here as needed
}