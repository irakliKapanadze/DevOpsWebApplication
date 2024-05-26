using DevOpsWebApplication.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevOpsWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public UserController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await dbContext.Set<User>().FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet()]
        public async Task<IActionResult> GetUser()
        {
            var users = await dbContext.Set<User>().ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            dbContext.Set<User>().Add(user);
            await dbContext.SaveChangesAsync();
            return Ok(user);
        }
    }
}
