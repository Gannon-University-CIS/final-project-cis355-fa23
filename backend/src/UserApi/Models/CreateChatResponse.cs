namespace UserApi.Models
{
    /// <summary>
    /// Represents the response returned when a new room is created.
    /// </summary>
    public class CreateChatResponse
    {
        /// <summary>
        /// ID of the new chat.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The message sent to the chatroom.
        /// </summary>
        public string message { get; set; } = null!;
    }
}
