using AutoMapper;
using BlogBE.Core.Dtos.Post;
using BlogBE.Core.Dtos.User;
using BlogBE.Core.Entities;

namespace BlogBE.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<CreateUserDto, UserModel>();
            CreateMap<UserModel, GetUserDto>();

            CreateMap<CreatePostDto, PostModel>();
            CreateMap<PostModel, GetPostDto>();
            CreateMap<UpdatePostDto, PostModel>();//UpdatePosttan, PostModele
            CreateMap<DeletePostDto,PostModel >();
        }
    }
}
