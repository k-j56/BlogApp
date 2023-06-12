using BlogApp.Web.Data;
using BlogApp.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Web.Services;


public class PostService : IPostService
{
    private readonly BlogDbContext _context;
    public PostService(BlogDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task CreatePostAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }

    public async Task AddCommentAsync(int postId, Comment comment)
    {
        Post post = await GetPostAsync(postId);
        post?.Comments.Add(comment);
    }

    public Task GetAllComments(int postId)
    {
        throw new NotImplementedException();
    }

    public async Task<Post> GetPostAsync(int postId)
    {
        return await _context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == postId);
    }
}
