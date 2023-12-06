using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserApi.Authorization;
using UserApi.Models;
using UserApi.Services;
using UserApi.Entities;

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
        // Authenticate that room exists and password is right
        var response = await _userService.AuthenticateRoom(model);

        if (response == null)
            return BadRequest(new { message = "Room Id or password is incorrect" });

        // Get user id and verify that user is logged in
        var user = (User?)HttpContext.Items["User"];

        if (user == null)
        {
            return BadRequest(new { message = "User is not logged in" });
        }

        // Create message
        var createdMessage = await _userService.CreateMessageAsync(model, user.Id, response.Id);

        return Ok(createdMessage);
    }

    [HttpGet("chat")]
    public async Task<IActionResult> GetChats(string roomId, string password)
    {
        // Authenticate that room exists and password is right

        ChatFilterRequest model = new ChatFilterRequest
        {
            RoomId = roomId,
            Password = password
        };
        var response = await _userService.AuthenticateChat(model);

        if (response == null)
            return BadRequest(new { message = "Room Id or password is incorrect" });

        if (roomId == null)
            return BadRequest(new { message = "Invalid room id" });

        var rooms = await _userService.GetChatsAsync(roomId);

        return Ok(rooms);
    }
}