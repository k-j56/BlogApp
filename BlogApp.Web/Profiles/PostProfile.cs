using AutoMapper;
using BlogApp.Web.Entities;
using BlogApp.Web.Models;

namespace BlogApp.Web.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<Post, PostDto>();
        CreateMap<PostDto, Post>();
    }
}
