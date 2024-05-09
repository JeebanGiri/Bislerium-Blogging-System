using Application.BisleriumBloggingSystem.Interface;
using Domain.BisleriumBloggingSystem.Entities;
using Insfrastructure.BisleriumBloggingSystem.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.BisleriumBloggingSystem.Service
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BlogService(ApplicationDBContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = context;
            _userManager = userManager;
        }

        public async Task<Blog> CreateBlog(Blog blog, IFormFile imageFile)
        {

            if (imageFile != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(Path.GetTempPath(), fileName);
                await using (var fileStream = File.Create(filePath))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
                blog.Image = fileName; 
            }

            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return blog;

        }

        public async Task<IEnumerable<Blog>> GetAllBlog()
        {
            var blogDetails = await _dbContext.Blogs.ToListAsync();
            return blogDetails;
        }
            
        public async Task<IEnumerable<Blog>> GetAllBloggerBlog()
        {
            var bloggerBlogs = await _dbContext.Blogs.ToListAsync();
            return bloggerBlogs;
        }

        //public async Task<Blog> UpdateBlog(Blog blog)
        //{
        //    var existingBlog = await _dbContext.Blogs.FindAsync(blog.Id);

        //    if (existingBlog == null)
        //    {
        //        throw new Exception("Blog not found");
        //    }
        //    existingBlog.Content = blog.Content;
        //    existingBlog.Title = blog.Title;
        //    existingBlog.Image = blog.Image;
        //    await _dbContext.SaveChangesAsync();

        //    return existingBlog;
        //}

        public async Task<Blog> UpdateBlog(Blog blog)
        {
            Blog prevBlog = await GetBlogById(blog.Id);
            BlogHistory bloghistory = new BlogHistory();


            if (prevBlog != null)
            {
                bloghistory.Blog = prevBlog.Id;
                bloghistory.PreviousBlogTitle = prevBlog.Title;
                bloghistory.PreviousBlogContent = prevBlog.Content;
                bloghistory.BlogCreatedDateTime = prevBlog.CreatedDate;
                bloghistory.PreviousBlogImage = prevBlog.Image;
                await _dbContext.BlogHistories.AddAsync(bloghistory);

                if (!string.IsNullOrEmpty(blog.Image))
                {
                    prevBlog.Image = blog.Image;

                }
                prevBlog.Title = blog.Title;
                prevBlog.Content = blog.Content;


                _dbContext.Blogs.Update(prevBlog);
                await _dbContext.SaveChangesAsync();

            }
            return prevBlog;

        }

        public async Task DeleteBlog(Guid id)
        {
            var existingBlog = await _dbContext.Blogs.FindAsync(id);

            if (existingBlog == null)
            {
                throw new Exception("Blog not found");
            }

            _dbContext.Remove(existingBlog);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Blog> GetBlogById(Guid id)
        {
            // Implement logic to retrieve student by ID from the database
            var blogs = await _dbContext.Blogs.FindAsync(id);
            if (blogs == null)
            {
                throw new Exception("Blog not found");
            }
            //return new List<Blog> { blogs };
            return blogs;
        }


    }
}
