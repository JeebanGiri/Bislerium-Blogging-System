using Application.BisleriumBloggingSystem.Interface;
using Domain.BisleriumBloggingSystem.Entities;
using Insfrastructure.BisleriumBloggingSystem;
using Insfrastructure.BisleriumBloggingSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.BisleriumBloggingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Authorize(Roles = "Blogger")]
        [HttpPost, Route("create-comment")]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            //try
            //{
            //    var addComments = await _commentService.CreateComment(comment);
            //    return Ok(addComments);
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create Comment");
            //}


            try
            {
                // Retrieve userId from token
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Console.WriteLine(userId);

                // Assign userId to AuthorId property of the comment
                comment.AuthorId = userId;

                // Create the comment
                var addedComment = await _commentService.CreateComment(comment, userId);

                return Ok(addedComment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create Comment");
            }
        }
        

        [Authorize(Roles = "Blogger")]
        [HttpPost, Route("update-comment")]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            try
            {
                var updateComment = await _commentService.UpdateComment(comment);
                return Ok(updateComment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update comment");
            }
        }

        [Authorize(Roles = "Blogger")]
        [HttpDelete, Route("delete-comment/{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            try
            {
                await _commentService.DeleteComment(id);
                return Ok("Comment deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete Comment");
            }
        }

        [HttpGet, Route("get-comment")]
        public async Task<IActionResult> GetAllComment()
        {
            try
            {
                var comments = await _commentService.GetAllComment();
                return Ok(comments);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve comments");
            }
        }

        [HttpGet, Route("get-comment/{id}")]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            try
            {
                var comments = await _commentService.GetCommentById(id);
                return Ok(comments);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve comments");
            }
        }


    }
}
