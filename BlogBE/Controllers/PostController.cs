using AutoMapper;
using BlogBE.Core.Context;
using BlogBE.Core.Dtos.Post;
using BlogBE.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private AppDBContext _context;
        private IMapper _mapper;
        public PostController(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto dto)
        {
            PostModel newPost = _mapper.Map<PostModel>(dto);
            await _context.Posts.AddAsync(newPost);
            await _context.SaveChangesAsync();
            return Ok(newPost);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<GetPostDto>>> GetPost()
        {
            var posts = await _context.Posts.ToListAsync();
            var convertPost = _mapper.Map<IEnumerable<GetPostDto>>(posts);
            return Ok(convertPost);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdatePost([FromRoute] long id, UpdatePostDto dto)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.ID == id);
            if (post == null)
            {
                return NotFound("Post Bulunamadı");
            }
            _mapper.Map(dto, post);
            await _context.SaveChangesAsync();
            return Ok(post);

        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeletePost([FromBody] DeletePostDto dto)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.ID == dto.ID && p.UserId == dto.UserId);
            if (post == null)
            {
                return NotFound("Post Bulunamadı");
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }
    }
}
