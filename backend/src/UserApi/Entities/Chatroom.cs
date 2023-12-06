using System;
using System.Collections.Generic;

namespace UserApi.Entities;

public partial class Chatroom
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public int? Capacity { get; set; }
    public int? TotalUsers { get; set; }

    public DateTime? DateCreated { get; set; }
}
