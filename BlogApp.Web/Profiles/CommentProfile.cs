using AutoMapper;
using BlogApp.Web.Entities;
using BlogApp.Web.Models;

namespace BlogApp.Web.Profiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentDto>();
        CreateMap<CommentDto, Comment>();
    }
}
