using AutoMapper;
using Management_Backend.Core.Context;
using Management_Backend.Core.Dtos.Company;
using Management_Backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Management_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private AppDBContext _context;
    private IMapper _mapper;
    public CompanyController(AppDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //!====>CRUD<====


    //Create
    [HttpPost]
    [Route("Create")]//Urlde "Create" e karsilik CreateCompany Metodu gelir
    public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDto dto)
    //url e gelen istegin govdesinnden CopmanyCreateDto turunde asenkron veri alır
    {
        Company newCompany = _mapper.Map<Company>(dto);//Company modeli turunde newCompany olusturur ve Company, gelen dto verisi ile doldurur
        await _context.Companies.AddAsync(newCompany);//DbSet'e(Companies'e) yeni veri asenkron olarak eklenir
        await _context.SaveChangesAsync();//yapılan değişiklikler kaydedilir
        return Ok(newCompany);//Ekranda görmek icin yeni veriyi döndürudum
    }


    //Read
    [HttpGet]//urle Get istegi yapılır.
    [Route("Get")]//Urlde "Get" e karsilik GetCompanies Metodu gelir
    public async Task<ActionResult<IEnumerable<CompanyGetDto>>> GetCompanies()//IEnumrable Company Bilgilerini tutan bir listedir.
    {
        var companies = await _context.Companies.ToListAsync();//DbSet'e(Companies'e) yeni verinin listeli hali asenkron olarak eklenir
        var convertedComp = _mapper.Map<IEnumerable<CompanyGetDto>>(companies);
        //companies listesindeki her firmayı CompanyGetDto nesnesine dönüştürür ve yeni bir liste oluşturur.
        return Ok(convertedComp);
    }
}
