using Domain.BisleriumBloggingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BisleriumBloggingSystem.Interface
{
    public interface IBlogLikeService
    {
        Task<BlogLikeResponse> AddUpvote(BlogLike like);
        Task<BlogLikeResponse> AddDownVote(BlogLike like);
        Task<BlogLike> GetUsersLike(Guid id, string u_id);
        Task DeleteVote(Guid id);
    }
}
