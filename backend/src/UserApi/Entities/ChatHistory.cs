using System;
using System.Collections.Generic;

namespace UserApi.Entities;

public partial class ChatHistory
{
    public Guid Id { get; set; }

    public int? RoomId { get; set; } = null!;

    public int? UserId { get; set; } = null!;

    public DateTime? DateCreated { get; set; }

    public string Message { get; set; } = null!;
}
