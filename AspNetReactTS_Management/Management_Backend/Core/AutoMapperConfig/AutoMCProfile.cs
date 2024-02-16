using AutoMapper;
using Management_Backend.Core.Dtos.Candidate;
using Management_Backend.Core.Dtos.Company;
using Management_Backend.Core.Dtos.Job;
using Management_Backend.Core.Entities;

namespace Management_Backend.Core.AutoMapperConfig
{
    public class AutoMCProfile : Profile
    {
        public AutoMCProfile()
        {
            //Company
            CreateMap<CompanyCreateDto, Company>();
            //CompanyCreateDto türünden bir nesneyi Company türünden bir nesneye eşledim.
            CreateMap<Company, CompanyGetDto>();
            //Company türünden bir nesneyi CompanyGetDto türünden bir nesneye eşledim.

            //Job
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>().ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));


            //Candidate
            CreateMap<CandidateCreateDto, Candidate>();
            CreateMap<Candidate, CandidateGetDto>()
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Job.Title))
                ;


        }
    }
}
