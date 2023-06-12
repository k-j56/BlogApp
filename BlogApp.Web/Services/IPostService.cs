using BlogApp.Web.Entities;

namespace BlogApp.Web.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();

        Task<Post> GetPostAsync(int postId);
        Task CreatePostAsync(Post post);

        Task<bool> SaveChangesAsync();

        Task AddCommentAsync(int postId, Comment comment);
        Task GetAllComments(int postId);
    }
}