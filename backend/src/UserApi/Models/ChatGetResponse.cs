namespace UserApi.Models;

using UserApi.Entities;

/// <summary>
/// Represents the response returned by the authentication endpoint.
/// </summary>
public class ChatGetResponse
{
    /// <summary>
    ///  The Id of the chatroom to prove it exists
    /// </summary>
    public Guid Id { get; set; }
}