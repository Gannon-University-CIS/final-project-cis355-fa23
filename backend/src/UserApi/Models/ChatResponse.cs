using System;

namespace UserApi.Models;

public class ChatResponse
{
    public Guid Id { get; set; }

    public string? UserId { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? Message { get; set; }
}