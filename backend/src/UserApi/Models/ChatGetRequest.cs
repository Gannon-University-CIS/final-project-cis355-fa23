namespace UserApi.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents a request to authenticate room
/// </summary>
public class ChatGetRequest
{
    /// <summary>
    /// The room id of the chatroom selected to send to specific room.
    /// </summary>
    [Required]
    public string RoomId { get; set; } = null!;

    /// <summary>
    /// The password of the chatroom to authenticate.
    /// </summary>
    [Required]
    public string Password { get; set; } = null!;

    /// <summary>
    /// The message to send to the chatroom.
    /// </summary>
    [Required]
    public string Message { get; set; } = null!;
}