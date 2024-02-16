using AutoMapper;
using Management_Backend.Core.Context;
using Management_Backend.Core.Dtos.Job;
using Management_Backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Management_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private AppDBContext _context;
        private IMapper _mapper;
        public JobController(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //!====>CRUD<====

        //Create
        [HttpPost]
        [Route("Create")]//Urlde "Create" e karsilik CreateJob Metodu gelir
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto dto)
        //url e gelen istegin govdesinnden JobCreateDto turunde asenkron veri alır
        {

            Job newJob = _mapper.Map<Job>(dto);//Job Modeli turunde newJob olusturur ve Job, gelen dto verisi ile doldurur
            await _context.Jobs.AddAsync(newJob);//DbSet'e(Jobs'a) yeni veri asenkron olarak eklenir
            await _context.SaveChangesAsync();//yapılan değişiklikler kaydedilir
            return Ok(newJob);
        }

        //Read
        [HttpGet]
        [Route("Get")]//Urlde "Get" e karsilik GetJobs Metodu gelir
        public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs()
        {
            var jobs = await _context.Jobs.Include(j => j.Company).ToListAsync();
            var convertedJobs = _mapper.Map<IEnumerable<JobGetDto>>(jobs);
            return Ok(convertedJobs);
        }

    }
}
