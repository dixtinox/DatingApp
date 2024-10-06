using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet] 
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync ()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }
    
    [Authorize]
    [HttpGet("{id:int}")] 
    public async Task<ActionResult<AppUser>> GetUsersByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id); 

        if (user == null) return NotFound();

        return user;
    }

    [HttpGet("{name}")]
    public ActionResult<string> Ready(string name)
    {
        return $"Hi {name}";
    }
}
