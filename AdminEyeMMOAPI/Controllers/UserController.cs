using Microsoft.AspNetCore.Mvc;
using DomainMMO.Models;
using ApplicationMMO.Services.Interfaces;

namespace AdminEyeMMOAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            success = true,
            message = "Get successfully!", 
            time = DateTime.Now.ToString()
        });
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        return Ok(new
        {
            success = true,
            message = $"Get {id} successfully!", 
            time = DateTime.Now.ToString()
        });
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserModel user)
    {
        return Ok(new
        {
            success = true,
            message = $"Post successfully!", 
            time = DateTime.Now.ToString()
        });
    }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put(string id, [FromBody] BookEntity book)
        // {
        //     var bookResponse = await _bookService.UpdateBook(id, book.Title, book.Author, book.PublishedYear);
        //     return Ok(JsonConvert.SerializeObject(bookResponse));
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(string id)
        // {
        //     var bookResponse = await _bookService.Delete(id);
        //     return Ok(JsonConvert.SerializeObject(bookResponse));
        // }

    [HttpGet("/Health")]
    public IActionResult Health()
    {
        return Ok(new
        {
            success = true,
            message = _userService.Health(), 
            time = DateTime.Now.ToString()
        });
    }
}
