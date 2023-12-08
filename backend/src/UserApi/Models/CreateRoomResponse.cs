namespace UserApi.Models
{
    /// <summary>
    /// Represents the response returned when a new room is created.
    /// </summary>
    public class CreateRoomResponse
    {
        /// <summary>
        /// ID of the new room.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the new room.
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// The id of the user who created the room.
        /// </summary>
        public string UserId { get; set; } = null!;
    }
}
