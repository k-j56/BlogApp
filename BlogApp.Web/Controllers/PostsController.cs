
using AutoMapper;
using BlogApp.Web.Entities;
using BlogApp.Web.Models;
using BlogApp.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _service;
    private readonly IMapper _mapper;

    public PostsController(IPostService service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPostsAsync()
    {
        var posts = await _service.GetPostsAsync();

        var postDtos = posts.Select(post => new
        {
            post.Title,
            post.Content,
            TotalComments = post.Comments.Count
        });

        return Ok(postDtos);
    }


    [HttpPost]
    public async Task<ActionResult> CreatePostAsync(PostDto postDto)
    {
        var post = _mapper.Map<Post>(postDto);

        await _service.CreatePostAsync(post);

        if (await _service.SaveChangesAsync())
        {
            return Ok(post);
        }
        return BadRequest();
    }

    [HttpPost("{postId}")]
    public async Task<ActionResult> AddCommentAsync(int postId, CommentDto commentDto)
    {
        Post post = await _service.GetPostAsync(postId);
        if (post is null) return NotFound();

        Comment comment = new()
        {
            Text = commentDto.Text,
            PostId = postId
        };

        await _service.AddCommentAsync(postId, comment);
        await _service.SaveChangesAsync();

        return Ok(post);
    }

}
