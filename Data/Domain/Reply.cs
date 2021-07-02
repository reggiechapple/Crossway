using System.Collections.Generic;
using Crossways.Data.Identity;

namespace Crossways.Data.Domain
{
    public class Reply : Entity
    {
        public string Content { get; set; }

        public long DiscussionId { get; set; }

        public Discussion Discussion { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public int ParentId { get; set; }

        public Reply Parent { get; set; }
        
        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}