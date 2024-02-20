using AutoMapper;
using BlogBE.Core.Context;
using BlogBE.Core.Dtos.User;
using BlogBE.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDBContext _context;
        private IMapper _mapper;

        public UserController(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            UserModel newUser = _mapper.Map<UserModel>(dto);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return Ok(newUser);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var convertUser = _mapper.Map<IEnumerable<GetUserDto>>(users);
            return Ok(convertUser);
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult> GetUser([FromRoute] long id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ID == id);
            if (user == null)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }
            return Ok(user);
        }
    }
}
