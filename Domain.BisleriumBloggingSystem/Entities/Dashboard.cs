using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BisleriumBloggingSystem.Entities
{
    public class Dashboard
    {
        public int UserCount { get; set; }
        public int PostCount { get; set; }
        public int TotalCommentCount { get; set; }
        public int UpvoteCount { get; set; }
        public int DownvoteCount { get; set; }
    }
}
