using Microsoft.AspNetCore.Mvc;
using UserApi.Authorization;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatroomController : ControllerBase
{
    private IUserService _userService;

    public ChatroomController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("room")]
    public async Task<IActionResult> Create(CreateRoomRequest newRoom)
    {
        var createdRoom = await _userService.CreateRoomAsync(newRoom);

        return Ok(createdRoom);
    }

    [HttpGet("room")]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await _userService.GetAllChatroomsAsync();

        return Ok(rooms);
    }
}
