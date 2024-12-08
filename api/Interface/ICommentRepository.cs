using api.Model;

namespace api.Interface;

public interface ICommentRepository
{
    Task<List<Comment>> FindAllAsync();
    
    Task<Comment?> FindByIdAsync(int id);
    
    Task<Comment> CreateAsync(Comment comment);
    
    Task<Comment?> UpdateAsync(int id, Comment comment);
    
    Task<Comment?> DeleteByIdAsync(int id);
}