using BlogApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public UsersController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _userManager.CreateAsync(
            new IdentityUser() { UserName = user.UserName, Email = user.Email },
            user.Password
        );

        if (!result.Succeeded) return BadRequest(result.Errors);

        user.Password = null;
        return Created("", user);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<User>> GetUser(string username)
    {
        IdentityUser user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            return NotFound();
        }
        return new User
        {
            UserName = user.UserName,
            Email = user.Email
        };
    }
}