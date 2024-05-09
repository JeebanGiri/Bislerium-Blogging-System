using Application.BisleriumBloggingSystem.Interface;
using Domain.BisleriumBloggingSystem.Entities;
using Insfrastructure.BisleriumBloggingSystem.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.BisleriumBloggingSystem.Service
{
    public class CommentService(ApplicationDBContext dbContext) : ICommentService
    {
        private readonly ApplicationDBContext _dbContext = dbContext;

        public async Task<Comment> CreateComment(Comment comment, string? userId)
        {
            //Assign user_Id
            comment.AuthorId = userId;
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAllComment()
        {
            var commentDetails = await _dbContext.Comments.ToListAsync();
            return commentDetails;
        }

        public async Task<Comment> UpdateComment(Comment comment)
        {
            var existingComment = await _dbContext.Comments.FindAsync(comment.Id);

            if (existingComment == null)
            {
                throw new Exception("Comment not found");
            }
            existingComment.Content = comment.Content;
            await _dbContext.SaveChangesAsync();

            return existingComment;
        }

        public async Task DeleteComment(Guid id)
        {
            var existingComment = await _dbContext.Comments.FindAsync(id);

            if (existingComment == null)
            {
                throw new Exception("Comment not found");
            }

            _dbContext.Remove(existingComment);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Comment> GetCommentById(Guid id)
        {
            // Implement logic to retrieve student by ID from the database
            var comments = await _dbContext.Comments.FindAsync(id);
            if (comments == null)
            {
                throw new Exception("Comment not found");
            }
            /*return new List<Comment> { comments };*/
            return comments;
        }

    }
}
