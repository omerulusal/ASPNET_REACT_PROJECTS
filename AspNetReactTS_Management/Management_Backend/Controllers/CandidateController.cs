using AutoMapper;
using Management_Backend.Core.Context;
using Management_Backend.Core.Dtos.Candidate;
using Management_Backend.Core.Dtos.Job;
using Management_Backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Management_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidateController : ControllerBase
{
    private AppDBContext _context;
    private IMapper _mapper;
    public CandidateController(AppDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //!====>CRUD<====

    //Create
    [HttpPost]
    [Route("Create")]//Urlde "Create" e karsilik CreateCandidate Metodu gelir
    public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDto dto, IFormFile pdfFile)
    //url e gelen istegin Form yapısından CandidateCreateDto turunde asenkron veri ve Pdf dosyasını alır
    {
        var fiveMB = 5 * 1024 * 1024;
        var pdfType = "application/pdf";

        if (pdfFile.Length > fiveMB || pdfFile.ContentType != pdfType)
        {
            return BadRequest("Pdf size must be less than 5 MB and must be JSON");
        }
        var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
        var pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", resumeUrl);

        using (var stream = new FileStream(pdfPath, FileMode.Create))
        {
            await pdfFile.CopyToAsync(stream);
        }

        Candidate newCandidate = _mapper.Map<Candidate>(dto);
        //Candidate modeli turunde newCandidate olusturur ve Candidate, gelen dto verisi ile doldurur
        newCandidate.ResumeUrl = resumeUrl;
        await _context.Candidates.AddAsync(newCandidate);//Yeni adayi asenkron olarak Candidates DbSetine ekler
        await _context.SaveChangesAsync();//yapılan değişiklikler kaydedilir
        return Ok(newCandidate);
    }

    //Read
    [HttpGet]
    [Route("Get")]//Urlde "Get" e karsilik GetCandidaties Metodu gelir
    public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetCandidaties()//IEnumrable<...Dto>>> Aday Bilgilerini tutan bir listedir.
    {
        var candidates = await _context.Candidates.Include(c => c.Job).ToListAsync();
        //DbSet'Teki Candidates Tablosundan tum aday verilerini alır,liste halinde bir veri döndürür ve bu liste candidates değişkenine atanır.
        var convertedJobs = _mapper.Map<IEnumerable<CandidateGetDto>>(candidates);
        //Dbden gelen is verilerini listeli olarak maplar ve convertedJobs değişkenine atanır.
        return Ok(convertedJobs);
    }

    //Read (Pdf Indirme)
    [HttpGet]
    [Route("download/{url}")]
    public IActionResult DownloadPdf(string url)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", url);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("File Not Found");
        }

        var pdfBoyut = System.IO.File.ReadAllBytes(filePath);
        var file = File(pdfBoyut, "application/pdf", url);
        return file;
    }
}
