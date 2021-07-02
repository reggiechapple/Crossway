using System.Collections.Generic;
using Crossways.Data.Identity;

namespace Crossways.Data.Domain
{
    public class Comment : Entity
    {
        public string Body { get; set; }

        public long? ParentId { get; set; }
        public Comment Parent { get; set; }

        public long AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public long PostId { get; set; }
        public Post Post { get; set; }

        public ICollection<Comment> Replies { get; set; }
    }
}