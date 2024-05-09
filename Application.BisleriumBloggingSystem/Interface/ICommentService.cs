using Domain.BisleriumBloggingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BisleriumBloggingSystem.Interface
{
    public interface ICommentService
    {
        Task<Comment> CreateComment(Comment comment, string? userId);
        Task<IEnumerable<Comment>> GetAllComment();
        Task<Comment> UpdateComment(Comment comment);
        Task DeleteComment(Guid id);
        Task<Comment> GetCommentById(Guid id);
    }
}
