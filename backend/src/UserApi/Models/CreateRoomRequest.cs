using System.ComponentModel.DataAnnotations;

namespace UserApi.Models;

/// <summary>
/// Represents a request to create a new chat room.
/// </summary>
public class CreateRoomRequest
{
    /// <summary>
    /// The name of the chatroom
    /// </summary>
    [Required]
    public string Title { get; set; } = null!;

    /// <summary>
    /// The password for room security
    /// </summary>
    [Required]
    [MinLength(8)]
    public string Password { get; set; } = null!;
}