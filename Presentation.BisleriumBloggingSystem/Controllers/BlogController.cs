using Application.BisleriumBloggingSystem.Interface;
using Domain.BisleriumBloggingSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.BisleriumBloggingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [Authorize(Roles = "Blogger")]
        [HttpPost, Route("create-blog")]
        public async Task<IActionResult> AddBlog([FromForm] Blog blog, IFormFile? imageFile)
        {
            try
            {
                var addBlogs = await _blogService.CreateBlog(blog, imageFile);
                return Ok(addBlogs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create Blog");
            }
        }



        [Authorize(Roles = "Blogger")]
        [HttpPost, Route("update-blog")]
        public async Task<IActionResult> UpdateBlog(Blog blog)
        {
            try
            {
                var updateBlog = await _blogService.UpdateBlog(blog);
                return Ok(updateBlog);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update blog");
            }
        }

        [Authorize(Roles = "Blogger, Admin")]
        [HttpDelete, Route("delete-blog/{id}")]
        public async Task<IActionResult> DeleteBlog(Guid id)
        {
            try
            {
                await _blogService.DeleteBlog(id);
                return Ok("Blog deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete blog");
            }
        }

        [Authorize(Roles = "Blogger")]
        [HttpGet, Route("get-blog")]
        public async Task<IActionResult> GetAllBlogs()
        {
            try
            {
                var blogs = await _blogService.GetAllBlog();
                return Ok(blogs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve blogs");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet, Route("get-all-blog")]
        public async Task<IActionResult> GetAllBloggerBlogs()
        {
            try
            {
                var blogs = await _blogService.GetAllBloggerBlog();
                return Ok(blogs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve blogs");
            }
        }

        [HttpGet, Route("get-blog/{id}")]
        public async Task<IActionResult> GetBlogById(Guid id)
        {
            try
            {
                var blogs = await _blogService.GetBlogById(id);
                return Ok(blogs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve blogs");
            }
        }

    }
}
