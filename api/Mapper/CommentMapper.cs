using api.Dto;
using api.Model;

namespace api.Mapper;

public static class CommentMapper
{
    public static CommentDto ToDto(this Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            Title = comment.Title,
            Content = comment.Content,
            CreatedOn = comment.CreatedOn,
            StockId = comment.StockId,
        };
    }
    
    public static Comment ToComment(this RequestCommentDto dto)
    {
        return new Comment
        {
            Title = dto.Title,
            Content = dto.Content,
            StockId = dto.StockId,
        };
    }
}