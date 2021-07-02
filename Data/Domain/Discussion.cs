using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Crossways.Data.Identity;

namespace Crossways.Data.Domain
{
    public class Discussion : Entity
    {
        public string Subject { get; set; }

        [DataType(DataType.Text)]
        public string Body { get; set; }

        public long TopicId { get; set; }
        
        public Topic Topic { get; set; }

        public long PublisherId { get; set; }
        
        public Publisher Publisher { get; set; }

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}