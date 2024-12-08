using api.Dto;
using api.Interface;
using api.Mapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller;

[Route("/api/comments")]
[ApiController]
public class CommentController: ControllerBase
{
    
    private readonly ICommentRepository _commentRepository;

    public CommentController(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    [HttpGet]
    public async Task<ActionResult> FindAll()
    {
        var comments = await _commentRepository.FindAllAsync();
        
        //Select() is like stream.map()
        var commentDto = comments.Select(c => c.ToDto()).ToList();
       
        return Ok(commentDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindById(int id)
    {
        var comment = await _commentRepository.FindByIdAsync(id);

        if (comment == null)
        {
            return NotFound(id);
        }
        
        return Ok(comment.ToDto());
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] RequestCommentDto requestCommentDto)
    {
        var comment = requestCommentDto.ToComment();
        
        await _commentRepository.CreateAsync(comment);

        return CreatedAtAction(nameof(FindById), new { id = comment.Id }, comment.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] RequestCommentDto rquestCommentDto)
    {
        var comment = await _commentRepository.UpdateAsync(id, rquestCommentDto.ToComment());
        return Ok(comment);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteById([FromRoute] int id)
    {
        var comment = await _commentRepository.DeleteByIdAsync(id);

        if (comment == null)
        {
            return NotFound(id);
        }

        return NoContent();
    }
}