using api.Data;
using api.Interface;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class CommentRepository: ICommentRepository
{
    private readonly ApplicationDBContext _context;

    public CommentRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>> FindAllAsync()
    {
        return await _context.Comment.ToListAsync();
    }

    public async Task<Comment?> FindByIdAsync(int id)
    {
        return await _context.Comment.FindAsync(id);
    }

    public async Task<Comment> CreateAsync(Comment comment)
    {
        await _context.Comment.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> UpdateAsync(int id, Comment comment)
    {
        var existingComment = await _context.Comment.FindAsync(id);

        if (existingComment == null)
        {
            return null;
        }
        
        existingComment.Title = comment.Title;
        existingComment.Content = comment.Content;
        existingComment.StockId = comment.StockId;

        await _context.SaveChangesAsync();
        
        return existingComment;
    }

    public async Task<Comment?> DeleteByIdAsync(int id)
    {
        var comment = await _context.Comment.FirstOrDefaultAsync(c => c.Id == id);

        if (comment == null)
        {
            return null;
        }

        _context.Remove(comment);
        await _context.SaveChangesAsync();
        
        return comment;
    }
}