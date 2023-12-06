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

    [AllowAnonymous]
    [HttpPost("room")]
    public async Task<IActionResult> CreateRoom(CreateRoomRequest newRoom)
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

    [HttpPost("chat")]
    public async Task<IActionResult> ChatPost(ChatGetRequest model)
    {
        var response = await _userService.AuthenticateRoom(model);

        if (response == null)
            return BadRequest(new { message = "Room Id or password is incorrect" });

        return Ok(response);
    }
}
