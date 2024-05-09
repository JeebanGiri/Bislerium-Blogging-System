using Application.BisleriumBloggingSystem.Interface;
using Domain.BisleriumBloggingSystem.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.BisleriumBloggingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogLikeController : ControllerBase
    {
        private readonly IBlogLikeService _blogLikeService;
        public BlogLikeController(IBlogLikeService blogLikeService)
        {
            _blogLikeService = blogLikeService;
        }
        [HttpPost, Route("upvote")]
        public async Task<IActionResult> Upvote(BlogLike
            blogLike)
        {
            var result = await _blogLikeService.AddUpvote(blogLike);
            return Ok(result);
        }

        [HttpPost, Route("downvote")]
        public async Task<IActionResult> DownVote(BlogLike blogLike)
        {
            var result = await _blogLikeService.AddDownVote(blogLike);
            return Ok(result);
        }

    }
}
