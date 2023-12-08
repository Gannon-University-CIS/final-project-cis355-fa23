using System;

namespace UserApi.Models;

public class RoomResponse
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public int? TotalUsers { get; set; }

    public int? Capacity { get; set; }

    public DateTime? DateCreated { get; set; }
}